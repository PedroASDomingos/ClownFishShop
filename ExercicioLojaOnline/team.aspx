<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="team.aspx.cs" Inherits="ExercicioLojaOnline.team" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/MaterialDesign-Webfont/5.3.45/css/materialdesignicons.css" integrity="sha256-NAxhqDvtY0l4xn+YVa6WjAcmd94NNfttjNsDmNatFVc=" crossorigin="anonymous" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Start Banner Area -->
    <section class="banner-area organic-breadcrumb">
        <div class="container">
            <div class="breadcrumb-banner d-flex flex-wrap align-items-center justify-content-end">
                <div class="col-first">
                    <h1>A nossa Equipa</h1>
                    <nav class="d-flex align-items-center">
                        <a href="index.aspx">Home<span class="lnr lnr-arrow-right"></span></a>
                        <a href="team.aspx">Equipa</a>
                    </nav>
                </div>
            </div>
        </div>
    </section>
    <!-- End Banner Area -->

    <!-- Equipa -->
    <div class="container bootdey">
        <div class='container-fluid mx-auto mt-5 mb-5 col-12' style="text-align: center">
    <div class="blog_details"><h2>A nossa equipa!</h2></div>
    <p class="text-muted">Estaremos prontamente onde precisar de nós e realizaremos sempre o trabalho.</p>
            </div>
            <asp:Repeater ID="d1" runat="server">
				<HeaderTemplate>
				 <div class="row">   
				</HeaderTemplate>
				    <ItemTemplate>
                    <div class="col-lg-3 col-md-6 col-12 mt-4 pt-2">
					<div class="team text-center rounded p-3 py-4">
                    <asp:Image ID="Image1" Width="200" Height="200" class="img-fluid avatar avatar-medium shadow rounded-pill" runat="server" ImageUrl='<%# GetImage(Eval("contenttype"), Eval("imagem")) %>'/>
                    
                    <div class="content mt-3">
                        <h4 class="title mb-0"><%# Eval("nome") %></h4>
                        <small class="text-muted"><%# Eval("cargo") %></small>
                        <ul class="list-unstyled mt-3 social-icon social mb-0">
                            <li class="list-inline-item"><a href="<%# Eval("linkface") %>" target="_blank" class="rounded"><i class="mdi mdi-facebook" title="Facebook"></i></a></li>
                            <li class="list-inline-item"><a href="<%# Eval("linkinsta") %>" target="_blank" class="rounded"><i class="mdi mdi-instagram" title="Instagram"></i></a></li>
                            <li class="list-inline-item"><a href="<%# Eval("linktwitter") %>" target="_blank" class="rounded"><i class="mdi mdi-twitter" title="Twitter"></i></a></li>
                            <li class="list-inline-item"><a href="<%# Eval("linklinkedin") %>" target="_blank" class="rounded"><i class="mdi mdi-linkedin" title="Linkedin"></i></a></li>
                        </ul><!--end icon-->
                    </div>
                        </div>	
                        </div><!--end col-->
				    </ItemTemplate>
						<FooterTemplate>
                         		</div><!--end row-->			
						</FooterTemplate>
					</asp:Repeater>
                
            
            </div>
    <!-- End Equipa -->
</asp:Content>
