using si730pc2u20221c936.API.HR.Domain.Model.Aggregates;
using si730pc2u20221c936.API.HR.Domain.Model.Commands;

namespace si730pc2u20221c936.API.HR.Domain.Services;

public interface IJoinRequestCommandService
{
    Task<bool> IsDepartmentIdValid(int departmentId);
    Task<JoinRequest?> Handle(CreateJoinRequestCommand command);
    Task<bool> DoesJoinRequestExist(string name, int departmentId);
}