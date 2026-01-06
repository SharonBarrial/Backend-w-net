using Carpio.Domain.HR.Models.Entities;
namespace Carpio.Domain.HR.Repositories;

/// <summary>
/// IJoinRequestRepository is an interface that represents the repository for the JoinRequest entity.
/// </summary>
public interface IJoinRequestRepository
{
    Task<JoinRequest?> SaveAsync (JoinRequest joinRequest);
    Task<JoinRequest?> GetJoinRequestByNameAsync(string name);
    Task<JoinRequest?> GetJoinRequestByDepartmentIdAsync(int id);
}