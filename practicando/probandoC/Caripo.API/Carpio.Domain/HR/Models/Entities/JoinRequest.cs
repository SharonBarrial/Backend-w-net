using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Carpio.Domain.HR.Models.Entities;

/// <summary>
/// Represents a **plan** that a user can subscribe to.
/// </summary>
public class JoinRequest
{
    [Required]
    public int Id { get; set; }
    [Required]
    public required string Name { get; set; }
    [Required]
    public int DepartmentId { get; set; }
    [Required]
    public string DesiredJobTitle { get; set; }
    [Required]
    public string ResumeUrl { get; set; }
    
    public DateTime CreatedDate { get; set; } = DateTime.Now;

    public DateTime? UpdatedDate { get; set; }
}