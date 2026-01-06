using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Whereto.Domain.Booking.Models.Entities;

public class Booking: ModelBase
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
