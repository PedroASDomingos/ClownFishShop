<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="shop.aspx.cs" Inherits="ExercicioLojaOnline.shop" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Start Banner Area -->
    <section class="banner-area organic-breadcrumb">
        <div class="container">
            <div class="breadcrumb-banner d-flex flex-wrap align-items-center justify-content-end">
                <div class="col-first">
                    <h1>ClownFish - Loja Online</h1>
                    <nav class="d-flex align-items-center">
                        <a href="index.aspx">Home<span class="lnr lnr-arrow-right"></span></a>
                        <a href="shop.aspx">Loja</a>
                    </nav>
                </div>
            </div>
        </div>
    </section>
    <!-- End Banner Area -->
    <div class="container">
        <div class="row">
            <div class="col-xl-3 col-lg-4 col-md-5">
                <div class="sidebar-categories">
                    <div class="head">Categorias</div>

                    <ul class="main-categories">

                        <asp:Repeater ID="Repeater1" runat="server">
                            <HeaderTemplate>
                                <ul class="main-nav-list" id="fruitsVegetable" data-toggle="collapse" aria-expanded="false" aria-controls="fruitsVegetable">
                                    <li class="main-nav-list">
                                        <asp:LinkButton ID="LinkButtonAll" runat="server" OnClick="LinkButtonAll_Click">Todos os produtos<span class="number">(<%# GetCountAll(Eval("Todas")) %>)</span></asp:LinkButton></li>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <li class="main-nav-list">
                                    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" CommandArgument='<%#Eval("cod_categoria")%>'><%# Eval("categoria") %><span class="number">(<%# GetCounts(Eval("cod_categoria")) %>)</span></asp:LinkButton></li>
                            </ItemTemplate>
                            <FooterTemplate>
                                </ul>
                            </FooterTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
                <div class="sidebar-filter mt-50">
                    <div class="top-filter-head"></div>


                    <div class="common-filter">
                    </div>
                </div>
            </div>
            <div class="col-xl-9 col-lg-8 col-md-7">
                <!-- Start Filter Bar -->
                <div class="filter-bar d-flex flex-wrap align-items-center">
                    <div class="sorting">
                        <asp:DropDownList ID="DropDownList1" runat="server">
                            <asp:ListItem Value="NoOrder">Ordenar por</asp:ListItem>
                            <asp:ListItem Value="nome_produto">Por Nome</asp:ListItem>
                            <asp:ListItem Value="preco">Por Preço</asp:ListItem>
                        </asp:DropDownList>

                    </div>
                    <div class="sorting mr-auto">
                        <asp:ImageButton ID="btn_asc" runat="server" src="img/down.png" OnClick="btn_asc_Click" />
                        <asp:ImageButton ID="btn_dsc" runat="server" src="img/up.png" OnClick="btn_dsc_Click" />
                    </div>
                    <div id="divPaging" class="pagination" runat="server">
                        <asp:Repeater ID="rptPages" runat="server">
                            <HeaderTemplate>
                                <table>
                                    <tr>
                                        <td>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:LinkButton ID="btnPage" CommandName="Page" CommandArgument="<%#Container.DataItem %>" CssClass="text" runat="server"><%# Container.DataItem %>
                                </asp:LinkButton>
                            </ItemTemplate>
                            <FooterTemplate>
                                </td>
                              </tr>
                              </table>
                            </FooterTemplate>
                        </asp:Repeater>
                    </div>
                </div>
                <!-- End Filter Bar -->
                <!-- Start Best Seller -->
                <section class="lattest-product-area pb-40 category-list">


                    <asp:Repeater ID="d1" runat="server" OnItemDataBound="d1_ItemDataBound">
                        <HeaderTemplate>
                            <div class="row">
                        </HeaderTemplate>

                        <ItemTemplate>
                            <div class="col-lg-4 col-md-6">
                                <!-- single product -->

                                <div class="single-product">
                                    <a href="product-details.aspx?id=<%# Eval("cod_produto") %>">
                                        <asp:Image ID="Image1" Width="220" Height="220" class="img-fluid" runat="server" ImageUrl='<%# GetImage(Eval("contenttype"), Eval("imagem")) %>' />
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
                                                <p class="hover-text">Ver Mais</p>
                                            </a>
                                        </div>
                                    </div>
                                </div>

                                <!-- single product -->
                            </div>
                        </ItemTemplate>

                        <FooterTemplate>
                            </div>	
                        </FooterTemplate>
                    </asp:Repeater>


                    <!-- End Best Seller -->


                </section>
            </div>
        </div>
    </div>

</asp:Content>
