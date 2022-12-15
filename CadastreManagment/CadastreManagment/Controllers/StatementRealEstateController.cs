using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CadastreManagment.Controllers
{
    public class StatementRealEstateController : Controller
    {
        DataClasses1DataContext dc = new DataClasses1DataContext();

        // GET: StatementRealEstate
        public ActionResult Index()
        {
            var statementDetails = from x in dc.StatementRealEstate select x;
            return View(statementDetails);
        }

        // GET: StatementRealEstate/Details/5
        public ActionResult Details(int id)
        {
            var statementDetails = dc.StatementRealEstate.Single(x => x.Id == id);
            return View(statementDetails);
        }

        public ActionResult IndexId(string userId)
        {
            List<StatementRealEstate> statementRealEstateDetails = new List<StatementRealEstate>();
            statementRealEstateDetails = dc.StatementRealEstate.Where(x => x.Passport == userId).ToList();
            return View(statementRealEstateDetails);
        }

        // GET: StatementRealEstate/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StatementRealEstate/Create
        [HttpPost]
        public ActionResult Create(StatementRealEstate collection)
        {
            try
            {
                // TODO: Add insert logic here
                collection.Status = "Обрабатывается";
                dc.StatementRealEstate.InsertOnSubmit(collection);
                dc.SubmitChanges();
                return RedirectToAction("Index","Home");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult CreateRealEstate(int id, StatementRealEstate collection)
        {

            // TODO: Add insert logic here


            RealEstateCadastre statementRealEstate = new RealEstateCadastre();
            StatementRealEstate statement = dc.StatementRealEstate.Single(x => x.Id == id);
            statementRealEstate.Area = statement.Area;
            statementRealEstate.Address = statement.Address;
            statementRealEstate.Approval_Date = DateTime.Today;
            statementRealEstate.Passport = statement.Passport;
            statementRealEstate.Type = statement.Type;
            statementRealEstate.Readiness = statement.Readiness;
            statementRealEstate.Appointment = statement.Appointment;
            statementRealEstate.Floors = statement.Floors;
            const double V = 0.2;
            statementRealEstate.Tax_coefficint = (float)V;
            dc.RealEstateCadastre.InsertOnSubmit(statementRealEstate);
            statement.Status = "Одобрено";
            dc.SubmitChanges();
            return RedirectToAction("Index");

        }

        public ActionResult RefuseRealEstate(int id, StatementRealEstate collection)
        {

            // TODO: Add insert logic here

            StatementRealEstate statement = dc.StatementRealEstate.Single(x => x.Id == id);
            statement.Status = "Отказано";
            dc.SubmitChanges();
            return RedirectToAction("Index");

        }

        // GET: StatementRealEstate/Edit/5
        public ActionResult Edit(int id)
        {
            var getStatementDetails = dc.StatementRealEstate.Single(x => x.Id == id);
            return View(getStatementDetails);
        }

        // POST: StatementRealEstate/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, StatementRealEstate collection)
        {
            try
            {
                // TODO: Add update logic here

                StatementRealEstate statement = dc.StatementRealEstate.Single(x => x.Id == id);
                statement.Status = collection.Status;
                statement.Type = collection.Type;
                statement.Area = collection.Area;
                statement.Address = collection.Address;
                statement.Passport = collection.Passport;
                statement.Readiness = collection.Readiness;
                statement.Appointment = collection.Appointment;
                statement.Floors = collection.Floors;

                dc.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: StatementRealEstate/Delete/5
        public ActionResult Delete(int id)
        {
            var getStatementDetails = dc.StatementRealEstate.Single(x => x.Id == id);
            return View(getStatementDetails);
        }

        // POST: StatementRealEstate/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                var statementDelete = dc.StatementRealEstate.Single(x => x.Id == id);
                dc.StatementRealEstate.DeleteOnSubmit(statementDelete);
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
