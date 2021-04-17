using Hotel.Entities;
using Hotel.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelWebApi.Business
{
    public interface IBookingManager
    {
        Task<IEnumerable<BookingDetail>> GetBookings(string user);
        Task<Room> CreateBooking(CreateBooking newBooking);
    }
}
