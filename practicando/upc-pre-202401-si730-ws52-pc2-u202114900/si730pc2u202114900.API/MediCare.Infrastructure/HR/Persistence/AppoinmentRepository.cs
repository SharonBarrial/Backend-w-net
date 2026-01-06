using MediCare.Domain.HR.Models.Entities;
using MediCare.Domain.HR.Repositories;
using Microsoft.EntityFrameworkCore;
using MediCare.Infrastructure.Shared.Contexts;

namespace MediCare.Infrastructure.HR.Persistence;

/// <summary>
/// Provides an implementation of the <see cref="IAppoinmentRepository"/> for managing <see cref="Appointment"/> entities in a database.
/// </summary>
public class AppoinmentRepository : IAppoinmentRepository
{
    private readonly HrContext _hrContext;
    /// <summary>
    /// Initializes a new instance of the <see cref="AppoinmentRepository"/> class.
    /// </summary>
    /// <param name="hrContext">The database context to be used for repository operations.</param>
    public AppoinmentRepository(HrContext hrContext)
    {
        _hrContext = hrContext;
    }
    /// <summary>
    /// Saves a <see cref="Appointment"/> entity to the database.
    /// </summary>
    /// <param name="appointment">The appointment entity to save.</param>
    /// <returns>The saved appointment entity with updated state.</returns>
    /// <exception cref="Exception">Throws an exception if the database operation fails.</exception>
    public async Task<Appointment?> SaveAsync(Appointment appointment)
    {
        try
        {
            await _hrContext.Appointments.AddAsync(appointment);
            await _hrContext.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception("Failed to save the appointment: " + ex.Message, ex);
        }
        return appointment;
    }
    /// <summary>
    /// Retrieves a appointment entity from the database by its name.
    /// </summary>
    /// <param name="email">The email of the patient to retrieve.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the found <see cref="Appointment"/> entity or null if no entity is found.</returns>

    public async Task<Appointment?> GetAppoinmentByEmailAsync(string email)
    {
        return await _hrContext.Appointments.Where(p => p.Email==email).FirstOrDefaultAsync();
    }

    public async Task<Appointment?> GetAppointmentByDoctorNameAsync(string doctorName)
    {
        return await _hrContext.Appointments.Where(p => p.DoctorName==doctorName).FirstOrDefaultAsync();
    }

    public async Task<Appointment?> GetAppointmentByDateNameAsync(DateOnly date)
    {
        return await _hrContext.Appointments.Where(p => p.AppoinmentDate==date).FirstOrDefaultAsync();
    }

    public async Task<Appointment?> GetAppointmentByTimeAsync(TimeOnly time)
    {
        return await _hrContext.Appointments.Where(p => p.AppoinmentTime==time).FirstOrDefaultAsync();
    }
}