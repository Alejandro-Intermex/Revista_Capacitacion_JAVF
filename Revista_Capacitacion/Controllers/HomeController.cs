
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

        public JsonResult getCategorias()
        {
            ConnectionDB showlist = new ConnectionDB();
            return Json(showlist.catego(), JsonRequestBehavior.AllowGet);
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

        public JsonResult Create2(REVISTAS obj)
        {
            ConnectionDB cnx = new ConnectionDB();
            JsonResult result = Json(cnx.Create(obj), JsonRequestBehavior.AllowGet);
            return result;
        }

        //public bool Create2(REVISTAS model)
        //{
        //    ConnectionDB cnx = new ConnectionDB();
        //    bool bandera = cnx.Create(model);
        //    return bandera;
        //}

        [HttpGet]
        public JsonResult Edit(int ID_REV = 0)
        {
            ConnectionDB emprepo = new ConnectionDB();

            return Json(emprepo.View(ID_REV)[0], JsonRequestBehavior.AllowGet);
        }
        [HttpPost]

        public void Edit2(REVISTAS obj)
        {
            ConnectionDB emprepo = new ConnectionDB();
            emprepo.Edit(obj);
            //return View(emprepo.Index().Find(model => model.ID_REV == ob));
        }
        [HttpGet]
        public JsonResult Delete(int ID_REV)
        {
            ConnectionDB cnx = new ConnectionDB();

            return Json(cnx.Delete(ID_REV), JsonRequestBehavior.AllowGet);
        }
    }
}