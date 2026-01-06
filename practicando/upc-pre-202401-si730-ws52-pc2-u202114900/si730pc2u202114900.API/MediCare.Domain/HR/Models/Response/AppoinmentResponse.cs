using System.Globalization;

namespace MediCare.Domain.HR.Models.Response;

/// <summary>
/// Represents the response model for a schedule appointment.
/// </summary>
public class AppoinmentResponse
{
    public int Id { get; set; }
    public string PatientName { get; set; }
    public string DoctorName { get; set; }
    public string Email { get; set; }
    public int Speciality { get; set; }
    public DateTime AppoinmentDate { get; set; }
    public TimeOnly AppoinmentTime { get; set; }
}