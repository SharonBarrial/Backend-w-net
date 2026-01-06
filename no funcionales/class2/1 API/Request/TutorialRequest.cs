using System.ComponentModel.DataAnnotations;

namespace _1_API.Request;

public class TutorialRequest
{
    //Reglas de formato de datos
    [Required]
    [MinLength(4)]
    [MaxLength(20)]
    public string Name { get; set; }
    public string Description { get; set; }
}