using System.ComponentModel.DataAnnotations;

namespace _1_API.Request;

public class TutorialRequest
{
    [Required]
    [MinLength(4)]
    [MaxLength(20)]
    public string Name { get; set; }

    [StringLength(5, ErrorMessage = "Nombre no puede tener más de 5 caracteres.")]
    public string Description { get; set; }
    
    public List<SectionRequest> Sections { get; set; }

}