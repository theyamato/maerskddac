using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Maersk_Line.Models;

namespace Maersk_Line.Controllers
{
    public class BookingsController : Controller
    {
        private Maersk_LineContext db = new Maersk_LineContext();

        // GET: Bookings
        public ActionResult Index()
        {
            var bookings = db.Bookings.Include(b => b.container).Include(b => b.ships).Include(b => b.shipYard).Include(b => b.warehouse);
            return View(bookings.ToList());
        }

        // GET: Bookings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // GET: Bookings/Create
        public ActionResult Create()
        {
            ViewBag.ContainerID = new SelectList(db.Containers, "ContainerID", "ContainerName");
            ViewBag.ShipCode = new SelectList(db.Ships, "ShipCode", "ShipName");
            ViewBag.ShipyardID = new SelectList(db.ShipYards, "ShipyardID", "ShipYardName");
            ViewBag.WarehouseID = new SelectList(db.Warehouses, "WarehouseID", "WarehouseName");
            return View();
        }

        // POST: Bookings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BookingID,WarehouseID,ShipCode,ShipyardID,ContainerID,Price,Date,Time,Departure,Destination")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                db.Bookings.Add(booking);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ContainerID = new SelectList(db.Containers, "ContainerID", "ContainerName", booking.ContainerID);
            ViewBag.ShipCode = new SelectList(db.Ships, "ShipCode", "ShipName", booking.ShipCode);
            ViewBag.ShipyardID = new SelectList(db.ShipYards, "ShipyardID", "ShipYardName", booking.ShipyardID);
            ViewBag.WarehouseID = new SelectList(db.Warehouses, "WarehouseID", "WarehouseName", booking.WarehouseID);
            return View(booking);
        }

        // GET: Bookings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            ViewBag.ContainerID = new SelectList(db.Containers, "ContainerID", "ContainerName", booking.ContainerID);
            ViewBag.ShipCode = new SelectList(db.Ships, "ShipCode", "ShipName", booking.ShipCode);
            ViewBag.ShipyardID = new SelectList(db.ShipYards, "ShipyardID", "ShipYardName", booking.ShipyardID);
            ViewBag.WarehouseID = new SelectList(db.Warehouses, "WarehouseID", "WarehouseName", booking.WarehouseID);
            return View(booking);
        }

        // POST: Bookings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BookingID,WarehouseID,ShipCode,ShipyardID,ContainerID,Price,Date,Time,Departure,Destination")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                db.Entry(booking).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ContainerID = new SelectList(db.Containers, "ContainerID", "ContainerName", booking.ContainerID);
            ViewBag.ShipCode = new SelectList(db.Ships, "ShipCode", "ShipName", booking.ShipCode);
            ViewBag.ShipyardID = new SelectList(db.ShipYards, "ShipyardID", "ShipYardName", booking.ShipyardID);
            ViewBag.WarehouseID = new SelectList(db.Warehouses, "WarehouseID", "WarehouseName", booking.WarehouseID);
            return View(booking);
        }

        // GET: Bookings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // POST: Bookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Booking booking = db.Bookings.Find(id);
            db.Bookings.Remove(booking);
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
