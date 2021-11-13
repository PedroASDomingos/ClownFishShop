<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="cart.aspx.cs" Inherits="ExercicioLojaOnline.cart" ValidateRequest="false" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Start Banner Area -->
    <section class="banner-area organic-breadcrumb">
        <div class="container">
            <div class="breadcrumb-banner d-flex flex-wrap align-items-center justify-content-end">
                <div class="col-first">
                    <h1>Carrinho de compras</h1>
                    <nav class="d-flex align-items-center">
                        <a href="index.aspx">Home<span class="lnr lnr-arrow-right"></span></a>
                        <a href="cart.aspx">Carrinho</a>
                    </nav>
                </div>
            </div>
        </div>
    </section>
    <!-- End Banner Area -->

    <!--================Cart Area =================-->
    <section class="cart_area">
        <div class="container">
            <div class="cart_inner">
                <div class="table-responsive">
                    
                    <asp:Repeater ID="Repeater1" runat="server">
                        <HeaderTemplate>
                        <table class="table">
                        <thead>
                            <tr>
                                <th scope="col">Produto</th>
                                <th scope="col">Preço</th>
                                <th scope="col">Quantidade</th>
                                <th scope="col">Total</th>
                                <th scope="col"></th>
                            </tr>
                            <tbody>
                        </thead>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <div class="media">
                                        <div class="d-flex">
                                            <asp:Image ID="Image1" Width="100" Height="100" runat="server" ImageUrl='<%# GetImageProduto(Eval("cod_produto")) %>'/>
                                        </div>
                                        <div class="media-body">
                                            <p><%# GetNomeProduto(Eval("cod_produto")) %></p>
                                        </div>
                                    </div>
                                </td>
                                <td>
                                    <h5><%# GetNomePreco(Eval("cod_produto")) %>€</h5>
                                </td>
                                <td>
                                    <div class="product_count">
                                        <asp:TextBox ID="tb_quantidade" runat="server" TextMode="Number" Text="1"></asp:TextBox>
                                    </div>
                                </td>
                                <td>
                                    <h5><asp:Label ID="lbl_preco" runat="server" CommandArgument='<%#Eval("cod_produto")%>' ><%# GetTotal(Eval("cod_produto")) %></asp:Label></h5>
                                </td>
                                <td>
                                     <asp:ImageButton ID="btn_apaga" CommandName="btn_apaga" OnClick="btn_apaga_Click" ImageUrl="img/Delete2.png" runat="server" CommandArgument='<%#Eval("cod_produto")%>'/>
                                </td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            </tbody>
                        </table>
                        </FooterTemplate>
                    </asp:Repeater>
                    <table class="table">
                    <tr class="bottom_button">
                                <td>
                                    <a class="gray_btn" href="#">Atualizar carrinho</a>
                                </td>
                                <td>

                                </td>
                                <td>
                                    <h5>Total</h5>
                                </td>
                                <td>
                                    <h5><asp:Label ID="lbl_total" runat="server" Text=""></asp:Label></h5>
                                </td>
                            </tr>
                    
                            <tr class="shipping_area">
                                <td>

                                </td>
                                <td>

                                </td>
                                <td>
                                    <h5>Envio</h5>
                                </td>
                                <td>
                                    <div class="shipping_box">
                                        <ul class="list">
                                            <li><a href="#">Recolha em loja: 0.00€</a></li>
                                            <li><a href="#">Envio por CTT: 5.50€</a></li>
                                            <li><a href="#">Envio por NACEX: 4.20€</a></li>
                                        </ul>
                                        
                                    </div>
                                </td>
                            </tr>
                            <tr class="out_button_area">
                                <td>

                                </td>
                                <td>

                                </td>
                                <td>

                                </td>
                                <td>
                                    <div class="checkout_btn_inner d-flex align-items-center">
                                        <asp:Button ID="btn_continuar" class="gray_btn" runat="server" Text="Continue" OnClick="btn_continuar_Click" />
                                        <asp:Button ID="btn_checkout" class="primary-btn" runat="server" Text="Fazer o check-out" BorderStyle="None" OnClick="btn_checkout_Click" />
                                    </div>
                                </td>
                            </tr>
                        </table>
                </div>
            </div>
        </div>
    </section>
    <!--================End Cart Area =================-->
    
</asp:Content>
