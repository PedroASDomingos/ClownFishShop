using ExercicioLojaOnline.Models;
using iTextSharp.text.pdf;
using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Web.UI.WebControls;

namespace ExercicioLojaOnline
{
    public partial class cart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Repeater1.DataSource = ItemCarrinho.ListaCarrinhoCompras;
            Repeater1.DataBind();


            double Total = 0;
            foreach (var item in ItemCarrinho.ListaCarrinhoCompras)
            {
                foreach (var produto in Produto.ListaProdutos)
                {
                    if (item.cod_produto == produto.cod_produto)
                    {
                        Total = Total + produto.preco;
                    }
                }
            }

            lbl_total.Text =(Total + "€").ToString();
        }
 

        public string GetImageProduto(object idproduto)
        {
            int id = Convert.ToInt32(idproduto);

            foreach (var item in Produto.ListaProdutos)
            {
                if (id == item.cod_produto)
                {
                    return "data:" + item.contenttype + ";base64," + Convert.ToBase64String((byte[])item.imagem);
                }
            }
            return "No image!";
        }
        public string GetNomeProduto(object idproduto)
        {
            int id = Convert.ToInt32(idproduto);

            foreach (var item in Produto.ListaProdutos)
            {
                if (id == item.cod_produto)
                {
                    return item.nome_produto;
                }
            }
            return "No Name!";
        }

        public string GetNomePreco(object idproduto)
        {
            int id = Convert.ToInt32(idproduto);

            foreach (var item in Produto.ListaProdutos)
            {
                if (id == item.cod_produto)
                {
                    return item.preco.ToString();
                }
            }
            return "No Name!";
        }
        public string GetQuantidadeProduto(object idproduto)
        {
            int id = Convert.ToInt32(idproduto);

            foreach (var item in Produto.ListaProdutos)
            {
                if (id == item.cod_produto)
                {
                    return item.quantidade.ToString();
                }
            }
            return "1";
        }
        public string GetTotal(object idproduto)
        {
            int id = Convert.ToInt32(idproduto);

            foreach (var item in Produto.ListaProdutos)
            {
                if (id == item.cod_produto)
                {
                    return ((item.preco* 1) +"€").ToString();
                }
            }
            
            return "0€";
        } //
        protected void btn_apaga_Click(object sender, EventArgs e)
        {
            ImageButton btn = (ImageButton)(sender);
            string yourValue = btn.CommandArgument;

            int codproduto = Convert.ToInt32(yourValue);

            int codcliente = Convert.ToInt32(Session["idUtilizador"]);

            ItemCarrinho.RemoveProdutoCarrinho(codproduto, codcliente);
            var resposta = ItemCarrinho.RemoveBD(codproduto, codcliente);

            if (resposta == 1)
            {
                Response.Redirect("cart.aspx");
            }
        }

        protected void btn_continuar_Click(object sender, EventArgs e)
        {
            Response.Redirect("shop.aspx");
        }

        protected void btn_checkout_Click(object sender, EventArgs e)
        {
            if (Session["idUtilizador"] == null)
            {
                Response.Redirect("login.aspx");
            }
            if (ItemCarrinho.ListaCarrinhoCompras == null)
            {
                return;
            }
            Guid numFatura = Guid.NewGuid();
            var data = DateTime.Now;
            CriaPDF(numFatura, data);
            foreach (var item in ItemCarrinho.ListaCarrinhoCompras)
            {
                Compras.AtualizaBDFatruas(numFatura.ToString(), data.ToString(), item.cod_produto, item.quantidade, item.cod_cliente);
            }
            foreach (var item in ItemCarrinho.ListaCarrinhoCompras)
            {
                ItemCarrinho.RemoveBD(item.cod_produto, item.cod_cliente);
            }

            ItemCarrinho.ListaCarrinhoCompras.Clear();

            Compras.ConstroiListaFaturas(Convert.ToInt32(Session["idUtilizador"]));

            Response.Redirect("cart.aspx");
        }

        private void CriaPDF(Guid numFatura, DateTime data)
        {
            string caminhoSite = Server.MapPath("~/");
            string caminhoPDFS = caminhoSite + "PDFS\\";
            string pdfTemplate = caminhoPDFS + "Template\\fatura.pdf";
            string nomePDF = numFatura + ".pdf";
            string newFile = caminhoPDFS + nomePDF;

            PdfReader pdfreader = new PdfReader(pdfTemplate);
            PdfStamper pdfStamper = new PdfStamper(pdfreader, new FileStream(newFile, FileMode.Create));
            AcroFields camposPDF = pdfStamper.AcroFields;

            camposPDF.SetField("NumFatura", numFatura.ToString());
            camposPDF.SetField("Nome", Utilizador.user.nome.ToString());
            camposPDF.SetField("Morada", Utilizador.user.morada.ToString());
            camposPDF.SetField("Nif", Utilizador.user.nif.ToString());
            camposPDF.SetField("Data", data.ToString());
            camposPDF.SetField("TotalFinal", lbl_total.Text);
            
            var i = 1;
            foreach (var item in ItemCarrinho.ListaCarrinhoCompras)
            {
                camposPDF.SetField("Ref" + i, item.cod_produto.ToString());
                foreach (var produto in Produto.ListaProdutos)
                {
                    if (item.cod_produto == produto.cod_produto)
                    {
                        camposPDF.SetField("Descricao" + i, produto.nome_produto.ToString());
                        camposPDF.SetField("Total" + i, produto.preco.ToString());
                    }
                }
                camposPDF.SetField("Quantidade"+i, item.quantidade.ToString());
                i = i + 1;
            }
            
            pdfStamper.Close();

            var Ficheiro = caminhoPDFS + nomePDF;

            EnviaEmail(Utilizador.user.email, Ficheiro, data);

            //System.Diagnostics.Process.Start(caminhoPDFS + nomePDF);
        }

        private void EnviaEmail(string email, string ficheiro, DateTime data)
        {
            SmtpClient sc = new SmtpClient();
            MailMessage m = new MailMessage();

            m.From = new MailAddress("pedro.domingos.21734@formandos.cinel.pt");
            m.To.Add(new MailAddress(email));
            m.Subject = "ClownFish: Envio de factura";
            m.IsBodyHtml = true;
            m.Body = "Caro cliente, enviamos em anexo a fatura referente a sua compra de " + data;

            Attachment att = new Attachment(ficheiro);
            m.Attachments.Add(att);

            sc.Host = "smtp.office365.com";
            sc.Port = 587;
            sc.Credentials = new NetworkCredential("pedro.domingos.21734@formandos.cinel.pt", "Domingos1404");
            sc.EnableSsl = true;

            sc.Send(m);
        }
    }
}