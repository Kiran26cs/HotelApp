using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Entities.Model
{
    public class CreateBooking
    {
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string RoomType { get; set; }
        public string CreatedBy { get; set; }
    }
}
