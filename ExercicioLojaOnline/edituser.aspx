<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="edituser.aspx.cs" Inherits="ExercicioLojaOnline.EditUser" %>
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
                        <a href="edituser.aspx">Editar Perfil
                        </a>
                    </nav>
                </div>
            </div>
        </div>
    </section>
    <!-- End Banner Area -->
    <section class="contact_area section_gap_bottom">
        <div class="container d-flex justify-content-center">
        <div class="row">
            
              <div class="card">
                <div class="card-header card-header-primary">
                  <h4 class="card-title">Perfil Cliente</h4>
                  <p class="card-category">Atualize os seus dados!</p>
                </div>
                <div class="card-body">
                  <section>
                    <div class="row">
                      <div class="col-md-12">
                        <div class="form-group">
                          <label class="bmd-label-floating">Email</label>
                            <asp:Label ID="tb_email" class="form-control" runat="server" Text=""></asp:Label>
                        </div>
                      </div>
                    </div>
                      <div class="row">
                      <div class="col-md-6">
                        <div class="form-group">
                          <label class="bmd-label-floating">Utilizador</label>
                             <asp:Label ID="tb_user" class="form-control" runat="server" Text=""></asp:Label>
                        </div>
                      </div>
                      <div class="col-md-6">
                        <div class="form-group">
                          <label class="bmd-label-floating">NIF</label>
                            <asp:TextBox ID="tb_nif" class="form-control" runat="server"></asp:TextBox>
                        </div>
                      </div>
                    </div>
                    <div class="row">
                      <div class="col-md-6">
                        <div class="form-group">
                          <label class="bmd-label-floating">Nome</label>
                            <asp:TextBox ID="tb_nome" class="form-control" runat="server"></asp:TextBox>
                        </div>
                      </div>
                        <div class="col-md-6">
                        <div class="form-group">
                          <label class="bmd-label-floating">Data de Nascimento</label>
                            <asp:TextBox ID="tb_datanas" class="form-control" runat="server" TextMode="Date"></asp:TextBox>
                          
                        </div>
                      </div>
                    </div>
                    <div class="row">
                      <div class="col-md-12">
                        <div class="form-group">
                          <label class="bmd-label-floating">Morada</label>
                          <asp:TextBox ID="tb_morada" class="form-control" runat="server"></asp:TextBox>
                        </div>
                      </div>
                    </div>
                    <div class="row">
                      <div class="col-md-4">
                        <div class="form-group">
                          <label class="bmd-label-floating">Código Postal</label>
                          <asp:TextBox ID="tb_codpostal" class="form-control" runat="server"></asp:TextBox>
                        </div>
                      </div>
                      <div class="col-md-4">
                        <div class="form-group">
                          <label class="bmd-label-floating">Telefone</label>
                          <asp:TextBox ID="tb_telefone" class="form-control" runat="server"></asp:TextBox>
                        </div>
                      </div>
                         <div class="col-md-4">
                        <div class="form-group">
                          <label class="bmd-label-floating">Perfil</label>
                            <asp:DropDownList ID="DropDownList1" runat="server" class="form-control">
                                <asp:ListItem Value="2">Normal</asp:ListItem>
                                <asp:ListItem Value="3">Revenda</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                      </div>
                    </div>
                    <asp:Button ID="btn_updatePerfil" runat="server" class="btn btn-primary pull-right" Text="Atualizar perfil" OnClick="btn_updatePerfil_Click" />
                    
                   <asp:Label ID="lbl_mensagem" runat="server" Text=""></asp:Label>
                  </section>
                </div>
              </div>
                
            </div>
        
          </div>
        </section>
</asp:Content>
