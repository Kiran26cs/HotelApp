using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel.Entities;
using Hotel.Entities.Model;
using HotelWebApi.DataContext;
using HotelWebApi.Repositories;

namespace HotelWebApi.Business
{
    public class BookingManager : IBookingManager
    {
        IBookingRepository iBookingRepository;
        IRoomRepository iRoomRepository;
        public BookingManager(IBookingRepository iBookingRepository, IRoomRepository iRoomRepository)
        {
            this.iBookingRepository = iBookingRepository;
            this.iRoomRepository = iRoomRepository;
        }
        public async Task<Room> CreateBooking(CreateBooking newBooking)
        {
            var selectedRoom = await iRoomRepository.GetRoomAvailability(newBooking.RoomType, newBooking.FromDate, newBooking.ToDate);
            //prepare the entity to insert
            if (selectedRoom != null)
            {
                Booking booking = new Booking
                {
                    RoomId = selectedRoom.Id,
                    RoomType = newBooking.RoomType,
                    Status = "Booked",
                    FromDate = newBooking.FromDate,
                    ToDate = newBooking.ToDate,
                    CreatedBy = newBooking.CreatedBy,
                    CreatedOn = DateTime.Now,
                    UpdatedBy = newBooking.CreatedBy,
                    UpdatedOn = DateTime.Now 
                };
                await this.iBookingRepository.CreateBooking(booking);
                //retdurn selected room
                return selectedRoom;
            }
            else
            {
                return null;
            }
            
        }

        public async Task<IEnumerable<BookingDetail>> GetBookings(string user)
        {
            return await this.iBookingRepository.GetBookings(user);
        }
    }
}
