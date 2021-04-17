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
    }
}
