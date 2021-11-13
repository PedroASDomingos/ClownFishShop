<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="ativar.aspx.cs" Inherits="ExercicioLojaOnline.ativar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <!-- Start Banner Area -->
    <section class="banner-area organic-breadcrumb">
        <div class="container">
            <div class="breadcrumb-banner d-flex flex-wrap align-items-center justify-content-end">
                <div class="col-first">
                    <h1>Ativação de conta</h1>
                    <nav class="d-flex align-items-center">
                        <a href="index.aspx">Home<span class="lnr lnr-arrow-right"></span></a>
                        <a href="ativar.aspx">Ativar</a>
                    </nav>
                </div>
            </div>
        </div>
    </section>
    <!-- End Banner Area -->

    <!--================About Area =================-->
    <section class="blog_area single-post-area section_gap">
        <div class="container">
                <div class=" posts-list">
					<center> 
                            <h1> A Sua conta foi ativada com sucesso</h1>

                        <asp:Button ID="btn_login" class="primary-btn" runat="server" Text="Login" OnClick="btn_login_Click" />
						</center>
               </div>          
      </div>
    </section>

</asp:Content>
