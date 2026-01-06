using AutoMapper;
using caseplans.Infrastructure.Entities;
using caseplans.Presentation.Publishing.Request;
using Microsoft.AspNetCore.Http.HttpResults;

namespace caseplans.Presentation.Mapper;

public class RequestToModels : Profile
{
    public RequestToModels()
    {
        CreateMap<PlanRequest, Plan>();
    }
}