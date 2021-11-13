<%@ Page Title="" Language="C#" MasterPageFile="~/CMS/cms.Master" AutoEventWireup="true" CodeBehind="addcategoria.aspx.cs" Inherits="ExercicioLojaOnline.CMS.addcategoria" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>Adicionar uma categoria</h3>
    <table>
        <tr>
            <td>Nome da Categoria:</td>
            <td><asp:TextBox ID="tb_categoria" runat="server"></asp:TextBox></td>
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
