using si730pc2u20221c936.API.HR.Domain.Model.Aggregates;
using si730pc2u20221c936.API.HR.Interfaces.REST.Resources;

namespace si730pc2u20221c936.API.HR.Interfaces.REST.Transform;

public static class JoinRequestResourceFromEntityAssembler
{
    public static JoinRequestResource ToResourceFromEntity(JoinRequest joinRequest)
    {
        return new JoinRequestResource(
            joinRequest.Id,
            joinRequest.Name,
            joinRequest.DepartmentId,
            joinRequest.DesiredJobTitle,
            joinRequest.ResumeUrl
        );
    }
}