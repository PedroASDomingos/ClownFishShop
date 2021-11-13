using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Security.Cryptography;

namespace ExercicioLojaOnline
{
    public partial class registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_submit_Click(object sender, EventArgs e)
        {
            if (tb_pass.Text != tb_confirmPass.Text)
            {
                lbl_mensagem.Text = "Password não coicide com a confirmação";
                return;
            }

            SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["ClownfishDBConnectionString"].ConnectionString);
            SqlCommand myCommand = new SqlCommand();

            myCommand.Parameters.AddWithValue("@utilizador", tb_user.Text);
            myCommand.Parameters.AddWithValue("@palavra_pass", EncryptString(tb_pass.Text));
            myCommand.Parameters.AddWithValue("@email", tb_email.Text);

            //parametro de output
            SqlParameter valor = new SqlParameter();
            valor.ParameterName = "@retorno";
            valor.Direction = ParameterDirection.Output;
            valor.SqlDbType = SqlDbType.Int;

            myCommand.Parameters.Add(valor);

            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.CommandText = "registo_utilizador";

            myCommand.Connection = myConn;
            myConn.Open();
            myCommand.ExecuteNonQuery();
            int respostaSP = Convert.ToInt32(myCommand.Parameters["@retorno"].Value);

            myConn.Close();
            if (respostaSP != 0)
            {
                string cod_encriptado = EncryptString(respostaSP.ToString());
                lbl_mensagem.Text = "Registo efetuado com sucesso, verifique o seu email!";
                EnviaEmailAtivacao(tb_email.Text, cod_encriptado);
            }
            else
                lbl_mensagem.Text = "Utilizador já existe!";
        }

        static void EnviaEmailAtivacao(string email, string codencriptado)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.office365.com");

                mail.From = new MailAddress("pedro.domingos.21734@formandos.cinel.pt");
                mail.To.Add(new MailAddress(email));
                mail.Subject = "ClownFish - Ativação de conta";
                mail.Body = "Para ativar a sua conta clique <a href='https://localhost:44398/ativar.aspx?id="+ codencriptado + "'>AQUI</a>";
                                                               
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