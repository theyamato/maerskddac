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
    public class ShipYardsController : Controller
    {
        private Maersk_LineContext db = new Maersk_LineContext();

        // GET: ShipYards
        public ActionResult Index()
        {
            return View(db.ShipYards.ToList());
        }

        // GET: ShipYards/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShipYard shipYard = db.ShipYards.Find(id);
            if (shipYard == null)
            {
                return HttpNotFound();
            }
            return View(shipYard);
        }

        // GET: ShipYards/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ShipYards/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ShipyardID,ShipYardName,CurrentNumberOfShipsDocked,ShipYardDockNumber,TotalNumberOfContainers")] ShipYard shipYard)
        {
            if (ModelState.IsValid)
            {
                db.ShipYards.Add(shipYard);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(shipYard);
        }

        // GET: ShipYards/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShipYard shipYard = db.ShipYards.Find(id);
            if (shipYard == null)
            {
                return HttpNotFound();
            }
            return View(shipYard);
        }

        // POST: ShipYards/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ShipyardID,ShipYardName,CurrentNumberOfShipsDocked,ShipYardDockNumber,TotalNumberOfContainers")] ShipYard shipYard)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shipYard).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(shipYard);
        }

        // GET: ShipYards/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShipYard shipYard = db.ShipYards.Find(id);
            if (shipYard == null)
            {
                return HttpNotFound();
            }
            return View(shipYard);
        }

        // POST: ShipYards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ShipYard shipYard = db.ShipYards.Find(id);
            db.ShipYards.Remove(shipYard);
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
