<%@ Control Language="C#" AutoEventWireup="true" CodeFile="sbAccount.ascx.cs" Inherits="sbAccount" %>

<div class="row input-margin-bottom">
<div class="form-group">

    <asp:Label ID="lblAccount" CssClass="col-md-4 control-label" runat="server" Text="Label"></asp:Label>

    <div class="col-md-8">
    <asp:TextBox ID="txtAccount" CssClass="form-control" runat="server" Width="100%"></asp:TextBox>
        <asp:RequiredFieldValidator ID="valAccount" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtAccount" Display="Dynamic" ForeColor="#CC0000" ValidationGroup="None"></asp:RequiredFieldValidator>
    </div><!-- ./col-md-8 -->

</div><!-- ./form-group -->
</div><!-- ./input-margin-bottom -->