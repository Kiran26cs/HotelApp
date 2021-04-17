using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel.Entities;
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
        public async Task CreateRoom(Room newRoom)
        {
            await this.iRoomRepository.AddNewRoom(newRoom);
        }

        public async Task<IEnumerable<Room>> GetRooms()
        {
            return await this.iRoomRepository.GetRooms();
        }
    }
}
