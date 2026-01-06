using Microsoft.EntityFrameworkCore;

using Travelers.Domain.Subscriptions.Models.Entities;

namespace Travelers.Infrastructure.Shared.Contexts;

/// <summary>
/// Represents the Entity Framework database context for the Subscription module,
/// providing access to the Plans entities stored in the database.
/// </summary>
public class SubscriptionContext : DbContext
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SubscriptionContext"/> with the specified options.
    /// The options are typically configured in the startup class of the application.
    /// </summary>
    /// <param name="options">The options to be used by the DbContext.</param>
    public SubscriptionContext(DbContextOptions<SubscriptionContext> options) : base(options) {}
    /// <summary>
    /// Gets or sets the <see cref="DbSet{TEntity}"/> of Plans, representing the collection of all Plans
    /// in the context, or that can be queried from the database.
    /// </summary>
    public DbSet<Plan> Plans { get; set; }
}