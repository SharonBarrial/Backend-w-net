using System.Data;
using AutoMapper;
using Whereto.Domain.Booking.Models.Commands;
using Whereto.Domain.Booking.Models.Queries;
using Whereto.Domain.Booking.Repositories;
using Whereto.Domain.Booking.Services;
using Whereto.Shared;

namespace Whereto.Application.Booking.CommandServices;

public class BookingCommandService: IBookingCommandService
{
    private readonly IBookingRepository _bookingRepository;
    private readonly IMapper _mapper;
    
    public BookingCommandService(IBookingRepository bookingRepository, IMapper mapper)
    {
        _bookingRepository = bookingRepository;
        _mapper = mapper;
    }
    
    public async Task<int> Handle(CreateBookingCommand command)
    {
        var booking = _mapper.Map<CreateBookingCommand, Domain.Booking.Models.Entities.Booking>(command);
        
        var existingBookingByUsernameAsync = await _bookingRepository.GetByUsernameAsync(booking.Username);
        var existingBookingByRouteIdAsync = await _bookingRepository.GetByRouteIdAsync(booking.RouteId);
        var existingBookingByDateAsync = await _bookingRepository.GetByDateAsync(booking.CreatedAt);
        if (existingBookingByDateAsync != null || existingBookingByRouteIdAsync != null && existingBookingByUsernameAsync != null) 
            throw new DuplicateNameException("You can't make a make with the same username and route on the same day");

        if (command.Days < Constants.MIN_DAYS || command.Days > Constants.MAX_DAYS) 
            throw new ConstraintException("You only can make a booking for a minimum of 1 day and a maximum of 30 days");
        
        return await _bookingRepository.SaveBookingAsync(booking);

    }
}