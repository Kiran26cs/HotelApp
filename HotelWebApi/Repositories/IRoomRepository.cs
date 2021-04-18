using Hotel.Entities;
using Hotel.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelWebApi.Repositories
{
    public interface IRoomRepository
    {
        Task<bool> AddNewRoom(Room room);
        Task<IEnumerable<RoomDetailByDate>> GetRoomsByDate(string dateselected);
        Task<Room> GetRoomAvailability(string RoomType, DateTime startDate, DateTime endDate);
    }
}
