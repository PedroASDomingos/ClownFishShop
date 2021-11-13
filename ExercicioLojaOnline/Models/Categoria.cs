using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ExercicioLojaOnline.Models
{
    public class Categoria
    {
        public int cod_categoria { get; set; }
        public string categoria { get; set; }

        public static List<Categoria> ListaCategorias;

        public static void ConstroiListaCategorias()
        {
            ListaCategorias = new List<Categoria>();

            string query = "select * from categoria";

            SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["ClownfishDBConnectionString"].ConnectionString);
            SqlCommand myCommand = new SqlCommand(query, myConn);

            myConn.Open();

            SqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                Categoria categoria = new Categoria();
                categoria.cod_categoria = (int)reader["cod_categoria"];
                categoria.categoria = (string)reader["categoria"];

                ListaCategorias.Add(categoria);
            }
            reader.Close();
        }
    }
}