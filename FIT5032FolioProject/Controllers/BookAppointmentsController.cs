using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FIT5032FolioProject.Models;
using Microsoft.AspNet.Identity;

namespace FIT5032FolioProject.Controllers
{
    public class BookAppointmentsController : Controller
    {
        private Entities db = new Entities();

        // GET: BookAppointments
        public ActionResult Index()
        {
            var bookAppointmentSet = db.BookAppointmentSet.Include(b => b.AspNetUsers);
            return View(bookAppointmentSet.ToList());
        }

        // GET: BookAppointments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookAppointment bookAppointment = db.BookAppointmentSet.Find(id);
            if (bookAppointment == null)
            {
                return HttpNotFound();
            }
            return View(bookAppointment);
        }

        // GET: BookAppointments/Create
        public ActionResult Create()
        {
            ViewBag.AspNetUsersId = new SelectList(db.AspNetUsers, "Id", "Email");
            return View();
        }

        // POST: BookAppointments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "BookingId,Description,BookingDate,AspNetUsersId")] BookAppointment bookAppointment)
        {
            
            if (ModelState.IsValid)
            {
                db.BookAppointmentSet.Add(bookAppointment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AspNetUsersId = new SelectList(db.AspNetUsers, "Id", "Email", bookAppointment.AspNetUsersId);
            return View(bookAppointment);
        }

        // GET: BookAppointments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookAppointment bookAppointment = db.BookAppointmentSet.Find(id);
            if (bookAppointment == null)
            {
                return HttpNotFound();
            }
            ViewBag.AspNetUsersId = new SelectList(db.AspNetUsers, "Id", "Email", bookAppointment.AspNetUsersId);
            return View(bookAppointment);
        }

        // POST: BookAppointments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BookingId,Description,BookingDate,AspNetUsersId")] BookAppointment bookAppointment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bookAppointment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AspNetUsersId = new SelectList(db.AspNetUsers, "Id", "Email", bookAppointment.AspNetUsersId);
            return View(bookAppointment);
        }

        // GET: BookAppointments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookAppointment bookAppointment = db.BookAppointmentSet.Find(id);
            if (bookAppointment == null)
            {
                return HttpNotFound();
            }
            return View(bookAppointment);
        }

        // POST: BookAppointments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BookAppointment bookAppointment = db.BookAppointmentSet.Find(id);
            db.BookAppointmentSet.Remove(bookAppointment);
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
