using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelWebApp.Models
{
    public class BookingDetail
    {
        [Required(ErrorMessage ="Start date is mandatory")]
        [Display(Name ="Stay Starts from")]
        public DateTime FromDate { get; set; }
        [Required(ErrorMessage = "End date is mandatory")]
        [Display(Name = "Stay Ends on")]
        public DateTime ToDate { get; set; }
        [Required(ErrorMessage = "Room type is mandatory")]
        [Display(Name = "Select a Room type")]
        public string RoomType { get; set; }
    }
}
