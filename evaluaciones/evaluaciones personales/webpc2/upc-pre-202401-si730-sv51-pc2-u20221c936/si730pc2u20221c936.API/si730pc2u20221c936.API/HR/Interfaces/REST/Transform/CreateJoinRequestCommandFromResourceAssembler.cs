using si730pc2u20221c936.API.HR.Domain.Model.Commands;
using si730pc2u20221c936.API.HR.Interfaces.REST.Resources;

namespace si730pc2u20221c936.API.HR.Interfaces.REST.Transform;

public static class CreateJoinRequestCommandFromResourceAssembler
{
    public static CreateJoinRequestCommand ToCommandFromResource(CreateJoinRequestResource resource)
    {
        return new CreateJoinRequestCommand(resource.Name, resource.DepartmentId, resource.DesiredJobTitle,
            resource.ResumeUrl);
    }
}