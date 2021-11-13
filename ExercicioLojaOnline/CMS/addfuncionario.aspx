<%@ Page Title="" Language="C#" MasterPageFile="~/CMS/cms.Master" AutoEventWireup="true" CodeBehind="addfuncionario.aspx.cs" Inherits="ExercicioLojaOnline.CMS.addfuncionario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <h3>Adicionar um funcionário</h3>
    <table>
        <tr>
            <td>Nome do funcionário:</td>
            <td><asp:TextBox ID="tb_nome" runat="server" Width="350"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Cargo do funcionário</td>
            <td><asp:TextBox ID="tb_cargo" runat="server" Width="350"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Link do Facebook</td>
            <td><asp:TextBox ID="tb_face" runat="server" Width="350"></asp:TextBox></td>
        </tr>
        <tr>
           <td>Link do Instagram</td>
            <td><asp:TextBox ID="tb_insta" runat="server" Width="350"></asp:TextBox></td>
         <tr>
            <td>Link do Twitter</td>
            <td><asp:TextBox ID="tb_twitter" runat="server" Width="350"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Link do Linkedin</td>
            <td><asp:TextBox ID="tb_linkedin" runat="server" Width="350"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Imagem:</td>
            <td><asp:FileUpload ID="FileUpload1" runat="server" /></td>
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
