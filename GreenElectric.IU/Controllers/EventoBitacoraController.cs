using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GreenElectric.EE.Servicios.Bitacora;
using GreenElectric.Negocio.Bitacoras;

namespace GreenElectric.IU.Controllers
{
    public class EventoBitacoraController : Controller
    {
        // GET: EventoBitacora
        public ActionResult Index()
        {
            EventoBitacoraBE eventoBitacoraBE = new EventoBitacoraBE();
            
            return View(eventoBitacoraBE.Read());
        }

        // GET: EventoBitacora/Details/5
        public ActionResult Details(int id)
        {
            EventoBitacoraBE eventoBitacoraBE = new EventoBitacoraBE();
            return View(eventoBitacoraBE.ReadBy(id));
        }

        // GET: EventoBitacora/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EventoBitacora/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                  EventoBitacoraBE eventoBitacoraBE = new EventoBitacoraBE();
                // TODO: Add insert logic here
                EventoBitacora eventoBitacora = new EventoBitacora();
                eventoBitacora.eventoBitacora = collection.Get("eventoBitacora");
                eventoBitacoraBE.Create(eventoBitacora);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: EventoBitacora/Edit/5
        public ActionResult Edit(int id)
        {
            EventoBitacoraBE eventoBitacoraBE = new EventoBitacoraBE();
            return View(eventoBitacoraBE.ReadBy(id));
        }

        // POST: EventoBitacora/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                EventoBitacoraBE eventoBitacoraBE = new EventoBitacoraBE();
                EventoBitacora eventoBitacora = new EventoBitacora();
                eventoBitacora.Id = id;
                eventoBitacora.eventoBitacora = collection.Get("eventoBitacora");
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: EventoBitacora/Delete/5
        public ActionResult Delete(int id)
        {
            EventoBitacoraBE eventoBitacoraBE = new EventoBitacoraBE();
            return View(eventoBitacoraBE.ReadBy(id));
        }

        // POST: EventoBitacora/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                EventoBitacoraBE eventoBitacoraBE = new EventoBitacoraBE();
                eventoBitacoraBE.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
