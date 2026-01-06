using Carpio.Domain.HR.Models.Entities;
using Carpio.Domain.HR.Repositories;
using Microsoft.EntityFrameworkCore;
using Carpio.Infrastructure.Shared.Contexts;

namespace Carpio.Infrastructure.HR.Persistence;

/// <summary>
/// Provides an implementation of the <see cref="IJoinRequestRepository"/> for managing <see cref="JoinRequest"/> entities in a database.
/// </summary>
public class JoinRequestRepository : IJoinRequestRepository
{
    private readonly HrContext _hrContext;
    /// <summary>
    /// Initializes a new instance of the <see cref="JoinRequestRepository"/> class.
    /// </summary>
    /// <param name="hrContext">The database context to be used for repository operations.</param>
    public JoinRequestRepository(HrContext hrContext)
    {
        _hrContext = hrContext;
    }
    /// <summary>
    /// Saves a <see cref="JoinRequest"/> entity to the database.
    /// </summary>
    /// <param name="joinRequest">The joinRequest entity to save.</param>
    /// <returns>The saved joinRequest entity with updated state.</returns>
    /// <exception cref="Exception">Throws an exception if the database operation fails.</exception>
    public async Task<JoinRequest?> SaveAsync(JoinRequest joinRequest)
    {
        try
        {
            await _hrContext.Plans.AddAsync(joinRequest);
            await _hrContext.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception("Failed to save the joinRequest: " + ex.Message, ex);
        }
        return joinRequest;
    }
    /// <summary>
    /// Retrieves a join request entity from the database by its name.
    /// </summary>
    /// <param name="name">The name of the join request to retrieve.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the found <see cref="JoinRequest"/> entity or null if no entity is found.</returns>
    public async Task<JoinRequest?> GetJoinRequestByNameAsync(string name)
    {
        return await _hrContext.Plans
            .Where(p => p.Name == name)
            .FirstOrDefaultAsync();
    }
    
    public async Task<JoinRequest?> GetJoinRequestByDepartmentIdAsync(int id)
    {
        return await _hrContext.Plans.Where(p => p.DepartmentId == id).FirstOrDefaultAsync();
    }
}