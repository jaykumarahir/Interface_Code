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
                <div class="row">
                    <asp:Button ID="btnLogIn" runat="server" Text="Log In" Width="100%" CssClass="btn btn-md btn-info" ValidationGroup="loginInfo"/>
                </div><!-- ./row -->
                </div><!-- ./well -->
            </div><!-- ./col-md-5 -->
            <div class="col-md-7">
                <div class="page-header text-center">
                    <h3>Create Account</h3>
                 </div><!-- ./page-header -->

                <!-- CONTROL #1 -->
                <uc1:sbAccount runat="server" ID="sbAccount" LabelText="First Name" PlaceHolderText="First Name" ValidatorMessage="First Name is required." ValidationGroupText="signUpInfo"/>

                <!-- CONTROL #2 -->
                <uc1:sbAccount runat="server" ID="sbAccount1" LabelText="Last Name" PlaceHolderText="Last Name" ValidatorMessage="Last Name is required." ValidationGroupText="signUpInfo"/>

                <!-- CONTROL #3 --> 
                <uc1:sbAccount runat="server" ID="sbAccount2" LabelText="Phone Number" PlaceHolderText="999-999-9999" ValidatorMessage="Phone Number is required" ValidationGroupText="signUpInfo"/>
                
                <!-- CONTROL #4 -->
                <uc1:sbAccountEmail runat="server" ID="sbAccountEmail" LabelText="Email" PlaceHolderText="example@mail.com" ValidatorMessage="Email is required" ValidationGroupText="signUpInfo"/>

                <!-- CONTROL #5 -->
                <uc1:sbAccountPassword runat="server" ID="sbAccountPassword1" LabelText="Password" PlaceHolderText="Password" ValidationGroupText="signUpInfo"/>

                <div class="row">
                    <asp:Button ID="btnSaveAccount" runat="server" Text="Create Account" Width="100%" CssClass="btn btn-md btn-primary" ValidationGroup="signUpInfo"/>
                </div><!-- ./row -->

            </div><!-- ./col-md-7 -->
            </div><!-- ./col-md-12 -->
        </section><!-- ./section -->

    </div><!-- ./container -->
</asp:Content>

