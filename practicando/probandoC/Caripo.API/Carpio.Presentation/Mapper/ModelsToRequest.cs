using AutoMapper;
using Carpio.Domain.HR.Models.Commands;
using Carpio.Domain.HR.Models.Entities;

namespace Carpio.Presentation.Mapper;

public class ModelsToRequest : Profile
{
    public ModelsToRequest()
    {
        CreateMap<JoinRequest, CreateJoinRequestCommand>();
    }
}