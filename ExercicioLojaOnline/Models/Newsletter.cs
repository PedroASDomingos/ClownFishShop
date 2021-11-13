using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ExercicioLojaOnline.Models
{
    public class Newsletter
    {
        public string email { get; set; }

        public static List<Newsletter> ListaNewsletter;

        public static void ConstroiListaNewsletter()
        {
            ListaNewsletter = new List<Newsletter>();

            string query = "select * from newsletter";

            SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["ClownfishDBConnectionString"].ConnectionString);
            SqlCommand myCommand = new SqlCommand(query, myConn);

            myConn.Open();

            SqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                Newsletter newsletter = new Newsletter();
                newsletter.email = (string)reader["email"];

                ListaNewsletter.Add(newsletter);
            }
            reader.Close();
        }
    }
}