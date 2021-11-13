<%@ Page Title="" Language="C#" MasterPageFile="~/CMS/cms.Master" AutoEventWireup="true" CodeBehind="addproduct.aspx.cs" Inherits="ExercicioLojaOnline.CMS.addproduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>Adicionar um novo produto</h3>
    <table>
        <tr>
            <td>Nome do produto:</td>
            <td><asp:TextBox ID="tb_nomeProduto" runat="server" Width="350"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Nome científico do produto:</td>
            <td><asp:TextBox ID="tb_nomeCientifico" runat="server" Width="350"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Categoria do produto:</td>
            <td><asp:DropDownList ID="ddl_categoria" runat="server" Width="350" DataSourceID="SqlDataSource1" DataTextField="categoria" DataValueField="cod_categoria"></asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ClownfishDBConnectionString %>" SelectCommand="SELECT [cod_categoria], [categoria] FROM [categoria]"></asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td>Preço:</td>
            <td><asp:TextBox ID="tb_preco" runat="server" Width="350"></asp:TextBox></td>
        </tr>
         <tr>
            <td>Descrição do produto:</td>
            <td><asp:TextBox ID="tb_descricao" runat="server" TextMode="MultiLine" Width="350"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Imagem:</td>
            <td><asp:FileUpload ID="FileUpload1" runat="server" /></td>
        </tr>
        <tr>
            <td>Taxa de IVA do produto:</td>
            <td><asp:DropDownList ID="ddl_iva" runat="server" DataSourceID="SqlDataSource2" Width="350" DataTextField="descricao" DataValueField="cod_iva"></asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ClownfishDBConnectionString %>" SelectCommand="SELECT * FROM [iva]"></asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td>Quantidade</td>
            <td><asp:TextBox ID="tb_quantidade" runat="server" Width="350"></asp:TextBox></td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <asp:Button runat="server" ID="btn_submit" Text="Inserir" CssClass="btn btn-primary" OnClick="btn_submit_Click" /></td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <asp:Label ID="lbl_mensagem" runat="server" Text=""></asp:Label></td>
        </tr>
    </table>
</asp:Content>
