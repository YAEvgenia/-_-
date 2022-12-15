using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CadastreManagment.Controllers
{
    public class LandRegistryController : Controller
    {
        DataClasses1DataContext dc = new DataClasses1DataContext();
        // GET: LandRegistry
        public ActionResult Index()
        {
            //var landRegistryDetails = from x in dc.LandRegistry select x;
            //return View(landRegistryDetails);
            return View(dc.LandRegistry.ToList());
        }



        // GET: LandRegistry/Details/5
        public ActionResult Details(int id)
        {
            var getLandRegistryDetails = dc.LandRegistry.Single(x => x.Id == id);
            return View(getLandRegistryDetails);
        }
        [Authorize(Roles = "user")]

        public ActionResult IndexId(string userId)
        {
            List<LandRegistry> landRegistryDetails = new List<LandRegistry>() ;
            landRegistryDetails = dc.LandRegistry.Where(x => x.Passport == userId).ToList();
            return View(landRegistryDetails);
        }
        [Authorize(Roles = "admin")]

        // GET: LandRegistry/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LandRegistry/Create
        [HttpPost]
        public ActionResult Create(LandRegistry collection)
        {
            try
            {
                // TODO: Add insert logic here
                dc.LandRegistry.InsertOnSubmit(collection);
                dc.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        [Authorize(Roles = "admin")]
        // GET: LandRegistry/Edit/5
        public ActionResult Edit(int id)
        {
            var getLandRegistryDetails = dc.LandRegistry.Single(x => x.Id == id);
            return View(getLandRegistryDetails);
        }

        // POST: LandRegistry/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, LandRegistry collection)
        {
            try
            {
                // TODO: Add update logic here
                LandRegistry landRegistry = dc.LandRegistry.Single(x => x.Id == id);
                landRegistry.Passport = collection.Passport;
                landRegistry.Price = collection.Price;
                landRegistry.Address = collection.Address;
                landRegistry.ApprovalDate = collection.ApprovalDate;
                landRegistry.Area = collection.Area;
                landRegistry.Tax_coefficint = collection.Tax_coefficint;
                dc.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: LandRegistry/Delete/5
        [Authorize(Roles = "admin")]
        public ActionResult Delete(int id)
        {
            var getLandRegistryDetails = dc.LandRegistry.Single(x => x.Id == id);
            return View(getLandRegistryDetails);
        }

        // POST: LandRegistry/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, LandRegistry collection)
        {
            try
            {
                // TODO: Add delete logic here
                var landRegistryDelete = dc.LandRegistry.Single(x => x.Id == id);
                dc.LandRegistry.DeleteOnSubmit(landRegistryDelete);
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
