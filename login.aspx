<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div style="width:220px; margin: 0 auto;">
<table>
<tr>
<td>Username:</td>
<td style="text-align:left">
    <asp:TextBox ID="tbUsername" runat="server" Width="140px"></asp:TextBox></td>
</tr>
<tr>
<td>Password:</td>
<td style="text-align:left">
    <asp:TextBox ID="tbPassword" runat="server" TextMode="Password"></asp:TextBox></td>
</tr>
<tr>
<td>&nbsp;</td>
<td style="text-align:left"> 
    <asp:Button ID="btnLogin" runat="server" Text="Login" Width="100px" 
        onclick="btnLogin_Click"/> 
    &nbsp;<asp:CustomValidator ID="cvInvalid" runat="server" 
        ErrorMessage="Invalid" Font-Bold="True" ForeColor="Red" 
        onservervalidate="cvInvalid_ServerValidate"></asp:CustomValidator>
    </td>
</tr>
</table>
</div>
</asp:Content>

