<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Recipe_Details.aspx.cs" Inherits="Recipe_Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container">
        <section role="recipe-details-container">
            <div class="page-header text-center page-header-bottom">
                <h1 class="main-title top-space">Recipe Details</h1>
            </div><!-- ./page-header -->

            <div class="col-md-12">
                
            <div class="col-md-6">
             <asp:Repeater ID="rptSingleRecipe" runat="server" OnItemCommand="rptSingleRecipe_ItemCommand">
            <HeaderTemplate>
                <%-- This only happens once! --%>
                <table class="table table-condensed">
                    <thead>
                        <tr>
                            <th colspan="2" class="main-title text-center">Recipe Information</th></tr>
                    </thead>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>Recipe ID</td>
                    <td><%#Eval("reci_id")%></td>
                </tr>
                <tr>
                    <td>Name</td>
                    <td><%#Eval("name")%></td>
                </tr>
                <tr>
                    <td>Submitted By</td>
                    <td><%#Eval("submitted_by")%></td>
                </tr>
                <tr>
                    <td>Category</td>
                    <td><%#Eval("category")%></td>
                </tr>
                <tr>
                    <td>Prepare/Cooking Time (MIN)</td>
                    <td><%#Eval("cook_time")%> min</td>
                </tr>
                <tr>
                    <td>Number of Servings</td>
                    <td><%#Eval("num_serving")%></td>
                </tr>
                <tr>
                    <td>Description</td>
                    <td><%#Eval("descr")%></td>
                </tr>
                <tr>
                    <td colspan="2"><asp:LinkButton ID="delButton" CommandName="Delete" CommandArgument=<%#Eval("reci_id") %> runat="server" CssClass="btn btn-lg btn-warning" Width="100%">Delete Recipe</asp:LinkButton></td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
                </div><!-- ./col-md-6 -->
                <div class="col-md-6">

                    <asp:Repeater ID="rptIngredient" runat="server" OnItemCommand="rptSingleRecipe_ItemCommand">
            <HeaderTemplate>
                <%-- This only happens once! --%>
                <table class="table table-condensed">
                    <thead>
                        <tr>
                        <th class="text-center main-title">Name</th>
                        <th class="text-center main-title">Quantity</th>
                        <th class="text-center main-title">Unit Measure</th>
                        </tr>
                    </thead>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td class="text-center"><%#Eval("name") %></td>
                    <td class="text-center"><%#Eval("qty")%></td>
                    <td class="text-center"><%#Eval("unit_m")%></td>
                </tr>

            </ItemTemplate>
            <FooterTemplate>
                <tr>
                    <td colspan="3"><a href="All_Recipes.aspx" class="btn btn-lg btn-warning" style="width: 100%">Return to View Recipes</a></td>
                </tr>
                </table>
            </FooterTemplate>
        </asp:Repeater>

                </div><!-- ./col-md-6 -->
           
                
            </div><!-- ./col-md-12 -->
        </section><!-- ./section -->
    </div><!-- ./container -->
</asp:Content>

