using Hotel.Entities;
using Hotel.Entities.Model;
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
        public async Task<bool> AddNewRoom(Room room)
        {
            bool newRoomAdded = false;
            //check if the room number already exists
            var exists = hotelAppContext.Rooms.Any(x=>x.RoomNo == room.RoomNo);
            if (!exists)
            {
                newRoomAdded = true;
                await hotelAppContext.Rooms.AddAsync(room);
                await hotelAppContext.SaveChangesAsync();
            }
            return newRoomAdded;
        }

        public async Task<IEnumerable<RoomDetailByDate>> GetRoomsByDate(string dateselected)
        {
            List<int> bookedRoomIDs = null;
            List<RoomDetailByDate> FinalList = new List<RoomDetailByDate>();
            try
            {
                //select the bookings active during this period
                var bookedRooms = await hotelAppContext.Bookings.Where(x => x.FromDate.Date <= Convert.ToDateTime(dateselected).Date && x.ToDate.Date >= Convert.ToDateTime(dateselected).Date).ToListAsync();
                if (bookedRooms!=null && bookedRooms.Any())
                {
                    bookedRoomIDs = bookedRooms.Select(x=>x.RoomId).ToList();
                    //left join the room IDs above with actuial rooms --> matching ones are booked otherwise Not booked
                    FinalList = await (from r in hotelAppContext.Rooms
                                       join i in bookedRoomIDs.Distinct()
                                       on r.Id equals i into roomjoinres
                                       from res in roomjoinres.DefaultIfEmpty()
                                       select new RoomDetailByDate
                                       {
                                           RoomNo = r.RoomNo,
                                           RoomType = r.RoomType,
                                           Status = res > 0 ? "Booked" : "Not Booked"
                                       }).ToListAsync();
                }
                else
                {
                    await hotelAppContext.Rooms.ForEachAsync(x=>
                    {
                        FinalList.Add(new RoomDetailByDate {RoomNo = x.RoomNo, RoomType = x.RoomType, Status="Not Booked" });
                    });
                }
                
                
                
            }
            catch (Exception es)
            {
                throw es;
            }
            
            return FinalList;
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
