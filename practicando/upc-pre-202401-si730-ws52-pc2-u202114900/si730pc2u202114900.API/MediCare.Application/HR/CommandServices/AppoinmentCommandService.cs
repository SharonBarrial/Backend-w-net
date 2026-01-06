using System.Data;
using AutoMapper;
using MediCare.Domain.HR.Models.Commands;
using MediCare.Domain.HR.Models.Entities;
using MediCare.Domain.HR.Models.Response;
using MediCare.Domain.HR.Repositories;
using MediCare.Domain.HR.Services;
using MediCare.Shared;

namespace MediCare.Application.HR.CommandServices;

/// <summary>
/// Provides services for managing plan commands and responses.
/// </summary>
public class AppoinmentCommandService : IAppoinmentCommandService
{
    private readonly IAppoinmentRepository _appoinmentRepository;
    private readonly IMapper _mapper;
    /// <summary>
    /// Initializes a new instance of the <see cref="AppoinmentCommandService"/> class.
    /// </summary>
    /// <param name="appoinmentRepository">The plan repository to interact with the database.</param>
    /// <param name="mapper">The AutoMapper instance for mapping between domain models and DTOs.</param>
    public AppoinmentCommandService(IAppoinmentRepository appoinmentRepository, IMapper mapper)
    {
        _appoinmentRepository = appoinmentRepository;
        _mapper = mapper;
    }
    /// <summary>
    /// Handles the creation of a new appoinemnt based on a given command.
    /// </summary>
    /// <param name="command">The create plan command containing the new appoinment's details.</param>
    /// <returns>The response model of the newly created appointment or null if creation failed.</returns>
    /// <exception cref="DuplicateNameException">Thrown if an appointment with the same email, doctorname in the same date and time already exists.</exception>
    /// <exception cref="ConstraintException">Thrown if the speciality not within the allowed ranges. </exception>
    public async Task<AppoinmentResponse?> Handle(CreateAppointmentCommand command)
    {
        var appointment = _mapper.Map<CreateAppointmentCommand, Appointment>(command);
        // Check for existing plan with the same name
        var existingAppoinmentByEmail = await _appoinmentRepository.GetAppoinmentByEmailAsync(appointment.Email);
        var existingAppoinmentByDoctorName = await _appoinmentRepository.GetAppointmentByDoctorNameAsync(appointment.DoctorName);
        var existingAppoinmentByDate = await _appoinmentRepository.GetAppointmentByDateNameAsync(appointment.AppoinmentDate);
        var existingAppoinmentByTime = await _appoinmentRepository.GetAppointmentByTimeAsync(appointment.AppoinmentTime);
        
        
        if (existingAppoinmentByEmail != null && existingAppoinmentByDoctorName != null ||existingAppoinmentByDate != null && existingAppoinmentByTime != null) 
            throw new DuplicateNameException("Appointment with this DoctorName and DepartmentId already exists in this same date and hour.");
        
        // Check if DepartmentId is within the allowed range (1-6)
        if(!Enum.IsDefined(typeof(EnumSpeciality.ESpeciality), appointment.Speciality)) 
            throw new ConstraintException("DepartmentId must be within the allowed range (1-6) for the appointment");
        
        await _appoinmentRepository.SaveAsync(appointment);
        // Map the domain model back to the response DTO
        var appoinmentResponse = _mapper.Map<Appointment, AppoinmentResponse>(appointment);
        return appoinmentResponse;
    }
}