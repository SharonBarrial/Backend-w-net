using Microsoft.EntityFrameworkCore;
using Whereto.Domain.Booking.Repositories;
using Whereto.Infrastructure.Shared.Contexts;

namespace Whereto.Infrastructure.Booking.Persistence;

public class BookingRepository: IBookingRepository
{
    private readonly WheretoContext _wheretoContext;
    
    public BookingRepository(WheretoContext wheretoContext)
    {
        _wheretoContext = wheretoContext;
    }
    
    public async Task<Domain.Booking.Models.Entities.Booking> GetByUsernameAsync(string name)
    {
        var result = await _wheretoContext.Bookings
            .Where(t => t.Username.Contains(name))
            .FirstOrDefaultAsync();

        return result;
    }

    public async Task<Domain.Booking.Models.Entities.Booking> GetByRouteIdAsync(int id)
    {
        var result = await _wheretoContext.Bookings
            .Where(t => t.RouteId == id)
            .FirstOrDefaultAsync();

        return result;
    }

    public async Task<Domain.Booking.Models.Entities.Booking> GetByDateAsync(DateTime date)
    {
        var result = await _wheretoContext.Bookings
            .Where(t => t.CreatedAt == date)
            .FirstOrDefaultAsync();

        return result;
    }

    public async Task<int> SaveBookingAsync(Domain.Booking.Models.Entities.Booking data)
    {
        using (var transaction = await _wheretoContext.Database.BeginTransactionAsync())
        {
            try
            {
                _wheretoContext.Bookings.Add(data);
                await _wheretoContext.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw new Exception(ex.Message);
            }
        }
        
        return data.Id;
    }
}