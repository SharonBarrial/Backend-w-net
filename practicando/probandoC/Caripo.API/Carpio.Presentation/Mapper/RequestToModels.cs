using AutoMapper;
using Carpio.Domain.HR.Models.Commands;
using Carpio.Domain.HR.Models.Entities;

namespace Carpio.Presentation.Mapper;

public class RequestToModels : Profile
{
    public RequestToModels()
    {
        CreateMap<CreateJoinRequestCommand, JoinRequest>();
    }
}