using GreenElectric.EE.Servicios.Permisos;
using GreenElectric.Negocio.Permisos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace GreenElectric.IU.Controllers
{
    public class FamiliaController : Controller
    {
        // GET: Familia
        public ActionResult Index()
        {
            FamiliaBE familiaBE = new FamiliaBE();
            return View(familiaBE.Read());
        }

        // GET: Familia/Details/5
        public ActionResult Details(int id)
        {
            FamiliaBE familiaBE = new FamiliaBE();
            Familia familia = new Familia();
            familia = familiaBE.ReadBy(id);
            familiaBE.ObtenerTodosLosPermisos(familia);
           
          
           
            return View(familia);
        }

        // GET: Familia/Create
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult AgregarFamilia()
        {
            List<SelectListItem> lst = new List<SelectListItem>();

            lst.Add(new SelectListItem() { Text = "Auditor", Value = "1" });
            lst.Add(new SelectListItem() { Text = "Tecnico", Value = "2" });
            
            ViewBag.Roles = lst;
            List<SelectListItem> lst2 = new List<SelectListItem>();

            lst2.Add(new SelectListItem() { Text = "Ventas", Value = "1" });
            lst2.Add(new SelectListItem() { Text = "Backup", Value = "2" });

            ViewBag.Permisos = lst2;

            return View();
        }
        // POST: Familia/Create
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

        // GET: Familia/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Familia/Edit/5
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

        // GET: Familia/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Familia/Delete/5
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
