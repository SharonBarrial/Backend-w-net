using AutoMapper;
using Whereto.Domain.Booking.Models.Commands;
using Whereto.Domain.Booking.Models.Entities;
using Whereto.Domain.Booking.Models.Response;

namespace Whereto.Presentation.Mapper;

public class ModelsToRequest: Profile
{
    public ModelsToRequest()
    {
        CreateMap<Domain.Booking.Models.Entities.Booking, CreateBookingCommand>();
    }
}