using Whereto.Domain.Booking.Models.Commands;
using Whereto.Domain.Booking.Models.Entities;
using Whereto.Domain.Booking.Models.Queries;

namespace Whereto.Domain.Booking.Services;

public interface IBookingCommandService
{
    Task<int> Handle(CreateBookingCommand command);
}