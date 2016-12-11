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
                <table class="table table-striped table-bordered table-hover">
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
                    <td>Price</td>
                    <td><%#Eval("price")%></td>
                </tr>
                <tr>
                    <td colspan="2"><a class="btn btn-md btn-primary" style="width: 49%" data-toggle="modal" data-target="#modal-rating">Add Rating</a>
                        <asp:LinkButton ID="delButton" CommandName="Delete" CommandArgument=<%#Eval("reci_id") %> runat="server" CssClass="btn btn-md btn-danger" Width="49%">Delete Recipe From Basket</asp:LinkButton></td>
                    
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>

                   <!-- Modal - Website 1 :: Start -->
  		<div class="modal fade" id="modal-rating" role="dialog">
    		<div class="modal-dialog modal-lg">
      		<div class="modal-content">
        		<div class="modal-header">
          			<button type="button" class="close" data-dismiss="modal">&times;</button>
          			<h4 class="modal-title">Rating for <asp:Label ID="lblRecipeName" runat="server" Text="Label"></asp:Label></h4>
        		</div><!-- ./modal-header -->
        		<div class="modal-body">
          			
                <div class="row input-margin-bottom">
                <div class="form-group">

                    <strong><asp:Label ID="lbl1" CssClass="col-md-4 control-label" runat="server" Text="My Current Rating"></asp:Label></strong>

                    <div class="col-md-8">
                        <asp:TextBox ID="txtCurrRating" CssClass="form-control" runat="server" Width="100%" Enabled="false"></asp:TextBox>
                </div><!-- ./col-md-8 -->

            </div><!-- ./form-group -->
            </div><!-- ./input-margin-bottom -->

                    <div class="row input-margin-bottom">
                    <div class="form-group">

                    <strong><asp:Label ID="Label1" CssClass="col-md-4 control-label" runat="server" Text="New Rating - 1 (poor) to 10 (excellent)"></asp:Label></strong>

                    <div class="col-md-8">
                        <asp:TextBox ID="txtNewRating" CssClass="form-control" runat="server" Width="100%" placeholder="1 (poor) - 10 (excellent)"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="New Rating is required" ControlToValidate="txtNewRating" Display="Dynamic" ForeColor="#CC0000" ValidationGroup="valRatingGroup"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="valNewBalance" runat="server" ErrorMessage="Only Numbers - 1 (poor) to 10 (excellent) ."
                 Display="Dynamic" ControlToValidate="txtNewRating" ValidationExpression="^\d+$" ForeColor="#CC0000" ValidationGroup="valRatingGroup"></asp:RegularExpressionValidator>
                    </div><!-- ./col-md-8 -->

                    </div><!-- ./form-group -->
                    </div><!-- ./input-margin-bottom -->

        		</div><!-- ./modal-body -->
        		<div class="modal-footer">
                    <asp:Button ID="btnAddRating" runat="server" Text="Add Rating" CssClass="btn btn-primary" ValidationGroup="valRatingGroup" OnClick="btnAddRating_Click"/>
          			<button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
        		</div><!-- ./moda-footer-->
      		</div><!-- ./modal-content-->
    		</div><!-- ./modal-dialog -->
  		</div><!-- ./modal -->
		<!-- Modal - Website 1 :: End -->
                <div class="row">
                    <asp:label ID="lblRating" runat="server"></asp:label>
                </div>
                </div><!-- ./col-md-6 -->
                <div class="col-md-6">

                    <asp:Repeater ID="rptIngredient" runat="server" OnItemCommand="rptSingleRecipe_ItemCommand">
            <HeaderTemplate>
                <%-- This only happens once! --%>
                <table class="table table-striped table-bordered table-hover">
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
                    <td colspan="3"><a href="My_Basket.aspx" class="btn btn-md btn-info" style="width: 100%">Return to My Basket</a></td>
                </tr>
                </table>
            </FooterTemplate>
        </asp:Repeater>

                </div><!-- ./col-md-6 -->
           
                
            </div><!-- ./col-md-12 -->
        </section><!-- ./section -->
    </div><!-- ./container -->
</asp:Content>

