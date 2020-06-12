using GreenElectric.Negocio.Permisos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GreenElectric.IU.Controllers
{
    public class PatenteController : Controller
    {
        // GET: Patente
        public ActionResult Index()
        {
            PatenteBE patenteBE = new PatenteBE();
            return View(patenteBE.Read());
        }

        // GET: Patente/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        // GET: Patente/Details/5
        public ActionResult Error(int id)
        {
            PatenteBE patenteBE = new PatenteBE();
            return View(patenteBE.ReadBy(id));
        }

        // GET: Patente/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: Patente/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Patente/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Patente/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Patente/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Patente/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
