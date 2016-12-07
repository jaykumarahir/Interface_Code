<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>MyRecipe Home</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <!-- FIRST CONTAINER - CIRCLES :: START -->
    <div class="gray-back no-margin-bottom">
    <div class="container">
        <div class="page-header text-center page-header-bottom">
            <h1 class="logo-title top-space">Welcome to MyRecipes!</h1>
        </div><!-- ./page-header -->
    </div><!-- ./container -->
    </div><!-- ./gray-back-->

    <div class="">
        <section role="interactive-buttons" class="text-center">

            <div id="sub-banner-1" class="col-md-6 text-center">
                    <h3 class="banner-text">
                        View Our Largest Collection of Home-Made Recipes in the World!</h3>
            </div><!-- .col-md-3-->

            <div class="col-md-6 text-center" id="sub-banner-2">
                    <h3 class="banner-text">Search or Add Your Favorite Recipe!</h3>
            </div><!-- ./col-md-3-->
            
            <!--<div class="col-xs-6 col-md-3 text-center" id="lg-menu-div-3">
                    <h3 class="main-title"><span class="text-middle-div">
                        Add</span>
                    </h3>
            </div>--><!-- ./col-md-3 -->

            <!--<div class="col-xs-6 col-md-3 text-center" id="lg-menu-div-4">
                    <h3 class="main-title"><span class="text-middle-div">
                        Search</span></h3>
            </div>--><!-- ./col-md-3-->
        </section>
    </div>

    <!-- FIRST CONTAINER - CIRCLES :: END -->


    <div class="container">
        <div class="col-md-4">
            <div class="page-header text-center page-header-bottom">
                <h3 class="main-title">MyRecipe Features</h3>
            </div>
                <p>MyRecipe contains the largest collection of home-made recipes from around the world.
                    Each day hundreds of delicious recipes are added by our active users.
                    These are some of the features our website provide:
                </p>
                <ul>
                    <li>Find the food you need for any occasion with our recipe finder.</li>
                    <li>Add any recipe you like to our largest collection of home-made recipes.</li>
                    <li>View the delicious recipes added by our users.</li>
                </ul>
        </div><!-- ./col-md-6 -->

        <div class="col-md-8">

            	<!-- GALLERY :: START -->
	<div class="gallery-border temp-margin-top" id="main-gallery">
		<section role="main-gallery">
			<!-- CAROUSEL :: END -->
			<div class="carousel slide" id="screenshot-carousel" data-ride="carousel">
				<ol class="carousel-indicators">
					<li data-target="#screenshot-carousel" data-slide-to="0" class="active"></li>
					<li data-target="#screenshot-carousel" data-slide-to="1"></li>
					<li data-target="#screenshot-carousel" data-slide-to="2"></li>
                    <li data-target="#screenshot-carousel" data-slide-to="3"></li>
                    <li data-target="#screenshot-carousel" data-slide-to="4"></li>
				</ol><!-- ./carousel-slide -->

				<!-- CAROUSEL-INNER :: START -->
				<div class="carousel-inner">
					<!-- FIRST ELEMENT :: START -->
					<div class="item active">
						<img src="img/recipe1.jpg" alt="Gallery Picture 1">
						<div class="carousel-caption">

							<div class="text-center">
							<h3 class="logo-title">American Cuisine</h3>
							</div><!-- ./text-center -->
						</div><!-- ./carousel-caption -->
					</div><!-- ./item -->
					<!-- FIRST ELEMENT :: END -->

					<!-- SECOND ELEMENT :: START -->
					<div class="item">
						<img src="img/recipe2.jpg" alt="Gallery Picture 2">
						<div class="carousel-caption">
							

							<div class="text-center">
							<h3 class="logo-title">Indian Cousine</h3>
							</div><!-- ./text-center -->
						</div> <!-- ./carousel-caption -->
					</div><!-- ./item -->
					<!-- SECOND ELEMENT :: END -->

					<!-- THIRD ELEMENT :: START -->
					<div class="item">
						<img src="img/recipe3.jpg" alt="Gallery Picture 3">
						<div class="carousel-caption">

							<div class="text-center">
							<h3 class="logo-title">Chinese Cuisine</h3>
							</div><!-- ./text-center -->
						</div> <!-- carousel-caption-->
					</div> <!-- ./item -->
					<!-- THIRD ELEMENT :: END -->

                    <!-- FOURTH ELEMENT :: START -->
					<div class="item">
						<img src="img/recipe4.jpg" alt="Gallery Picture 4">
						<div class="carousel-caption">
							

							<div class="text-center">
							<h3 class="logo-title">Greek Cuisine</h3>
							</div><!-- ./text-center -->
						</div> <!-- ./carousel-caption -->
					</div> <!-- ./item -->
					<!-- FOURTH ELEMENT :: END -->

                    <!-- FIFTH ELEMENT :: START -->
					<div class="item">
						<img src="img/recipe5.jpg" alt="Gallery Picture 5">
						<div class="carousel-caption">

							<div class="text-center">
							<h3 class="logo-title">Arab Cuisine</h3>
							</div><!-- ./text-center -->
						</div> <!-- ./carousel-caption -->
					</div> <!-- ./item -->
					<!-- FIFTH ELEMENT :: END -->
				</div>
				<!-- CAROUSEL-INNER :: END -->
				<a href="#screenshot-carousel" class="left carousel-control" data-slide="prev">
					<span class="glyphicon glyphicon-chevron-left"></span>
				</a>
				<a href="#screenshot-carousel" class="right carousel-control" data-slide="next">
					<span class="glyphicon glyphicon-chevron-right"></span>
				</a>
			</div>
			<!-- CAROUSEL :: END -->
		</section>
	</div>
	<!-- GALLERY :: END -->


        </div><!-- ./col-md-6 -->
    </div><!-- ./container -->
</asp:Content>

