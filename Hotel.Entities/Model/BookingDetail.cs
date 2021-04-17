using System;
using System.Collections.Generic;
using System.Text;
using Hotel.Entities;
namespace Hotel.Entities.Model
{
    public class BookingDetail:Booking
    {
        public Room RoomDetail { get; set; }
    }
}
