<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="All_Recipes.aspx.cs" Inherits="All_Recipes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>View Recipes</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container">
        <section role="under-construction-container">
            <div class="page-header text-center page-header-bottom">
                <h1 class="main-title top-space">View All Recipes</h1>
            </div><!-- ./page-header -->

            <%-- REMEMBER: YOU HAVE MADE AS COMMENTS THREE COLUMNS OF THE RECIPE TABLE--%>

            <div class="col-md-12 text-center">

            <asp:Repeater ID="rptRecipes" runat="server" OnItemCommand="rptRecipes_ItemCommand">
            <HeaderTemplate>
                <%-- This only happens once! --%>
                <table class="table table-condensed">
                    <thead>
                        <tr class="main-title">
                            <th class="text-center">Name</th>
                            <th class="text-center">Category</th>
                            <th class="text-center">Description</th>
                            <th class="text-center">Rating</th>
                            <th class="text-center">Price</th>
                        </tr>
                    </thead>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><%#Eval("name") %></td>
                    <td><%#Eval("category")%></td>
                    <td><%#Eval("descr") %></td>
                    <td>10.0</td><!-- Value need to be changed! -->
                    <td><asp:LinkButton ID="LinkButton1" runat="server" CommandArgument=<%#Eval("reci_id") %> CommandName="BuyRecipe" CssClass="btn btn-sm btn-warning">Buy $<%#Eval("price") %></asp:LinkButton></td>

                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>

            </div><!-- ./col-md-12 -->
        </section><!-- ./section -->

    </div><!-- ./container -->
</asp:Content>

