using AutoMapper;

using Travelers.Domain.Subscriptions.Models.Entities;
using Travelers.Domain.Subscriptions.Models.Response;

namespace Travelers.Presentation.Mapper;

public class ModelsToResponse : Profile
{
    public ModelsToResponse()
    {
        CreateMap<Plan, PlanResponse>();
    }
}