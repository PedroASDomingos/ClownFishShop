<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="product-details.aspx.cs" Inherits="ExercicioLojaOnline.product_details" ValidateRequest="false" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .postiva {
            color: green;
        }

        .negativa {
            color: red;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Start Banner Area -->
    <section class="banner-area organic-breadcrumb">
        <div class="container">
            <div class="breadcrumb-banner d-flex flex-wrap align-items-center justify-content-end">
                <div class="col-first">
                    <h1>Detalhes do Produto</h1>
                    <nav class="d-flex align-items-center">
                        <a href="index.aspx">Home<span class="lnr lnr-arrow-right"></span></a>
                        <a href="shop.aspx">Shop<span class="lnr lnr-arrow-right"></span></a>
                        <a href="product-details.aspx">Detalhes-do-Produto</a>
                    </nav>
                </div>
            </div>
        </div>
    </section>
    <!-- End Banner Area -->

    <!--================Single Product Area =================-->
    <asp:Repeater ID="d1" runat="server" OnItemDataBound="d1_ItemDataBound">

        <HeaderTemplate>
            <div class="product_image_area">
                <div class="container">
        </HeaderTemplate>
        <ItemTemplate>
            <div class="row s_product_inner">
                <div class="col-lg-6">
                    <div class="s_Product_carousel">
                        <div class="single-prd-item">
                            <asp:Image ID="Image1" Height="500" Width="500" class="img-fluid" runat="server" ImageUrl='<%# GetImage(Eval("contenttype"), Eval("imagem")) %>' />
                        </div>
                        <div class="single-prd-item">
                            <asp:Image ID="Image2" Height="500" Width="500" class="img-fluid" runat="server" ImageUrl='<%# GetImage(Eval("contenttype"), Eval("imagem")) %>' />
                        </div>
                        <div class="single-prd-item">
                            <asp:Image ID="Image3" Height="500" Width="500" class="img-fluid" runat="server" ImageUrl='<%# GetImage(Eval("contenttype"), Eval("imagem")) %>' />
                        </div>
                    </div>
                </div>
                <div class="col-lg-5 offset-lg-1">
                    <div class="s_product_text">
                        <h3><%# Eval("nome_produto") %></h3>
                        <h5><i><%# Eval("nome_cientifico") %></i></h5>
                        <asp:Panel ID="Panel_PrecoNormal" runat="server">
                            <h2><%# Eval("preco") %>€</h2>
                        </asp:Panel>
                        <asp:Panel ID="Panel_PanelPrecoRevenda" runat="server" Visible="false">
                            <h2><%# Eval("preco_promocao") %>€</h2>
                        </asp:Panel>
                        <ul class="list">
                            <li><a href="#">Categoria: <%# GetCategoria(Eval("cod_categoria")) %></a></li>
                            <li><a href="#" class="<%# GetEstilo(Eval("quantidade")) %>">Disponivel: <%# GetStock(Eval("quantidade")) %></a></li>
                        </ul>
                        <p><%# Eval("descricao_produto") %></p>
                        <div class="product_count">
                        </div>
                        <div class="card_area d-flex align-items-center">
                            <asp:LinkButton ID="btn_adicionar" class="primary-btn" Text="Adicionar" CommandArgument='<%#Eval("cod_produto")%>' OnClick="btn_adicionar_Click" runat="server">										</asp:LinkButton>

                        </div>
                    </div>
                </div>
            </div>

            <!--================End Single Product Area =================-->
        </ItemTemplate>
        <FooterTemplate>
            </div>
		</div>
        </FooterTemplate>
    </asp:Repeater>


</asp:Content>
