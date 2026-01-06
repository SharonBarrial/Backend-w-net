namespace Travelers.Domain.Subscriptions.Models.Response;

/// <summary>
/// Represents the response model for a subscription plan.
/// </summary>
public class PlanResponse
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public int MaxUsers { get; set; }
}