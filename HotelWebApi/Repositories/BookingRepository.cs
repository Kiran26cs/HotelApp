using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel.Entities;
using HotelWebApi.DataContext;
using Microsoft.EntityFrameworkCore;

namespace HotelWebApi.Repositories
{
    public class BookingRepository: IBookingRepository
    {
        readonly HotelAppContext hotelAppContext;
        public BookingRepository(HotelAppContext hotelAppContext)
        {
            this.hotelAppContext = hotelAppContext;
        }
        public async Task CreateBooking(Booking booking)
        {
            await hotelAppContext.Bookings.AddAsync(booking);
            hotelAppContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Booking>> GetBookings()
        {
            return await hotelAppContext.Bookings.ToListAsync();
        }
    }
}
