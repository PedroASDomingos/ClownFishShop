using ExercicioLojaOnline.Models;
using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.UI.WebControls;

namespace ExercicioLojaOnline
{
    public partial class shop : System.Web.UI.Page
    {
        public int PageNumber
        {
            get
            {
                if (ViewState["PageNumber"] != null)
                    return Convert.ToInt32(ViewState["PageNumber"]);
                else
                    return 0;
            }
            set
            {
                ViewState["PageNumber"] = value;
            }
        }
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            rptPages.ItemCommand +=
               new RepeaterCommandEventHandler(rptPages_ItemCommand);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Produto.ListaProdutos == null)
            {
                Produto.ConstroiListaProdutos();

            }
            if (Categoria.ListaCategorias == null)
            {
                Categoria.ConstroiListaCategorias();
            }
            //LoadPeixes();
            LoadCartegorias();
            LoadData();
        }

        private void LoadCartegorias()
        {
            Repeater1.DataSource = Categoria.ListaCategorias;
            Repeater1.DataBind();
        }

        private void LoadPeixes()
        {
            d1.DataSource = Produto.ListaProdutos;
            d1.DataBind();
        }

        private void LoadData()
        {
            SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["ClownfishDBConnectionString"].ConnectionString);
            string query = "select * from produto";

            myConn.Open();
            SqlDataAdapter da = new SqlDataAdapter(query, myConn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            myConn.Close();

            PagedDataSource pgitems = new PagedDataSource();
            DataView dv = new DataView(dt);

            pgitems.DataSource = dv;
            pgitems.AllowPaging = true;
            pgitems.PageSize = 9;
            pgitems.CurrentPageIndex = PageNumber;
            if (pgitems.PageCount > 1)
            {
                rptPages.Visible = true;
                ArrayList pages = new ArrayList();
                for (int i = 0; i < pgitems.PageCount; i++)
                    pages.Add((i + 1).ToString());
                rptPages.DataSource = pages;
                rptPages.DataBind();
            }
            else
                rptPages.Visible = false;
            d1.DataSource = pgitems;
            d1.DataBind();
        }
        void rptPages_ItemCommand(object source,
                             RepeaterCommandEventArgs e)
        {
            PageNumber = Convert.ToInt32(e.CommandArgument) - 1;
            LoadData();
        }

        public string GetImage(object ctype, object img)
        {
            return "data:" + ctype + ";base64," + Convert.ToBase64String((byte[])img);
        }

        public string GetCounts(object cat)
        {
            int comparaCategoria = Convert.ToInt32(cat);
            int countador = 0;
            foreach (var item in Produto.ListaProdutos)
            {
                if (comparaCategoria == item.cod_categoria)
                {
                    countador = countador + 1;
                }
            }
            return countador.ToString();
        }

        public string GetCountAll(object cat)
        {
            int countador = 0;
            foreach (var item in Produto.ListaProdutos)
            {
                countador = countador + 1;
            }
            return countador.ToString();
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            divPaging.Visible = false;
            rptPages.Visible = false;
            
            LinkButton btn = (LinkButton)(sender);
            string yourValue = btn.CommandArgument;

            int comparaCategoria = Convert.ToInt32(yourValue);
            Session["CategoriaEscolhida"] = Convert.ToInt32(yourValue);

            d1.DataSource = Produto.ListaProdutos.Where(item => item.cod_categoria == comparaCategoria);
            d1.DataBind();
        }

        protected void LinkButtonAll_Click(object sender, EventArgs e)
        {
            divPaging.Visible = true;
            rptPages.Visible = true;

            Session["CategoriaEscolhida"] = 0;
            d1.DataSource = Produto.ListaProdutos;
            d1.DataBind();
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
                    return;
                }
            }
            ItemCarrinho.AdProdutoCarrinho(IdProduto, 1, iduser);
            Page.Response.Redirect(Page.Request.Url.ToString(), true);

        }
        protected void btn_asc_Click(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedValue == "NoOrder")
            {
                return;
            }
            if (DropDownList1.SelectedValue == "nome_produto")
            {
                if (Convert.ToInt32(Session["CategoriaEscolhida"]) == 0)
                {
                    d1.DataSource = Produto.ListaProdutos.OrderBy(Item => Item.nome_produto);
                    d1.DataBind();
                }
                if (Convert.ToInt32(Session["CategoriaEscolhida"]) > 0)
                {
                    d1.DataSource = Produto.ListaProdutos.OrderBy(Item => Item.nome_produto).Where(item => item.cod_categoria == Convert.ToInt32(Session["CategoriaEscolhida"]));
                    d1.DataBind();
                }

            }
            if (DropDownList1.SelectedValue == "preco")
            {
                if (Convert.ToInt32(Session["CategoriaEscolhida"]) == 0)
                {
                    d1.DataSource = Produto.ListaProdutos.OrderBy(Item => Item.preco);
                    d1.DataBind();
                }
                if (Convert.ToInt32(Session["CategoriaEscolhida"]) > 0)
                {
                    d1.DataSource = Produto.ListaProdutos.OrderBy(Item => Item.preco).Where(item => item.cod_categoria == Convert.ToInt32(Session["CategoriaEscolhida"]));
                    d1.DataBind();
                }
            }
        }
        protected void btn_dsc_Click(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedValue == "NoOrder")
            {
                return;
            }
            if (DropDownList1.SelectedValue == "nome_produto")
            {
                if (Convert.ToInt32(Session["CategoriaEscolhida"]) == 0)
                {
                    d1.DataSource = Produto.ListaProdutos.OrderByDescending(Item => Item.nome_produto);
                    d1.DataBind();
                }
                if (Convert.ToInt32(Session["CategoriaEscolhida"]) > 0)
                {
                    d1.DataSource = Produto.ListaProdutos.OrderByDescending(Item => Item.nome_produto).Where(item => item.cod_categoria == Convert.ToInt32(Session["CategoriaEscolhida"]));
                    d1.DataBind();
                }

            }
            if (DropDownList1.SelectedValue == "preco")
            {
                if (Convert.ToInt32(Session["CategoriaEscolhida"]) == 0)
                {
                    d1.DataSource = Produto.ListaProdutos.OrderByDescending(Item => Item.preco);
                    d1.DataBind();
                }
                if (Convert.ToInt32(Session["CategoriaEscolhida"]) > 0)
                {
                    d1.DataSource = Produto.ListaProdutos.OrderByDescending(Item => Item.preco).Where(item => item.cod_categoria == Convert.ToInt32(Session["CategoriaEscolhida"]));
                    d1.DataBind();
                }
            }
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