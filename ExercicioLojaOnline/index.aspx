<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="ExercicioLojaOnline.index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- start banner Area -->
    <section class="banner-area">
        <div class="container">
            <div class="row fullscreen align-items-center justify-content-start">
                <div class="col-lg-12">
                    <div class="active-banner-slider owl-carousel">
                        <!-- single-slide -->
                        <div class="row single-slide align-items-center d-flex">
                            <div class="col-lg-5 col-md-6">
                                <div class="banner-content">
                                    <h1>Bem-vindo a ClownFish<br>
                                        Loja Online</h1>
                                    <p> 
                                        Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et
										dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation.
                                    </p>
                                </div>
                            </div>
                            <div class="col-lg-7">
                                <div class="banner-img">
                                    <img class="img-fluid" src="img/fish4.png" alt="">
                                </div>
                            </div>
                        </div>
                        <!-- single-slide -->
                        <div class="row single-slide">
                            <div class="col-lg-5">
                                <div class="banner-content">
                                    <h1>New arrivals!</h1>
                                    <p>
                                        Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et
										dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation.
                                    </p>
                                </div>
                            </div>
                            <div class="col-lg-7">
                                <div class="banner-img">
                                    <img class="img-fluid" src="img/fish5.png" alt="">
                                </div>
                            </div>
                        </div>
                        <!-- single-slide -->
                        <div class="row single-slide">
                            <div class="col-lg-5">
                                <div class="banner-content">
                                    <h1>New arrivals!</h1>
                                    <p>
                                        Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et
										dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation.
                                    </p>
                                </div>
                            </div>
                            <div class="col-lg-7">
                                <div class="banner-img">
                                    <img class="img-fluid" src="img/fish1.png" alt="">
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <!-- End banner Area -->

    <!-- start product Area -->
    <section class="owl-carousel active-product-area section_gap">
        <!-- single product slide -->
        <div class="single-product-slider">
            <div class="container">
                <div class="row justify-content-center">
                    <div class="col-lg-6 text-center">
                        <div class="section-title">
                            <h1>Novidades</h1>
                            <p>
                                Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et
								dolore
								magna aliqua.
                            </p>
                        </div>
                    </div>
                </div>
                <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound" >
                    <HeaderTemplate>
                        <div class="row">
                    </HeaderTemplate>
                    <ItemTemplate>
                        <div class="col-lg-3 col-md-6">
                            <!-- single product -->
                            <div class="single-product">
                                <a href="product-details.aspx?id=<%# Eval("cod_produto") %>">
                                    <asp:Image ID="Image1" class="img-fluid" Height="260" Width="240" runat="server" ImageUrl='<%# GetImage(Eval("contenttype"), Eval("imagem")) %>' />
                                </a>
                                <div class="product-details">
                                    <h6><%# Eval("nome_produto") %></h6>
                                    <div class="price">
                                        <asp:Panel ID="Panel_PrecoNormal" runat="server">
                                            <h6><%# Eval("preco") %>€</h6>
                                        </asp:Panel>
                                        <asp:Panel ID="Panel_PanelPrecoRevenda" runat="server" Visible="false">
                                            <h6><%# Eval("preco_promocao") %>€</h6>
                                            <h6 class="l-through"><%# Eval("preco") %>€</h6>
                                        </asp:Panel>
                                    </div>
                                    <div class="prd-bottom">
                                        <asp:LinkButton ID="LinkButtonBuy" class="social-info" CommandArgument='<%#Eval("cod_produto")%>' runat="server" OnClick="LinkButtonBuy_Click">
										<span class="ti-bag"></span>
										<p class="hover-text">adicionar</p>
                                        </asp:LinkButton>
                                        <a href="product-details.aspx?id=<%# Eval("cod_produto") %>" class="social-info">
                                            <span class="lnr lnr-move"></span>
                                            <p class="hover-text">veja mais</p>
                                        </a>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <!-- single product -->
                    </ItemTemplate>
                    <FooterTemplate>
                        </div>
                    </FooterTemplate>
                </asp:Repeater>
            </div>
        </div>
        <!-- single product slide -->
        <div class="single-product-slider">
            <div class="container">
                <div class="row justify-content-center">
                    <div class="col-lg-6 text-center">
                        <div class="section-title">
                            <h1>TOP VENDAS</h1>
                            <p>
                                Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et
								dolore
								magna aliqua.
                            </p>
                        </div>
                    </div>
                </div>
                <asp:Repeater ID="Repeater2" runat="server" OnItemDataBound="Repeater2_ItemDataBound">
                    <HeaderTemplate>
                        <div class="row">
                    </HeaderTemplate>
                    <ItemTemplate>
                        <div class="col-lg-3 col-md-6">
                            <!-- single product -->
                            <div class="single-product">
                                <a href="product-details.aspx?id=<%# Eval("cod_produto") %>">
                                    <asp:Image ID="Image1" class="img-fluid" Height="260" Width="240" runat="server" ImageUrl='<%# GetImage(Eval("contenttype"), Eval("imagem")) %>' />
                                </a>
                                <div class="product-details">
                                    <h6><%# Eval("nome_produto") %></h6>
                                    <div class="price">
                                        <asp:Panel ID="Panel_PrecoNormal" runat="server">
                                            <h6><%# Eval("preco") %>€</h6>
                                        </asp:Panel>
                                        <asp:Panel ID="Panel_PanelPrecoRevenda" runat="server" Visible="false">
                                            <h6><%# Eval("preco_promocao") %>€</h6>
                                            <h6 class="l-through"><%# Eval("preco") %>€</h6>
                                        </asp:Panel>
                                    </div>
                                    <div class="prd-bottom">
                                        <asp:LinkButton ID="LinkButtonBuy" class="social-info" CommandArgument='<%#Eval("cod_produto")%>' runat="server" OnClick="LinkButtonBuy_Click">
										<span class="ti-bag"></span>
										<p class="hover-text">adicionar</p>
                                        </asp:LinkButton>
                                        <a href="product-details.aspx?id=<%# Eval("cod_produto") %>" class="social-info">
                                            <span class="lnr lnr-move"></span>
                                            <p class="hover-text">veja mais</p>
                                        </a>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <!-- single product -->
                    </ItemTemplate>
                    <FooterTemplate>
                        </div>
                    </FooterTemplate>
                </asp:Repeater>
                <!-- single product -->
            </div>
        </div>
    </section>
    <!-- end product Area -->
</asp:Content>
