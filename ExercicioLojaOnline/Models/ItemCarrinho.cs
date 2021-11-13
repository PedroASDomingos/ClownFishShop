using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ExercicioLojaOnline.Models
{
    public class ItemCarrinho
    {
        public int cod_produto { get; set; }
        public int quantidade { get; set; }
        public int cod_cliente { get; set; }

        public static List<ItemCarrinho> ListaCarrinhoCompras = new List<ItemCarrinho>();

        public static void ConstroiCarrinhoCompras(int id)
        {
            string query = "select * from itemcarrinho WHERE cod_cliente='" + id + "'";

            SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["ClownfishDBConnectionString"].ConnectionString);
            SqlCommand myCommand = new SqlCommand(query, myConn);

            myConn.Open();

            SqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                ItemCarrinho item = new ItemCarrinho();
                item.cod_produto = (int)reader["cod_produto"];
                item.quantidade = (int)reader["quantidade"];
                item.cod_cliente = (int)reader["cod_cliente"];
                ListaCarrinhoCompras.Add(item);
            }
            reader.Close();
        }

        public static void AdProdutoCarrinho(int IDProduto, int Quantidade, int IDCliente)
        {
            ListaCarrinhoCompras.Add(new ItemCarrinho
            {
                cod_produto = IDProduto,
                quantidade = Quantidade,
                cod_cliente = IDCliente
            });
            AtualizaBD(IDProduto, Quantidade, IDCliente);
        }

        private static void AtualizaBD(int IDProduto, int Quantidade, int IDCliente)
        {
            SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["ClownfishDBConnectionString"].ConnectionString);
            SqlCommand myCommand = new SqlCommand();

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
            myCommand.CommandText = "inserir_produtocarrinho";

            myCommand.Connection = myConn;
            myConn.Open();
            myCommand.ExecuteNonQuery();

            int respostaSP = Convert.ToInt32(myCommand.Parameters["@retorno"].Value);

            myConn.Close();
        }
        public static void RemoveProdutoCarrinho(int IDProduto, int IDCliente)
        {
            ItemCarrinho apagado = null;
            foreach (var item in ListaCarrinhoCompras)
            {
                if (item.cod_produto == IDProduto && item.cod_cliente == IDCliente)
                {
                    apagado = item;  
                }
            }
            ListaCarrinhoCompras.Remove(apagado);
        }
        public static int RemoveBD(int IDProduto, int IDCliente)
        {
            SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["ClownfishDBConnectionString"].ConnectionString);
            SqlCommand myCommand = new SqlCommand();

            myCommand.Parameters.AddWithValue("@cod_produto", IDProduto);
            myCommand.Parameters.AddWithValue("@cod_cliente", IDCliente);

            //parametro de output
            SqlParameter valor = new SqlParameter();
            valor.ParameterName = "@retorno";
            valor.Direction = ParameterDirection.Output;
            valor.SqlDbType = SqlDbType.Int;

            myCommand.Parameters.Add(valor);

            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.CommandText = "apaga_produtocarrinho";

            myCommand.Connection = myConn;
            myConn.Open();
            myCommand.ExecuteNonQuery();

            int respostaSP = Convert.ToInt32(myCommand.Parameters["@retorno"].Value);

            myConn.Close();

            return respostaSP;
        }
    }
}