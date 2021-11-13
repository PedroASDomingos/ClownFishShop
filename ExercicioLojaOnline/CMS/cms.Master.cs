using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExercicioLojaOnline.CMS
{
    public partial class cms : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SetCurrentPage();
        }

        private void SetCurrentPage()
        {
            //Get the current name of your Page
            var pageName = Request.Url.AbsolutePath.Split('/').LastOrDefault();

            //Apply the class based on your page name
            switch (pageName)
            {
                case "backoffice.aspx":
                    Menu_A.Attributes["class"] = "active";
                    Menu_B.Attributes["class"] = Menu_B.Attributes["class"].Replace("active", "").Trim();
                    Menu_C.Attributes["class"] = Menu_C.Attributes["class"].Replace("active", "").Trim();
                    Menu_D.Attributes["class"] = Menu_D.Attributes["class"].Replace("active", "").Trim();
                    Menu_E.Attributes["class"] = Menu_E.Attributes["class"].Replace("active", "").Trim();
                    //Menu_F.Attributes["class"] = Menu_F.Attributes["class"].Replace("active", "").Trim();
                    Menu_G.Attributes["class"] = Menu_G.Attributes["class"].Replace("active", "").Trim(); 
                    Li1.Attributes["class"] = Li1.Attributes["class"].Replace("active", "").Trim();
                    Li2.Attributes["class"] = Menu_G.Attributes["class"].Replace("active", "").Trim();
                    Li3.Attributes["class"] = Li3.Attributes["class"].Replace("active", "").Trim();
                    break;
                case "addproduct.aspx":
                    Menu_B.Attributes["class"] = "active";
                    Menu_A.Attributes["class"] = Menu_A.Attributes["class"].Replace("active", "").Trim();
                    Menu_C.Attributes["class"] = Menu_C.Attributes["class"].Replace("active", "").Trim();
                    Menu_D.Attributes["class"] = Menu_D.Attributes["class"].Replace("active", "").Trim();
                    Menu_E.Attributes["class"] = Menu_E.Attributes["class"].Replace("active", "").Trim();
                    //Menu_F.Attributes["class"] = Menu_F.Attributes["class"].Replace("active", "").Trim();
                    Menu_G.Attributes["class"] = Menu_G.Attributes["class"].Replace("active", "").Trim();
                    Li1.Attributes["class"] = Li1.Attributes["class"].Replace("active", "").Trim();
                    Li2.Attributes["class"] = Menu_G.Attributes["class"].Replace("active", "").Trim();
                    Li3.Attributes["class"] = Li3.Attributes["class"].Replace("active", "").Trim();
                    break;
                case "EditProdutos.aspx":
                    Menu_C.Attributes["class"] = "active";
                    Menu_A.Attributes["class"] = Menu_A.Attributes["class"].Replace("active", "").Trim();
                    Menu_B.Attributes["class"] = Menu_B.Attributes["class"].Replace("active", "").Trim();
                    Menu_D.Attributes["class"] = Menu_D.Attributes["class"].Replace("active", "").Trim();
                    Menu_E.Attributes["class"] = Menu_E.Attributes["class"].Replace("active", "").Trim();
                    //Menu_F.Attributes["class"] = Menu_F.Attributes["class"].Replace("active", "").Trim();
                    Menu_G.Attributes["class"] = Menu_G.Attributes["class"].Replace("active", "").Trim();
                    Li1.Attributes["class"] = Li1.Attributes["class"].Replace("active", "").Trim();
                    Li2.Attributes["class"] = Menu_G.Attributes["class"].Replace("active", "").Trim();
                    Li3.Attributes["class"] = Li3.Attributes["class"].Replace("active", "").Trim();
                    break;
                case "addcategoria.aspx":
                    Menu_D.Attributes["class"] = "active";
                    Menu_A.Attributes["class"] = Menu_A.Attributes["class"].Replace("active", "").Trim();
                    Menu_B.Attributes["class"] = Menu_B.Attributes["class"].Replace("active", "").Trim();
                    Menu_C.Attributes["class"] = Menu_C.Attributes["class"].Replace("active", "").Trim();
                    Menu_E.Attributes["class"] = Menu_E.Attributes["class"].Replace("active", "").Trim();
                    //Menu_F.Attributes["class"] = Menu_F.Attributes["class"].Replace("active", "").Trim();
                    Menu_G.Attributes["class"] = Menu_G.Attributes["class"].Replace("active", "").Trim();
                    Li1.Attributes["class"] = Li1.Attributes["class"].Replace("active", "").Trim();
                    Li2.Attributes["class"] = Menu_G.Attributes["class"].Replace("active", "").Trim();
                    Li3.Attributes["class"] = Li3.Attributes["class"].Replace("active", "").Trim();
                    break;
                case "EditCategoria.aspx":
                    Menu_E.Attributes["class"] = "active";
                    Menu_A.Attributes["class"] = Menu_A.Attributes["class"].Replace("active", "").Trim();
                    Menu_B.Attributes["class"] = Menu_B.Attributes["class"].Replace("active", "").Trim();
                    Menu_C.Attributes["class"] = Menu_C.Attributes["class"].Replace("active", "").Trim();
                    Menu_D.Attributes["class"] = Menu_D.Attributes["class"].Replace("active", "").Trim();
                    //Menu_F.Attributes["class"] = Menu_F.Attributes["class"].Replace("active", "").Trim();
                    Menu_G.Attributes["class"] = Menu_G.Attributes["class"].Replace("active", "").Trim();
                    Li1.Attributes["class"] = Li1.Attributes["class"].Replace("active", "").Trim();
                    Li2.Attributes["class"] = Menu_G.Attributes["class"].Replace("active", "").Trim();
                    Li3.Attributes["class"] = Li3.Attributes["class"].Replace("active", "").Trim();
                    break;
                //case "F.aspx":
                //    Menu_F.Attributes["class"] = "active";
                //    Menu_A.Attributes["class"] = Menu_A.Attributes["class"].Replace("active", "").Trim();
                //    Menu_B.Attributes["class"] = Menu_B.Attributes["class"].Replace("active", "").Trim();
                //    Menu_C.Attributes["class"] = Menu_C.Attributes["class"].Replace("active", "").Trim();
                //    Menu_D.Attributes["class"] = Menu_D.Attributes["class"].Replace("active", "").Trim();
                //    Menu_E.Attributes["class"] = Menu_E.Attributes["class"].Replace("active", "").Trim();
                //    Menu_G.Attributes["class"] = Menu_G.Attributes["class"].Replace("active", "").Trim();
                //    Li1.Attributes["class"] = Li1.Attributes["class"].Replace("active", "").Trim();
                //    Li2.Attributes["class"] = Menu_G.Attributes["class"].Replace("active", "").Trim();
                //    Li3.Attributes["class"] = Li3.Attributes["class"].Replace("active", "").Trim();
                //    break;
                case "newsletter.aspx":
                    Menu_G.Attributes["class"] = "active";
                    Menu_A.Attributes["class"] = Menu_A.Attributes["class"].Replace("active", "").Trim();
                    Menu_B.Attributes["class"] = Menu_B.Attributes["class"].Replace("active", "").Trim();
                    Menu_C.Attributes["class"] = Menu_C.Attributes["class"].Replace("active", "").Trim();
                    Menu_D.Attributes["class"] = Menu_D.Attributes["class"].Replace("active", "").Trim();
                    Menu_E.Attributes["class"] = Menu_E.Attributes["class"].Replace("active", "").Trim();
                    //Menu_F.Attributes["class"] = Menu_F.Attributes["class"].Replace("active", "").Trim();
                    Li1.Attributes["class"] = Li1.Attributes["class"].Replace("active", "").Trim();
                    Li2.Attributes["class"] = Menu_G.Attributes["class"].Replace("active", "").Trim();
                    Li3.Attributes["class"] = Li3.Attributes["class"].Replace("active", "").Trim();
                    break;
                case "destaques.aspx":
                    Li1.Attributes["class"] = "active";
                    Menu_A.Attributes["class"] = Menu_A.Attributes["class"].Replace("active", "").Trim();
                    Menu_B.Attributes["class"] = Menu_B.Attributes["class"].Replace("active", "").Trim();
                    Menu_C.Attributes["class"] = Menu_C.Attributes["class"].Replace("active", "").Trim();
                    Menu_D.Attributes["class"] = Menu_D.Attributes["class"].Replace("active", "").Trim();
                    Menu_E.Attributes["class"] = Menu_E.Attributes["class"].Replace("active", "").Trim();
                    //Menu_F.Attributes["class"] = Menu_F.Attributes["class"].Replace("active", "").Trim();
                    Menu_G.Attributes["class"] = Menu_G.Attributes["class"].Replace("active", "").Trim();
                    Li2.Attributes["class"] = Menu_G.Attributes["class"].Replace("active", "").Trim();
                    Li3.Attributes["class"] = Li3.Attributes["class"].Replace("active", "").Trim();
                    break;

                case "addfuncionario.aspx":
                    Li2.Attributes["class"] = "active";
                    Menu_A.Attributes["class"] = Menu_A.Attributes["class"].Replace("active", "").Trim();
                    Menu_B.Attributes["class"] = Menu_B.Attributes["class"].Replace("active", "").Trim();
                    Menu_C.Attributes["class"] = Menu_C.Attributes["class"].Replace("active", "").Trim();
                    Menu_D.Attributes["class"] = Menu_D.Attributes["class"].Replace("active", "").Trim();
                    Menu_E.Attributes["class"] = Menu_E.Attributes["class"].Replace("active", "").Trim();
                    //Menu_F.Attributes["class"] = Menu_F.Attributes["class"].Replace("active", "").Trim();
                    Menu_G.Attributes["class"] = Menu_G.Attributes["class"].Replace("active", "").Trim();
                    Li1.Attributes["class"] = Li1.Attributes["class"].Replace("active", "").Trim();
                    Li3.Attributes["class"] = Li3.Attributes["class"].Replace("active", "").Trim();
                    break;
                case "editfuncionario.aspx":
                    Li3.Attributes["class"] = "active";
                    Menu_A.Attributes["class"] = Menu_A.Attributes["class"].Replace("active", "").Trim();
                    Menu_B.Attributes["class"] = Menu_B.Attributes["class"].Replace("active", "").Trim();
                    Menu_C.Attributes["class"] = Menu_C.Attributes["class"].Replace("active", "").Trim();
                    Menu_D.Attributes["class"] = Menu_D.Attributes["class"].Replace("active", "").Trim();
                    Menu_E.Attributes["class"] = Menu_E.Attributes["class"].Replace("active", "").Trim();
                    //Menu_F.Attributes["class"] = Menu_F.Attributes["class"].Replace("active", "").Trim();
                    Menu_G.Attributes["class"] = Menu_G.Attributes["class"].Replace("active", "").Trim();
                    Li1.Attributes["class"] = Li1.Attributes["class"].Replace("active", "").Trim();
                    Li2.Attributes["class"] = Li2.Attributes["class"].Replace("active", "").Trim();
                    break;
                default:
                    //Page was not found
                    break;
            }

        }

        protected void btn_logout_Click(object sender, ImageClickEventArgs e)
        {
            Session["utilizador"] = null;
            Session["perfil"] = null;
            Session["id"] = 0;

            Response.Redirect("login.aspx");
        }
    }
}