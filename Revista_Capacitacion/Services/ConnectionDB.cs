using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Threading.Tasks;

namespace Revista_Capacitacion.Services
{
    public class ConnectionDB
    {
        private SqlConnection conec;

        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["getconn"].ToString();
            conec = new SqlConnection(constr);
        }
        public bool Create(REVISTAS obj)
        {
            connection();
            SqlCommand com = new SqlCommand("SpCrudRevista", conec);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@TITULO_REV", obj.TITULO_REV);
            com.Parameters.AddWithValue("@CB", obj.CB);
            com.Parameters.AddWithValue("@FECHA_CIRCULACION", obj.FECHA_CIRCULACION);
            com.Parameters.AddWithValue("@ID_CAT", obj.ID_CAT);
            com.Parameters.AddWithValue("@PRECIO", obj.PRECIO);
            com.Parameters.AddWithValue("@Accion", "Insertar");
            conec.Open();
            int i = com.ExecuteNonQuery();
            conec.Close();
            if (i >= 1)
            {

                return true;

            }
            else
            {

                return false;
            }

        }
        public List<REVISTAS> Index()
        {
            connection();
            List<REVISTAS> EmpList = new List<REVISTAS>();
            SqlCommand com = new SqlCommand("SpCrudRevista", conec);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            com.Parameters.AddWithValue("@Accion", "tabla");
            conec.Open();
            da.Fill(dt);
            conec.Close();

            EmpList = (from DataRow dr in dt.Rows
                       select new REVISTAS()
                       {
                           ID_REV = Convert.ToInt32(dr["ID_REV"]),
                           TITULO_REV = Convert.ToString(dr["TITULO_REV"]),
                           CB = Convert.ToString(dr["CB"]),
                           FECHA_CIRCULACION = Convert.ToDateTime(dr["FECHA_CIRCULACION"]),
                           ID_CAT = Convert.ToInt32(dr["ID_CAT"]),
                           PRECIO = Convert.ToDouble(dr["PRECIO"]),
                           ROW_CREATE = Convert.ToDateTime(dr["ROW_CREATE"])
                       }).ToList();

            return EmpList;
        }
        //TITULO = Convert.IsDBNull(dr["TITULO"]) ? "" : Convert.ToString(dr["TITULO"]),

        public bool Edit(REVISTAS obj)
        {
            connection();
            SqlCommand com = new SqlCommand("SpCrudRevista", conec);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@ID_REV", obj.ID_REV);
            com.Parameters.AddWithValue("@TITULO_REV", obj.TITULO_REV);
            com.Parameters.AddWithValue("@CB", obj.CB);
            com.Parameters.AddWithValue("@FECHA_CIRCULACION", obj.FECHA_CIRCULACION);
            com.Parameters.AddWithValue("@ID_CAT", obj.ID_CAT);
            com.Parameters.AddWithValue("@PRECIO", obj.PRECIO);
            com.Parameters.AddWithValue("@Accion", "Editar");
            conec.Open();
            int i = com.ExecuteNonQuery();
            conec.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<REVISTAS> View(int id)
        {
            connection();
            List<REVISTAS> EmpList2 = new List<REVISTAS>();
            SqlCommand con = new SqlCommand("SpCrudRevista", conec);
            con.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(con);
            DataTable dt = new DataTable();
            con.Parameters.AddWithValue("@ID_REV", id);
            con.Parameters.AddWithValue("@Accion", "Editar2");
            conec.Open();
            da.Fill(dt);
            conec.Close();

            EmpList2 = (from DataRow dr in dt.Rows
                        select new REVISTAS()
                        {
                            ID_REV = Convert.ToInt32(dr["ID_REV"]),
                            TITULO_REV = Convert.ToString(dr["TITULO_REV"]),
                            CB = Convert.ToString(dr["CB"]),
                            FECHA_CIRCULACION = Convert.ToDateTime(dr["FECHA_CIRCULACION"]),
                            ID_CAT = Convert.ToInt32(dr["ID_CAT"]),
                            PRECIO = Convert.ToDouble(dr["PRECIO"]),
                            ROW_CREATE = Convert.ToDateTime(dr["ROW_CREATE"])
                        }).ToList();

            return EmpList2;
        }

        public bool Delete(int id)
        {
            connection();
            SqlCommand com = new SqlCommand("SpCrudRevista", conec);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@ID_REV", id);
            com.Parameters.AddWithValue("@Accion", "Eliminar");
            conec.Open();
            int i = com.ExecuteNonQuery();
            conec.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
