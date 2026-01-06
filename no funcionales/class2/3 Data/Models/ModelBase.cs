using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace _3_Data;

public class ModelBase
{
    public int Id { get; set; } 
    public int CreatedUser { get; set; }
    public int? UpdatedUser { get; set; }
    
    
    [DefaultValue(true)]
    public bool IsActive { get; set; }
    
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public DateTime? UpdatedDate { get; set; }
}