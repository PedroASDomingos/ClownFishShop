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
    public partial class addfuncionario : System.Web.UI.Page
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
                Stream imgStream = FileUpload1.PostedFile.InputStream;
                int imgLen = FileUpload1.PostedFile.ContentLength;
                string imgContentType = FileUpload1.PostedFile.ContentType;

                byte[] imgBinaryData = new byte[imgLen];
                imgStream.Read(imgBinaryData, 0, imgLen);

                SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["ClownfishDBConnectionString"].ConnectionString);
                SqlCommand myCommand = new SqlCommand();

                myCommand.Parameters.AddWithValue("@nome", tb_nome.Text);
                myCommand.Parameters.AddWithValue("@cargo", tb_cargo.Text);
                myCommand.Parameters.AddWithValue("@linkface", tb_face.Text);
                myCommand.Parameters.AddWithValue("@linkinsta", tb_insta.Text);
                myCommand.Parameters.AddWithValue("@linktwitter", tb_twitter.Text);
                myCommand.Parameters.AddWithValue("@linklinkedin", tb_linkedin.Text);
                myCommand.Parameters.AddWithValue("@imagem", imgBinaryData);
                myCommand.Parameters.AddWithValue("@contenttype", imgContentType);

                //parametro de output
                SqlParameter valor = new SqlParameter();
                valor.ParameterName = "@retorno";
                valor.Direction = ParameterDirection.Output;
                valor.SqlDbType = SqlDbType.Int;

                myCommand.Parameters.Add(valor);

                myCommand.CommandType = CommandType.StoredProcedure;
                myCommand.CommandText = "inserir_funcionario";

                myCommand.Connection = myConn;
                myConn.Open();
                myCommand.ExecuteNonQuery();

                int respostaSP = Convert.ToInt32(myCommand.Parameters["@retorno"].Value);

                myConn.Close();

                if (respostaSP == 1)
                {
                    lbl_mensagem.Text = "Funcionário insrido com sucesso!";
                    tb_nome.Text = string.Empty;
                    tb_cargo.Text = string.Empty;
                    tb_face.Text = string.Empty;
                    tb_insta.Text = string.Empty; 
                    tb_twitter.Text = string.Empty; 
                    tb_linkedin.Text = string.Empty;
                }
                else
                    lbl_mensagem.Text = "Erro ao inserir o funcionário...";
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}