using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CadastreManagment.Controllers
{
    public class RealEstateCadastreController : Controller
    {
        DataClasses1DataContext dc = new DataClasses1DataContext();
        // GET: RealEstateCadastre
        public ActionResult Index()
        {
            var realEstateCadastreDetails = from x in dc.RealEstateCadastre select x;
            return View(realEstateCadastreDetails);
        }
        [Authorize(Roles = "user")]
        public ActionResult IndexId(string userId)
        {
            List<RealEstateCadastre> realEstateCadastreDetails = new List<RealEstateCadastre>();
            realEstateCadastreDetails = dc.RealEstateCadastre.Where(x => x.Passport == userId).ToList();
            return View(realEstateCadastreDetails);
        }


        // GET: RealEstateCadastre/Details/5
        public ActionResult Details(int id)
        {
            var getRealEstateCadastreDetails = dc.RealEstateCadastre.Single(x => x.Id == id);
            return View(getRealEstateCadastreDetails);
        }
        [Authorize(Roles = "admin")]
        // GET: RealEstateCadastre/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RealEstateCadastre/Create
        [HttpPost]
        public ActionResult Create(RealEstateCadastre collection)
        {
            try
            {
                // TODO: Add insert logic here
                dc.RealEstateCadastre.InsertOnSubmit(collection);
                dc.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        [Authorize(Roles = "admin")]
        // GET: RealEstateCadastre/Edit/5
        public ActionResult Edit(int id)
        {
            var getRealEstateCadastreDetails = dc.RealEstateCadastre.Single(x => x.Id == id);
            return View(getRealEstateCadastreDetails);
        }

        // POST: RealEstateCadastre/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, RealEstateCadastre collection)
        {
            try
            {
                // TODO: Add update logic here
                RealEstateCadastre realEstateCadastre = dc.RealEstateCadastre.Single(x => x.Id == id);
                realEstateCadastre.Passport = collection.Passport;
                realEstateCadastre.Readiness = collection.Readiness;
                realEstateCadastre.Type = collection.Type;

                realEstateCadastre.Notes = collection.Notes;
                realEstateCadastre.Tax_coefficint = collection.Tax_coefficint;
                realEstateCadastre.Area = collection.Area;
                realEstateCadastre.Address = collection.Address;
                realEstateCadastre.Appointment = collection.Appointment;
                realEstateCadastre.Floors = collection.Floors;
                realEstateCadastre.Approval_Date = collection.Approval_Date;
                dc.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        [Authorize(Roles = "admin")]
        // GET: RealEstateCadastre/Delete/5
        public ActionResult Delete(int id)
        {
            var getRealEstateCadastreDetails = dc.RealEstateCadastre.Single(x => x.Id == id);
            return View(getRealEstateCadastreDetails);
        }

        // POST: RealEstateCadastre/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, RealEstateCadastre collection)
        {
            try
            {
                // TODO: Add delete logic here
                var realEstateCadastre = dc.RealEstateCadastre.Single(x => x.Id == id);
                dc.RealEstateCadastre.DeleteOnSubmit(realEstateCadastre);
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
