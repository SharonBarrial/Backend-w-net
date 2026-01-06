using AutoMapper;
using MediCare.Domain.HR.Models.Commands;
using MediCare.Domain.HR.Models.Entities;

namespace MediCare.Presentation.Mapper;

public class RequestToModels : Profile
{
    public RequestToModels()
    {
        CreateMap<CreateAppointmentCommand, Appointment>();
    }
}