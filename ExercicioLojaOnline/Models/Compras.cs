using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ExercicioLojaOnline.Models
{
    public class Compras
    {
        public string numFatura { get; set; }
        public string data { get; set; }
        public int cod_produto { get; set; }
        public int quantidade { get; set; }
        public int cod_cliente { get; set; }

        public static List<Compras> ListaFaturas = new List<Compras>();

        public static void ConstroiListaFaturas(int id)
        {

            string query = "select * from fatura WHERE cod_cliente='" + id + "'";

            SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["ClownfishDBConnectionString"].ConnectionString);
            SqlCommand myCommand = new SqlCommand(query, myConn);

            myConn.Open();

            SqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                Compras item = new Compras();
                item.numFatura = (string)reader["numFatura"];
                item.data = (string)reader["data"];
                item.cod_produto = (int)reader["cod_produto"];
                item.quantidade = (int)reader["quantidade"];
                item.cod_cliente = (int)reader["cod_cliente"];
                ListaFaturas.Add(item);
            }
            reader.Close();
        }

        public static void AtualizaBDFatruas(string numFatura, string data, int IDProduto, int Quantidade, int IDCliente)
        {
            SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["ClownfishDBConnectionString"].ConnectionString);
            SqlCommand myCommand = new SqlCommand();

            myCommand.Parameters.AddWithValue("@numFatura", numFatura);
            myCommand.Parameters.AddWithValue("@data", data);
            myCommand.Parameters.AddWithValue("@cod_produto", IDProduto);
            myCommand.Parameters.AddWithValue("@quantidade", Quantidade);
            myCommand.Parameters.AddWithValue("@cod_cliente", IDCliente);

            //parametro de output
            SqlParameter valor = new SqlParameter();
            valor.ParameterName = "@retorno";
            valor.Direction = ParameterDirection.Output;
            valor.SqlDbType = SqlDbType.Int;

            myCommand.Parameters.Add(valor);

            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.CommandText = "inserir_tabelaFaturas";

            myCommand.Connection = myConn;
            myConn.Open();
            myCommand.ExecuteNonQuery();

            int respostaSP = Convert.ToInt32(myCommand.Parameters["@retorno"].Value);

            myConn.Close();
        }
        
    }
}