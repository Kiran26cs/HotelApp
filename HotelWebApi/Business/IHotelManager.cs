using Hotel.Entities;
using Hotel.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelWebApi.Business
{
    public interface IHotelManager
    {
        Task<IEnumerable<RoomDetailByDate>> GetRoomsByDate(string DateSelected);
        Task<bool> CreateRoom(Room newRoom);
    }
}
