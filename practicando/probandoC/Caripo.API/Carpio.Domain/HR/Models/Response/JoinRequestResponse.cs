namespace Carpio.Domain.HR.Models.Response;

/// <summary>
/// Represents the response model for a subscription plan.
/// </summary>
public class JoinRequestResponse
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public int DepartmentId { get; set; }
    public string DesiredJobTitle { get; set; }
    public string ResumeUrl { get; set; }
}