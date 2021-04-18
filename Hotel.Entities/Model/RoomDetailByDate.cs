using System;
using System.Collections.Generic;
using System.Text;
using Hotel.Entities;

namespace Hotel.Entities.Model
{
    public class RoomDetailByDate:Room
    {
        public string Status { get; set; }
    }

    public class RoomDetailByDateResponse
    {
        public List<RoomDetailByDate> roomsData { get; set; }
    }
}
