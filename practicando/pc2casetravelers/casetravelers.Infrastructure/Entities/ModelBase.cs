using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace casetravelers.Infrastructure.Entities;

public class ModelBase
{
    [Key]
    public int Id { get; set; }
    
}