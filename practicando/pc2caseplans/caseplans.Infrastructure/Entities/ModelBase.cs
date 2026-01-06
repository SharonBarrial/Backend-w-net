using System.ComponentModel.DataAnnotations;

namespace caseplans.Infrastructure.Entities;

public class ModelBase
{
    [Required]
    public int Id { get; set; }
}