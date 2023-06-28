
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
            //ConnectionDB showlist = new ConnectionDB();
            //ModelState.Clear();
            //return View(showlist.Index());
            return View();
        }

        public JsonResult getRevistas()
        {
            ConnectionDB showlist = new ConnectionDB();
            ModelState.Clear();
            return Json(showlist.Index(), JsonRequestBehavior.AllowGet);
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
        public JsonResult Edit(int Id = 0)
        {
            ConnectionDB emprepo = new ConnectionDB();

            return Json(emprepo.View(Id)[0], JsonRequestBehavior.AllowGet);
        }
        [HttpPost]

        public ActionResult Edit2(REVISTAS obj)
        {
            try
            {
                ConnectionDB emprepo = new ConnectionDB();
                emprepo.Edit(obj);
                //return View(emprepo.Index().Find(model => model.ID_REV == ob));
                return View("Index", emprepo);
            }
            catch
            {
                return View();
            }
        }
        [HttpGet]
        public JsonResult Delete(int Id)
        {
            ConnectionDB cnx = new ConnectionDB();

            return Json(cnx.Delete(Id), JsonRequestBehavior.AllowGet);
        }
    }
}