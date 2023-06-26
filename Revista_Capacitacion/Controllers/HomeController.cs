
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Revista_Capacitacion.Services
{
    public class HomeController : Controller
    {

        ConnectionDB revDB = new ConnectionDB();

        // CAPACITACIONEntities7 _context = new CAPACITACIONEntities7();
        ////[HttpGet]
        public ActionResult Index()
        {
            ConnectionDB showlist = new ConnectionDB();
            ModelState.Clear();
            return View(showlist.Index());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }


        public bool Create2(REVISTAS model)
        {
            ConnectionDB cnx = new ConnectionDB();
            bool bandera = cnx.Create(model);
            return bandera;
        }

        [HttpGet]
        public ActionResult Edit(int id = 0)
        {
            ConnectionDB emprepo = new ConnectionDB();

            return View(emprepo.Index().Find(model => model.ID_REV == id));
        }
        [HttpPost]
        public ActionResult Edit(int id, REVISTAS obj)
        {
            try
            {
                ConnectionDB emprepo = new ConnectionDB();
                emprepo.Edit(obj);


                //return View(emprepo.Index().Find(model => model.ID_REV == id));E
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            try
            {
                ConnectionDB emprepo = new ConnectionDB();
                if (emprepo.Delete(id))
                {
                    ViewBag.AlertMsg = "Revista borrada";
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

    }
}