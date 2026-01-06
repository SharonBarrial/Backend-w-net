using AutoMapper;
using MediCare.Domain.HR.Models.Entities;
using MediCare.Domain.HR.Models.Response;

namespace MediCare.Presentation.Mapper;

public class ModelsToResponse : Profile
{
    public ModelsToResponse()
    {
        CreateMap<Appointment, AppoinmentResponse>()
            .ForMember(dest => dest.AppoinmentDate, opt => opt.MapFrom(src => src.AppoinmentDate.ToString()));
    }
}