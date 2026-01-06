using System.ComponentModel.DataAnnotations;

namespace Whereto.Domain.Booking.Models.Commands;

public class CreateBookingCommand
{
    [Required]
    public string Username { get; set; }
    [Required]
    public int RouteId { get; set; }
    [Required]
    public int Days { get; set; }
    public string Comments { get; set; }
    [Required]
    public DateTime CreatedAt { get; set; }
}