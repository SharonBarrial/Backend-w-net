using AutoMapper;
using MediCare.Domain.HR.Models.Commands;
using MediCare.Domain.HR.Models.Entities;

namespace MediCare.Presentation.Mapper;

public class ModelsToRequest : Profile
{
    public ModelsToRequest()
    {
        CreateMap<Appointment, CreateAppointmentCommand>();
    }
}