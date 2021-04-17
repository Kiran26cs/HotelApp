using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel.Entities;
namespace HotelWebApi.DataContext
{
    public class HotelAppContext : DbContext
    {
        public HotelAppContext()
        {

        }
        public HotelAppContext(DbContextOptions<HotelAppContext> hotelContext):base(hotelContext)
        {

        }

        //Data sets
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Room> Rooms { get; set; }
    }
}
