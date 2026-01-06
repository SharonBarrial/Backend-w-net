using MediCare.Domain.HR.Models.Commands;
using MediCare.Domain.HR.Models.Response;

namespace MediCare.Domain.HR.Services;

/// <summary>
/// IAppoinmentCommandService is an interface that represents the service for the Appointment entity.
/// </summary>
public interface IAppoinmentCommandService
{
    Task<AppoinmentResponse?> Handle(CreateAppointmentCommand command);
}