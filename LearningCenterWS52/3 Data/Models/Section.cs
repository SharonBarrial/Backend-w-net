using System.ComponentModel.DataAnnotations;

namespace _3_Data;

public class Section : ModelBase
{
    
    [MaxLength(25)]
    [Required]
    
    public string Name { get; set; }
    
    public int TutorialId { get; set; }
    public Tutorial Tutorial { get; set; }
    
}