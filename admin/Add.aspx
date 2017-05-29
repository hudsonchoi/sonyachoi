<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageAdmin.master" AutoEventWireup="true" CodeFile="Add.aspx.cs" Inherits="admin_Add" %>
<%@ MasterType VirtualPath="~/MasterPageAdmin.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<br /><br /><br /><br />
<div style="width:400px; margin:0 auto;">
<table border="0" style="width:400px">
<tr>
<td align="center" class="heavy" colspan="8">
         <asp:CheckBox ID="cbSale" runat="server" Text="Sale"/> <asp:CheckBox ID="cbRental" runat="server" Text="Rental"/>
                  <asp:CustomValidator ID="cvType" runat="server" 
             ErrorMessage="<img src='../images/alert.gif'>" Display="Dynamic" 
             onservervalidate="cvType_ServerValidate"></asp:CustomValidator>
    </td>
</tr>
<tr>
<td align="right" class="heavy">Listing ID:</td><td><asp:TextBox ID="tbListingID" runat="server" Width="77px"></asp:TextBox>
<asp:RequiredFieldValidator ID="rfvListingID" runat="server" ErrorMessage="<img src='../images/alert.gif'>" 
        ControlToValidate="tbListingID" Display="Dynamic"></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator ID="revListingID" runat="server" 
        ControlToValidate="tbListingID" Display="Dynamic" ErrorMessage="<img src='../images/alert.gif'>" 
        ValidationExpression="^\d+(\.\d+)?$"></asp:RegularExpressionValidator>
</td>
<td align="right" style="width:85px" class="heavy"># of Images:</td><td><asp:TextBox ID="tbNumOfImages" runat="server" Width="33px"></asp:TextBox>
<asp:RequiredFieldValidator ID="rfvNumOfImages" runat="server" ErrorMessage="<img src='../images/alert.gif'>" 
        ControlToValidate="tbNumOfImages" Display="Dynamic"></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator ID="revNumOfImages" runat="server" 
        ControlToValidate="tbNumOfImages" Display="Dynamic" ErrorMessage="<img src='../images/alert.gif'>" 
        ValidationExpression="^\d+(\.\d+)?$"></asp:RegularExpressionValidator>
</td>
</tr>
<tr><td colspan="4">&nbsp;</td></tr>
<tr><td colspan="4" align="center"><asp:Button ID="btnSave" runat="server" 
        Text="Save" Width="300px" onclick="btnSave_Click"/></td></tr>
</table><br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
</div>
</asp:Content>

