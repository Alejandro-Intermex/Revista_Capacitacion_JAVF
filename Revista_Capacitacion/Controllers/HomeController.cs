using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Revista_Capacitacion.Controllers
{
    public class HomeController : Controller
    {
        CAPACITACIONEntities5 _context = new CAPACITACIONEntities5();
        public ActionResult Index()
        {
            var listofData = _context.Employees.ToList();
            return View(listofData);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(REVISTAS model)
        {
            _context.Employees.Add(model);
            _context.SaveChanges();
            ViewBag.Message = "Data Insert Successfully";
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var data = _context.Employees.Where(x => x.EmployeeId == id).FirstOrDefault();
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(REVISTAS Model)
        {
            var data = _context.Employees.Where(x => x.EmployeeId == Model.ID_REV).FirstOrDefault();
            if (data != null)
            {
                data.EmployeeCity = Model.TITULO_REV;
                data.EmployeeName = Model.CB;
                data.EmployeeSalary = Model.FECHA_CIRCULACION;
                data.Employeeidcat = Model.ID_CAT;
                data.Employeerow = Model.ROW_CREATE;
                data.Employeeprecio = Model.PRECIO;
                _context.SaveChanges();
            }

            return RedirectToAction("index");
        }
        public ActionResult Delete(int id)
        {
            var data = _context.Employees.Where(x => x.EmployeeId == id).FirstOrDefault();
            _context.Employees.Remove(data);
            _context.SaveChanges();
            ViewBag.Messsage = "Record Delete Successfully";
            return RedirectToAction("index");
        }
        public ActionResult Detail(int id)
        {
            var data = _context.Employees.Where(x => x.EmployeeId == id).FirstOrDefault();
            return View(data);
        }

    }
}