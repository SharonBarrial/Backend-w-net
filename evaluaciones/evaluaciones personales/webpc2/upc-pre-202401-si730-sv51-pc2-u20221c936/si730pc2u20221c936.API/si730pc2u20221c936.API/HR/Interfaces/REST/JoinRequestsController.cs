using Microsoft.AspNetCore.Mvc;
using si730pc2u20221c936.API.HR.Domain.Repositories;
using si730pc2u20221c936.API.HR.Domain.Services;
using si730pc2u20221c936.API.HR.Interfaces.REST.Resources;
using si730pc2u20221c936.API.HR.Interfaces.REST.Transform;

namespace si730pc2u20221c936.API.HR.Interfaces.REST;

[ApiController]
[Route("api/v1/join-requests")]
public class JoinRequestsController(IJoinRequestCommandService joinRequestCommandService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateJoinRequest([FromBody] CreateJoinRequestResource createJoinRequestResource)
    {
        if(await joinRequestCommandService.DoesJoinRequestExist(createJoinRequestResource.Name, createJoinRequestResource.DepartmentId))
        {
            return Conflict("The combination of name and Department Id is already being used.");
        }
        if(!await joinRequestCommandService.IsDepartmentIdValid(createJoinRequestResource.DepartmentId))
        {
            return Conflict("Please enter a valid number for Department Id.");
        }
        
        var createJoinRequestCommand = CreateJoinRequestCommandFromResourceAssembler.ToCommandFromResource(createJoinRequestResource);
        var joinRequest = await joinRequestCommandService.Handle(createJoinRequestCommand);
        if (joinRequest is null) return BadRequest();
        var resource = JoinRequestResourceFromEntityAssembler.ToResourceFromEntity(joinRequest);
        return new CreatedResult("", resource);
    }
}