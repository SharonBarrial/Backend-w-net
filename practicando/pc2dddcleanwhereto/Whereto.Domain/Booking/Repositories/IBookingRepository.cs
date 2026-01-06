namespace Whereto.Domain.Booking.Repositories;
using Whereto.Domain.Booking.Models.Entities;

public interface IBookingRepository
{
    Task<Booking> GetByUsernameAsync(string name);
    Task<Booking> GetByRouteIdAsync(int id);
    Task<Booking> GetByDateAsync(DateTime date);
    Task<int> SaveBookingAsync(Booking data);
}