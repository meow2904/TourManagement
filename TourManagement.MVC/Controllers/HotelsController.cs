using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TourManagement.Core.DbContext;
using TourManagement.Core.Repository;

namespace TourManagement.MVC.Controllers
{
    public class HotelsController : Controller
    {
        private readonly IHotelRepository _hotelRepository;

        public HotelsController(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }
        // GET: Hotels
        public ActionResult Index()
        {
            var hotels = _hotelRepository.GetAll();
            return View(hotels);
        }

        // GET: Hotels/Details/5
        public ActionResult Details(int? id)
        {
            var hotel = _hotelRepository.GetById((int)id);
            if (hotel == null)
            {
                return HttpNotFound();
            }
            return View(hotel);
        }

        // GET: Hotels/Create

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
