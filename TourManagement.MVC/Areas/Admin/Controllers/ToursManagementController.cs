using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TourManagement.Core.DbContext;

namespace TourManagement.MVC.Areas.Admin.Controllers
{
    public class ToursManagementController : Controller
    {
        private DuLichTourContext db = new DuLichTourContext();

        // GET: Admin/ToursManagement
        public ActionResult Index()
        {
            var tours = db.Tours.Include(t => t.Destination).Include(t => t.Employee).Include(t => t.Group).Include(t => t.Hotel).Include(t => t.Transport);
            return View(tours.ToList());
        }

        // GET: Admin/ToursManagement/Details/5
        public ActionResult Details(int? id)
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

        // GET: Admin/ToursManagement/Create
        public ActionResult Create()
        {
            ViewBag.DestinationID = new SelectList(db.Destinations, "DestinationID", "Name");
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "Name");
            ViewBag.GroupID = new SelectList(db.Groups, "GroupID", "Name");
            ViewBag.HotelID = new SelectList(db.Hotels, "HotelID", "Name");
            ViewBag.TransportID = new SelectList(db.Transports, "TransportID", "Name");
            return View();
        }

        // POST: Admin/ToursManagement/Create
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
            ViewBag.TransportID = new SelectList(db.Transports, "TransportID", "Name", tour.TransportID);
            return View(tour);
        }

        // GET: Admin/ToursManagement/Edit/5
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
            ViewBag.TransportID = new SelectList(db.Transports, "TransportID", "Name", tour.TransportID);
            return View(tour);
        }

        // POST: Admin/ToursManagement/Edit/5
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
            ViewBag.TransportID = new SelectList(db.Transports, "TransportID", "Name", tour.TransportID);
            return View(tour);
        }

        // GET: Admin/ToursManagement/Delete/5
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

        // POST: Admin/ToursManagement/Delete/5
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
