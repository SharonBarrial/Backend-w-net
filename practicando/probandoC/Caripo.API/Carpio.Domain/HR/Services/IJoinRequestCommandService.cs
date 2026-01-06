using Carpio.Domain.HR.Models.Commands;
using Carpio.Domain.HR.Models.Response;

namespace Carpio.Domain.HR.Services;

/// <summary>
/// IJoinRequestCommandService is an interface that represents the service for the JoinRequest entity.
/// </summary>
public interface IJoinRequestCommandService
{
    Task<JoinRequestResponse?> Handle(CreateJoinRequestCommand command);
}