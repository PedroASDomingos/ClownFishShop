<%@ Page Title="" Language="C#" MasterPageFile="~/CMS/cms.Master" AutoEventWireup="true" CodeBehind="EditProdutos.aspx.cs" Inherits="ExercicioLojaOnline.CMS.EditProdutos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>Editar/Apagar Produtos</h3>
    <asp:Repeater ID="rpt_editprod" runat="server" DataSourceID="SqlDataSource3" OnItemCommand="rpt_editprod_ItemCommand" OnItemDataBound="rpt_editprod_ItemDataBound">
        <HeaderTemplate>
            <table>
                <tr>
                    <td><b>ID</b></td>
                    <td><b>Nome Produto</b></td>
                    <td><b>Nome Científico</b></td>
                    <td><b>Categoria</b></td>
                    <td><b>Preço</b></td>
                    <td><b>Descrição</b></td>
                    <td><b>Imagem</b></td>
                    <td><b>IVA</b></td>
                    <td><b>Quantidade</b></td>
                    <td></td>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td>
                    <asp:Label ID="lbl_cod" runat="server" Text=""></asp:Label></td>
                <td>
                    <asp:TextBox ID="tb_nome" runat="server"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="tb_nomeC" runat="server"></asp:TextBox></td>
                <td>
                    <asp:DropDownList ID="ddl_categoria" runat="server" DataSourceID="SqlDataSource1" DataTextField="categoria" DataValueField="cod_categoria"></asp:DropDownList></td>
                <td>
                    <asp:TextBox ID="tb_preco" runat="server"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="tb_descricao" runat="server" TextMode="MultiLine"></asp:TextBox></td>
                <td>
                    <asp:FileUpload ID="FileUpload1" runat="server" /></td>
                <td>
                    <asp:DropDownList ID="ddl_iva" runat="server" DataSourceID="SqlDataSource2" DataTextField="iva" DataValueField="cod_iva"></asp:DropDownList><asp:SqlDataSource runat="server" ID="SqlDataSource2" ConnectionString='<%$ ConnectionStrings:ClownfishDBConnectionString %>' SelectCommand="SELECT [cod_iva], [iva] FROM [iva]"></asp:SqlDataSource>
                </td>
                <td>
                    <asp:TextBox ID="tb_quantidade" runat="server"></asp:TextBox></td>
                <td>
                    <asp:ImageButton ID="btn_grava" CommandName="btn_grava" ImageUrl="images/Save.png" runat="server" /></td>
                <td>
                    <asp:ImageButton ID="btn_apaga" CommandName="btn_apaga" ImageUrl="images/Delete.png" runat="server" /></td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
    <asp:SqlDataSource runat="server" ID="SqlDataSource3" ConnectionString='<%$ ConnectionStrings:ClownfishDBConnectionString %>' SelectCommand="SELECT produto.*, categoria.cod_categoria AS Expr1, categoria.categoria, iva.cod_iva, iva.iva FROM categoria INNER JOIN produto ON categoria.cod_categoria = produto.cod_categoria INNER JOIN iva ON produto.cod_tx_iva = iva.cod_iva"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ClownfishDBConnectionString %>" SelectCommand="SELECT * FROM [categoria]"></asp:SqlDataSource>
</asp:Content>
