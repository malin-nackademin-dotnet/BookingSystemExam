namespace BookingSystem.Models;

public interface IBookingRepository
{
    IReadOnlyList<Booking> GetAll();
    void Add(Booking booking);
    void Save();
}
