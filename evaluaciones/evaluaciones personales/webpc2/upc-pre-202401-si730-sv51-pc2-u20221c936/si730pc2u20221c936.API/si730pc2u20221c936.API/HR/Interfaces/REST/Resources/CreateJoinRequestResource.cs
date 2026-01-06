namespace si730pc2u20221c936.API.HR.Interfaces.REST.Resources;

public record CreateJoinRequestResource(string Name, int DepartmentId, string DesiredJobTitle, string ResumeUrl);