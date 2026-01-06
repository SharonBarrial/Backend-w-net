namespace Whereto.Shared;

public class BookingNotException : Exception
{
    public BookingNotException()
    {
    }

    public BookingNotException(string message) : base(message)
    {
        
    }

    public BookingNotException(string message, Exception inner) : base(message, inner)
    {
        
    }
}