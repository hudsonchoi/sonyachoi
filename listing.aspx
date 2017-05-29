<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="listing.aspx.cs" EnableViewState="false" Inherits="listing" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<div style="text-align:center"><h1><asp:Literal ID="ltCity" runat="server"></asp:Literal> <asp:Literal ID="ltPrice" runat="server"></asp:Literal></h1></div>
<div style="width:645px; margin:0 auto">
<div style="text-align:center;position:relative">
<asp:Image ID="imgStatus" runat="server" CssClass="status"/>
<asp:Literal ID="ltImageGallery" runat="server"></asp:Literal>
</div>
<div style="margin-left:20px">
<table width="600px">
<tr>
<td style="font-size:16px; text-align:center; font-weight:bolder; color:Red"><asp:Literal ID="ltSellingPoint" runat="server"></asp:Literal></td>
</tr>
<tr>
<td align="center">
<table>
<tr>
<td align="right" class="heavy">침실:</td><td><asp:Literal ID="ltBed" runat="server"></asp:Literal>
</td>
<td align="right" class="heavy">욕실:</td><td><asp:Literal ID="ltBath" runat="server"></asp:Literal>
</td>
<td align="right" class="heavy">스타일:</td><td><asp:Literal ID="ltStyle" runat="server"></asp:Literal>
</td>
</tr>
</table>
</td>
</tr>

<tr>
<td>
<asp:Literal ID="ltDescription" runat="server"></asp:Literal>
</td>
</tr>
</table>

</div>
</div>
</asp:Content>

