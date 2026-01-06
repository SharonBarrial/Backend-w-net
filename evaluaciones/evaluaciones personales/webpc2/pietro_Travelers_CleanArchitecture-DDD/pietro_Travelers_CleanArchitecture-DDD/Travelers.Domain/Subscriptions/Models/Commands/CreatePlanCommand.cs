namespace Travelers.Domain.Subscriptions.Models.Commands;

/// <summary>
///  CreatePlanCommand is a record that represents the command to create a new plan.
/// Declares as record for immutability and value-based equality.
/// </summary>
/// <param name="Name"></param>
/// <param name="MaxUsers"></param>
/// <param name="IsDefault"></param>
public record CreatePlanCommand(string Name, int MaxUsers, int IsDefault);