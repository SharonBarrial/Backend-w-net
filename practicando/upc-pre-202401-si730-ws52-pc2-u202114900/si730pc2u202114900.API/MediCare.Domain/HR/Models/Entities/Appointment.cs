using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices.JavaScript;

namespace MediCare.Domain.HR.Models.Entities;

/// <summary>
/// Represents a appointment that a user can schedule to.
/// </summary>
public class Appointment
{
    [Required]
    public int Id { get; set; }
    [Required]
    public string PatientName { get; set; }
    [Required]
    public string DoctorName { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public int Speciality { get; set; }
    [Required]
    public DateOnly AppoinmentDate { get; set; }
    [Required]
    public TimeOnly AppoinmentTime { get; set; }
    
    public DateTime CreatedDate { get; set; } = DateTime.Now;

    public DateTime? UpdatedDate { get; set; }
}