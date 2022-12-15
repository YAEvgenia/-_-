using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CadastreManagment.Controllers
{
    public class DirectoryController : Controller
    {
        DataClasses1DataContext dc = new DataClasses1DataContext();

        // GET: Directory
        public ActionResult Index()
        {

            var directoriDetails = from x in dc.Directory select x;
            return View(directoriDetails);
        }

        // GET: Directory/Details/5
        public ActionResult Details(string type)
        {
            var getDirectoryDetails = dc.Directory.Single(x => x.Type == type);
            return View(getDirectoryDetails);
        }

        // GET: Directory/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Directory/Create
        [HttpPost]
        public ActionResult Create(Directory collection)
        {
            try
            {
                // TODO: Add insert logic here

                dc.Directory.InsertOnSubmit(collection);
                dc.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Directory/Edit/5
        public ActionResult Edit(string type)
        {
            var getDirectoryDetails = dc.Directory.Single(x => x.Type == type);
            return View(getDirectoryDetails);
        }

        // POST: Directory/Edit/5
        [HttpPost]
        public ActionResult Edit(string type, Directory collection)
        {
            try
            {
                // TODO: Add update logic here

                Directory directory = dc.Directory.Single(x => x.Type == type);
                directory.Type = collection.Type;
                directory.Notes = collection.Notes;
                dc.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Directory/Delete/5
        public ActionResult Delete(string type)
        {
            var getDirectoryDetails = dc.Directory.Single(x => x.Type == type);
            return View(getDirectoryDetails);
        }

        // POST: Directory/Delete/5
        [HttpPost]
        public ActionResult Delete(string type, Directory collection)
        {
            try
            {
                // TODO: Add delete logic here

                var directoryDelete = dc.Directory.Single(x => x.Type == type);
                dc.Directory.DeleteOnSubmit(directoryDelete);
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
