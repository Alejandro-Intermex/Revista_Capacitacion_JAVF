using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using DEMO01_CRUD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace DEMO01_CRUD.Controllers
{
    public class HomeController : Controller
    {
        public IConfiguration Configuration { get; }
        public HomeController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Crear(ClsRegistro ClsRegistro)
        {
            if (ModelState.IsValid)
            {
                string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string sql = $"Insert Into USUARIO(Usuario, Contrasena, Intentos, NivelSeg) Values('{clsUsuario.usuario}', '{clsUsuario.contrasena}', '{clsUsuario.intentos}', '{clsUsuario.nivelSeg}')";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.CommandType = CommandType.Text;

                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                    }
                    return RedirectToAction("Index");
                }
            }
            else
                return View();
        }
    }
}
