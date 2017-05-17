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
    public class CommonsController : Controller
    {
        private BooksDbContext db = new BooksDbContext();

        // GET: Commons
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetCountry(int stateId)
        {
            IQueryable<Country> countries = db.States.Where(s => s.ID == stateId).Select(s => s.Country);

            return Json(countries.FirstOrDefault().Name, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetState(int cityId)
        {
            IQueryable<State> states = db.Cities.Where(c => c.ID == cityId).Select(c => c.State);

            return Json(states.FirstOrDefault(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetAuthors(string name)
        {
            var persons = db.Persons.Where(p => p.Name == name).ToList();

            return Json(persons, JsonRequestBehavior.AllowGet);
        }
    }
}