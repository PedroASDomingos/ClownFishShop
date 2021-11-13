using ExercicioLojaOnline.Models;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace ExercicioLojaOnline
{
    public partial class product_details : System.Web.UI.Page
    {
        
        int id;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.QueryString["id"] == null)
            {
                Response.Redirect("shop.aspx");
            }
            LoadProduct();
        }

        private void LoadProduct()
        {
            try
            {
                
                id = Convert.ToInt32(Request.QueryString["id"].ToString());

                SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["ClownfishDBConnectionString"].ConnectionString);
                myConn.Open();

                SqlCommand myCommand = myConn.CreateCommand();
                myCommand.CommandType = CommandType.Text;
                myCommand.CommandText = "select * from produto where cod_produto=" + id;

                myCommand.ExecuteNonQuery();

                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(myCommand);

                da.Fill(dt);
                d1.DataSource = dt;
                d1.DataBind();

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

        public string GetStock(object quantidade)
        {
            int Stock = Convert.ToInt32(quantidade);

            if (Stock>0)
            {
                return "Em Stock";
            }
            else
            {
                return "Sem Stock";
            }
            
        }
        public string GetCategoria(object idcategoria)
        {
            int id = Convert.ToInt32(idcategoria);

            foreach (var item in Categoria.ListaCategorias)
            {
                if (id == item.cod_categoria)
                {
                    return item.categoria;
                }else
                    return "Categoria";
            }
            return "Categoria";
            
        }

        public string GetEstilo(object quantidade)
        {
            int Stock = Convert.ToInt32(quantidade);

            if (Stock > 0)
            {
                return "postiva";
            }
            else
            {
                return "negativa";
            }

        }

        protected void btn_adicionar_Click(object sender, EventArgs e)
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
        }

        protected void d1_ItemDataBound(object sender, RepeaterItemEventArgs e)
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