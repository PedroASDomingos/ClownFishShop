<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="googleSignIn.aspx.cs" Inherits="ExercicioLojaOnline.googleSignIn" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script> 
    function signOut() {
        window.open("https://mail.google.com/mail/?logout&hl=en", '', 'width=600,height=400')
        var auth2 = gapi.auth2.getAuthInstance();
        auth2.signOut().then(function () {
            console.log('User signed out.');
        });
        auth2.disconnect();
    }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <!-- Start Banner Area -->
    <section class="banner-area organic-breadcrumb">
        <div class="container">
            <div class="breadcrumb-banner d-flex flex-wrap align-items-center justify-content-end">
                <div class="col-first">
                    <h1>Google Login</h1>
                    <nav class="d-flex align-items-center">
                        <a href="index.aspx">Home<span class="lnr lnr-arrow-right"></span></a>
                        <a href="googleSignIn.aspx">GoogleLogin</a>
                    </nav>
                </div>
            </div>
        </div>
    </section>
    <!-- End Banner Area -->
    <section class="contact_area section_gap_bottom">
        <div class="container">


            <center>
            <div class="row">
                <div class="col-md-12">
                    <div class="form-group">
                        <h1>Login efetuado com Google+</h1>
                        
                    </div>
                    <button type="button" class="btn btn-danger" onclick="signOut();">Logout Google</button>
                </div>
            </div>
            </center>

        </div>
    </section>
    
</asp:Content>
