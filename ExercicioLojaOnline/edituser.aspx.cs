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

namespace ExercicioLojaOnline
{
    public partial class EditUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["idUtilizador"] == null)
            {
                Response.Redirect("login.aspx");
            }
            LoadUserInfo();
        }

        private void LoadUserInfo()
        {
            tb_user.Text = Utilizador.user.utilizador.ToString();
            tb_email.Text = Utilizador.user.email.ToString();
        }

        protected void btn_updatePerfil_Click(object sender, EventArgs e)
        {
            SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["ClownfishDBConnectionString"].ConnectionString);
            SqlCommand myCommand = new SqlCommand();

            myCommand.Parameters.AddWithValue("@cod_utilizador", Utilizador.user.cod_utilizador);
            myCommand.Parameters.AddWithValue("@utilizador", Utilizador.user.utilizador);
            myCommand.Parameters.AddWithValue("@morada", tb_morada.Text);
            myCommand.Parameters.AddWithValue("@cod_postal", tb_codpostal.Text);
            myCommand.Parameters.AddWithValue("@data_nascimento", tb_datanas.Text);
            myCommand.Parameters.AddWithValue("@nif", tb_nif.Text);
            myCommand.Parameters.AddWithValue("@telemovel", tb_telefone.Text);
            myCommand.Parameters.AddWithValue("@cod_perfil", DropDownList1.SelectedValue);
            myCommand.Parameters.AddWithValue("@email", Utilizador.user.email);
            myCommand.Parameters.AddWithValue("@nome", tb_nome.Text);

            //parametro de output
            SqlParameter valor = new SqlParameter();
            valor.ParameterName = "@retorno";
            valor.Direction = ParameterDirection.Output;
            valor.SqlDbType = SqlDbType.Int;

            myCommand.Parameters.Add(valor);

            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.CommandText = "alterar_dadosutilizador";

            myCommand.Connection = myConn;
            myConn.Open();
            myCommand.ExecuteNonQuery();
            int respostaSP = Convert.ToInt32(myCommand.Parameters["@retorno"].Value);

            myConn.Close();
            if (respostaSP == 1)
            {
                Utilizador.user.morada = tb_morada.Text;
                Utilizador.user.cod_postal = tb_codpostal.Text;
                Utilizador.user.data_nascimento = tb_datanas.Text;
                Utilizador.user.nif = Convert.ToInt32(tb_nif.Text);
                Utilizador.user.telemovel = tb_telefone.Text;
                Utilizador.user.cod_perfil = Convert.ToInt32(DropDownList1.SelectedValue);
                Utilizador.user.nome = tb_nome.Text;

                lbl_mensagem.Text = "Dados de utilizador atualizados com sucesso";
                Response.Redirect("perfilUser.aspx");
            }
            else
                lbl_mensagem.Text = "Dados errados!";
        }
        
    }
}