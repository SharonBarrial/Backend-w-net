namespace Travelers.Domain.Subscriptions.Models.Entities;

/// <summary>
/// Represents a plan that a user can subscribe to.
/// </summary>
public class Plan
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public int MaxUsers { get; set; }
    public int IsDefault { get; set; }
}