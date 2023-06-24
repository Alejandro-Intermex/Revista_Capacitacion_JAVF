﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Revista_Capacitacion.Services
{
    public class HomeController : Controller
    {
        // CAPACITACIONEntities7 _context = new CAPACITACIONEntities7();

        [HttpGet]
        public ActionResult ShowAllCustomerDetails()
        {
            ConnectionDB showlist = new ConnectionDB();
            ModelState.Clear();
            return View(showlist.ShowAllCustomerDetails());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(REVISTAS model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ConnectionDB emprepo = new ConnectionDB();
                    if (emprepo.Create(model))
                    {
                        ViewBag.message = "revista creada";
                    }
                }
                return View();
            }
            catch
            {
                return View();
            }
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            ConnectionDB emprepo = new ConnectionDB();

            return View(emprepo.ShowAllCustomerDetails().Find(model => model.ID_REV == id));
        }
        [HttpPost]
        public ActionResult Edit(int id, REVISTAS obj)
        {
            try
            {
                ConnectionDB emprepo = new ConnectionDB();
                emprepo.Edit(obj);

                return RedirectToAction("ShowAllCustomerDetails");
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
                return RedirectToAction("ShowAllCustomerDetails");
            }
            catch
            {
                return View();
            }
        }
    }
}