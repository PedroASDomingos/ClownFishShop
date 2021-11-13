<%@ Page Title="" Language="C#" MasterPageFile="~/CMS/cms.Master" AutoEventWireup="true" CodeBehind="newsletter.aspx.cs" Inherits="ExercicioLojaOnline.CMS.newsletter" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section class="contact_area section_gap_bottom">
		<div class="container">
			<div id="mapBox" class="mapBox" data-lat="38.702143" data-lon="-9.1881536" data-zoom="15" data-info="Pólo de Educação e Formação D. João de Castro, R. Jau, 1300-312, Lisboa, Portugal"
			 data-mlat="38.702143" data-mlon="-9.1881536">
			</div>
			<div class="row">
				<div class="col-lg-9">
					<div class="row contact_form" action="contact_process.php" method="post" id="contactForm" novalidate="novalidate">
						<div class="col-md-12">
							<div class="form-group">
								<h3>Enviar email Assinantes da Newsletter</h3>
							</div>
						</div>
						<div class="col-md-12">
							<div class="form-group">
								<asp:TextBox ID="tb_subject" class="form-control" placeholder="Introduza o assunto" onfocus="this.placeholder = ''" onblur="this.placeholder = 'Introduza o assunto'" runat="server" required="true"></asp:TextBox>
							</div>
						</div>
						<div class="col-md-12">
							<div class="form-group">
								<asp:TextBox ID="tb_message" class="form-control" runat="server" rows="1" placeholder="Digite a mensagem" onfocus="this.placeholder = ''" onblur="this.placeholder = 'Digite a mensagem'" TextMode="MultiLine" required="true"></asp:TextBox>
							</div>
						</div>
						<div class="col-md-12">
							<asp:Button ID="btn_submit" class="primary-btn" runat="server" Text="Enviar mensagem" OnClick="btn_submit_Click"  />
						</div>
							<div class="col-md-6">
							<div class="form-group">
								<asp:Label ID="lbl_mensage" runat="server" Text=""></asp:Label>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
	</section>
</asp:Content>
