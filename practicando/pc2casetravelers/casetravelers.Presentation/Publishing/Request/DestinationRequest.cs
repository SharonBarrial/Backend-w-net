using System.ComponentModel.DataAnnotations;

namespace casetravelers.Presentation.Publishing.Request;

public class DestinationRequest
{
    [Required]
    public string Name { get; set; }
    [Required]
    public int MaxUsers { get; set; }
    [Required]
    public int IsRisky { get; set; }
}