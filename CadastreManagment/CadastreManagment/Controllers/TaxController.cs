using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CadastreManagment.Controllers
{
    public class TaxController : Controller
    {
        DataClasses1DataContext dc = new DataClasses1DataContext();

        // GET: Tax
        public ActionResult Index()
        {
            var taxDetails = from x in dc.Tax select x;
            return View(taxDetails);
        }
        [Authorize(Roles = "user")]
        public ActionResult IndexId(int cadastreId, string cadastreType)
        {
            List<Tax> taxDetails = new List<Tax>();
            taxDetails = dc.Tax.Where(x =>  x.Cadastre_id == cadastreId && x.Cadastre_type == cadastreType).ToList();
            return View(taxDetails);
        }

       


        // GET: Tax/Details/5
        public ActionResult Details(int id)
        {
            var getTaxDetails = dc.Tax.Single(x => x.Id == id);
            return View(getTaxDetails);
        }
        [Authorize(Roles = "admin")]
        // GET: Tax/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tax/Create
        [HttpPost]
        public ActionResult Create(Tax collection)
        {
            try
            {
                // TODO: Add insert logic here

                dc.Tax.InsertOnSubmit(collection);
                dc.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        [Authorize(Roles = "admin")]
        // GET: Tax/Edit/5
        public ActionResult Edit(int id)
        {
            var getTaxDetails = dc.Tax.Single(x => x.Id == id);
            return View(getTaxDetails);
        }

        // POST: Tax/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Tax collection)
        {
            try
            {
                // TODO: Add update logic here

                Tax tax = dc.Tax.Single(x => x.Id == id);
                tax.Price = collection.Price;
                tax.Date_of_creation = collection.Date_of_creation;
                tax.Payment_date = collection.Payment_date;
                tax.Cadastre_type = collection.Cadastre_type;
                tax.Cadastre_id = collection.Cadastre_id;

                dc.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        [Authorize(Roles = "admin")]
        // GET: Tax/Delete/5
        public ActionResult Delete(int id)
        {
            var getTaxDetails = dc.Tax.Single(x => x.Id == id);
            return View(getTaxDetails);
        }

        // POST: Tax/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Tax collection)
        {
            try
            {
                // TODO: Add delete logic here

                var taxDelete = dc.Tax.Single(x => x.Id == id);
                dc.Tax.DeleteOnSubmit(taxDelete);
                dc.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        [Authorize(Roles = "user")]
        public ActionResult EditPaymentDate(int id)
        {
            var getTaxDetails = dc.Tax.Single(x => x.Id == id);
            return View(getTaxDetails);
        }

        // POST: Tax/Edit/5
        [HttpPost]
        public ActionResult EditPaymentDate(int id, Tax collection)
        {
            try
            {
                // TODO: Add update logic here

                Tax tax = dc.Tax.Single(x => x.Id == id);
                tax.Price = collection.Price;
                tax.Date_of_creation = collection.Date_of_creation;
                tax.Payment_date = DateTime.Today;
                tax.Cadastre_type = collection.Cadastre_type;
                tax.Cadastre_id = collection.Cadastre_id;

                dc.SubmitChanges();
                return RedirectToAction("Index","Home");
            }
            catch
            {
                return View();
            }
        }
    }
}
