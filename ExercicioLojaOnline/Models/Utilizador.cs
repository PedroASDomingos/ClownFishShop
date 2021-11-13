using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ExercicioLojaOnline.Models
{
    public class Utilizador
    {
        public int cod_utilizador { get; set; }
        public string utilizador { get; set; }
        public string palavra_pass { get; set; }
        public string morada { get; set; } 
        public string cod_postal { get; set; }
        public string data_nascimento { get; set; } 
        public int? nif { get; set; }
        public string telemovel { get; set; }
        public int cod_perfil { get; set; }
        public string email { get; set; }
        public bool? ativo { get; set; }
        public string nome { get; set; }

        public static Utilizador user = new Utilizador();

        public static void AddUser(int ID)
        {
            string query = "select * from utilizador WHERE cod_utilizador='" + ID + "'";

            SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["ClownfishDBConnectionString"].ConnectionString);
            SqlCommand myCommand = new SqlCommand(query, myConn);

            myConn.Open();

            SqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                user.cod_utilizador = reader.GetInt32(0);
                user.utilizador = reader.GetString(1);
                user.palavra_pass = string.Empty;

                if (!reader.IsDBNull(3))
                { user.morada = reader.GetString(3); }
                else { user.morada = string.Empty; }

                if (!reader.IsDBNull(4))
                { user.cod_postal = reader.GetString(4); }
                else { user.cod_postal = string.Empty; }

                if (!reader.IsDBNull(5))
                { user.data_nascimento = reader.GetString(5); }
                else { user.data_nascimento = string.Empty; }

                if (!reader.IsDBNull(6))
                { user.nif = reader.GetInt32(6); }
                else { user.nif = 0; }

                if (!reader.IsDBNull(7))
                { user.telemovel = reader.GetString(7); }
                else { user.telemovel = string.Empty; }

                if (!reader.IsDBNull(8))
                { user.cod_perfil = reader.GetInt32(8); }
                else { user.cod_perfil = 2; }

                if (!reader.IsDBNull(9))
                { user.email = reader.GetString(9); }
                else { user.email = string.Empty; }

                user.ativo = reader.GetBoolean(10);

                if (!reader.IsDBNull(11))
                { user.nome = reader.GetString(11); }
                else { user.nome = string.Empty; }
            }
            reader.Close();
        }
    }
}