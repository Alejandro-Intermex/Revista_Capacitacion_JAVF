
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Revista_Capacitacion.Controllers
{
    public class HomeController : Controller
    {
        CAPACITACIONEntities7 _context = new CAPACITACIONEntities7();
        public ActionResult Index()
        {
            var listofData = _context.REVISTAS.ToList();
            return View(listofData);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(REVISTA model)
        {
            _context.REVISTAS.Add(model);
            _context.SaveChanges();
            ViewBag.Message = "Data Insert Successfully";
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int ID_REV)
        {
            var data = _context.REVISTAS.Where(x => x.ID_REV == ID_REV).FirstOrDefault();
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(REVISTA Model)
        {
            var data = _context.REVISTAS.Where(x => x.ID_REV == Model.ID_REV).FirstOrDefault();
            if (data != null)
            {
                data.TITULO_REV = Model.TITULO_REV;
                data.CB = Model.CB;
                data.FECHA_CIRCULACION = Model.FECHA_CIRCULACION;
                data.ID_CAT = Model.ID_CAT;
                data.ROW_CREATE = Model.ROW_CREATE;
                data.PRECIO = Model.PRECIO;
                _context.SaveChanges();
            }

            return RedirectToAction("index");
        }
        public ActionResult Delete(int ID_REV)
        {
            var data = _context.REVISTAS.Where(x => x.ID_REV == ID_REV).FirstOrDefault();
            _context.REVISTAS.Remove(data);
            _context.SaveChanges();
            ViewBag.Messsage = "Record Delete Successfully";
            return RedirectToAction("index");
        }
        public ActionResult Details(int ID_REV)
        {
            var data = _context.REVISTAS.Where(x => x.ID_REV == ID_REV).FirstOrDefault();
            return View(data);
        }

    }
}