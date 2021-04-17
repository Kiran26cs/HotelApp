using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel.Entities;
using HotelWebApi.DataContext;
using Microsoft.EntityFrameworkCore;
using Hotel.Entities.Model;

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
            await hotelAppContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<BookingDetail>> GetBookings(string userID)
        {
            var bookingDetail = (from b in hotelAppContext.Bookings
                                join r in hotelAppContext.Rooms
                                on new { RoomId = b.RoomId, CustomerId = b.CreatedBy } equals new { RoomId = r.Id, CustomerId = userID } into results
                                from res in results.DefaultIfEmpty()
                                select new BookingDetail
                                {
                                    Id = b.Id,
                                    RoomId = b.RoomId,
                                    FromDate = b.FromDate,
                                    Status = b.Status,
                                    ToDate=b.ToDate,
                                    RoomDetail = new Room
                                    {
                                        Id = b.RoomId,
                                        RoomNo = res.RoomNo??"",
                                        RoomType = res.RoomType??""
                                    }
                                }).ToAsyncEnumerable<BookingDetail>();
            return await bookingDetail.ToList();
        }
    }
}
