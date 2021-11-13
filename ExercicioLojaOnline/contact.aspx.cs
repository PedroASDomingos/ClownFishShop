using System;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;

namespace ExercicioLojaOnline
{
    public partial class contact : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btn_submit_Click(object sender, EventArgs e)
        {
                try
                {
                    MailMessage mail = new MailMessage();
                    SmtpClient SmtpServer = new SmtpClient("smtp.office365.com");

                    mail.From = new MailAddress("pedro.domingos.21734@formandos.cinel.pt");
                    mail.To.Add("pedro.domingos.21734@formandos.cinel.pt");
                    mail.Subject = "ClownFish Shop - Contact: " + tb_subject.Text;
                    mail.Body = "O utilizador com o nome: " + tb_name.Text + " e email: " + tb_email.Text + " , enviou a seguinte mensagem: " + tb_message.Text;

                    SmtpServer.Port = 587;
                    SmtpServer.Credentials = new System.Net.NetworkCredential("pedro.domingos.21734@formandos.cinel.pt", "Domingos1404");
                    SmtpServer.EnableSsl = true;

                    SmtpServer.Send(mail);
                    lbl_mensage.Text = "Email enviado às " + DateTime.Now.ToString();
                }
                catch (Exception ex)
                {
                    lbl_mensage.Text = ex.ToString();
                }
        }
    }
}