<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="ExercicioLojaOnline.login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="https://apis.google.com/js/platform.js" async defer></script>
    <meta name="google-signin-client_id" content="491434620502-if247rgl1ecg73069r97orlgv0s5dr0h.apps.googleusercontent.com">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Start Banner Area -->
    <section class="banner-area organic-breadcrumb">
        <div class="container">
            <div class="breadcrumb-banner d-flex flex-wrap align-items-center justify-content-end">
                <div class="col-first">
                    <h1>Login/Registar</h1>
                    <nav class="d-flex align-items-center">
                        <a href="index.aspx">Home<span class="lnr lnr-arrow-right"></span></a>
                        <a href="login.aspx">Login</a>
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
                            <h4>Ainda não tem conta?</h4>
                            <h4>Registe-se agora</h4>
                            <p>Efetue já o seu registo e entre no maravilhso mundo da aquariofilia!</p>
                            <a class="primary-btn" href="registration.aspx">Crie a sua conta aqui</a>
                        </div>
                    </div>
                </div>
                <div class="col-lg-6">
                    <div class="login_form_inner">
                        <h3>Faça login para entrar</h3>
                        <section class="row login_form" action="contact_process.php" method="post" id="contactForm" novalidate="novalidate">
                            <div class="col-md-12 form-group">
                                <asp:TextBox ID="tb_user" class="form-control" runat="server" placeholder="Nome de utilizador" onfocus="this.placeholder = ''" onblur="this.placeholder = 'Nome de utilizador'"></asp:TextBox>
                            </div>
                            <div class="col-md-12 form-group">
                                <asp:TextBox ID="tb_pass" class="form-control" runat="server" TextMode="Password" placeholder="Password" onfocus="this.placeholder = ''" onblur="this.placeholder = 'Password'"></asp:TextBox>
                            </div>

                            <div class="col-md-12 form-group">
                                <asp:Button ID="btn_submit" class="primary-btn" runat="server" Text="Entrar" OnClick="btn_submit_Click" />
                                <a href="recuperar.aspx">Esqueceu a senha?</a>
                            </div>
                            <div class="col-md-12 form-group">
                                <div class="creat_account">
                                    <asp:Label ID="lbl_mensagem" runat="server" Text=""></asp:Label>
                                </div>
                            </div>
                            <div class="col-md-12 form-group">
                                <div class="creat_account">
                                    <center>
                                        <h3>Ou entra com uma rede social</h3>
                                        <div class="g-signin2" data-onsuccess="onSignIn" style="width: 150px"></div>
                                    </center>
                                </div>
                            </div>
                        </section>
                    </div>
                </div>            
            </div>
        </div>
    </section>
        <script>
            function onSignIn(googleUser) {
                var profile = googleUser.getBasicProfile();
                console.log('ID: ' + profile.getId()); // Do not send to your backend! Use an ID token instead.
                console.log('Name: ' + profile.getName());
                sessionStorage.setItem("Name", profile.getName());
                console.log('Image URL: ' + profile.getImageUrl());
                sessionStorage.setItem("Image", profile.getImageUrl());
                console.log('Email: ' + profile.getEmail()); // This is null if the 'email' scope is not present.
                sessionStorage.setItem("Email", profile.getEmail());
                window.location.href = 'googleSignIn.aspx';
            }
        </script>
    <!--================End Login Box Area =================-->
</asp:Content>
