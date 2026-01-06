using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;

namespace _3_Data;

public class Tutorial : ModelBase
{
   /* public int Id { get; set; }*/
    
    [MaxLength(25)]
    [Required]
    
    public string Name { get; set; }
    public string Description { get; set; }
    public List<Section> Sections { get; set; }
    
    /*
    public int CreatedUser { get; set; }
    public int UpdatedUser { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime UpdateDate { get; set; }*/
    
}