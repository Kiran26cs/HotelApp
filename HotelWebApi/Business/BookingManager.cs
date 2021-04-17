using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel.Entities;
using HotelWebApi.DataContext;
using HotelWebApi.Repositories;

namespace HotelWebApi.Business
{
    public class BookingManager : IBookingManager
    {
        IBookingRepository iBookingRepository;
        public BookingManager(IBookingRepository iBookingRepository)
        {
            this.iBookingRepository = iBookingRepository;
        }
        public async Task CreateBooking(Booking newBooking)
        {
            await this.iBookingRepository.CreateBooking(newBooking);
        }

        public async Task<IEnumerable<Booking>> GetBookings()
        {
            return await this.iBookingRepository.GetBookings();
        }
    }
}
