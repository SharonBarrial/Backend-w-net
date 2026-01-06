using Microsoft.AspNetCore.Mvc;

using Travelers.Domain.Subscriptions.Models.Commands;
using Travelers.Domain.Subscriptions.Services;

namespace Travelers.Presentation.Subscription.Controllers;

/// <summary>
///  PlanController class that is responsible for handling the plan requests.
/// </summary>
[Route("api/v1/[controller]")]
[ApiController]
public class PlanController : ControllerBase
{
    private readonly IPlanCommandService _planCommandService;
    /// <summary>
    /// Initializes a new instance of the <see cref="PlanController"/> class.
    /// </summary>
    /// <param name="planCommandService">The service handling plan-related commands.</param>
    public PlanController(IPlanCommandService planCommandService)
    {
        _planCommandService = planCommandService;
    }
    // POST api/v1/plan
    /// <summary>
    /// Creates a new plan based on the provided plan command.
    /// </summary>
    /// <param name="command">The command object containing all necessary data to create a plan.</param>
    /// <response code="201">Returns the newly created plan</response>
    [HttpPost]
    public async Task<IActionResult> CreatePlan([FromBody] CreatePlanCommand command)
    {
        if (!ModelState.IsValid) return BadRequest();
        var result = await _planCommandService.Handle(command);
        return StatusCode(StatusCodes.Status201Created, result);
    }
}