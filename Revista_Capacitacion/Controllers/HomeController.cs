
using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.IO;
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

        public JsonResult getEncabezado()
        {
            ConnectionDB showlist = new ConnectionDB();
            return Json(showlist.enca(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult GenerateReport()
        {
            ConnectionDB ds = new ConnectionDB();
            List<REVISTAS> array = new List<REVISTAS>();
            List<ENCABEZADO> array2 = new List<ENCABEZADO>();
            array = ds.Index();
            array2 = ds.enca();
            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/Reportes/REPORTE.rpt")));
            rd.Database.Tables[0].SetDataSource(
                array.Select(p => new
                {
                    ID_REV = p.ID_REV,
                    TITULO_REV = p.TITULO_REV,
                    CB = p.CB,
                    FECHA_CIRCULACION = p.FECHA_CIRCULACION,
                    ID_CAT = p.ID_CAT,
                    ROW_CREATE = p.ROW_CREATE,
                    PRECIO = p.PRECIO,
                })
            );
            rd.Database.Tables[1].SetDataSource(
                array2.Select(p => new
                {
                    NOMBRE_EMPRESA = p.NOMBRE_EMPRESA,
                    TITULO = p.TITULO,
                    CREADOR = p.CREADOR,
                })
            );

            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();
            try
            {
                Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                stream.Seek(0, SeekOrigin.Begin);
                //Imagen_Producto = stream;
                return File(stream, "aplication/pdf", "ReporteRevista.pdf");
            }
            catch (Exception)
            {
                //return null;
                throw;

            }
        }
    }
}