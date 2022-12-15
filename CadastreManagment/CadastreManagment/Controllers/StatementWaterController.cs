using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CadastreManagment.Controllers
{
    public class StatementWaterController : Controller
    {
        DataClasses1DataContext dc = new DataClasses1DataContext();

        // GET: StatementWater
        public ActionResult Index()
        {
            var statementDetails = from x in dc.StatementWater select x;
            return View(statementDetails);
        }

        // GET: StatementWater/Details/5
        public ActionResult Details(int id)
        {
            var statementDetails = dc.StatementWater.Single(x => x.Id == id);
            return View(statementDetails);
        }

        public ActionResult IndexId(string userId)
        {
            List<StatementWater> statementWaterDetails = new List<StatementWater>();
            statementWaterDetails = dc.StatementWater.Where(x => x.Passport == userId).ToList();
            return View(statementWaterDetails);
        }

        // GET: StatementWater/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StatementWater/Create
        [HttpPost]
        public ActionResult Create(StatementWater collection)
        {
            try
            {
                // TODO: Add insert logic here
                collection.Status = "Обрабатывается";
                dc.StatementWater.InsertOnSubmit(collection);
                dc.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult CreateWater(int id, StatementWater collection)
        {

            // TODO: Add insert logic here


            WaterCadastre statementWater= new WaterCadastre();
            StatementWater statement = dc.StatementWater.Single(x => x.Id == id);
            statementWater.Area = statement.Area;
            statementWater.Address = statement.Address;
            statementWater.Type = statement.Type;
            statementWater.Approval_date = DateTime.Today;
            statementWater.Passport = statement.Passport;
            statementWater.Water_management_facilities = statement.Water_management_facilities;
            statementWater.Water_quality = statement.Water_quality;
            const double V = 0.2;
            statementWater.Tax_coefficint = (float)V;
            dc.WaterCadastre.InsertOnSubmit(statementWater);
            statement.Status = "Одобрено";
            dc.SubmitChanges();
            return RedirectToAction("Index");

        }

        public ActionResult RefusalWater(int id, StatementWater collection)
        {

            // TODO: Add insert logic here

            StatementWater statement = dc.StatementWater.Single(x => x.Id == id);
            statement.Status = "Отказано";
            dc.SubmitChanges();
            return RedirectToAction("Index");

        }

        // GET: StatementWater/Edit/5
        public ActionResult Edit(int id)
        {
            var getStatementDetails = dc.StatementWater.Single(x => x.Id == id);
            return View(getStatementDetails);
        }

        // POST: StatementWater/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, StatementWater collection)
        {
            try
            {
                // TODO: Add update logic here

                StatementWater statement = dc.StatementWater.Single(x => x.Id == id);
                statement.Status = collection.Status;
                statement.Type = collection.Type;
                statement.Area = collection.Area;
                statement.Address = collection.Address;
                statement.Passport = collection.Passport;
                statement.Water_quality = collection.Water_quality;
                statement.Water_management_facilities = collection.Water_management_facilities;

                dc.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: StatementWater/Delete/5
        public ActionResult Delete(int id)
        {
            var getStatementDetails = dc.StatementWater.Single(x => x.Id == id);
            return View(getStatementDetails);
        }

        // POST: StatementWater/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, StatementWater collection)
        {
            try
            {
                // TODO: Add delete logic here
                var statementDelete = dc.StatementWater.Single(x => x.Id == id);
                dc.StatementWater.DeleteOnSubmit(statementDelete);
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
