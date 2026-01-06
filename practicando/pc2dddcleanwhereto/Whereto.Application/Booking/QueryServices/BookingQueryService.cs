using AutoMapper;
using Whereto.Domain.Booking.Models.Queries;
using Whereto.Domain.Booking.Models.Entities;
using Whereto.Domain.Booking.Models.Response;
using Whereto.Domain.Booking.Repositories;
using Whereto.Domain.Booking.Services;

namespace Whereto.Application.Booking.QueryServices;

public class BookingQueryService: IBookingQueryService
{
    private readonly IBookingRepository _bookingRepository;
    private readonly IMapper _mapper;
    
    public BookingQueryService(IBookingRepository bookingRepository,IMapper mapper)
    {
        _bookingRepository = bookingRepository;
        _mapper = mapper;
    }

    public async Task<List<BookingResponse>?> Handle(GetByUsernameQuery query)
    {
        var data =  await _bookingRepository.GetByUsernameAsync(query.Username);
        var result = new List<BookingResponse> { _mapper.Map<Domain.Booking.Models.Entities.Booking, BookingResponse>(data) };
        return result;
    }

    public async Task<List<BookingResponse>?> Handle(GetByDateQuery query)
    {
        var data = await _bookingRepository.GetByDateAsync(query.Date);
        var result = new List<BookingResponse> { _mapper.Map<Domain.Booking.Models.Entities.Booking, BookingResponse>(data) };
        return result;
    }
    
    public async Task<List<BookingResponse>?> Handle(GetByRouteIdQuery query)
    {
        var data = await _bookingRepository.GetByRouteIdAsync(query.RouteId);
        var result = new List<BookingResponse> { _mapper.Map<Domain.Booking.Models.Entities.Booking, BookingResponse>(data) };
        return result;
    }
}