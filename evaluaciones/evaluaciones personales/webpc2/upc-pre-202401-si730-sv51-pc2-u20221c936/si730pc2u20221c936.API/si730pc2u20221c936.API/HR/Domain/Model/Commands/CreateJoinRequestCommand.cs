namespace si730pc2u20221c936.API.HR.Domain.Model.Commands;

public record CreateJoinRequestCommand(string Name, int DepartmentId, string DesiredJobTitle, string ResumeUrl);