using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Revista_Capacitacion.Services
{
    public class ConnectionDB
    {
        private SqlConnection con;

        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["getconn"].ToString();
            con = new SqlConnection(constr);
        }
        public bool Create(REVISTAS obj)
        {
            connection();
            SqlCommand com = new SqlCommand("SpCrudRevista", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@titulo_rev", obj.TITULO_REV);
            com.Parameters.AddWithValue("@CB", obj.CB);
            com.Parameters.AddWithValue("@fecha_cir", obj.FECHA_CIRCULACION);
            com.Parameters.AddWithValue("@id_cat", obj.ID_CAT);
            com.Parameters.AddWithValue("@row_create", obj.ROW_CREATE);
            com.Parameters.AddWithValue("@precio", obj.PRECIO);
            com.Parameters.AddWithValue("@Action", "Insertar");
            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            return i >= 1;
        }
        public List<REVISTAS> ShowAllCustomerDetails()
        {
            connection();
            List<REVISTAS> EmpList = new List<REVISTAS>();
            SqlCommand com = new SqlCommand("SpCrudRevista", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            com.Parameters.AddWithValue("@Action", "tabla");
            con.Open();
            da.Fill(dt);
            con.Close();


            return EmpList;
        }
        public bool Edit(REVISTAS obj)
        {
            connection();
            SqlCommand com = new SqlCommand("SpCrudRevista", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@titulo_rev", obj.TITULO_REV);
            com.Parameters.AddWithValue("@CB", obj.CB);
            com.Parameters.AddWithValue("@fecha_cir", obj.FECHA_CIRCULACION);
            com.Parameters.AddWithValue("@id_cat", obj.ID_CAT);
            com.Parameters.AddWithValue("@precio", obj.PRECIO);
            com.Parameters.AddWithValue("@Action", "Editar");
            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool Delete(int id)
        {
            connection();
            SqlCommand com = new SqlCommand("SpCrudRevista", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@id_rev", id);
            com.Parameters.AddWithValue("@Action", "Eliminar");
            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
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
