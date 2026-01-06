using System.ComponentModel.DataAnnotations;

namespace caseplans.Infrastructure.Entities;

public class Plan :ModelBase
{
    [Required]
    public string Name { get; set; }
    [Required]
    public int MaxUsers { get; set; }
    [Required]
    public int IsDefault { get; set; }
}