<%@ Page Title="" Language="C#" MasterPageFile="~/CMS/cms.Master" AutoEventWireup="true" CodeBehind="EditCategoria.aspx.cs" Inherits="ExercicioLojaOnline.CMS.EditCategoria" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>Editar/Apagar categorias</h3>
    <asp:Repeater ID="rpt_editcat" runat="server" OnItemDataBound="rpt_editcat_ItemDataBound" DataSourceID="SqlDataSource1" OnItemCommand="rpt_editcat_ItemCommand">
        <HeaderTemplate>
            <table>
                <tr>
                    <td><b>ID</b></td>
                    <td>&nbsp;&nbsp;&nbsp;</td>
                    <td><b>Categoria</b></td>
                    <td></td>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td>
                    <asp:Label ID="lbl_cod" runat="server" Text=""></asp:Label></td>
                <td></td>
                <td>
                    <asp:TextBox ID="tb_categoria" runat="server"></asp:TextBox></td>
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
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ClownfishDBConnectionString %>" SelectCommand="SELECT * FROM [categoria]"></asp:SqlDataSource>
</asp:Content>
