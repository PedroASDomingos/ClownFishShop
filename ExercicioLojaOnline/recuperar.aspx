<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="recuperar.aspx.cs" Inherits="ExercicioLojaOnline.recuperar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Start Banner Area -->
	<section class="banner-area organic-breadcrumb">
		<div class="container">
			<div class="breadcrumb-banner d-flex flex-wrap align-items-center justify-content-end">
				<div class="col-first">
					<h1>Recuperar Palavra-pass</h1>
					<nav class="d-flex align-items-center">
						<a href="index.aspx">Home<span class="lnr lnr-arrow-right"></span></a>
						<a href="login.aspx">Recuperar</a>
					</nav>
				</div>
			</div>
		</div>
	</section>
	<!-- End Banner Area -->
	<section class="login_box_area section_gap">
		<div class="container">
			<div class="row">
				<div class="col-lg-6">
					<div >
						<img  src="img/fish5.png" alt="">
						
					</div>
				</div>
				<div class="col-lg-6">
					<div class="login_form_inner">
						<h3>Introduza o seu email</h3>
						<section class="row login_form" action="contact_process.php" method="post" id="contactForm" novalidate="novalidate">
							<div class="col-md-12 form-group">
								<asp:TextBox ID="tb_email" class="form-control" runat="server" TextMode="Email" placeholder="Email" onfocus="this.placeholder = ''" onblur="this.placeholder = 'Email'"></asp:TextBox>
							</div>
							
							<div class="col-md-12 form-group">
								<asp:Button ID="btn_submit" class="primary-btn" runat="server" Text="Recuperar" OnClick="btn_submit_Click" />
							</div>
							<div class="col-md-12 form-group">
								<div class="creat_account">
									<asp:Label ID="lbl_mensagem" runat="server" Text=""></asp:Label>
								</div>
							</div>
						</section>
					</div>
				</div>
			</div>
		</div>
	</section>
	<!--================End Login Box Area =================-->
</asp:Content>
