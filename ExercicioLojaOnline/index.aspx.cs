using ExercicioLojaOnline.Models;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace ExercicioLojaOnline
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadDestaques();
        }

        private void LoadDestaques()
        {
            try
            {
                SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["ClownfishDBConnectionString"].ConnectionString);
                myConn.Open();

                SqlCommand myCommand = myConn.CreateCommand();
                myCommand.CommandType = CommandType.Text;

                myCommand.CommandText = "SELECT TOP 8 * FROM produto ORDER BY cod_produto DESC";

                myCommand.ExecuteNonQuery();

                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(myCommand);

                da.Fill(dt);
                Repeater1.DataSource = dt;
                Repeater1.DataBind();

                myConn.Close();
            }
            catch (Exception)
            {
                throw;
            }
            try
            {
                SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["ClownfishDBConnectionString"].ConnectionString);
                myConn.Open();

                SqlCommand myCommand = myConn.CreateCommand();
                myCommand.CommandType = CommandType.Text;

                myCommand.CommandText = "SELECT destaque_top.cod_produto AS Expr1, produto.* FROM destaque_top INNER JOIN produto ON destaque_top.cod_produto = produto.cod_produto";

                myCommand.ExecuteNonQuery();

                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(myCommand);

                da.Fill(dt);
                Repeater2.DataSource = dt;
                Repeater2.DataBind();

                myConn.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public string GetImage(object ctype, object img)
        {
            return "data:" + ctype + ";base64," + Convert.ToBase64String((byte[])img);
        }

        protected void LinkButtonBuy_Click(object sender, EventArgs e)
        {
            if (Session["idUtilizador"] == null)
            {
                Response.Redirect("login.aspx");
            }
            int iduser = Convert.ToInt32(Session["idUtilizador"]);

            LinkButton btn = (LinkButton)(sender);
            string yourValue = btn.CommandArgument;

            int IdProduto = Convert.ToInt32(yourValue);

            foreach (var item in ItemCarrinho.ListaCarrinhoCompras)
            {
                if (item.cod_produto == IdProduto)
                {
                    //item.quantidade = item.quantidade + 1;
                    return;
                }
            }
            ItemCarrinho.AdProdutoCarrinho(IdProduto, 1, iduser);
            //Page.Response.Redirect(Page.Request.Url.ToString(), true);
        }


        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                if (Utilizador.user.cod_perfil == 3)
                {
                    Panel panelNormal = (Panel)e.Item.FindControl("Panel_PrecoNormal");
                    panelNormal.Visible = false;
                    Panel panelRevenda = (Panel)e.Item.FindControl("Panel_PanelPrecoRevenda");
                    panelRevenda.Visible = true;
                }
            }
        }

        protected void Repeater2_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                if (Utilizador.user.cod_perfil == 3)
                {
                    Panel panelNormal = (Panel)e.Item.FindControl("Panel_PrecoNormal");
                    panelNormal.Visible = false;
                    Panel panelRevenda = (Panel)e.Item.FindControl("Panel_PanelPrecoRevenda");
                    panelRevenda.Visible = true;
                }
            }
        }
    }
}