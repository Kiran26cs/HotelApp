using Hotel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelWebApi.Repositories
{
    public interface IRoomRepository
    {
        Task AddNewRoom(Room room);
        Task<IEnumerable<Room>> GetRooms();
        Task<Room> GetRoomAvailability(string RoomType, DateTime startDate, DateTime endDate);
    }
}
