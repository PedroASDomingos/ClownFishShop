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
    public partial class backoffice : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["utilizador"] == null)
            {
                Response.Redirect("login.aspx");
            }
            LoadUserInfo();

        }

        private void LoadUserInfo()
        {
                string query = "select * from utilizador WHERE cod_utilizador='" + Session["id"] + "'";

                SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["ClownfishDBConnectionString"].ConnectionString);
                SqlCommand myCommand = new SqlCommand(query, myConn);

                myConn.Open();

                SqlDataReader reader = myCommand.ExecuteReader();

                Utilizador nt = new Utilizador();
                while (reader.Read())
                {
                    nt.cod_utilizador = reader.GetInt32(0);
                    nt.utilizador = reader.GetString(1);
                    nt.palavra_pass = reader.GetString(2);

                    if (!reader.IsDBNull(3))
                    {nt.morada = reader.GetString(3);}
                    else{nt.morada = string.Empty;}

                    if (!reader.IsDBNull(4))
                    { nt.cod_postal = reader.GetString(4); }
                    else { nt.cod_postal = string.Empty; }

                    if (!reader.IsDBNull(5))
                    { nt.data_nascimento = reader.GetString(5); }
                    else { nt.data_nascimento = string.Empty; }

                    if (!reader.IsDBNull(6))
                    { nt.nif = reader.GetInt32(6); }
                    else { nt.nif = 0; }

                    if (!reader.IsDBNull(7))
                    { nt.telemovel = reader.GetString(7); }
                    else { nt.telemovel = string.Empty; }

                    if (!reader.IsDBNull(8))
                    { nt.cod_perfil = reader.GetInt32(8); }
                    else { nt.cod_perfil = 0; }

                    if (!reader.IsDBNull(9))
                    { nt.email = reader.GetString(9); }
                    else { nt.email = string.Empty; }
                
                    nt.ativo = reader.GetBoolean(10);

                    if (!reader.IsDBNull(11))
                    { nt.nome = reader.GetString(11); }
                    else { nt.nome = string.Empty; }
                }
                reader.Close();
                myConn.Close();

                if (!string.IsNullOrEmpty(nt.utilizador))
                {tb_user.Text = nt.utilizador;}
                else{ tb_user.Text = "N/D"; }

                if (!string.IsNullOrEmpty(nt.morada))
                { tb_morada.Text = nt.morada; }
                else { tb_morada.Text = "N/D"; }

                if (!string.IsNullOrEmpty(nt.cod_postal))
                { tb_codpostal.Text = nt.cod_postal; }
                else { tb_codpostal.Text = "N/D"; }

                if (!string.IsNullOrEmpty(nt.data_nascimento.ToString()))
                { tb_datanas.Text = nt.data_nascimento.ToString(); }
                else { tb_datanas.Text = "N/D"; }

                if (nt.nif != 0)
                { tb_nif.Text = nt.nif.ToString(); }
                else { tb_nif.Text = "N/D"; }

                if (!string.IsNullOrEmpty(nt.telemovel.ToString()))
                { tb_telefone.Text = nt.telemovel.ToString(); }
                else { tb_telefone.Text = "N/D"; }

                if (!string.IsNullOrEmpty(nt.email))
                { tb_email.Text = nt.email; }
                else { tb_email.Text = "N/D"; }

                if (!string.IsNullOrEmpty(nt.nome))
                { tb_nome.Text = nt.nome; }
                else { tb_nome.Text = "N/D"; }

        }
    }
}