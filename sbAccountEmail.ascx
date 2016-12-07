<%@ Control Language="C#" AutoEventWireup="true" CodeFile="sbAccountEmail.ascx.cs" Inherits="sbAccountEmail" %>

<div class="row input-margin-bottom">
<div class="form-group">

    <asp:Label ID="lblAccount" CssClass="col-md-4 control-label" runat="server" Text="Label"></asp:Label>

    <div class="col-md-8">
    <asp:TextBox ID="txtAccount" CssClass="form-control" runat="server" Width="100%" TextMode="Email" ></asp:TextBox>
        <asp:RequiredFieldValidator ID="valAccount" runat="server" ErrorMessage="valEmail" ControlToValidate="txtAccount" Display="Dynamic" ForeColor="#CC0000" ValidateGroup="None"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator Display = "Dynamic" ControlToValidate = "txtAccount" ID="valEmail2" ValidationExpression = "^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$" runat="server" ErrorMessage="Invalid email" ForeColor="#CC0000" ValidateGroup="None"></asp:RegularExpressionValidator>

    </div><!-- ./col-md-8 -->

</div><!-- ./form-group -->
</div><!-- ./input-margin-bottom -->