using Hotel.Entities;
using Hotel.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelWebApi.Repositories
{
    public interface IBookingRepository
    {
        Task CreateBooking(Booking booking);
        Task<IEnumerable<BookingDetail>> GetBookings(string userID);
    }
}
