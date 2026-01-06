using AutoMapper;
using Whereto.Domain.Booking.Models.Commands;

namespace Whereto.Presentation.Mapper;

public class RequestToModels:Profile
{
    public RequestToModels()
    {
        CreateMap<CreateBookingCommand, Domain.Booking.Models.Entities.Booking>();
    }
}