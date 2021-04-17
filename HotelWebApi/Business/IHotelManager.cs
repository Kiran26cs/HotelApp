using Hotel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelWebApi.Business
{
    public interface IHotelManager
    {
        Task<IEnumerable<Room>> GetRooms();
        Task CreateRoom(Room newRoom);
    }
}
