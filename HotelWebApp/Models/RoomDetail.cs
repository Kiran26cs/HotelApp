using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelWebApp.Models
{
    public class RoomDetail:Error
    {
        [Display(Name = "Room Number")]
        public string RoomNo { get; set; }
        [Display(Name = "Type of Room")]
        public string RoomType { get; set; }
    }
}
