using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GreenElectric.Negocio.Backup;
using GreenElectric.EE.Servicios.Backup;

namespace GreenElectric.IU.Controllers
{
    public class BackupController : Controller
    {
        // GET: Backup
        public ActionResult Index()
        {
            BackupsBE backupsBE = new BackupsBE();
            return View(backupsBE.Read());
        }

        // GET: Backup/Details/5
        public ActionResult Details(int id)
        {

            BackupsBE backupsBE = new BackupsBE();
            return View(backupsBE.ReadBy(id));
        }

        // GET: Backup/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Backup/Create
        [HttpPost]
        public ActionResult Create(FormCollection form)
        {
            try
            {
                BackupsBE backupsBE = new BackupsBE();
                Backup backup = new Backup();
                backup.fecha = DateTime.Now;
                backup.Path = @"C:\Backup\Backup_" + DateTime.Now ;
                backupsBE.Create(backup);
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                return View();
            }
        }
        // GET: Backup/Edit/5
        public ActionResult Error(int id)
        {
            BackupsBE backupsBE = new BackupsBE();
            return View(backupsBE.ReadBy(id));


        }
        // GET: Backup/Edit/5
        public ActionResult Restaurar(int id)
        {
            BackupsBE backupsBE = new BackupsBE();
            return View(backupsBE.ReadBy(id));

          
        }

        // POST: Backup/Edit/5
        [HttpPost]
        public ActionResult Restaurar(int id, FormCollection collection)
        {
            try
            {   BackupsBE backupsBE = new BackupsBE();

                if (backupsBE.RestaurarBackup(id))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Error");
                }

                // TODO: Add update logic here

               
            }
            catch
            {
                return View();
            }
        }

       

        // GET: Backup/Delete/5
        public ActionResult Delete(int id)
        {

            BackupsBE backupsBE = new BackupsBE();
            return View(backupsBE.ReadBy(id));
        }

        // POST: Backup/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                BackupsBE backupsBE = new BackupsBE();
                backupsBE.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
