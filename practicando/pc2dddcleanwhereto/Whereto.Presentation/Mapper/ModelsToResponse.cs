using AutoMapper;
using Whereto.Domain.Booking.Models.Response;
using Whereto.Domain.Booking.Models.Entities;

namespace Whereto.Presentation.Mapper;

public class ModelsToResponse: Profile
{
    public ModelsToResponse()
    {
        CreateMap<Domain.Booking.Models.Entities.Booking, BookingResponse>();
        CreateMap<Domain.Booking.Models.Entities.Booking, BookingResponse>();
    }
}