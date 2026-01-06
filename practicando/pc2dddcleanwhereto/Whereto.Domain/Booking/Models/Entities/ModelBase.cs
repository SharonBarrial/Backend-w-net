using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Whereto.Domain.Booking.Models.Entities;

public class ModelBase
{
    [Required]
    public int Id { get; set; }
}