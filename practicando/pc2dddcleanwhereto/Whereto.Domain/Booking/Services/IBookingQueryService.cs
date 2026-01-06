using Whereto.Domain.Booking.Models.Queries;
using Whereto.Domain.Booking.Models.Response;

namespace Whereto.Domain.Booking.Services;

public interface IBookingQueryService
{
    Task<List<BookingResponse>?> Handle(GetByUsernameQuery query);
    Task<List<BookingResponse>?> Handle(GetByDateQuery query);
    Task<List<BookingResponse>?> Handle(GetByRouteIdQuery query);
}