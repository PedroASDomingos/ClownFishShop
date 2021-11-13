<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="about.aspx.cs" Inherits="ExercicioLojaOnline.about" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Start Banner Area -->
    <section class="banner-area organic-breadcrumb">
        <div class="container">
            <div class="breadcrumb-banner d-flex flex-wrap align-items-center justify-content-end">
                <div class="col-first">
                    <h1>Quem Somos</h1>
                    <nav class="d-flex align-items-center">
                        <a href="index.aspx">Home<span class="lnr lnr-arrow-right"></span></a>
                        <a href="about.aspx">Quem Somos</a>
                    </nav>
                </div>
            </div>
        </div>
    </section>
    <!-- End Banner Area -->

    <!--================About Area =================-->
    <section class="blog_area single-post-area section_gap">
        <div class="container">
                <div class=" posts-list">
					<center> 
                        <div id="carouselExampleSlidesOnly" class="carousel slide" data-ride="carousel">
                          <div class="carousel-inner">
                            <div class="carousel-item active">
                              <img class="d-block w-50" src="img/about/cinel2.jpg" alt="First slide">
                            </div>
                            <div class="carousel-item">
                              <img class="d-block w-50" src="img/about/cinel3.jpg" alt="Second slide">
                            </div>
                            <div class="carousel-item">
                              <img class="d-block w-50" src="img/about/cinel2.jpg" alt="Third slide">
                            </div>
                          </div>
                        </div>
                        <div class="col-lg-9 col-sm-4 blog_details">
                            <h2>ClownFish - Loja Online</h2>
                            <p class="excert">
                                A ClownFish é uma empresa jovem e dinâmica, com experiência comercial e profissional, acumuladas ao longo de mais de 2 dias.
                            </p>
                            <p>
                                 Adquirimos técnicas e conhecimento, permitindo desta forma uma especialização no maravilhoso mundo da AQUARIOFILIA.
                            </p>
                            <p>
                                Temos ao seu dispor, cerca de 65.000 Litros de água, ao longo de um espaço total de 700 metros quadrados, divididos em áreas bem definidas.
                            </p>
                            <h3>Venha conhecer as nossas instalações!</h3>
                        </div>
						</center>
               </div>          
      </div>

    </section>
    <!--================About Area =================-->
    </asp:Content>
