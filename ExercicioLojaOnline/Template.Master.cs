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
    public partial class Template : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SetCurrentPage();
            Produto.ConstroiListaProdutos();
            Categoria.ConstroiListaCategorias();

            lbl_totalArtigos.Text = ItemCarrinho.ListaCarrinhoCompras.Count.ToString();
        }

        private void SetCurrentPage()
        {
            //Get the current name of your Page
            var pageName = Request.Url.AbsolutePath.Split('/').LastOrDefault();

            //Apply the class based on your page name
            switch (pageName)
            {
                case "index.aspx":
                    Home.Attributes["class"] = "nav-item active";
                    Quem.Attributes["class"] = Quem.Attributes["class"].Replace("active", "").Trim();
                    Equipa.Attributes["class"] = Equipa.Attributes["class"].Replace("active", "").Trim();
                    Servicos.Attributes["class"] = Servicos.Attributes["class"].Replace("active", "").Trim();
                    Loja.Attributes["class"] = Loja.Attributes["class"].Replace("active", "").Trim();
                    //Pages.Attributes["class"] = Pages.Attributes["class"].Replace("active", "").Trim();
                    Contactos.Attributes["class"] = Contactos.Attributes["class"].Replace("active", "").Trim();
                    Carrinho.Attributes["class"] = Carrinho.Attributes["class"].Replace("active", "").Trim();
                    break;
                case "about.aspx":
                    Quem.Attributes["class"] = "nav-item active";
                    Home.Attributes["class"] = Home.Attributes["class"].Replace("active", "").Trim();
                    Equipa.Attributes["class"] = Equipa.Attributes["class"].Replace("active", "").Trim();
                    Servicos.Attributes["class"] = Servicos.Attributes["class"].Replace("active", "").Trim();
                    Loja.Attributes["class"] = Loja.Attributes["class"].Replace("active", "").Trim();
                    //Pages.Attributes["class"] = Pages.Attributes["class"].Replace("active", "").Trim();
                    Contactos.Attributes["class"] = Contactos.Attributes["class"].Replace("active", "").Trim();
                    Carrinho.Attributes["class"] = Carrinho.Attributes["class"].Replace("active", "").Trim();
                    break;
                case "team.aspx":
                    Equipa.Attributes["class"] = "nav-item active";
                    Home.Attributes["class"] = Home.Attributes["class"].Replace("active", "").Trim();
                    Quem.Attributes["class"] = Quem.Attributes["class"].Replace("active", "").Trim();
                    Servicos.Attributes["class"] = Servicos.Attributes["class"].Replace("active", "").Trim();
                    Loja.Attributes["class"] = Loja.Attributes["class"].Replace("active", "").Trim();
                    //Pages.Attributes["class"] = Pages.Attributes["class"].Replace("active", "").Trim();
                    Contactos.Attributes["class"] = Contactos.Attributes["class"].Replace("active", "").Trim();
                    Carrinho.Attributes["class"] = Carrinho.Attributes["class"].Replace("active", "").Trim();
                    break;
                case "services.aspx":
                    Servicos.Attributes["class"] = "nav-item active";
                    Home.Attributes["class"] = Home.Attributes["class"].Replace("active", "").Trim();
                    Quem.Attributes["class"] = Quem.Attributes["class"].Replace("active", "").Trim();
                    Equipa.Attributes["class"] = Equipa.Attributes["class"].Replace("active", "").Trim();
                    Loja.Attributes["class"] = Loja.Attributes["class"].Replace("active", "").Trim();
                    //Pages.Attributes["class"] = Pages.Attributes["class"].Replace("active", "").Trim();
                    Contactos.Attributes["class"] = Contactos.Attributes["class"].Replace("active", "").Trim();
                    Carrinho.Attributes["class"] = Carrinho.Attributes["class"].Replace("active", "").Trim();
                    break;
                case "shop.aspx":
                    Loja.Attributes["class"] = "nav-item active";
                    Home.Attributes["class"] = Home.Attributes["class"].Replace("active", "").Trim();
                    Quem.Attributes["class"] = Quem.Attributes["class"].Replace("active", "").Trim();
                    Equipa.Attributes["class"] = Equipa.Attributes["class"].Replace("active", "").Trim();
                    Servicos.Attributes["class"] = Servicos.Attributes["class"].Replace("active", "").Trim();
                    //Pages.Attributes["class"] = Pages.Attributes["class"].Replace("active", "").Trim();
                    Contactos.Attributes["class"] = Contactos.Attributes["class"].Replace("active", "").Trim();
                    Carrinho.Attributes["class"] = Carrinho.Attributes["class"].Replace("active", "").Trim();
                    break;
                
                case "contact.aspx":
                    Contactos.Attributes["class"] = "nav-item active";
                    Home.Attributes["class"] = Home.Attributes["class"].Replace("active", "").Trim();
                    Quem.Attributes["class"] = Quem.Attributes["class"].Replace("active", "").Trim();
                    Equipa.Attributes["class"] = Equipa.Attributes["class"].Replace("active", "").Trim();
                    Servicos.Attributes["class"] = Servicos.Attributes["class"].Replace("active", "").Trim();
                    Loja.Attributes["class"] = Loja.Attributes["class"].Replace("active", "").Trim();
                    //Pages.Attributes["class"] = Pages.Attributes["class"].Replace("active", "").Trim();
                    Carrinho.Attributes["class"] = Carrinho.Attributes["class"].Replace("active", "").Trim();
                    break;
                case "cart.aspx":
                    Carrinho.Attributes["class"] = "nav-item active";
                    Contactos.Attributes["class"] = Contactos.Attributes["class"].Replace("active", "").Trim();
                    Home.Attributes["class"] = Home.Attributes["class"].Replace("active", "").Trim();
                    Quem.Attributes["class"] = Quem.Attributes["class"].Replace("active", "").Trim();
                    Equipa.Attributes["class"] = Equipa.Attributes["class"].Replace("active", "").Trim();
                    Servicos.Attributes["class"] = Servicos.Attributes["class"].Replace("active", "").Trim();
                    Loja.Attributes["class"] = Loja.Attributes["class"].Replace("active", "").Trim();
                    //Pages.Attributes["class"] = Pages.Attributes["class"].Replace("active", "").Trim();
                    break;
                default:
                    //Page was not found
                    break;
            }
        }

        protected void btn_SubmitNewsletter_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["ClownfishDBConnectionString"].ConnectionString);
                SqlCommand myCommand = new SqlCommand();

                myCommand.Parameters.AddWithValue("@email", tb_newsletterEmail.Text);

                //parametro de output
                SqlParameter valor = new SqlParameter();
                valor.ParameterName = "@retorno";
                valor.Direction = ParameterDirection.Output;
                valor.SqlDbType = SqlDbType.Int;

                myCommand.Parameters.Add(valor);

                myCommand.CommandType = CommandType.StoredProcedure;
                myCommand.CommandText = "inserir_newsletter";

                myCommand.Connection = myConn;
                myConn.Open();
                myCommand.ExecuteNonQuery();

                int respostaSP = Convert.ToInt32(myCommand.Parameters["@retorno"].Value);

                myConn.Close();

                if (respostaSP == 1)
                    tb_newsletterEmail.Text = "Insrido com sucesso!";
                else
                    tb_newsletterEmail.Text = "Email já existe!";
            }
            catch (Exception)
            {
                throw;
            }
        }
        protected void LinkButtonUser_Click(object sender, EventArgs e)
        {
            if (Session["idUtilizador"] == null)
            {
                Response.Redirect("login.aspx");
            }
            else
            {
                Response.Redirect("perfilUser.aspx");
            }
        }
        public int GetCount()
        {
            if (ItemCarrinho.ListaCarrinhoCompras.Count == 0)
            {
                return 0;
            }
            return ItemCarrinho.ListaCarrinhoCompras.Count;
        }
    }
}