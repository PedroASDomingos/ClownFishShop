using ExercicioLojaOnline.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExercicioLojaOnline.CMS
{
    public partial class destaques : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["utilizador"] == null)
            {
                Response.Redirect("login.aspx");
            }
            if (Produto.ListaProdutos == null)
            {
                Produto.ConstroiListaProdutos();

            }
            if (Categoria.ListaCategorias == null)
            {
                Categoria.ConstroiListaCategorias();
            }
            if (Destaque.ListaDestaques == null)
            {
                Destaque.ConstroiListaDestaques();
            }
        }


        protected void btn_adicionar_Click(object sender, EventArgs e)
        {
            if (lst_produtos.SelectedIndex == -1) { 
                lbl_mensagem.Text = "Selecione um produto";
                return;
            }
            if (lst_destaque.Items.Count == 8)
            {
                lbl_mensagem.Text = "So pode adicioar até 8 produtos";
                return;
            }
            try
            {
                SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["ClownfishDBConnectionString"].ConnectionString);
                SqlCommand myCommand = new SqlCommand();

                myCommand.Parameters.AddWithValue("@cod_produto", lst_produtos.SelectedValue);

                //parametro de output
                SqlParameter valor = new SqlParameter();
                valor.ParameterName = "@retorno";
                valor.Direction = ParameterDirection.Output;
                valor.SqlDbType = SqlDbType.Int;

                myCommand.Parameters.Add(valor);

                myCommand.CommandType = CommandType.StoredProcedure;
                myCommand.CommandText = "inserir_destaque";

                myCommand.Connection = myConn;
                myConn.Open();
                myCommand.ExecuteNonQuery();

                int respostaSP = Convert.ToInt32(myCommand.Parameters["@retorno"].Value);

                myConn.Close();

                if (respostaSP == 1)
                {
                    lbl_mensagem.Text = "Destaque insrido com sucesso!";
                    Response.Redirect("destaques.aspx");
                }
                else
                    lbl_mensagem.Text = "Erro ao inserir o destaque...";
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void btn_remover_Click(object sender, EventArgs e)
        {
            if (lst_destaque.SelectedIndex == -1)
            {
                lbl_mensagem.Text = "Selecione um produto da Lista de Destaques";
                return;
            }
            SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["ClownfishDBConnectionString"].ConnectionString);

            myConn.Open();

            string querydel = "DELETE FROM destaque_top WHERE cod_produto=" + lst_destaque.SelectedValue;

            SqlCommand myCommand = new SqlCommand(querydel, myConn);
            myCommand.ExecuteNonQuery();

            myConn.Close();

            Response.Redirect("destaques.aspx");
        }
    }
}