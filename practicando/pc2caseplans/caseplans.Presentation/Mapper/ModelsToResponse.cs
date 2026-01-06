using AutoMapper;
using caseplans.Infrastructure.Entities;
using caseplans.Presentation.Publishing.Response;

namespace caseplans.Presentation.Mapper;

public class ModelsToResponse: Profile
{
    public ModelsToResponse()
    {
        CreateMap<Plan, PlanResponse>();
    }
}