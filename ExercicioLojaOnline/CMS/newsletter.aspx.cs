using ExercicioLojaOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExercicioLojaOnline.CMS
{
    public partial class newsletter : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_submit_Click(object sender, EventArgs e)
        {
            Newsletter.ConstroiListaNewsletter();

            if (Newsletter.ListaNewsletter == null)
            {
                lbl_mensage.Text = "Não há emails na base de dados!";
                return;
            }
            foreach (var item in Newsletter.ListaNewsletter)
            {

                try
                {
                    MailMessage mail = new MailMessage();
                    SmtpClient SmtpServer = new SmtpClient("smtp.office365.com");

                    mail.From = new MailAddress("pedro.domingos.21734@formandos.cinel.pt");
                    mail.To.Add(item.email);
                    mail.Subject = "ClownFish Shop - Newsletter: " + tb_subject.Text;
                    mail.Body = tb_message.Text;

                    SmtpServer.Port = 587;
                    SmtpServer.Credentials = new System.Net.NetworkCredential("pedro.domingos.21734@formandos.cinel.pt", "Domingos1404");
                    SmtpServer.EnableSsl = true;

                    SmtpServer.Send(mail);
                    lbl_mensage.Text = "Emails enviado às " + DateTime.Now.ToString();
                }
                catch (Exception ex)
                {
                    lbl_mensage.Text = ex.ToString();
                }
            }
        }
    }
}