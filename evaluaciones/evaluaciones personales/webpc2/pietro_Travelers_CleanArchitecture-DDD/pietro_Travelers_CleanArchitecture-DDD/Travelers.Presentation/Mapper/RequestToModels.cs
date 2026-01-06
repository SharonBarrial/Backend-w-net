using AutoMapper;

using Travelers.Domain.Subscriptions.Models.Commands;
using Travelers.Domain.Subscriptions.Models.Entities;

namespace Travelers.Presentation.Mapper;

public class RequestToModels : Profile
{
    public RequestToModels()
    {
        CreateMap<CreatePlanCommand, Plan>();
    }
}