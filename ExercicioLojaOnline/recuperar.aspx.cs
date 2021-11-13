using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Security.Cryptography;

namespace ExercicioLojaOnline
{
    public partial class recuperar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btn_submit_Click(object sender, EventArgs e)
        {
            SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["ClownfishDBConnectionString"].ConnectionString);
            SqlCommand myCommand = new SqlCommand();

            myCommand.Parameters.AddWithValue("@email", tb_email.Text);

            //parametro de output
            SqlParameter valor = new SqlParameter();
            valor.ParameterName = "@retorno";
            valor.Direction = ParameterDirection.Output;
            valor.SqlDbType = SqlDbType.Int;

            myCommand.Parameters.Add(valor);

            SqlParameter valor_user = new SqlParameter();
            valor_user.ParameterName = "@retorno_user";
            valor_user.Direction = ParameterDirection.Output;
            valor_user.SqlDbType = SqlDbType.VarChar;
            valor_user.Size = 50;

            myCommand.Parameters.Add(valor_user);

            SqlParameter valor_pass = new SqlParameter();
            valor_pass.ParameterName = "@retorno_pass";
            valor_pass.Direction = ParameterDirection.Output;
            valor_pass.SqlDbType = SqlDbType.VarChar;
            valor_pass.Size = 50;

            myCommand.Parameters.Add(valor_pass);

            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.CommandText = "recuperacaoSP";

            myCommand.Connection = myConn;
            myConn.Open();
            myCommand.ExecuteNonQuery();

            int respostaSP = Convert.ToInt32(myCommand.Parameters["@retorno"].Value);
            string respostaSP_user = myCommand.Parameters["@retorno_user"].Value.ToString();
            string respostaSP_pass = myCommand.Parameters["@retorno_pass"].Value.ToString();

            myConn.Close();
            if (respostaSP == 1)
            {
                EnviaEmail(respostaSP_user, respostaSP_pass);
                lbl_mensagem.Text = "Email enviado com sucesso as " + DateTime.Now;
            }
            else
                lbl_mensagem.Text = "Esse email não se encontra registado!";
        }

        private void EnviaEmail(string user, string passEncriptada)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.office365.com");

                mail.From = new MailAddress("pedro.domingos.21734@formandos.cinel.pt");
                mail.To.Add(new MailAddress(tb_email.Text));
                mail.Subject = "ClownFish - Recuperaçã de Palavra-pass";
                mail.Body = "Enviamos a palavra-pass: " + DecryptString(passEncriptada) + " referente ao Nome de utilizador: " + user ;

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("pedro.domingos.21734@formandos.cinel.pt", "Domingos1404");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);

            }
            catch (Exception)
            {
                throw;
            }
        }
        public static string DecryptString(string Message)
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

            // Step 3. Setup the decoder
            TDESAlgorithm.Key = TDESKey;
            TDESAlgorithm.Mode = CipherMode.ECB;
            TDESAlgorithm.Padding = PaddingMode.PKCS7;

            // Step 4. Convert the input string to a byte[]

            Message = Message.Replace("KKK", "+");
            Message = Message.Replace("JJJ", "/");
            Message = Message.Replace("III", "\\");


            byte[] DataToDecrypt = Convert.FromBase64String(Message);

            // Step 5. Attempt to decrypt the string
            try
            {
                ICryptoTransform Decryptor = TDESAlgorithm.CreateDecryptor();
                Results = Decryptor.TransformFinalBlock(DataToDecrypt, 0, DataToDecrypt.Length);
            }
            finally
            {
                // Clear the TripleDes and Hashprovider services of any sensitive information
                TDESAlgorithm.Clear();
                HashProvider.Clear();
            }

            // Step 6. Return the decrypted string in UTF8 format
            return UTF8.GetString(Results);
        }

    }
}