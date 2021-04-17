using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Hotel.Entities;
using HotelWebApi.Business;

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
        public async Task<IEnumerable<Booking>> Get()
        {
            return await this.bookingManager.GetBookings();
        }

        // GET: api/Booking/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Booking
        [HttpPost]
        public async Task Post([FromBody] Booking booking)
        {
            await this.bookingManager.CreateBooking(booking);
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
