<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="registration.aspx.cs" Inherits="ExercicioLojaOnline.registration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Start Banner Area -->
	<section class="banner-area organic-breadcrumb">
		<div class="container">
			<div class="breadcrumb-banner d-flex flex-wrap align-items-center justify-content-end">
				<div class="col-first">
					<h1>Novo Registo</h1>
					<nav class="d-flex align-items-center">
						<a href="index.aspx">Home<span class="lnr lnr-arrow-right"></span></a>
						<a href="registration.aspx">Registo</a>
					</nav>
				</div>
			</div>
		</div>
	</section>
	<!-- End Banner Area -->
	<!--================Login Box Area =================-->
	<section class="login_box_area section_gap">
		<div class="container">
			<div class="row">
				<div class="col-lg-6">
					<div class="login_box_img">
						<img class="img-fluid" src="img/login.jpg" alt="">
						<div class="hover">
							<h4></h4>
							
						</div>
					</div>
				</div>
				<div class="col-lg-6">
					<div class="login_form_inner">
						<h3>Faça o seu registo!</h3>
						<section class="row login_form" action="contact_process.php" method="post" id="contactForm" novalidate="novalidate">
							<div class="col-md-12 form-group">
								<table>
								<tr>
									<td>Nome de Utilizador:</td>
									<td><asp:TextBox ID="tb_user" class="form-control" runat="server"></asp:TextBox></td>
								</tr>
								<tr>
									<td>Password:</td>
									<td><asp:TextBox ID="tb_pass" class="form-control" runat="server" TextMode="Password"></asp:TextBox></td>
								</tr>
								<tr>
									<td>Confirme Password:</td>
									<td><asp:TextBox ID="tb_confirmPass" class="form-control" runat="server" TextMode="Password"></asp:TextBox></td>
								</tr>
								<tr>
									<td>Email:</td>
									<td><asp:TextBox ID="tb_email" class="form-control" runat="server" TextMode="Email"></asp:TextBox></td>
								</tr>
								</table>
							</div>
							
							<div class="col-md-12 form-group">
								<asp:Button ID="btn_submit" class="primary-btn" runat="server" Text="Registar" OnClick="btn_submit_Click"/>
								<a href="login.aspx">Voltar ao Login</a>
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
