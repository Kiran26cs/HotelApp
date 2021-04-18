using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HotelWebApi.Business;
using Hotel.Entities.Model;
using Hotel.Entities;
using Microsoft.AspNetCore.Cors;

namespace HotelWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        IHotelManager hotelManager;
        public HotelController(IHotelManager hotelManager)
        {
            this.hotelManager = hotelManager;
        }
        // GET: api/Hotel
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Hotel/5
        [HttpGet("{selectedDate}")]
        public object Get(string selectedDate)
        {
            RoomDetailByDateResponse servResponse = null;
            if (!string.IsNullOrEmpty(selectedDate))
            {
                servResponse = new RoomDetailByDateResponse { roomsData = this.hotelManager.GetRoomsByDate(selectedDate).Result.ToList() };
                return servResponse;
            }
            return null;
        }

        // POST: api/Hotel
        [HttpPost]
        public async Task<bool> Post([FromBody] Room value)
        {
            return await hotelManager.CreateRoom(value);
        }

        // PUT: api/Hotel/5
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
