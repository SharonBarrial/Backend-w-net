using System.ComponentModel;

namespace _3_Data;

public class ModelBase
{
    public int Id { get; set; }
    public int CreatedUser { get; set; }
    public int? UpdatedUser { get; set; }
    
    [DefaultValue(true)]
    public bool IsActive { get; set; }
    
    public DateTime CreateDate { get; set; } = DateTime.Now;
    public DateTime? UpdateDate { get; set; }
}