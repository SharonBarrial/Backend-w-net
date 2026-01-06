namespace Carpio.Domain.HR.Models.Commands;

/// <summary>
///  CreateJoinRequestCommand is a record that represents the command to create a new plan.
/// Declares as record for immutability and value-based equality.
/// </summary>
/// <param name="Name"></param>
/// <param name="DepartmentId"></param>
/// <param name="DesiredJobTitle"></param>
/// <param name="ResumeUrl"></param>
public record CreateJoinRequestCommand(string Name, int DepartmentId, string DesiredJobTitle, string ResumeUrl);