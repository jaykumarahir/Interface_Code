<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="My_Basket.aspx.cs" Inherits="My_Basket" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="container">
        <section role="my-basket-container">
            <div class="page-header text-center page-header-bottom">
                <h1 class="main-title top-space">View My Basket</h1>
            </div><!-- ./page-header -->

            <%-- REMEMBER: YOU HAVE MADE AS COMMENTS THREE COLUMNS OF THE RECIPE TABLE--%>

            <div class="col-md-12">
            <div class="col-md-3">
                <div class="page-header text-center">
                    <h3>Hello, <asp:Label ID="lblName" runat="server">Dannel Alon</asp:Label></h3>
                 </div><!-- ./page-header -->
                    <table class="table table-condensed">
                        <thead class="text-center">
                            <tr class="text-center main-title">
                                <th colspan="2">Account Information</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>Customer ID</td>
                                <td>
                                    <asp:Label ID="lblCustId" runat="server" Text="Label"></asp:Label></td>
                            </tr>
                            <tr>
                                <td>Email</td>
                                <td>
                                    <asp:Label ID="lblEmail" runat="server" Text="Label"></asp:Label></td>
                            </tr>
                            <tr>
                                <td>Phone</td>
                                <td>
                                    <asp:Label ID="lblPhone" runat="server" Text="Label"></asp:Label></td>
                            </tr>
                            <tr>
                                <td>Basket ID</td>
                                <td>
                                    <asp:Label ID="lblBasket" runat="server" Text="Label"></asp:Label></td>
                            </tr>
                            <tr>
                                <td><h5><strong>Current Balance</strong></h5></td>
                                <td>
                                    <h5><strong><asp:Label ID="lblBalance" runat="server" Text="$Label"></asp:Label></strong></h5></td>
                            </tr>
                            <tr>
                                <td colspan="2"><div class="btn btn-sm btn-warning" style="width: 100%">Add Balance</div></td>
                            </tr>
                        </tbody>
                    </table>
                
            </div><!-- ./col-md-3 -->
            <div class="col-md-9 text-center">
                <div class="page-header text-center">
                    <h3>View My Recipes</h3>
                 </div><!-- ./page-header -->
            <asp:Repeater ID="rptRecipes" runat="server" OnItemCommand="rptRecipes_ItemCommand">
            <HeaderTemplate>
                <%-- This only happens once! --%>
                <table class="table table-condensed">
                    <thead>
                        <tr class="main-title">
                            <th class="text-center">Name</th>
                            <th class="text-center">Category</th>
                            <th class="text-center">Description</th>
                            <th class="text-center">More Information</th>
                        </tr>
                    </thead>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><%#Eval("name") %></td>
                    <td><%#Eval("category")%></td>
                    <td><%#Eval("descr") %></td>
                    <td><asp:LinkButton ID="btnMoreInfo" runat="server" CommandArgument=<%#Eval("reci_id") %> CommandName="MoreInformation" CssClass="btn btn-sm btn-warning">More Information</asp:LinkButton></td>

                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
            </div><!-- ./col-md-9-->
            </div><!-- ./col-md-12 -->
        </section><!-- ./section -->

    </div><!-- ./container -->
</asp:Content>

