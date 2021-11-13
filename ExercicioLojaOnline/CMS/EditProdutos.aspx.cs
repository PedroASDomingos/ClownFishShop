using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web.UI.WebControls;

namespace ExercicioLojaOnline.CMS
{
    public partial class EditProdutos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["utilizador"] == null)
            {
                Response.Redirect("login.aspx");
            }
        }

        protected void rpt_editprod_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DataRowView dr = (DataRowView)e.Item.DataItem;

                ((Label)e.Item.FindControl("lbl_cod")).Text = dr["cod_produto"].ToString();
                ((TextBox)e.Item.FindControl("tb_nome")).Text = dr["nome_produto"].ToString();
                ((TextBox)e.Item.FindControl("tb_nomeC")).Text = dr["nome_cientifico"].ToString();
                ((DropDownList)e.Item.FindControl("ddl_categoria")).SelectedValue = dr["cod_categoria"].ToString();
                ((TextBox)e.Item.FindControl("tb_preco")).Text = dr["preco"].ToString();
                ((TextBox)e.Item.FindControl("tb_descricao")).Text = dr["descricao_produto"].ToString();
                ((DropDownList)e.Item.FindControl("ddl_iva")).SelectedValue = dr["cod_tx_iva"].ToString();
                ((TextBox)e.Item.FindControl("tb_quantidade")).Text = dr["quantidade"].ToString();
                ((ImageButton)e.Item.FindControl("btn_grava")).CommandArgument = dr["cod_produto"].ToString();
                ((ImageButton)e.Item.FindControl("btn_apaga")).CommandArgument = dr["cod_produto"].ToString();
            }
        }

        protected void rpt_editprod_ItemCommand(object source, RepeaterCommandEventArgs e)
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

                    myCommand.Parameters.AddWithValue("@nome_produto", ((TextBox)e.Item.FindControl("tb_nome")).Text);
                    myCommand.Parameters.AddWithValue("@nome_cientifico", ((TextBox)e.Item.FindControl("tb_nomeC")).Text);
                    myCommand.Parameters.AddWithValue("@cod_categoria", ((DropDownList)e.Item.FindControl("ddl_categoria")).SelectedValue);
                    myCommand.Parameters.AddWithValue("@preco", ((TextBox)e.Item.FindControl("tb_preco")).Text);
                    myCommand.Parameters.AddWithValue("@descricao_produto", ((TextBox)e.Item.FindControl("tb_descricao")).Text);
                    myCommand.Parameters.AddWithValue("@cod_tx_iva", ((DropDownList)e.Item.FindControl("ddl_iva")).SelectedValue);
                    myCommand.Parameters.AddWithValue("@quantidade", ((TextBox)e.Item.FindControl("tb_quantidade")).Text);
                    myCommand.Parameters.AddWithValue("@imagem", imgBinaryData);
                    myCommand.Parameters.AddWithValue("@contenttype", imgContentType);
                    myCommand.Parameters.AddWithValue("@cod_produto", ((ImageButton)e.Item.FindControl("btn_grava")).CommandArgument);

                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.CommandText = "editar_produto";

                    myCommand.Connection = myConn;
                    myCommand.ExecuteNonQuery();
                }
                else
                {
                    string query = "UPDATE produto SET ";
                    query += " nome_produto='" + ((TextBox)e.Item.FindControl("tb_nome")).Text + "',";
                    query += " nome_cientifico='" + ((TextBox)e.Item.FindControl("tb_nomeC")).Text + "',";
                    query += " cod_categoria='" + ((DropDownList)e.Item.FindControl("ddl_categoria")).SelectedValue + "',";
                    query += " preco='" + ((TextBox)e.Item.FindControl("tb_preco")).Text + "',";
                    query += " descricao_produto='" + ((TextBox)e.Item.FindControl("tb_descricao")).Text + "',";
                    query += " cod_tx_iva='" + ((DropDownList)e.Item.FindControl("ddl_iva")).SelectedValue + "',";
                    query += " quantidade='" + ((TextBox)e.Item.FindControl("tb_quantidade")).Text + "'";
                    query += " WHERE cod_produto=" + ((ImageButton)e.Item.FindControl("btn_grava")).CommandArgument;

                    SqlCommand myCommand = new SqlCommand(query, myConn);
                    myCommand.ExecuteNonQuery();
                }
            }

            if (e.CommandName.Equals("btn_apaga"))
            {
                string querydel = "DELETE FROM produto";
                querydel += " WHERE cod_produto=" + ((ImageButton)e.Item.FindControl("btn_apaga")).CommandArgument;

                SqlCommand myCommand = new SqlCommand(querydel, myConn);
                myCommand.ExecuteNonQuery();
            }
            myConn.Close();
        }
    }
}