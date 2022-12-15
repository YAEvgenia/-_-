using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CadastreManagment.Controllers
{
    public class MineralsController : Controller
    {
        DataClasses1DataContext dc = new DataClasses1DataContext();
        // GET: Minerals
        public ActionResult Index()
        {
            var mineralsDetails = from x in dc.Minerals select x;
            return View(mineralsDetails);
        }

        // GET: Minerals/Details/5
        public ActionResult Details(int id)
        {
            var getMineralsDetails = dc.Minerals.Single(x => x.Id == id);
            return View(getMineralsDetails);
        }
        [Authorize(Roles = "user")]
        public ActionResult IndexId(string userId)
        {
            List<Minerals> mineralsDetails = new List<Minerals>();
            mineralsDetails = dc.Minerals.Where(x => x.Passport == userId).ToList();
            return View(mineralsDetails);
        }
        [Authorize(Roles = "admin")]

        // GET: Minerals/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Minerals/Create
        [HttpPost]
        public ActionResult Create(Minerals collection)
        {
            try
            {
                // TODO: Add insert logic here
                dc.Minerals.InsertOnSubmit(collection);
                dc.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        [Authorize(Roles = "admin")]
        // GET: Minerals/Edit/5
        public ActionResult Edit(int id)
        {
            var getMineralsDetails = dc.Minerals.Single(x => x.Id == id);
            return View(getMineralsDetails);
        }

        // POST: Minerals/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Minerals collection)
        {
            try
            {
                // TODO: Add update logic here
                Minerals minerals = dc.Minerals.Single(x => x.Id == id);
                minerals.Passport = collection.Passport;
                minerals.Price = collection.Price;
                minerals.Type = collection.Type;
                minerals.Tax_coefficint = collection.Tax_coefficint;
                minerals.Address = collection.Address;
                minerals.Amount = collection.Amount;
                minerals.Approval_date = collection.Approval_date;
                dc.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        [Authorize(Roles = "admin")]
        // GET: Minerals/Delete/5
        public ActionResult Delete(int id)
        {
            var getMineralsDetails = dc.Minerals.Single(x => x.Id == id);
            return View(getMineralsDetails);
        }

        // POST: Minerals/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Minerals collection)
        {
            try
            {
                // TODO: Add delete logic here
                var mineralsDelete = dc.Minerals.Single(x => x.Id == id);
                dc.Minerals.DeleteOnSubmit(mineralsDelete);
                dc.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
