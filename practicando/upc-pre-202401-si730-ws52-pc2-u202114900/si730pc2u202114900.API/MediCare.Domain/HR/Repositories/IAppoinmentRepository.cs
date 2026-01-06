using MediCare.Domain.HR.Models.Entities;

namespace MediCare.Domain.HR.Repositories;

/// <summary>
/// IAppoinmentRepository is an interface that represents the repository for the Appointment entity.
/// </summary>
public interface IAppoinmentRepository
{
    Task<Appointment?> SaveAsync (Appointment appointment);
    Task<Appointment?> GetAppoinmentByEmailAsync(string email);
    Task<Appointment?> GetAppointmentByDoctorNameAsync(string doctorName);
    Task<Appointment?> GetAppointmentByDateNameAsync(DateOnly date);
    Task<Appointment?> GetAppointmentByTimeAsync(TimeOnly time);
}