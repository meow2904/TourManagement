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

namespace TourManagement.MVC.Areas.Admin.Controllers
{
    public class HotelsManagementController : Controller
    {
        
        private readonly IHotelRepository _hotelRepository;

        public HotelsManagementController(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }

        // GET: Admin/HotelsManagement
        public ActionResult Index()
        {
            return View(_hotelRepository.GetAll());
        }

        // GET: Admin/HotelsManagement/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hotel hotel =_hotelRepository.GetById((int)id);
            if (hotel == null)
            {
                return HttpNotFound();
            }
            return View(hotel);
        }

        // GET: Admin/HotelsManagement/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/HotelsManagement/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HotelID,Name,Phone,Address,Email,Image,Content,Price")] Hotel hotel)
        {
            if (ModelState.IsValid)
            {
                _hotelRepository.Add(hotel);
                return RedirectToAction("Index");
            }

            return View(hotel);
        }

        // GET: Admin/HotelsManagement/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hotel hotel = _hotelRepository.GetById((int)id);
            if (hotel == null)
            {
                return HttpNotFound();
            }
            return View(hotel);
        }

        // POST: Admin/HotelsManagement/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HotelID,Name,Phone,Address,Email,Image,Content,Price")] Hotel hotel)
        {
            if (ModelState.IsValid)
            {
                _hotelRepository.Update(hotel);
                return RedirectToAction("Index");
            }
            return View(hotel);
        }

        // GET: Admin/HotelsManagement/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hotel hotel = _hotelRepository.GetById((int)id);
            if (hotel == null)
            {
                return HttpNotFound();
            }
            return View(hotel);
        }

        // POST: Admin/HotelsManagement/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Hotel hotel = _hotelRepository.GetById(id);
            _hotelRepository.Delete(hotel);
            return RedirectToAction("Index");
        }

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
