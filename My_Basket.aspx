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
                <div class="text-center">
                    <asp:Label ID="lblLoginMessage" runat="server" Text="" CssClass="control-label text-center" ForeColor="#cc0000"></asp:Label>
                </div><!-- ./text-center -->

            <div class="col-md-3">
                <div class="page-header text-center">
                    <h3>Hello, <asp:Label ID="lblName" runat="server"></asp:Label></h3>
                 </div><!-- ./page-header -->
                    <table class="table table-condensed table-striped">
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
                                <td colspan="2">
                                    <a class="btn btn-sm btn-primary" style="width: 100%" role="button" data-toggle="modal" data-target="#modal-balance">Add Balance</a>
                                </td>
                            </tr>
                        </tbody>
                    </table>

                <!-- Modal - Website 1 :: Start -->
  		<div class="modal fade" id="modal-balance" role="dialog">
    		<div class="modal-dialog modal-lg">
      		<div class="modal-content">
        		<div class="modal-header">
          			<button type="button" class="close" data-dismiss="modal">&times;</button>
          			<h4 class="modal-title">Account Balance for <asp:Label ID="lblCustFullName" runat="server" Text="Label"></asp:Label></h4>
        		</div><!-- ./modal-header -->
        		<div class="modal-body">
          			
                <div class="row input-margin-bottom">
                <div class="form-group">

                    <strong><asp:Label ID="lbl1" CssClass="col-md-4 control-label" runat="server" Text="Current Balance"></asp:Label></strong>

                    <div class="col-md-8">
                        <asp:TextBox ID="txtCurrBalance" CssClass="form-control" runat="server" Width="100%" Enabled="false"></asp:TextBox>
                </div><!-- ./col-md-8 -->

            </div><!-- ./form-group -->
            </div><!-- ./input-margin-bottom -->

                    <div class="row input-margin-bottom">
                    <div class="form-group">

                    <strong><asp:Label ID="Label1" CssClass="col-md-4 control-label" runat="server" Text="New Amount"></asp:Label></strong>

                    <div class="col-md-8">
                        <asp:TextBox ID="txtNewAmount" CssClass="form-control" runat="server" Width="100%"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="New Amount is required" ControlToValidate="txtNewAmount" Display="Dynamic" ForeColor="#CC0000" ValidationGroup="valBalanceGroup"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="valNewBalance" runat="server" ErrorMessage="Only Numbers (Integers)."
                 Display="Dynamic" ControlToValidate="txtNewAmount" ValidationExpression="^\d+$" ForeColor="#CC0000" ValidationGroup="valBalanceGroup"></asp:RegularExpressionValidator>
                    </div><!-- ./col-md-8 -->

                    </div><!-- ./form-group -->
                    </div><!-- ./input-margin-bottom -->

        		</div><!-- ./modal-body -->
        		<div class="modal-footer">
                    <asp:Button ID="btnAddBalance" CssClass="btn btn-primary" runat="server" Text="Add Balance" ValidationGroup="valBalanceGroup" OnClick="btnAddBalance_Click"/>
          			<button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
        		</div><!-- ./moda-footer-->
      		</div><!-- ./modal-content-->
    		</div><!-- ./modal-dialog -->
  		</div><!-- ./modal -->
		<!-- Modal - Website 1 :: End -->
                
            </div><!-- ./col-md-3 -->
            <div class="col-md-9 text-center">
                <div class="page-header text-center">
                    <h3>View My Recipes</h3>
                 </div><!-- ./page-header -->
            <asp:Repeater ID="rptRecipes" runat="server" OnItemCommand="rptRecipes_ItemCommand">
            <HeaderTemplate>
                <%-- This only happens once! --%>
                <table class="table table-striped table-bordered table-hover">
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

