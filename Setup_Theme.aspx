<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Setup_Theme.aspx.cs" Inherits="Setup_Theme" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
        <title>MyRecipe Themes</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container">
        <section role="under-construction-container">
            <div class="page-header text-center page-header-bottom">
                <h1 class="main-title top-space">Setup Theme</h1>
            </div><!-- ./page-header -->

            <div class="col-md-12">
                
                <div class="col-sm-6 col-md-6">
    		<div class="thumbnail">
      			<img src="img/light_theme.png" alt="MyRecipe Website with Light Theme">
      			<div class="caption">
        			<h3>Light Theme</h3>
        			<p>Clean theme with soft colors.</p>
                      <asp:Button ID="btnLight" runat="server" Text="Select Light Theme" CssClass="btn btn-lg btn-info" OnClick="btnLight_Click" Width="100%"/>
      			</div><!-- ./caption -->
    		</div><!-- ./thumnail -->
  		</div><!-- ./col-md-6 -->

            <div class="col-sm-6 col-md-6">
    		<div class="thumbnail">
      			<img src="img/dark_theme.png" alt="MyRecipe Website with Dark Theme">
      			<div class="caption">
        			<h3>Dark Theme</h3>
        			<p>Beautiful theme with dark colors.</p>
        			<asp:Button ID="btnDark" runat="server" Text="Select Dark Theme" CssClass="btn btn-lg btn-info" OnClick="btnDark_Click" Width="100%" />
      			</div><!-- ./caption -->
    		</div><!-- ./thumnail -->
  		</div><!-- ./col-md-6 -->

            </div><!-- ./col-md-12 -->
        </section><!-- ./section -->
    </div><!-- ./container -->
</asp:Content>

