using System.Data;
using AutoMapper;

using Travelers.Domain.Subscriptions.Models.Commands;
using Travelers.Domain.Subscriptions.Models.Entities;
using Travelers.Domain.Subscriptions.Models.Response;
using Travelers.Domain.Subscriptions.Repositories;
using Travelers.Domain.Subscriptions.Services;
using Travelers.Shared;

namespace Travelers.Application.Subscriptions.CommandServices;

/// <summary>
/// Provides services for managing plan commands and responses.
/// </summary>
public class PlanCommandService : IPlanCommandService
{
    private readonly IPlanRepository _planRepository;
    private readonly IMapper _mapper;
    /// <summary>
    /// Initializes a new instance of the <see cref="PlanCommandService"/> class.
    /// </summary>
    /// <param name="planRepository">The plan repository to interact with the database.</param>
    /// <param name="mapper">The AutoMapper instance for mapping between domain models and DTOs.</param>
    public PlanCommandService(IPlanRepository planRepository, IMapper mapper)
    {
        _planRepository = planRepository;
        _mapper = mapper;
    }
    /// <summary>
    /// Handles the creation of a new plan based on a given command.
    /// </summary>
    /// <param name="command">The create plan command containing the new plan's details.</param>
    /// <returns>The response model of the newly created plan or null if creation failed.</returns>
    /// <exception cref="DuplicateNameException">Thrown if a plan with the same name already exists.</exception>
    /// <exception cref="ConstraintException">Thrown if the maximum number of users or default status are not within the allowed ranges. show this exception </exception>
    public async Task<PlanResponse?> Handle(CreatePlanCommand command)
    {
        var plan = _mapper.Map<CreatePlanCommand, Plan>(command);
        // Check for existing plan with the same name
        var existingPlanName = await _planRepository.GetPlanByNameAsync(plan.Name);
        if (existingPlanName != null) 
            throw new DuplicateNameException("Plan with this name already exists");
        // Validate the min MaxUser value 
        if (plan.MaxUsers < Constants.MIN_MAXUSER_VALUE) 
            throw new ConstraintException("MaxUsers must be greater than 0");
        if (plan.IsDefault < Constants.MIN_ISDEFAULT_VALUE || plan.IsDefault > Constants.MAX_ISDEFAULT_VALUE) 
            throw new ConstraintException("IsDefault must be 0 or 1");
        // Validate the IsDefault property
        await _planRepository.SaveAsync(plan);
        // Map the domain model back to the response DTO
        var planResponse = _mapper.Map<Plan, PlanResponse>(plan);
        return planResponse;
    }
}