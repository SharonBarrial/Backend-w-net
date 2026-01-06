using Travelers.Domain.Subscriptions.Models.Commands;
using Travelers.Domain.Subscriptions.Models.Response;

namespace Travelers.Domain.Subscriptions.Services;

/// <summary>
/// IPlanCommandService is an interface that represents the service for the Plan entity.
/// </summary>
public interface IPlanCommandService
{
    Task<PlanResponse?> Handle(CreatePlanCommand command);
}