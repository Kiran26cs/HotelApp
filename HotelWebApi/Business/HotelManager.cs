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
    public class HotelManager : IHotelManager
    {
        IRoomRepository iRoomRepository;
        public HotelManager(IRoomRepository iRoomRepository)
        {
            this.iRoomRepository = iRoomRepository;
        }
        public async Task<bool> CreateRoom(Room newRoom)
        {
            return await this.iRoomRepository.AddNewRoom(newRoom);
        }

        public async Task<IEnumerable<RoomDetailByDate>> GetRoomsByDate(string DateSelected)
        {
            return await this.iRoomRepository.GetRoomsByDate(DateSelected);
        }
    }
}
