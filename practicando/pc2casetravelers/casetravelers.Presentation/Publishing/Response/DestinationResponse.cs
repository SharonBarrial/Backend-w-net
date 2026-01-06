using System.ComponentModel.DataAnnotations;

namespace casetravelers.Presentation.Publishing.Response;

public class DestinationResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int MaxUsers { get; set; }
}