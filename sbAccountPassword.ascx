<%@ Control Language="C#" AutoEventWireup="true" CodeFile="sbAccountPassword.ascx.cs" Inherits="sbAccountPassword" %>

<div class="row input-margin-bottom">
<div class="form-group">

    <asp:Label ID="lblAccount" CssClass="col-md-4 control-label" runat="server" Text="Label"></asp:Label>

    <div class="col-md-8">
    <asp:TextBox ID="txtAccount" CssClass="form-control" runat="server" Width="100%" TextMode="Password"></asp:TextBox>
        <asp:RequiredFieldValidator ID="valAccount" runat="server" ErrorMessage="Password is required" ControlToValidate="txtAccount" Display="Dynamic" ForeColor="#CC0000"  ValidationGroup="None"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator Display = "Dynamic" ControlToValidate = "txtAccount" ID="valPassword2" ValidationExpression = "^[\s\S]{6,}$" runat="server" ErrorMessage="Minimum 6 characters required" ForeColor="#CC0000"  ValidationGroup="None"></asp:RegularExpressionValidator>
    </div><!-- ./col-md-8 -->

</div><!-- ./form-group -->
</div><!-- ./input-margin-bottom -->