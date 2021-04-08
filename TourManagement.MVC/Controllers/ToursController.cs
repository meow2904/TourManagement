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
    public class ToursController : Controller
    {
        private DuLichTourContext db = new DuLichTourContext();
        private readonly ITourRepository _tourRepository;
        public ToursController(ITourRepository tourRepository)
        {
            _tourRepository = tourRepository;
        }


        // GET: Tours
        public ActionResult Index(int id)
        {
            var tours = db.Tours.Include(t => t.Destination).Include(t => t.Employee).Include(t => t.Group).Include(t => t.Hotel);
            return View(tours.ToList());
        }

        // GET: Tours/Details/5
        public ActionResult Details(int? id)
        {
            var tour = _tourRepository.GetById((int)id);
            if (tour == null)
            {
                return HttpNotFound();
            }
            return View(tour);
        }

        public ActionResult GetByCategory(int? id)
        {
            var tours = _tourRepository.GetByCategory((int) id);
            if (tours == null)
            {
                return HttpNotFound();
            }
            return View(tours);
        }

        // GET: Tours/Create
        //public ActionResult Create()
        //{
        //    ViewBag.DestinationID = new SelectList(db.Destinations, "DestinationID", "Name");
        //    ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "Name");
        //    ViewBag.GroupID = new SelectList(db.Groups, "GroupID", "Name");
        //    ViewBag.HotelID = new SelectList(db.Hotels, "HotelID", "Name");
        //    ViewBag.TransportID = new SelectList(db.Transports, "TransportID", "Name");
        //    return View();
        //}

        // POST: Tours/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TourID,Name,Time,TimeStart,PositionStart,Content,HotelID,TransportID,GroupID,EmployeeID,DestinationID,Price,Image")] Tour tour)
        {
            if (ModelState.IsValid)
            {
                db.Tours.Add(tour);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DestinationID = new SelectList(db.Destinations, "DestinationID", "Name", tour.DestinationID);
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "Name", tour.EmployeeID);
            ViewBag.GroupID = new SelectList(db.Groups, "GroupID", "Name", tour.GroupID);
            ViewBag.HotelID = new SelectList(db.Hotels, "HotelID", "Name", tour.HotelID);
            return View(tour);
        }

        // GET: Tours/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tour tour = db.Tours.Find(id);
            if (tour == null)
            {
                return HttpNotFound();
            }
            ViewBag.DestinationID = new SelectList(db.Destinations, "DestinationID", "Name", tour.DestinationID);
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "Name", tour.EmployeeID);
            ViewBag.GroupID = new SelectList(db.Groups, "GroupID", "Name", tour.GroupID);
            ViewBag.HotelID = new SelectList(db.Hotels, "HotelID", "Name", tour.HotelID);
            return View(tour);
        }

        // POST: Tours/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TourID,Name,Time,TimeStart,PositionStart,Content,HotelID,TransportID,GroupID,EmployeeID,DestinationID,Price,Image")] Tour tour)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tour).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DestinationID = new SelectList(db.Destinations, "DestinationID", "Name", tour.DestinationID);
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "Name", tour.EmployeeID);
            ViewBag.GroupID = new SelectList(db.Groups, "GroupID", "Name", tour.GroupID);
            ViewBag.HotelID = new SelectList(db.Hotels, "HotelID", "Name", tour.HotelID);
            return View(tour);
        }

        // GET: Tours/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tour tour = db.Tours.Find(id);
            if (tour == null)
            {
                return HttpNotFound();
            }
            return View(tour);
        }

        // POST: Tours/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tour tour = db.Tours.Find(id);
            db.Tours.Remove(tour);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
