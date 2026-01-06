namespace MediCare.Domain.HR.Models.Commands;

/// <summary>
/// CreateAppointmentCommand is a record that represents the command to create a new appointment.
/// Declares as record for immutability and value-based equality.
/// </summary>
/// <param name="PatientName"></param>
/// <param name="DoctorName"></param>
/// <param name="Email"></param>
/// <param name="Speciality"></param>
/// <param name="AppoinmentDate"></param>
public record CreateAppointmentCommand(string PatientName, string DoctorName, string Email, int Speciality, DateOnly AppoinmentDate, TimeOnly AppoinmentTime);