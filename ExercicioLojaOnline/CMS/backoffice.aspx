<%@ Page Title="" Language="C#" MasterPageFile="~/CMS/cms.Master" AutoEventWireup="true" CodeBehind="backoffice.aspx.cs" Inherits="ExercicioLojaOnline.CMS.backoffice" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
            <div class="col-md-8">
              <div class="card">
                <div class="card-header card-header-primary">
                  <h4 class="card-title">Editar Perfil</h4>
                  <p class="card-category">Complete o seu perfil</p>
                </div>
                <div class="card-body">
                  <section>
                    <div class="row">
                      <div class="col-md-5">
                        <div class="form-group">
                          <label class="bmd-label-floating">Email</label>
                          <asp:TextBox ID="tb_email" class="form-control" runat="server" TextMode="Email"></asp:TextBox>
                        </div>
                      </div>
                      <div class="col-md-3">
                        <div class="form-group">
                          <label class="bmd-label-floating">Utilizador</label>
                           <asp:TextBox ID="tb_user" class="form-control" runat="server"></asp:TextBox>
                        </div>
                      </div>
                      <div class="col-md-4">
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
                            <asp:Label ID="lbl_perfil" class="form-control" runat="server" Text="Admin"></asp:Label>
                        </div>
                      </div>
                    </div>
                    <asp:Button ID="btn_updatePerfil" runat="server" class="btn btn-primary pull-right" Text="Atualizar perfil" />
                    
                    <div class="clearfix"></div>
                  </section>
                </div>
              </div>
            </div>
            <div class="col-md-4">
              <div class="card card-profile">
                <div class="card-avatar">
                  
                </div>
                <div class="card-body">
                 
                </div>
              </div>
            </div>
          </div>
</asp:Content>
