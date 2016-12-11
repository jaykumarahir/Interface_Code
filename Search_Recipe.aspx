<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Search_Recipe.aspx.cs" Inherits="Search_Recipe" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>Search Recipe</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container">
        <section role="under-construction-container">
            <div class="page-header text-center page-header-bottom">
                <h1 class="main-title top-space">Search Recipe</h1>
            </div><!-- ./page-header -->

            <div class="col-lg-12">
                <div class="text-center">
                    <asp:Label ID="lblLoginMessage" runat="server" Text="" CssClass="control-label text-center" ForeColor="#cc0000"></asp:Label>
                </div><!-- ./text-center -->
                <div class="col-sm-3">
                    <asp:DropDownList ID="ddlPriceRange" runat="server" Width="100%" CssClass="form-control"></asp:DropDownList>
                </div><!-- ./col-sm-3-->

                <div class="col-sm-3">
                    <asp:DropDownList ID="ddlCategory" runat="server" Width="100%" CssClass="form-control"></asp:DropDownList>
                </div><!-- ./col-sm-3-->

                <div class="col-sm-3">
                    <asp:DropDownList ID="ddlIngredient" runat="server" Width="100%" CssClass="form-control"></asp:DropDownList>
                </div><!-- ./col-sm-3-->
                    
                <div class="col-sm-2">
                    <asp:Button ID="btnSearch" CssClass="btn btn-lg btn-warning" runat="server" Text="Search" OnClick="btnSearch_Click" />
                </div>

                
            </div><!-- ./col-md-12 -->

            <div class="col-md-12">
                <asp:Label ID="lblError" runat="server" Text="" CssClass="control-label text-center" ForeColor="#cc0000"></asp:Label>

                <asp:Repeater ID="rptRecipes" runat="server" OnItemCommand="rptRecipes_ItemCommand">
            <HeaderTemplate>
                <%-- This only happens once! --%>
                <table class="table table-striped table-bordered table-hover">
                    <thead>
                        <tr>
                        <th class="text-center main-title">Name</th>
                        <th class="text-center main-title">Category</th>
                        <th class="text-center main-title">Cooking Time</th>
                        <th class="text-center main-title">Description</th>
                        <th class="text-center main-title">Price</th>
                        </tr>
                    </thead>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td class="text-center"><%#Eval("name") %></td>
                    <td class="text-center"><%#Eval("category")%></td>
                    <td class="text-center"><%#Eval("cook_time") %></td>
                    <td class="text-center"><%#Eval("descr")%></td>
                    <td class="text-center"><asp:LinkButton ID="btnBuy" runat="server" CommandArgument=<%#Eval("reci_id") %> CommandName="BuyRecipe" CssClass="btn btn-sm btn-info">Buy $<%#Eval("price") %></asp:LinkButton></td>
                </tr>

            </ItemTemplate>
            <FooterTemplate>
                <tr>
                    <td colspan="6"><a href="All_Recipes.aspx" class="btn btn-lg btn-warning" style="width: 100%">Return to View Recipes</a></td>
                </tr>
                </table>
            </FooterTemplate>
        </asp:Repeater>
            </div>
        </section><!-- ./section -->
    </div><!-- ./container -->
</asp:Content>

