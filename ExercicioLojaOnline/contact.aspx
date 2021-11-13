<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="contact.aspx.cs" Inherits="ExercicioLojaOnline.contact" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Start Banner Area -->
	<section class="banner-area organic-breadcrumb">
		<div class="container">
			<div class="breadcrumb-banner d-flex flex-wrap align-items-center justify-content-end">
				<div class="col-first">
					<h1>Contact Us</h1>
					<nav class="d-flex align-items-center">
						<a href="index.aspx">Home<span class="lnr lnr-arrow-right"></span></a>
						<a href="contact.aspx">Contactos</a>
					</nav>
				</div>
			</div>
		</div>
	</section>
	<!-- End Banner Area -->

	<!--================Contact Area =================-->
	<section class="contact_area section_gap_bottom">
		<div class="container">
			<div id="mapBox" class="mapBox" data-lat="38.702143" data-lon="-9.1881536" data-zoom="15" data-info="Pólo de Educação e Formação D. João de Castro, R. Jau, 1300-312, Lisboa, Portugal"
			 data-mlat="38.702143" data-mlon="-9.1881536">
			</div>
			<div class="row">
				<div class="col-lg-3">
					<div class="contact_info">
						<div class="info_item">
							<i class="lnr lnr-home"></i>
							<h6>Lisboa, Portugal</h6>
							<p>Rua Jau - Alto de Santo Amaro <br> 1300-312 Lisboa</p>
						</div>
						<div class="info_item">
							<i class="lnr lnr-phone-handset"></i>
							<h6><a href="#">(+351) 21 49 67 700</a></h6>
							<p>De segunda a sexta <br>das 8:30-12:30 e 13:30-22:00</p>
						</div>
						<div class="info_item">
							<i class="lnr lnr-envelope"></i>
							<h6><a href="#">geral@clownfish.pt</a></h6>
							<p>Envie-nos a sua mensagem a qualquer hora!</p>
						</div>
					</div>
				</div>
				<div class="col-lg-9">
					<div class="row contact_form" action="contact_process.php" method="post" id="contactForm" novalidate="novalidate">
						<div class="col-md-6">
							<div class="form-group">
								<asp:TextBox ID="tb_name" class="form-control" placeholder="Introduza o seu nome" onfocus="this.placeholder = ''" onblur="this.placeholder = 'Introduza o seu nome'" runat="server" required="true"></asp:TextBox>
							</div>
							<div class="form-group">
								<asp:TextBox ID="tb_email" class="form-control" TextMode="Email" placeholder="Introduza o seu email" onfocus="this.placeholder = ''" onblur="this.placeholder = 'Introduza o seu email'" runat="server" required="true"></asp:TextBox>
							</div>
							<div class="form-group">
								<asp:TextBox ID="tb_subject" class="form-control" placeholder="Introduza o assunto" onfocus="this.placeholder = ''" onblur="this.placeholder = 'Introduza o assunto'" runat="server" required="true"></asp:TextBox>
							</div>
						</div>
						<div class="col-md-6">
							<div class="form-group">
								<asp:TextBox ID="tb_message" class="form-control" runat="server" rows="1" placeholder="Digite a mensagem" onfocus="this.placeholder = ''" onblur="this.placeholder = 'Digite a mensagem'" TextMode="MultiLine" required="true"></asp:TextBox>
							</div>
						</div>
						<div class="col-md-12 text-right">
							<asp:Button ID="btn_submit" class="primary-btn" runat="server" Text="Enviar mensagem" OnClick="btn_submit_Click" />
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
	<!--================Contact Area =================-->
</asp:Content>
