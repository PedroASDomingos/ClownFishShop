using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web.UI.WebControls;

namespace ExercicioLojaOnline.CMS
{
    public partial class editfuncionario : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["utilizador"] == null)
            {
                Response.Redirect("login.aspx");
            }
        }

        protected void rpt_editfun_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DataRowView dr = (DataRowView)e.Item.DataItem;

                ((Label)e.Item.FindControl("lbl_codfuncionario")).Text = dr["cod_funcionario"].ToString();
                ((TextBox)e.Item.FindControl("tb_nome")).Text = dr["nome"].ToString();
                ((TextBox)e.Item.FindControl("tb_cargo")).Text = dr["cargo"].ToString();
                ((TextBox)e.Item.FindControl("tb_linkface")).Text = dr["linkface"].ToString();
                ((TextBox)e.Item.FindControl("tb_linkinsta")).Text = dr["linkinsta"].ToString();
                ((TextBox)e.Item.FindControl("tb_linktwitter")).Text = dr["linktwitter"].ToString();
                ((TextBox)e.Item.FindControl("tb_linklinkedin")).Text = dr["linklinkedin"].ToString();
                ((ImageButton)e.Item.FindControl("btn_grava")).CommandArgument = dr["cod_funcionario"].ToString();
                ((ImageButton)e.Item.FindControl("btn_apaga")).CommandArgument = dr["cod_funcionario"].ToString();
            }
        }

        protected void rpt_editfun_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["ClownfishDBConnectionString"].ConnectionString);
            myConn.Open();

            if (e.CommandName.Equals("btn_grava"))
            {
                if (((FileUpload)e.Item.FindControl("FileUpload1")).HasFile)
                {
                    Stream imgStream = ((FileUpload)e.Item.FindControl("FileUpload1")).PostedFile.InputStream;
                    int imgLen = ((FileUpload)e.Item.FindControl("FileUpload1")).PostedFile.ContentLength;
                    string imgContentType = ((FileUpload)e.Item.FindControl("FileUpload1")).PostedFile.ContentType;

                    byte[] imgBinaryData = new byte[imgLen];
                    imgStream.Read(imgBinaryData, 0, imgLen);

                    SqlCommand myCommand = new SqlCommand();

                    myCommand.Parameters.AddWithValue("@nome", ((TextBox)e.Item.FindControl("tb_nome")).Text);
                    myCommand.Parameters.AddWithValue("@cargo", ((TextBox)e.Item.FindControl("tb_cargo")).Text);
                    myCommand.Parameters.AddWithValue("@linkface", ((TextBox)e.Item.FindControl("tb_linkface")).Text);
                    myCommand.Parameters.AddWithValue("@linkinsta", ((TextBox)e.Item.FindControl("tb_linkinsta")).Text);
                    myCommand.Parameters.AddWithValue("@linktwitter", ((TextBox)e.Item.FindControl("tb_linktwitter")).Text);
                    myCommand.Parameters.AddWithValue("@linklinkedin", ((TextBox)e.Item.FindControl("tb_linklinkedin")).Text);
                    myCommand.Parameters.AddWithValue("@imagem", imgBinaryData);
                    myCommand.Parameters.AddWithValue("@contenttype", imgContentType);
                    myCommand.Parameters.AddWithValue("@cod_funcionario", ((ImageButton)e.Item.FindControl("btn_grava")).CommandArgument);

                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.CommandText = "editar_funcionario";

                    myCommand.Connection = myConn;
                    myCommand.ExecuteNonQuery();
                }
                else
                {
                    string query = "UPDATE funcionario SET ";
                    query += " nome='" + ((TextBox)e.Item.FindControl("tb_nome")).Text + "',";
                    query += " cargo='" + ((TextBox)e.Item.FindControl("tb_cargo")).Text + "',";
                    query += " linkface='" + ((TextBox)e.Item.FindControl("tb_linkface")).Text + "',";
                    query += " linkinsta='" + ((TextBox)e.Item.FindControl("tb_linkinsta")).Text + "',";
                    query += " linktwitter='" + ((TextBox)e.Item.FindControl("tb_linktwitter")).Text + "',";
                    query += " linklinkedin='" + ((TextBox)e.Item.FindControl("tb_linklinkedin")).Text + "'";
                    query += " WHERE cod_funcionario=" + ((ImageButton)e.Item.FindControl("btn_grava")).CommandArgument;

                    SqlCommand myCommand = new SqlCommand(query, myConn);
                    myCommand.ExecuteNonQuery();
                }
            }

            if (e.CommandName.Equals("btn_apaga"))
            {
                string querydel = "DELETE FROM funcionario";
                querydel += " WHERE cod_funcionario=" + ((ImageButton)e.Item.FindControl("btn_apaga")).CommandArgument;

                SqlCommand myCommand = new SqlCommand(querydel, myConn);
                myCommand.ExecuteNonQuery();
            }
            myConn.Close();
            Response.Redirect("editfuncionario.aspx");
        }
    }
}