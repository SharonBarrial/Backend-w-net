using AutoMapper;
using Carpio.Domain.HR.Models.Entities;
using Carpio.Domain.HR.Models.Response;

namespace Carpio.Presentation.Mapper;

public class ModelsToResponse : Profile
{

    public ModelsToResponse()
    {
        CreateMap<JoinRequest, JoinRequestResponse>();
    }
}