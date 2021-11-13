using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ExercicioLojaOnline.Models
{
    public class Destaque
    {
        public int cod_produto { get; set; }
        public string nome_produto { get; set; }

        public static List<Destaque> ListaDestaques;

        public static void ConstroiListaDestaques()
        {
            ListaDestaques = new List<Destaque>();

            string query = "SELECT destaque_top.cod_produto, produto.nome_produto FROM destaque_top INNER JOIN produto ON destaque_top.cod_produto = produto.cod_produto";

            SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["ClownfishDBConnectionString"].ConnectionString);
            SqlCommand myCommand = new SqlCommand(query, myConn);

            myConn.Open();

            SqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                Destaque destaque = new Destaque();
                destaque.cod_produto = (int)reader["cod_produto"];
                destaque.nome_produto = (string)reader["nome_produto"];

                ListaDestaques.Add(destaque);
            }
            reader.Close();
        }
    }
    
}