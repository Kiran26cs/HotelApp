using Hotel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelWebApi.Business
{
    public interface IBookingManager
    {
        Task<IEnumerable<Booking>> GetBookings();
        Task CreateBooking(Booking newBooking);
    }
}
