using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExercicioLojaOnline.CMS
{
    public partial class addproduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["utilizador"] == null)
            {
                Response.Redirect("login.aspx");
            }
        }

        protected void btn_submit_Click(object sender, EventArgs e)
        {
            try
            {
                double afterDiscount = 0;

                Stream imgStream = FileUpload1.PostedFile.InputStream;
                int imgLen = FileUpload1.PostedFile.ContentLength;
                string imgContentType = FileUpload1.PostedFile.ContentType;

                byte[] imgBinaryData = new byte[imgLen];
                imgStream.Read(imgBinaryData, 0, imgLen);

                SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["ClownfishDBConnectionString"].ConnectionString);
                SqlCommand myCommand = new SqlCommand();

                myCommand.Parameters.AddWithValue("@nome_produto", tb_nomeProduto.Text);
                myCommand.Parameters.AddWithValue("@nome_cientifico", tb_nomeCientifico.Text);
                myCommand.Parameters.AddWithValue("@cod_categoria", ddl_categoria.SelectedValue);
                myCommand.Parameters.AddWithValue("@preco", tb_preco.Text);

                if (tb_preco.Text != null)
                {
                    var preco = Convert.ToInt32(tb_preco.Text);
                    afterDiscount = preco - (preco * 0.2);
                }
                
                myCommand.Parameters.AddWithValue("@preco_promocao", afterDiscount);
                myCommand.Parameters.AddWithValue("@descricao_produto", tb_descricao.Text);
                myCommand.Parameters.AddWithValue("@imagem", imgBinaryData);
                myCommand.Parameters.AddWithValue("@contenttype", imgContentType);
                myCommand.Parameters.AddWithValue("@cod_tx_iva", ddl_iva.SelectedValue);
                myCommand.Parameters.AddWithValue("@quantidade", tb_quantidade.Text);

                //parametro de output
                SqlParameter valor = new SqlParameter();
                valor.ParameterName = "@retorno";
                valor.Direction = ParameterDirection.Output;
                valor.SqlDbType = SqlDbType.Int;

                myCommand.Parameters.Add(valor);

                myCommand.CommandType = CommandType.StoredProcedure;
                myCommand.CommandText = "inserir_produto";

                myCommand.Connection = myConn;
                myConn.Open();
                myCommand.ExecuteNonQuery();

                int respostaSP = Convert.ToInt32(myCommand.Parameters["@retorno"].Value);

                myConn.Close();

                if (respostaSP == 1)
                {
                    lbl_mensagem.Text = "Produto insrido com sucesso!";
                    tb_nomeProduto.Text = string.Empty;
                    tb_nomeCientifico.Text = string.Empty;
                    tb_preco.Text = string.Empty;
                    tb_descricao.Text = string.Empty;
                    tb_quantidade.Text = string.Empty;
                }
                else
                    lbl_mensagem.Text = "Erro ao inserir o produto...";
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}