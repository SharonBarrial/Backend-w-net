using si730pc2u20221c936.API.HR.Domain.Model.Aggregates;
using si730pc2u20221c936.API.HR.Domain.Model.Commands;
using si730pc2u20221c936.API.HR.Domain.Repositories;
using si730pc2u20221c936.API.HR.Domain.Services;
using si730pc2u20221c936.API.Shared.Domain.Repositories;

namespace si730pc2u20221c936.API.HR.Application.Internal.CommandServices;

public class JoinRequestCommandService(IJoinRequestRepository joinRequestRepository, IUnitOfWork unitOfWork) : IJoinRequestCommandService
{
    public async Task<bool> IsDepartmentIdValid(int departmentId)
    {
        if (departmentId is < 1 or > 9)
        {
            return false;
        }
        return await joinRequestRepository.IsDepartmentIdValid(departmentId);
    }

    public async Task<JoinRequest?> Handle(CreateJoinRequestCommand command)
    {
        var joinRequest = new JoinRequest(command);
        try
        {
            await joinRequestRepository.AddAsync(joinRequest);
            await unitOfWork.CompleteAsync();
            return joinRequest;
        } catch(Exception e)
        {
            Console.WriteLine($"An error occurred while creating a join request: {e.Message}");
            return null;
        }
    }

    public async Task<bool> DoesJoinRequestExist(string name, int departmentId)
    {
        return await joinRequestRepository.DoesJoinRequestExist(name, departmentId);
    }
}

