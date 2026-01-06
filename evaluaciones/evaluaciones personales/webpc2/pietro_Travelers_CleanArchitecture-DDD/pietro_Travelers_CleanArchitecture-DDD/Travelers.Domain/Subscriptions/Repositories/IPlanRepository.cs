using Travelers.Domain.Subscriptions.Models.Entities;

namespace Travelers.Domain.Subscriptions.Repositories;

/// <summary>
/// IPlanRepository is an interface that represents the repository for the Plan entity.
/// </summary>
public interface IPlanRepository
{
    Task<Plan?> SaveAsync (Plan plan);
    Task<Plan?> GetPlanByNameAsync(string name);
}