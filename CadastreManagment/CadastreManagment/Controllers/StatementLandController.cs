using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CadastreManagment.Controllers
{
    public class StatementLandController : Controller
    {
        DataClasses1DataContext dc = new DataClasses1DataContext();

        // GET: StatementLand
        public ActionResult Index()
        {
            List<StatementLand> statementDetails = new List<StatementLand>();
            statementDetails = dc.StatementLand.Where(x => x.Status == "Обрабатывается").ToList();
            return View(statementDetails);
        }

        // GET: StatementLand/Details/5
        public ActionResult Details(int id)
        {
            var statementDetails = dc.StatementLand.Single(x => x.Id == id);
            return View(statementDetails);
        }

        public ActionResult IndexId(string userId)
        {
            List<StatementLand> statementLandDetails = new List<StatementLand>();
            statementLandDetails = dc.StatementLand.Where(x => x.Passport == userId).ToList();
            return View(statementLandDetails);
        }

        // GET: StatementLand/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StatementLand/Create
        [HttpPost]
        public ActionResult Create(StatementLand collection)
        {
            try
            {
                // TODO: Add insert logic here
                collection.Status = "Обрабатывается";
                dc.StatementLand.InsertOnSubmit(collection);

                dc.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        

        public ActionResult CreateLand(int id, StatementLand collection)
        {
            
                // TODO: Add insert logic here

                
                LandRegistry statementLand =  new LandRegistry();
                StatementLand statement = dc.StatementLand.Single(x => x.Id == id);
                statementLand.Area = statement.Area;
                statementLand.Address = statement.Address;
                statementLand.Price = statement.Price;
                statementLand.ApprovalDate = DateTime.Today;
                statementLand.Passport = statement.Passport;
                const double V = 0.2;
                statementLand.Tax_coefficint =(float) V;
                dc.LandRegistry.InsertOnSubmit(statementLand);
                statement.Status = "Одобрено";
                dc.SubmitChanges();
                return RedirectToAction("Index", "Home");
            
        }

        public ActionResult RefusalLand(int id, StatementLand collection)
        {

            // TODO: Add insert logic here

            StatementLand statement = dc.StatementLand.Single(x => x.Id == id);
            statement.Status = "Отказано";
            dc.SubmitChanges();
            return RedirectToAction("Index");

        }

        // GET: StatementLand/Edit/5
        public ActionResult Edit(int id)
        {
            var getStatementDetails = dc.StatementLand.Single(x => x.Id == id);
            return View(getStatementDetails);
        }

        // POST: StatementLand/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, StatementLand collection)
        {
            try
            {
                // TODO: Add update logic here

                StatementLand statementLand = dc.StatementLand.Single(x => x.Id == id);
                statementLand.Status = collection.Status;
                statementLand.Area = collection.Area;
                statementLand.Address = collection.Address;
                statementLand.Price = collection.Price;
                statementLand.Passport = collection.Passport;

                dc.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: StatementLand/Delete/5
        public ActionResult Delete(int id)
        {
            var getStatementDetails = dc.StatementLand.Single(x => x.Id == id);
            return View(getStatementDetails);
        }

        // POST: StatementLand/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, StatementLand collection)
        {
            try
            {
                // TODO: Add delete logic here

                var statementDelete = dc.StatementLand.Single(x => x.Id == id);
                dc.StatementLand.DeleteOnSubmit(statementDelete);
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
