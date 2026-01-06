namespace Whereto.Domain.Booking.Models.Response;

public class BookingResponse
{
    public int Id { get; set; }
    public string Username { get; set; }
    public int RouteId { get; set; }
    public int Days { get; set; }
    public string Comments { get; set; }
    public DateTime CreatedAt { get; set; }
}