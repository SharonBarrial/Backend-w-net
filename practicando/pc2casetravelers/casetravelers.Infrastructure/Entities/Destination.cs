using System.ComponentModel.DataAnnotations;

namespace casetravelers.Infrastructure.Entities;

public class Destination: ModelBase
{
    [Required]
    public string Name { get; set; }
    [Required]
    public int MaxUsers { get; set; }
    [Required]
    public int IsRisky { get; set; }
}