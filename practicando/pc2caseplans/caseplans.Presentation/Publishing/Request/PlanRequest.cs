using System.ComponentModel.DataAnnotations;

namespace caseplans.Presentation.Publishing.Request;

public class PlanRequest
{
    [Required]
    public string Name { get; set; }
    [Required]
    public int MaxUsers { get; set; }
    [Required]
    public int IsDefault { get; set; }
}