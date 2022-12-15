using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CadastreManagment.Controllers
{
    public class StatementMineralsController : Controller
    {
        DataClasses1DataContext dc = new DataClasses1DataContext();

        // GET: StatementMinerals
        public ActionResult Index()
        {
            var statementDetails = from x in dc.StatementMinerals select x;
            return View(statementDetails);
        }

        // GET: StatementMinerals/Details/5
        public ActionResult Details(int id)
        {
            var statementDetails = dc.StatementMinerals.Single(x => x.Id == id);
            return View(statementDetails);
        }

        public ActionResult IndexId(string userId)
        {
            List<StatementMinerals> statementMineralsDetails = new List<StatementMinerals>();
            statementMineralsDetails = dc.StatementMinerals.Where(x => x.Passport == userId).ToList();
            return View(statementMineralsDetails);
        }

        // GET: StatementMinerals/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StatementMinerals/Create
        [HttpPost]
        public ActionResult Create(StatementMinerals collection)
        {
            try
            {
                // TODO: Add insert logic here
                collection.Status = "Обрабатывается";
                dc.StatementMinerals.InsertOnSubmit(collection);
                dc.SubmitChanges();
                return RedirectToAction("Index","Home");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult CreateLand(int id, StatementMinerals collection)
        {

            // TODO: Add insert logic here


            Minerals minerals = new Minerals();
            StatementMinerals statement = dc.StatementMinerals.Single(x => x.Id == id);
            minerals.Type = statement.Type;
            minerals.Address = statement.Address;
            minerals.Price = statement.Price;
            minerals.Approval_date = DateTime.Today;
            minerals.Amount = statement.Amount;
            minerals.Passport = statement.Passport;
            const double V = 0.2;
            minerals.Tax_coefficint = (float)V;
            dc.Minerals.InsertOnSubmit(minerals);
            statement.Status = "Одобрено";
            dc.SubmitChanges();
            return RedirectToAction("Index");

        }

        public ActionResult RefusalLand(int id, Minerals collection)
        {

            // TODO: Add insert logic here

            StatementMinerals statement = dc.StatementMinerals.Single(x => x.Id == id);
            statement.Status = "Отказано";
            dc.SubmitChanges();
            return RedirectToAction("Index");

        }

        // GET: StatementMinerals/Edit/5
        public ActionResult Edit(int id)
        {
            var getStatementDetails = dc.StatementMinerals.Single(x => x.Id == id);
            return View(getStatementDetails);
        }

        // POST: StatementMinerals/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, StatementMinerals collection)
        {
            try
            {
                // TODO: Add update logic here

                StatementMinerals statement = dc.StatementMinerals.Single(x => x.Id == id);
                statement.Status = collection.Status;
                statement.Type = collection.Type;
                statement.Address = collection.Address;
                statement.Passport = collection.Passport;
                statement.Price = collection.Price;
                statement.Amount = collection.Amount;

                dc.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: StatementMinerals/Delete/5
        public ActionResult Delete(int id)
        {
            var getStatementDetails = dc.StatementMinerals.Single(x => x.Id == id);
            return View(getStatementDetails);
        }

        // POST: StatementMinerals/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, StatementMinerals collection)
        {
            try
            {
                // TODO: Add delete logic here

                var statementDelete = dc.StatementMinerals.Single(x => x.Id == id);
                dc.StatementMinerals.DeleteOnSubmit(statementDelete);
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
