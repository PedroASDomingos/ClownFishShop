<%@ Page Title="" Language="C#" MasterPageFile="~/CMS/cms.Master" AutoEventWireup="true" CodeBehind="destaques.aspx.cs" Inherits="ExercicioLojaOnline.CMS.destaques" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>Destaque Top 8</h3>
    <asp:SqlDataSource
             ID="SqlDataSource1"
             runat="server" 
             ConnectionString="<%$ ConnectionStrings:ClownfishDBConnectionString %>" 
             SelectCommand="SELECT * FROM produto"></asp:SqlDataSource>
     <asp:SqlDataSource
             ID="SqlDataSource2"
             runat="server" 
             ConnectionString="<%$ ConnectionStrings:ClownfishDBConnectionString %>" 
             SelectCommand="SELECT destaque_top.cod_produto, produto.nome_produto FROM destaque_top INNER JOIN produto ON destaque_top.cod_produto = produto.cod_produto"></asp:SqlDataSource>
    <table>
        <tr>
            <td><asp:ListBox ID="lst_produtos" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource1" DataTextField="nome_produto" DataValueField="cod_produto"  Height="350" Width="250"></asp:ListBox></td>
            <td></td>
            <td><asp:ListBox ID="lst_destaque" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource2" DataTextField="nome_produto" DataValueField="cod_produto"  Height="350" Width="250"></asp:ListBox></td>
        </tr>
         <tr>
            <td><asp:Button ID="btn_adicionar" class="btn btn-success" runat="server" Text="Adicionar" OnClick="btn_adicionar_Click" /></td>
             <td></td>
             <td><asp:Button ID="btn_remover" class="btn btn-danger" runat="server" Text="Renover" OnClick="btn_remover_Click" /></td>
        </tr>
        <tr>
            <td><asp:Label ID="lbl_mensagem" runat="server" Text=""></asp:Label></td>
        </tr>

        </table>
</asp:Content>
