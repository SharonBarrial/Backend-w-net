using si730pc2u20221c936.API.HR.Domain.Model.Aggregates;
using si730pc2u20221c936.API.Shared.Domain.Repositories;

namespace si730pc2u20221c936.API.HR.Domain.Repositories;

public interface IJoinRequestRepository: IBaseRepository<JoinRequest>
{
    Task<bool> IsDepartmentIdValid(int departmentId);
    
    Task<bool> DoesJoinRequestExist(string name, int departmentId);
}