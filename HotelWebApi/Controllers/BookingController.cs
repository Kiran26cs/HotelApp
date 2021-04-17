using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Hotel.Entities;
using HotelWebApi.Business;
using Hotel.Entities.Model;

namespace HotelWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        IBookingManager bookingManager;
        public BookingController(IBookingManager bookingManager)
        {
            this.bookingManager = bookingManager;
        }
        // GET: api/Booking
        [HttpGet]
        public async Task<IEnumerable<BookingDetail>> Get()
        {
            var ctxt = HttpContext.User;
            var user = ctxt.Identity.Name;
            return await this.bookingManager.GetBookings(user);
        }

        // GET: api/Booking/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Booking
        [HttpPost]
        public async Task<Room> Post([FromBody] CreateBooking booking)
        {
            var ctxt = HttpContext.User;
            booking.CreatedBy = ctxt.Identity.Name;
            return await this.bookingManager.CreateBooking(booking);
        }

        // PUT: api/Booking/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
