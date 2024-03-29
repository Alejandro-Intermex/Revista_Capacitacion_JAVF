﻿using System;
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
        public List<REVISTAS> Create(REVISTAS obj)
        {
            connection();
            SqlCommand com = new SqlCommand("SpCrudRevista", conec);
            List<REVISTAS> EmpList = new List<REVISTAS>();
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            com.Parameters.AddWithValue("@TITULO_REV", obj.TITULO_REV);
            com.Parameters.AddWithValue("@CB", obj.CB);
            com.Parameters.AddWithValue("@FECHA_CIRCULACION", obj.FECHA_CIRCULACION);
            com.Parameters.AddWithValue("@ID_CAT", obj.ID_CAT);
            com.Parameters.AddWithValue("@PRECIO", obj.PRECIO);
            com.Parameters.AddWithValue("@Accion", "Insertar");
            conec.Open();
            da.Fill(dt);
            conec.Close();
            EmpList = (from DataRow dr in dt.Rows
                       select new REVISTAS()
                       {
                           ID_REV = Convert.ToInt32(dr["ID_REV"]),
                           TITULO_REV = Convert.ToString(dr["TITULO_REV"]),
                           CB = Convert.ToString(dr["CB"]),
                           FECHA_CIRCULACION = Convert.ToString(dr["FECHA_CIRCULACION"]),
                           ID_CAT = Convert.ToInt32(dr["ID_CAT"]),
                           PRECIO = Convert.ToInt32(dr["PRECIO"]),
                           ROW_CREATE = Convert.ToString(dr["ROW_CREATE"])
                       }).ToList();

            return EmpList;
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
                           FECHA_CIRCULACION = Convert.ToString(dr["FECHA_CIRCULACION"]),
                           ID_CAT = Convert.ToInt32(dr["ID_CAT"]),
                           PRECIO = Convert.ToInt32(dr["PRECIO"]),
                           ROW_CREATE = Convert.ToString(dr["ROW_CREATE"])
                       }).ToList();

            return EmpList;
        }
        //TITULO = Convert.IsDBNull(dr["TITULO"]) ? "" : Convert.ToString(dr["TITULO"]),

        public List<M_CATEGORIAS> catego()
        {
            connection();
            List<M_CATEGORIAS> EmpList = new List<M_CATEGORIAS>();
            SqlCommand com = new SqlCommand("SpCrudRevista", conec);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            com.Parameters.AddWithValue("@Accion", "categorias");
            conec.Open();
            da.Fill(dt);
            conec.Close();

            EmpList = (from DataRow dr in dt.Rows
                       select new M_CATEGORIAS()
                       {
                           ID_CAT = Convert.ToInt32(dr["ID_CAT"]),
                           NOMBRE_CAT = Convert.ToString(dr["NOMBRE_CAT"])
                       }).ToList();
            return EmpList;
        }


        public List<ENCABEZADO> enca()
        {
            connection();
            List<ENCABEZADO> EmpList = new List<ENCABEZADO>();
            SqlCommand com = new SqlCommand("SpCrudRevista", conec);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            com.Parameters.AddWithValue("@Accion", "encabezado");
            conec.Open();
            da.Fill(dt);
            conec.Close();

            EmpList = (from DataRow dr in dt.Rows
                       select new ENCABEZADO()
                       {
                           NOMBRE_EMPRESA = Convert.ToString(dr["NOMBRE_EMPRESA"]),
                           TITULO = Convert.ToString(dr["TITULO"]),
                           CREADOR = Convert.ToString(dr["CREADOR"])
                       }).ToList();
            return EmpList;
        }

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
            if (i < 1)
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
                            FECHA_CIRCULACION = Convert.ToString(dr["FECHA_CIRCULACION"]),
                            ID_CAT = Convert.ToInt32(dr["ID_CAT"]),
                            PRECIO = Convert.ToInt32(dr["PRECIO"]),
                            ROW_CREATE = Convert.ToString(dr["ROW_CREATE"])
                        }).ToList();

            return EmpList2;
        }

        public bool Delete(int ID_REV)
        {
            connection();
            SqlCommand com = new SqlCommand("SpCrudRevista", conec);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@ID_REV", ID_REV);
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
