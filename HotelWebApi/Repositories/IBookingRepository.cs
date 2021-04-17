using Hotel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelWebApi.Repositories
{
    public interface IBookingRepository
    {
        Task CreateBooking(Booking booking);
        Task<IEnumerable<Booking>> GetBookings();
    }
}
