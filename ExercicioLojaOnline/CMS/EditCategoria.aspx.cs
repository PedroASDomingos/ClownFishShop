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
    public partial class EditCategoria : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["utilizador"] == null)
            {
                Response.Redirect("login.aspx");
            }
        }

        protected void rpt_editcat_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DataRowView dr = (DataRowView)e.Item.DataItem;

                ((Label)e.Item.FindControl("lbl_cod")).Text = dr["cod_categoria"].ToString();
                ((TextBox)e.Item.FindControl("tb_categoria")).Text = dr["categoria"].ToString();
                ((ImageButton)e.Item.FindControl("btn_grava")).CommandArgument = dr["cod_categoria"].ToString();
                ((ImageButton)e.Item.FindControl("btn_apaga")).CommandArgument = dr["cod_categoria"].ToString();
            }
           
        }

        protected void rpt_editcat_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["ClownfishDBConnectionString"].ConnectionString);

            myConn.Open();

            if (e.CommandName.Equals("btn_grava"))
            {
                string query = "UPDATE categoria SET ";
                query += " categoria='" + ((TextBox)e.Item.FindControl("tb_categoria")).Text + "'";
                query += " WHERE cod_categoria=" + ((ImageButton)e.Item.FindControl("btn_grava")).CommandArgument;

                SqlCommand myCommand = new SqlCommand(query, myConn);
                myCommand.ExecuteNonQuery();

            }

            if (e.CommandName.Equals("btn_apaga"))
            {
                string querydel = "DELETE FROM categoria";
                querydel += " WHERE cod_categoria=" + ((ImageButton)e.Item.FindControl("btn_apaga")).CommandArgument;

                SqlCommand myCommand = new SqlCommand(querydel, myConn);
                myCommand.ExecuteNonQuery();
            }
            myConn.Close();
        }
    }
}