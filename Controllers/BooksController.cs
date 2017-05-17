using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Books.Models;
using Books.Common;

namespace Books.Controllers
{
    public class BooksController : Controller
    {
        private BooksDbContext db = new BooksDbContext();

        // GET: Books
        public ActionResult Index()
        {
            var books = db.Books.Include(b => b.Genre).Include(b => b.Person);
            return View(books.ToList());
        }

        // GET: Books/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // GET: Books/Create
        public ActionResult Create()
        {
            var authors = db.Persons.Where(p => p.PersonTypeID == (int)PersonTypeValue.Author);
            ViewBag.GenreID = new SelectList(db.Genres, "ID", "Name");
            ViewBag.PersonID = new SelectList(authors, "ID", "Name");
            ViewBag.AuthorID = new SelectList(authors, "ID", "FirstName");
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Description,Price,Image,PersonID,GenreID")] Book book, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                if (upload != null)
                    book.Image = Utility.GetImage(upload);

                db.Books.Add(book);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GenreID = new SelectList(db.Genres, "ID", "Name", book.GenreID);
            ViewBag.PersonID = new SelectList(db.Persons, "ID", "Name", book.PersonID);
            return View(book);
        }

        // GET: Books/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            var authors = db.Persons.Where(p => p.PersonTypeID == (int)PersonTypeValue.Author);
            ViewBag.GenreID = new SelectList(db.Genres, "ID", "Name", book.GenreID);
            ViewBag.PersonID = new SelectList(authors, "ID", "Name", book.PersonID);
            ViewBag.AuthorID = new SelectList(authors, "ID", "FirstName", book.PersonID);
            return View(book);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Description,Price,Image,PersonID,GenreID")] Book book, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                db.Entry(book).State = EntityState.Modified;

                if (upload != null)
                    book.Image = Utility.GetImage(upload);
                else
                    db.Entry(book).Property(m => m.Image).IsModified = false;

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GenreID = new SelectList(db.Genres, "ID", "Name", book.GenreID);
            ViewBag.PersonID = new SelectList(db.Persons, "ID", "Name", book.PersonID);
            return View(book);
        }

        // GET: Books/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Book book = db.Books.Find(id);
            db.Books.Remove(book);
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
