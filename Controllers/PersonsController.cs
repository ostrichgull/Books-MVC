using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Books.Models;

namespace Books.Controllers
{
    public class PersonsController : Controller
    {
        private BooksDbContext db = new BooksDbContext();

        // GET: Persons/Type/2
        public ActionResult Index(int typeId)
        {
            var persons = db.Persons
                                .Include(p => p.City)
                                .Include(p => p.CityAddress)
                                .Include(p => p.Gender)
                                .Where(p => p.PersonTypeID == typeId);
            return View(persons.ToList());
        }

        // GET: Persons/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = db.Persons.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // GET: Persons/Create        
        public ActionResult Create(int typeId)
        {
            ViewBag.CityID = new SelectList(db.Cities, "ID", "Name");
            ViewBag.CityAddressID = new SelectList(db.Cities, "ID", "Name");
            ViewBag.GenderID = new SelectList(db.Genders, "ID", "Name");
            ViewBag.PersonTypeID = new SelectList(db.PersonTypes, "ID", "Name", typeId);
            return View();
        }

        // POST: Persons/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,FirstName,DateOfBirth,StreetName,Number,Extension,Phone,Email,GenderID,CityID,CityAddressID,PersonTypeID")] Person person, int typeId)
        {
            if (ModelState.IsValid)
            {
                person.PersonTypeID = typeId;
                db.Persons.Add(person);
                db.SaveChanges();
                return RedirectToAction("Index", new { typeId = person.PersonTypeID });
            }

            ViewBag.CityID = new SelectList(db.Cities, "ID", "Name", person.CityID);
            ViewBag.CityAddressID = new SelectList(db.Cities, "ID", "Name", person.CityAddressID);
            ViewBag.GenderID = new SelectList(db.Genders, "ID", "Name", person.GenderID);
            return View(person);
        }

        // GET: Persons/Edit/5
        public ActionResult Edit(int? id, int typeId)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = db.Persons.Find(id);
            if (person == null)
            {   
                return HttpNotFound();
            }
            ViewBag.CityID = new SelectList(db.Cities, "ID", "Name", person.CityID);
            ViewBag.CityAddressID = new SelectList(db.Cities, "ID", "Name", person.CityAddressID);
            ViewBag.GenderID = new SelectList(db.Genders, "ID", "Name", person.GenderID);
            ViewBag.PersonTypeID = new SelectList(db.PersonTypes, "ID", "Name", person.PersonTypeID);
            ViewBag.TypeID = typeId;

            return View(person);
        }

        // POST: Persons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,FirstName,DateOfBirth,StreetName,Number,Extension,Phone,Email,GenderID,CityID,CityAddressID,PersonTypeID")] Person person, int typeId)
        {
            if (ModelState.IsValid)
            {
                db.Entry(person).State = EntityState.Modified;
                person.PersonTypeID = typeId;
                db.SaveChanges();
                return RedirectToAction("Index", new { typeId = person.PersonTypeID });
            }
            ViewBag.CityID = new SelectList(db.Cities, "ID", "Name", person.CityID);
            ViewBag.CityAddressID = new SelectList(db.Cities, "ID", "Name", person.CityAddressID);
            ViewBag.GenderID = new SelectList(db.Genders, "ID", "Name", person.GenderID);
            ViewBag.PersonTypeID = new SelectList(db.PersonTypes, "ID", "Name", typeId);
            return View(person);
        }

        // GET: Persons/Delete/5        
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = db.Persons.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // POST: Persons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int typeId, int id)
        {
            Person person = db.Persons.Find(id);            
            db.Persons.Remove(person);
            db.SaveChanges();
            return RedirectToAction("Index", new { typeId = typeId });
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
