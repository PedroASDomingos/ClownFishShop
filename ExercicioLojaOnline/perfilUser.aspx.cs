using ExercicioLojaOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExercicioLojaOnline
{
    public partial class perfilUser : System.Web.UI.Page
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
            lbl_user.Text = Utilizador.user.utilizador.ToString();
            lbl_morada.Text = Utilizador.user.morada.ToString();
            lbl_codpostal.Text = Utilizador.user.cod_postal.ToString();
            lbl_dataNascimento.Text = Utilizador.user.data_nascimento.ToString();
            lbl_nif.Text = Utilizador.user.nif.ToString();
            lbl_telefone.Text = Utilizador.user.telemovel.ToString();
            //DropDownList1.SelectedValue = Utilizador.user.cod_perfil.ToString();
            lbl_email.Text = Utilizador.user.email.ToString();
            lbl_nome.Text = Utilizador.user.nome.ToString();
        }
        protected void btn_updatePerfil_Click(object sender, EventArgs e)
        {
            Response.Redirect("edituser.aspx");
        }

        protected void btn_alteraPass_Click(object sender, EventArgs e)
        {
            Response.Redirect("alterarPass.aspx");
        }

        protected void btn_logout_Click(object sender, EventArgs e)
        {
            Session["utlizador"] = string.Empty;
            Session["perfil"] = string.Empty;
            Session["idUtilizador"] = string.Empty;
            Utilizador.user.utilizador = string.Empty;
            Utilizador.user.morada = string.Empty;
            Utilizador.user.cod_postal = string.Empty;
            Utilizador.user.data_nascimento = string.Empty;
            Utilizador.user.nif = 0;
            Utilizador.user.telemovel = string.Empty;
            Utilizador.user.email = string.Empty;
            Utilizador.user.nome = string.Empty;
            ItemCarrinho.ListaCarrinhoCompras.Clear();
            Response.Redirect("login.aspx");
        }
    }
}