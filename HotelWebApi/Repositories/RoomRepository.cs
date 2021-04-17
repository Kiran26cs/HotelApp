using Hotel.Entities;
using HotelWebApi.DataContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelWebApi.Repositories
{
    public class RoomRepository: IRoomRepository
    {
        readonly HotelAppContext hotelAppContext;
        public RoomRepository(HotelAppContext hotelAppContext)
        {
            this.hotelAppContext = hotelAppContext;
        }
        public async Task AddNewRoom(Room room)
        {
            await hotelAppContext.Rooms.AddAsync(room);
        }

        public async Task<IEnumerable<Room>> GetRooms()
        {
            return await hotelAppContext.Rooms.ToListAsync();
        }

        public async Task<Room> GetRoomAvailability(string RoomType, DateTime startDate, DateTime endDate)
        {
            //get booked rooms on the start date
            var BookedRooms = await hotelAppContext.Bookings.Where(x => x.FromDate.Date == startDate.Date).Select(x => x.RoomId).ToListAsync();
            //exclude the booked rooms 
            var RoomsActiveOnFirstDate = hotelAppContext.Rooms.Except(hotelAppContext.Rooms.Where(x=> BookedRooms.Contains(x.Id)).ToList());
            //remaining rooms check if their start date falls before end date of the current booking
            var roomsjoinwithBooking = (from b in hotelAppContext.Bookings.Where(x=>x.FromDate.Date <= endDate.Date)
                                  join r in RoomsActiveOnFirstDate
                                  on b.RoomId equals r.Id
                                  select new Room
                                  {
                                      Id = r.Id
                                  }).ToList();
            //exclude them
            var RoomsAvailableDuringTheGivenPeriod = roomsjoinwithBooking.Except(hotelAppContext.Rooms.Where(x => roomsjoinwithBooking.Select(y => y.Id).Contains(x.Id)).ToList());

            //fetch remaining rooms
            var SelectedRoomForGivenOption = (from r in hotelAppContext.Rooms.Where(x => x.RoomType == RoomType)
                                     join av in RoomsAvailableDuringTheGivenPeriod
                                     on r.Id equals av.Id
                                     select new Room
                                     {
                                         Id=r.Id,
                                         RoomNo = r.RoomNo,
                                         RoomType = r.RoomType
                                     }).FirstOrDefault();

            return SelectedRoomForGivenOption;
        }
    }
}
