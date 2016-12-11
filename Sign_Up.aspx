<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Sign_Up.aspx.cs" Inherits="Sign_Up" %>

<%@ Register Src="~/sbAccount.ascx" TagPrefix="uc1" TagName="sbAccount" %>
<%@ Register Src="~/sbAccountPassword.ascx" TagPrefix="uc1" TagName="sbAccountPassword" %>
<%@ Register Src="~/sbAccountEmail.ascx" TagPrefix="uc1" TagName="sbAccountEmail" %>




<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container">
        <section role="account-container">
            <div class="page-header text-center page-header-bottom">
                <h1 class="main-title top-space">Join Us Today!</h1>
            </div><!-- ./page-header -->

            <div class="col-md-12">
                

            <div class="col-md-5">
                <div class="page-header text-center">
                    <h3>Log In</h3>
                 </div><!-- ./page-header -->
                <asp:Label ID="lblError" runat="server" Text="" ForeColor="#CC0000"></asp:Label>
                <div class="well">
                <!-- CONTROL #1 -->
                <div class="row input-margin-bottom">
                <div class="form-group input-margin-top">

                    <asp:Label ID="lblName" CssClass="col-md-4 control-label" runat="server" Text="Account"></asp:Label>

                    <div class="col-md-8">
                        <asp:dropdownlist ID="ddlAccount" runat="server" CssClass="form-control" Width="100%" ValidationGroup="loginInfo"></asp:dropdownlist>
                        <asp:RequiredFieldValidator ID="valAccount" runat="server" ErrorMessage="Account is required" ControlToValidate="ddlAccount" Display="Dynamic" ForeColor="#CC0000"></asp:RequiredFieldValidator>
                    </div><!-- ./col-md-8 -->

                </div><!-- ./form-group -->
                </div><!-- ./input-margin-bottom -->

                <!-- CONTROL #2 -->
                <uc1:sbAccountPassword runat="server" ID="sbAccountPassword" LabelText="Password" PlaceHolderText="Password" ValidationGroupText="loginInfo"/>
                <asp:Label ID="Label1" runat="server" Text="Note: The password for all accounts is 'password'."></asp:Label>
                <div class="row">
                    <asp:Button ID="btnLogIn" runat="server" Text="Log In" Width="100%" CssClass="btn btn-md btn-info" ValidationGroup="loginInfo" OnClick="btnLogIn_Click"/>
                </div><!-- ./row -->
                </div><!-- ./well -->
            </div><!-- ./col-md-5 -->

            <div class="col-md-7">
                <div class="page-header text-center">
                    <h3>Create Account</h3>
                 </div><!-- ./page-header -->
                <asp:Label ID="lblError1" runat="server" Text="" ForeColor="#CC0000"></asp:Label>
                <!-- CONTROL #1 -->
                <uc1:sbAccount runat="server" ID="sbAccount" LabelText="First Name" PlaceHolderText="First Name" ValidatorMessage="First Name is required." ValidationGroupText="signUpInfo"/>

                <!-- CONTROL #2 -->
                <uc1:sbAccount runat="server" ID="sbAccount1" LabelText="Last Name" PlaceHolderText="Last Name" ValidatorMessage="Last Name is required." ValidationGroupText="signUpInfo"/>

                <!-- CONTROL #3 --> 
                <div class="row input-margin-bottom">
                <div class="form-group">

                    <asp:Label ID="lblPhone" CssClass="col-md-4 control-label" runat="server" Text="Phone"></asp:Label>

                    <div class="col-md-8">
                    <asp:TextBox ID="txtPhone" CssClass="form-control" runat="server" Width="100%" placeholder="9999999999"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="valPhone" runat="server" ErrorMessage="Invalid Phone Number. Only Numbers"
                 Display="Dynamic" ControlToValidate="txtPhone" ValidationExpression="^\d{10}$" ForeColor="#CC0000" ValidationGroup="signUpInfo"></asp:RegularExpressionValidator>

                    </div><!-- ./col-md-8 -->

                </div><!-- ./form-group -->
                </div><!-- ./input-margin-bottom -->
             
                
                <!-- CONTROL #4 -->
                <uc1:sbAccountEmail runat="server" ID="sbAccountEmail" LabelText="Email" PlaceHolderText="example@mail.com" ValidatorMessage="Email is required" ValidationGroupText="signUpInfo"/>

                <!-- CONTROL #5 -->
                <uc1:sbAccountPassword runat="server" ID="sbAccountPassword1" LabelText="Password" PlaceHolderText="Password" ValidationGroupText="signUpInfo"/>

                <div class="row">
                    <asp:Button ID="btnSaveAccount" runat="server" Text="Create Account" Width="100%" CssClass="btn btn-md btn-primary" ValidationGroup="signUpInfo" OnClick="btnSaveAccount_Click"/>
                </div><!-- ./row -->

            </div><!-- ./col-md-7 -->
            </div><!-- ./col-md-12 -->
        </section><!-- ./section -->

    </div><!-- ./container -->
</asp:Content>

