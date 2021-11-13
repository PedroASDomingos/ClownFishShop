<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="services.aspx.cs" Inherits="ExercicioLojaOnline.services" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <!-- Start Banner Area -->
	<section class="banner-area organic-breadcrumb">
		<div class="container">
			<div class="breadcrumb-banner d-flex flex-wrap align-items-center justify-content-end">
				<div class="col-first">
					<h1>Serviços</h1>
					<nav class="d-flex align-items-center">
						<a href="index.aspx">Home<span class="lnr lnr-arrow-right"></span></a>
						<a href="services.aspx">Serviços</a>
					</nav>
				</div>
			</div>
		</div>
	</section>
	<!-- End Banner Area -->
    <div class='container-fluid mx-auto mt-5 mb-5 col-12' style="text-align: center">
    <div class="blog_details"><h2>Os nossos serviços</h2></div>
    <p class="text-muted">Sempre preste a servir os nossos clientes, não importa o que você peça.</p>
    <div class="row" style="justify-content: center">
        <div class="card col-md-3 col-12">
            <div class="card-content">
                <div class="card-body"> <img class="rounded" src="img/services/1.jpg" />
                    <div class="shadow"></div>
                    <div class="card-title"><h4>Aconselhamento Técnico</h4> </div>
                    <div class="card-subtitle">
                        <p class="text-muted">A nossa Equipa aguarda a sua visita, onde o poderemos aconselhar, desde o género de aquário apropriado ao seu espaço, peixes e ornamentação de forma a obter o resultado desejado. </p>
                    </div>
                </div>
            </div>
        </div>
        <div class="card col-md-3 col-12 ml-2">
            <div class="card-content">
                <div class="card-body"> <img class="rounded" src="img/services/2.jpg" />
                    <div class="card-title"> <h4> Montagem e Manutenção de Aquários </h4></div>
                    <div class="card-subtitle">
                        <p class="text-muted"> Ter um Aquário muitas vezes com espécies específicas e únicas requer uma manutenção e um tratamento exclusivo e apropriado, solicitando ao seu proprietário um tempo e atenção que muitas vezes lhe é complicado de ter. Igualmente espaços comerciais e Empresas, têm uma necessidade de serviços de manutenção dos seus aquários de forma a terem sempre os seus peixes e plantas nas condições ideais.
                            A <b>CrownFish</b> faz não somente a Montagem do Aquário, como também faz a Manutenção Especializada. </p>
                    </div>
                </div>
            </div>
        </div>
        <div class="card col-md-3 col-12 ml-2">
            <div class="card-content">
                <div class="card-body"> <img class="rounded" src="img/services/3.jpg" />
                    <div class="card-title"><h4> Orçamentos Grátis </h4></div>
                    <div class="card-subtitle">
                        <p class="text-muted">Aconselhe-se Connosco! Dê-nos a conhecer o seu plano. Se necessitar de algum dos nossos serviços, <a href="contact.aspx">contacte-nos!</a> </p>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
</asp:Content>
