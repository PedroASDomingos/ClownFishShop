using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

namespace ExercicioLojaOnline.Models
{
    public class Produto
    {
        public int cod_produto { get; set; }
        public string nome_produto { get; set; }
        public string nome_cientifico { get; set; }
        public int cod_categoria { get; set; }
        public double preco { get; set; }
        public double preco_promocao { get; set; }
        public string descricao_produto { get; set; }
        public byte[] imagem { get; set; }
        public string contenttype { get; set; }
        public int cod_tx_iva { get; set; }
        public int quantidade { get; set; }

        public static List<Produto> ListaProdutos;

        public static void ConstroiListaProdutos()
        {
            ListaProdutos = new List<Produto>();

            string query = "select * from produto";

            SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["ClownfishDBConnectionString"].ConnectionString);
            SqlCommand myCommand = new SqlCommand(query, myConn);

            myConn.Open();

            SqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                Produto produto = new Produto();
                produto.cod_produto = (int)reader["cod_produto"];
                produto.nome_produto = (string)reader["nome_produto"];
                produto.nome_cientifico = (string)reader["nome_cientifico"];
                produto.cod_categoria = (int)reader["cod_categoria"];
                produto.preco = Convert.ToDouble(reader["preco"]);
                produto.preco_promocao = Convert.ToDouble(reader["preco_promocao"]);
                produto.descricao_produto = (string)reader["descricao_produto"];
                produto.imagem = (byte[])reader["imagem"];
                produto.contenttype = (string)reader["contenttype"];
                produto.cod_tx_iva = (int)reader["cod_tx_iva"];
                produto.quantidade = (int)reader["quantidade"];
                ListaProdutos.Add(produto);
            }
            reader.Close();
        }
    }
    
}