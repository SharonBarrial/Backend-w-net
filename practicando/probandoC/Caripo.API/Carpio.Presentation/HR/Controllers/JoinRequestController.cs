using Carpio.Domain.HR.Models.Commands;
using Carpio.Domain.HR.Services;
using Microsoft.AspNetCore.Mvc;

namespace Carpio.Presentation.HR.Controllers;

/// <summary>
///  JoinRequestController class that is responsible for handling the plan requests.
/// </summary>
[Route("api/v1/join-requests")]
[ApiController]
public class JoinRequestController : ControllerBase
{
    private readonly IJoinRequestCommandService _joinRequestCommandService;
    /// <summary>
    /// Initializes a new instance of the <see cref="JoinRequestController"/> class.
    /// </summary>
    /// <param name="joinRequestCommandService">The service handling join-requests commands.</param>
    public JoinRequestController(IJoinRequestCommandService joinRequestCommandService)
    {
        _joinRequestCommandService = joinRequestCommandService;
    }
    // POST api/v1/join-requests
    /// <summary>
    /// Creates a new join-requests based on the provided join request command.
    /// </summary>
    /// <param name="command">The command object containing all necessary data to create a join request.</param>
    /// <response code="201">Returns the newly created join request.</response>
    /// <response code="400">If the join request has invalid property</response>
    /// <response code="409">Error validating data</response>
    /// <response code="500">Unexpected error</response>
    [HttpPost]
    public async Task<IActionResult> CreatePlan([FromBody] CreateJoinRequestCommand command)
    {
        if (!ModelState.IsValid) return BadRequest();
        try
        {
            var result = await _joinRequestCommandService.Handle(command);
            return StatusCode(StatusCodes.Status201Created, result);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
        
    }
}