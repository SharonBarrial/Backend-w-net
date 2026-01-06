using Microsoft.EntityFrameworkCore;

using Travelers.Domain.Subscriptions.Models.Entities;
using Travelers.Domain.Subscriptions.Repositories;
using Travelers.Infrastructure.Shared.Contexts;

namespace Travelers.Infrastructure.Subscription.Persistence;

/// <summary>
/// Provides an implementation of the <see cref="IPlanRepository"/> for managing <see cref="Plan"/> entities in a database.
/// </summary>
public class PlanRepository : IPlanRepository
{
    private readonly SubscriptionContext _subscriptionContext;
    /// <summary>
    /// Initializes a new instance of the <see cref="PlanRepository"/> class.
    /// </summary>
    /// <param name="subscriptionContext">The database context to be used for repository operations.</param>
    public PlanRepository(SubscriptionContext subscriptionContext)
    {
        _subscriptionContext = subscriptionContext;
    }
    /// <summary>
    /// Saves a <see cref="Plan"/> entity to the database.
    /// </summary>
    /// <param name="plan">The plan entity to save.</param>
    /// <returns>The saved plan entity with updated state.</returns>
    /// <exception cref="Exception">Throws an exception if the database operation fails.</exception>
    public async Task<Plan?> SaveAsync(Plan plan)
    {
        try
        {
            await _subscriptionContext.Plans.AddAsync(plan);
            await _subscriptionContext.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception("Failed to save the plan: " + ex.Message, ex);
        }
        return plan;
    }
    /// <summary>
    /// Retrieves a plan entity from the database by its name.
    /// </summary>
    /// <param name="name">The name of the plan to retrieve.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the found <see cref="Plan"/> entity or null if no entity is found.</returns>
    public async Task<Plan?> GetPlanByNameAsync(string name)
    {
        return await _subscriptionContext.Plans.Where(p => p.Name == name).FirstOrDefaultAsync();
    }
}