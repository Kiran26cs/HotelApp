using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelWebApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HotelWebApp.Services;

namespace HotelWebApp.Controllers
{
    public class BookingController : Controller
    {
        // GET: Booking
        public ActionResult Index()
        {
            return View();
        }

        // GET: Booking/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult MyBooking()
        {
            try
            {
                // TODO: Add insert logic here
                var resp = ApiHelper.GetFromApi<List<MyBooking>, object>("https://localhost:44349/api/Booking");
                return View(resp);
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: Booking/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Booking/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BookingDetail bookingDetail)
        {
            try
            {
                // TODO: Add insert logic here
                var resp = ApiHelper.PostToApi<RoomDetail, BookingDetail>("https://localhost:44349/api/Booking", bookingDetail);
                ViewData["IsSaved"] = true;
                ViewData["IsSuccess"] = !resp.isError;
                ViewData["BookedRoomNo"] = resp.RoomNo;
                ViewData["BookedRoomType"] = bookingDetail.RoomType;
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Booking/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Booking/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Booking/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Booking/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}