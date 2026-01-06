using Microsoft.EntityFrameworkCore;
using si730pc2u20221c936.API.HR.Domain.Model.Aggregates;
using si730pc2u20221c936.API.HR.Domain.Repositories;
using si730pc2u20221c936.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using si730pc2u20221c936.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace si730pc2u20221c936.API.HR.Infrastructure.Persistence.EFC.Repositories;

public class JoinRequestRepository(AppDbContext context) : BaseRepository<JoinRequest>(context), IJoinRequestRepository
{
    public Task<bool> IsDepartmentIdValid(int departmentId)
    {
        if (departmentId is < 1 or > 9)
        {
            return Task.FromResult(false);
        }
        return Task.FromResult(true);
    }
    
    public async Task<bool> DoesJoinRequestExist(string name, int departmentId)
    {
        return await Context.JoinRequests.AnyAsync(jr => jr.Name == name && jr.DepartmentId == departmentId);
    }
}


