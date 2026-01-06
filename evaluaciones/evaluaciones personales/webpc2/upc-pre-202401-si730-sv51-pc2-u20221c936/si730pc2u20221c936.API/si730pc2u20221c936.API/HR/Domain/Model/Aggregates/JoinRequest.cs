using si730pc2u20221c936.API.HR.Domain.Model.Commands;

namespace si730pc2u20221c936.API.HR.Domain.Model.Aggregates;

public class JoinRequest
{
    public int Id { get; }
public string Name { get; private set; }
public int DepartmentId { get; private set; }
public string DesiredJobTitle { get; private set; }
public string ResumeUrl { get; private set; }

public JoinRequest(string name, int departmentId, string desiredJobTitle, string resumeUrl)
{
    Name = name;
    DepartmentId = departmentId;
    DesiredJobTitle = desiredJobTitle;
    ResumeUrl = resumeUrl;
}
public JoinRequest(CreateJoinRequestCommand command)
{
    Name = command.Name;
    DepartmentId = command.DepartmentId;
    DesiredJobTitle = command.DesiredJobTitle;
    ResumeUrl = command.ResumeUrl;
}
}