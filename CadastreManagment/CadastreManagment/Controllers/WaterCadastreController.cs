using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CadastreManagment.Controllers
{
    public class WaterCadastreController : Controller
    {
        DataClasses1DataContext dc = new DataClasses1DataContext();

        // GET: WaterCadastre
        public ActionResult Index()
        {
            var waterCadastreDetails = from x in dc.WaterCadastre select x;

            return View(waterCadastreDetails);
        }

        // GET: WaterCadastre/Details/5
        public ActionResult Details(int id)
        {
            var getWaterCadastreDetails = dc.WaterCadastre.Single(x => x.Id == id);
            return View(getWaterCadastreDetails);
        }
        [Authorize(Roles = "user")]
        public ActionResult IndexId(string userId)
        {
            List<WaterCadastre> waterDetails = new List<WaterCadastre>();
            waterDetails = dc.WaterCadastre.Where(x => x.Passport == userId).ToList();
            return View(waterDetails);
        }
        [Authorize(Roles = "admin")]
        // GET: WaterCadastre/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WaterCadastre/Create
        [HttpPost]
        public ActionResult Create(WaterCadastre collection)
        {
            try
            {
                // TODO: Add insert logic here
                dc.WaterCadastre.InsertOnSubmit(collection);
                dc.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        [Authorize(Roles = "admin")]
        // GET: WaterCadastre/Edit/5
        public ActionResult Edit(int id)
        {
            var getWaterCadastreDetails = dc.WaterCadastre.Single(x => x.Id == id);
            return View(getWaterCadastreDetails);
        }

        // POST: WaterCadastre/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, WaterCadastre collection)
        {
            try
            {
                // TODO: Add update logic here
                WaterCadastre waterCadastre = dc.WaterCadastre.Single(x => x.Id == id);
                waterCadastre.Passport = collection.Passport;
                waterCadastre.Type = collection.Type;
                waterCadastre.Area = collection.Area;
                waterCadastre.Address = collection.Address;
                waterCadastre.Approval_date = collection.Approval_date;
                waterCadastre.Tax_coefficint = collection.Tax_coefficint;
                waterCadastre.Water_management_facilities = collection.Water_management_facilities;
                waterCadastre.Water_quality = collection.Water_quality;
                dc.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        [Authorize(Roles = "admin")]
        // GET: WaterCadastre/Delete/5
        public ActionResult Delete(int id)
        {
            var getWaterCadastreDetails = dc.WaterCadastre.Single(x => x.Id == id);
            return View(getWaterCadastreDetails);
        }

        // POST: WaterCadastre/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, WaterCadastre collection)
        {
            try
            {
                // TODO: Add delete logic here
                var waterCadastre = dc.WaterCadastre.Single(x => x.Id == id);
                dc.WaterCadastre.DeleteOnSubmit(waterCadastre);
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
