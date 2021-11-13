<%@ Page Title="" Language="C#" MasterPageFile="~/CMS/cms.Master" AutoEventWireup="true" CodeBehind="editfuncionario.aspx.cs" Inherits="ExercicioLojaOnline.CMS.editfuncionario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>Editar/Apagar funcionários</h3>
    <asp:Repeater ID="rpt_editfun" runat="server" OnItemDataBound="rpt_editfun_ItemDataBound" DataSourceID="SqlDataSource2" OnItemCommand="rpt_editfun_ItemCommand">
        <HeaderTemplate>
            <table>
                <tr>
                    <td><b>ID</b></td>
                    <td><b>Nome funcionário</b></td>
                    <td><b>Cargo</b></td>
                    <td><b>Link Facebook</b></td>
                    <td><b>Link Instagram</b></td>
                    <td><b>Link Twitter</b></td>
                    <td><b>Link Linkedin</b></td>
                    <td><b>Imagem</b></td>
                    <td></td>
                    <td></td>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>

            <tr>
                <td>
                    <asp:Label ID="lbl_codfuncionario" runat="server" Text=""></asp:Label></td>
                <td>
                    <asp:TextBox ID="tb_nome" runat="server"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="tb_cargo" runat="server" ></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="tb_linkface" runat="server" ></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="tb_linkinsta" runat="server" ></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="tb_linktwitter" runat="server" ></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="tb_linklinkedin" runat="server"></asp:TextBox></td>
                <td>
                    <asp:FileUpload ID="FileUpload1" runat="server"></asp:FileUpload></td>
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
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ClownfishDBConnectionString %>" SelectCommand="SELECT * FROM [funcionario]"></asp:SqlDataSource>
</asp:Content>
