<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="perfilUser.aspx.cs" Inherits="ExercicioLojaOnline.perfilUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Start Banner Area -->
    <section class="banner-area organic-breadcrumb">
        <div class="container">
            <div class="breadcrumb-banner d-flex flex-wrap align-items-center justify-content-end">
                <div class="col-first">
                    <h1>O seu Perfil de Cliente</h1>
                    <nav class="d-flex align-items-center">
                        <a href="index.aspx">Home<span class="lnr lnr-arrow-right"></span></a>
                        <a href="perfilUser.aspx">Perfil</a>
                    </nav>
                </div>
            </div>
        </div>
    </section>
    <!-- End Banner Area -->

    <section class="contact_area section_gap_bottom">
        <div class="container">


            <div class="row">
                <div class="col-lg-9">
                    <div class="row contact_form">
                <h4 class="card-title">Perfil Cliente</h4>
            </div>
            <div class="row">
                <p class="card-category">Mantena os seus dados sempre atualizados!</p>

            </div>

            <div class="row">
                <div class="col-md-12">
                    <div class="form-group">
                        <label class="bmd-label-floating">Email</label>
                        <asp:Label ID="lbl_email" class="form-control" runat="server" Text=""></asp:Label>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-6">
                    <div class="form-group">
                        <label class="bmd-label-floating">Utilizador</label>
                        <asp:Label ID="lbl_user" class="form-control" runat="server" Text=""></asp:Label>

                    </div>
                </div>
                <div class="col-md-6">
                    <div class="form-group">
                        <label class="bmd-label-floating">NIF</label>
                        <asp:Label ID="lbl_nif" class="form-control" runat="server" Text=""></asp:Label>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <div class="form-group">
                        <label class="bmd-label-floating">Nome</label>
                        <asp:Label ID="lbl_nome" class="form-control" runat="server" Text=""></asp:Label>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <div class="form-group">
                        <label class="bmd-label-floating">Data de Nascimento</label>
                        <asp:Label ID="lbl_dataNascimento" class="form-control" runat="server" Text=""></asp:Label>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <div class="form-group">
                        <label class="bmd-label-floating">Morada</label>
                        <asp:Label ID="lbl_morada" class="form-control" runat="server" Text=""></asp:Label>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-6">
                    <div class="form-group">
                        <label class="bmd-label-floating">Código Postal</label>
                        <asp:Label ID="lbl_codpostal" class="form-control" runat="server" Text=""></asp:Label>

                    </div>
                </div>
                <div class="col-md-6">
                    <div class="form-group">
                        <label class="bmd-label-floating">Telefone</label>
                        <asp:Label ID="lbl_telefone" class="form-control" runat="server" Text=""></asp:Label>
                    </div>
                </div>
            </div>
            <table>
                <tr>
                    <td>
                        <asp:Button ID="btn_alteraPass" runat="server" class="btn btn-primary pull-right" Text="Alterar Pass" OnClick="btn_alteraPass_Click" /></td>
                    <td>
                        <asp:Button ID="btn_updatePerfil" runat="server" class="btn btn-primary pull-right" Text="Atualizar perfil" OnClick="btn_updatePerfil_Click" /></td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btn_logout" runat="server" class="btn btn-danger" Text="Logout" OnClick="btn_logout_Click" />
                    </td>
                </tr>
                
            </table>

            <asp:Label ID="lbl_mensagem" runat="server" Text=""></asp:Label>

        </div>

            </div>

        </div>
    </section>

</asp:Content>
