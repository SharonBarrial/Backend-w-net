using System.Data;
using AutoMapper;
using Carpio.Domain.HR.Models.Commands;
using Carpio.Domain.HR.Models.Entities;
using Carpio.Domain.HR.Models.Response;
using Carpio.Domain.HR.Repositories;
using Carpio.Domain.HR.Services;
using Carpio.Shared;

namespace Carpio.Application.HR.CommandServices;

/// <summary>
/// Provides services for managing plan commands and responses.
/// </summary>
public class JoinRequestCommandService : IJoinRequestCommandService
{
    private readonly IJoinRequestRepository _joinRequestRepository;
    private readonly IMapper _mapper;
    /// <summary>
    /// Initializes a new instance of the <see cref="JoinRequestCommandService"/> class.
    /// </summary>
    /// <param name="joinRequestRepository">The plan repository to interact with the database.</param>
    /// <param name="mapper">The AutoMapper instance for mapping between domain models and DTOs.</param>
    public JoinRequestCommandService(IJoinRequestRepository joinRequestRepository, IMapper mapper)
    {
        _joinRequestRepository = joinRequestRepository;
        _mapper = mapper;
    }
    /// <summary>
    /// Handles the creation of a new plan based on a given command.
    /// </summary>
    /// <param name="command">The create plan command containing the new plan's details.</param>
    /// <returns>The response model of the newly created plan or null if creation failed.</returns>
    /// <exception cref="DuplicateNameException">Thrown if a plan with the same name already exists.</exception>
    /// <exception cref="ConstraintException">Thrown if the maximum number of users or default status are not within the allowed ranges. show this exception </exception>
    public async Task<JoinRequestResponse?> Handle(CreateJoinRequestCommand command)
    {
        var joinRequest = _mapper.Map<CreateJoinRequestCommand, JoinRequest>(command);
        // Check for existing plan with the same name and DepartmentId
        var existingJoinRequestByName = await _joinRequestRepository.GetJoinRequestByNameAsync(joinRequest.Name);
        var existingJoinRequestByDepartmentId = await _joinRequestRepository.GetJoinRequestByDepartmentIdAsync(joinRequest.DepartmentId);
        if (existingJoinRequestByName != null && existingJoinRequestByDepartmentId != null) 
            throw new DuplicateNameException("JoinRequest with this name and DepartmentId already exists");
        
        // Check if DepartmentId is within the allowed range (1-9)
        // Check if DepartmentId is within the allowed range (1-9)
        if(!Enum.IsDefined(typeof(EnumDepartment.EDepartment), joinRequest.DepartmentId)) 
            throw new ConstraintException("DepartmentId must be within the allowed range (1-9)");
        
        // Save the new plan to the database
        await _joinRequestRepository.SaveAsync(joinRequest);
        // Map the domain model back to the response DTO
        var planResponse = _mapper.Map<JoinRequest, JoinRequestResponse>(joinRequest);
        return planResponse;
    }
}