using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GreenElectric.EE.Servicios.Bitacora;
using GreenElectric.EE.Servicios.Login;
using GreenElectric.Negocio.Bitacoras;
using GreenElectric.Negocio.Login;

namespace GreenElectric.IU.Controllers
{
    public class BitacoraController : Controller
    {
        // GET: Bitacora
        public ActionResult Index()
        {
            try
            {
                BitacoraBE bitacoraBE = new BitacoraBE();


                return View(bitacoraBE.Read());
            }
            catch (Exception e)
            {

                throw;
            }
          
        }
        public ActionResult Usuario()
        {
            BitacoraBE bitacoraBE  = new BitacoraBE();
            Bitacora bitacoras = new Bitacora();
            
            UsuarioBe usuarioBe = new UsuarioBe();
            EventoBitacoraBE eventoBitacoraBE = new EventoBitacoraBE();
            bitacoras.bitacoras = bitacoraBE.Read();
            bitacoras.usuarios = usuarioBe.Read();
            bitacoras.eventoBitacoras = eventoBitacoraBE.Read();
            bitacoras.usuarios.Select(y =>
                                new
                                {
                                    Id = y.Id,
                                    NombreUsuario = y.nombreUsuario
                                });

            ViewBag.usuariosLista = new SelectList(bitacoras.usuarios, "Id", "NombreUsuario");




            return View(bitacoras.bitacoras);
        }
        public ActionResult Evento()
        {
            BitacoraBE bitacoraBE = new BitacoraBE();
            Bitacora bitacoras = new Bitacora();

            UsuarioBe usuarioBe = new UsuarioBe();
            EventoBitacoraBE eventoBitacoraBE = new EventoBitacoraBE();


            bitacoras.bitacoras = bitacoraBE.Read();
     
            bitacoras.eventoBitacoras = eventoBitacoraBE.Read();
            bitacoras.eventoBitacoras.Select(y =>
                                new
                                {
                                    Id = y.Id,
                                    eventoBitacora = y.eventoBitacora
                                });

            ViewBag.BitacorasLista = new SelectList(bitacoras.eventoBitacoras, "Id", "eventoBitacora");




            return View(bitacoras.bitacoras);
        }
        // GET: Bitacora/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Bitacora/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bitacora/Create
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

        // GET: Bitacora/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Bitacora/Edit/5
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

        // GET: Bitacora/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Bitacora/Delete/5
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
