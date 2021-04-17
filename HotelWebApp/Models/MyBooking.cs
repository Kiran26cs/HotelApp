using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelWebApp.Models
{
    public class MyBooking
    {
        [Display(Name ="Start date")]
        public DateTime FromDate { get; set; }
        [Display(Name = "End date")]
        public DateTime ToDate { get; set; }

        public RoomDetail RoomDetail { get; set; }
        
    }
}
