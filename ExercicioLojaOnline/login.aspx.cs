using ExercicioLojaOnline.Models;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Web.UI;

namespace ExercicioLojaOnline
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btn_submit_Click(object sender, EventArgs e)
        {
            SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["ClownfishDBConnectionString"].ConnectionString);
            SqlCommand myCommand = new SqlCommand();

            myCommand.Parameters.AddWithValue("@utilizador", tb_user.Text);
            myCommand.Parameters.AddWithValue("@palavra_pass", EncryptString(tb_pass.Text));

            //parametro de output
            SqlParameter valor = new SqlParameter();
            valor.ParameterName = "@retorno";
            valor.Direction = ParameterDirection.Output;
            valor.SqlDbType = SqlDbType.Int;

            myCommand.Parameters.Add(valor);

            SqlParameter valor_perfil = new SqlParameter();
            valor_perfil.ParameterName = "@retorno_perfil";
            valor_perfil.Direction = ParameterDirection.Output;
            valor_perfil.SqlDbType = SqlDbType.VarChar;
            valor_perfil.Size = 50;

            myCommand.Parameters.Add(valor_perfil);

            SqlParameter valor_id = new SqlParameter();
            valor_id.ParameterName = "@retorno_id";
            valor_id.Direction = ParameterDirection.Output;
            valor_id.SqlDbType = SqlDbType.Int;

            myCommand.Parameters.Add(valor_id);

            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.CommandText = "loginSP";

            myCommand.Connection = myConn;
            myConn.Open();
            myCommand.ExecuteNonQuery();

            int respostaSP = Convert.ToInt32(myCommand.Parameters["@retorno"].Value);
            string respostaSP_perfil = myCommand.Parameters["@retorno_perfil"].Value.ToString();
            int respostaSP_ID = Convert.ToInt32(myCommand.Parameters["@retorno_id"].Value);

            myConn.Close();
            if (respostaSP == 1)
            {
                Session["utlizador"] = tb_user.Text;
                Session["perfil"] = respostaSP_perfil;
                Session["idUtilizador"] = respostaSP_ID;
                Utilizador.AddUser(respostaSP_ID);
                ItemCarrinho.ConstroiCarrinhoCompras(respostaSP_ID);
                Response.Redirect("perfilUser.aspx");
            }
            else
                lbl_mensagem.Text = "Esse utilizador ou pw errados!";
        }

        public static string EncryptString(string Message)
        {
            string Passphrase = "clownfishstore";
            byte[] Results;
            System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();

            // Step 1. We hash the passphrase using MD5
            // We use the MD5 hash generator as the result is a 128 bit byte array
            // which is a valid length for the TripleDES encoder we use below

            MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();
            byte[] TDESKey = HashProvider.ComputeHash(UTF8.GetBytes(Passphrase));

            // Step 2. Create a new TripleDESCryptoServiceProvider object
            TripleDESCryptoServiceProvider TDESAlgorithm = new TripleDESCryptoServiceProvider();

            // Step 3. Setup the encoder
            TDESAlgorithm.Key = TDESKey;
            TDESAlgorithm.Mode = CipherMode.ECB;
            TDESAlgorithm.Padding = PaddingMode.PKCS7;

            // Step 4. Convert the input string to a byte[]
            byte[] DataToEncrypt = UTF8.GetBytes(Message);

            // Step 5. Attempt to encrypt the string
            try
            {
                ICryptoTransform Encryptor = TDESAlgorithm.CreateEncryptor();
                Results = Encryptor.TransformFinalBlock(DataToEncrypt, 0, DataToEncrypt.Length);
            }
            finally
            {
                // Clear the TripleDes and Hashprovider services of any sensitive information
                TDESAlgorithm.Clear();
                HashProvider.Clear();
            }

            // Step 6. Return the encrypted string as a base64 encoded string

            string enc = Convert.ToBase64String(Results);
            enc = enc.Replace("+", "KKK");
            enc = enc.Replace("/", "JJJ");
            enc = enc.Replace("\\", "III");
            return enc;
        }

    }
}