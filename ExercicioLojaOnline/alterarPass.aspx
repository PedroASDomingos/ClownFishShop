<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="alterarPass.aspx.cs" Inherits="ExercicioLojaOnline.alterarPass" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Start Banner Area -->
    <section class="banner-area organic-breadcrumb">
        <div class="container">
            <div class="breadcrumb-banner d-flex flex-wrap align-items-center justify-content-end">
                <div class="col-first">
                    <h1>Alterar Palavra-pass</h1>
                    <nav class="d-flex align-items-center">
                        <a href="index.aspx">Home<span class="lnr lnr-arrow-right"></span></a>
                        <a href="perfilUser.aspx">Perfil Utilizador<span class="lnr lnr-arrow-right"></span></a>
                        <a href="alterarPass.aspx">Password</a>
                    </nav>
                </div>
            </div>
        </div>
    </section>
    <!-- End Banner Area -->
    <section class="contact_area section_gap_bottom">
        <div class="container d-flex justify-content-center">
            <center>
                <div class="row">
                    <div class="col-md-12">
                        <div class="form-group">
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <div class="form-group">
                            <label class="bmd-label-floating">Palavra-pass Antiga</label>
                            <asp:TextBox ID="tb_palavrapassAntiga" runat="server" TextMode="Password"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <div class="form-group">
                            <label class="bmd-label-floating">Nova Palavra-pass</label>
                            <asp:TextBox ID="tb_palavrapassNova" runat="server" TextMode="Password"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <div class="form-group">
                            <label class="bmd-label-floating">Repita a nova Palavra-pass</label>
                            <asp:TextBox ID="tb_palavrapassNova2" runat="server" TextMode="Password"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <div class="form-group">
                            <asp:Button ID="btn_altetarPass" class="btn btn-primary" runat="server" Text="Alterar" OnClick="btn_altetarPass_Click" />
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <div class="form-group">
                            <asp:Label ID="lbl_mensagem" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                </div>
            </center>
        </div>
    </section>
</asp:Content>
