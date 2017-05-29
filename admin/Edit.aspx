<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageAdmin.master" AutoEventWireup="true" CodeFile="Edit.aspx.cs" Inherits="admin_Default2" validateRequest="false"%>
<%@ MasterType VirtualPath="~/MasterPageAdmin.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="JavaScript" type="text/javascript" src="./rte/cbrte/html2xhtml.js"></script>
<script language="JavaScript" type="text/javascript" src="./rte/cbrte/richtext_compressed.js"></script>
<script type="text/javascript">
    $(document).ready(function () {
        //alert($('#ContentPlaceHolder1_cbSale').attr('checked'));
        if (!$('#ContentPlaceHolder1_cbSale').attr('checked')) {
            $("#ContentPlaceHolder1_lbPrice").css("display", "none");
            $("#ContentPlaceHolder1_tbPrice").css("display", "none");
        }
        if (!$('#ContentPlaceHolder1_cbRental').attr('checked')) {
            $("#ContentPlaceHolder1_lbRent").css("display", "none");
            $("#ContentPlaceHolder1_tbRent").css("display", "none");
        }

        $("#ContentPlaceHolder1_cbSale").click(function() {
            if ($('#ContentPlaceHolder1_cbSale').attr('checked')) {
                $("#ContentPlaceHolder1_lbPrice").css("display", "inline");
                $("#ContentPlaceHolder1_tbPrice").css("display", "inline");
            } else {
                $("#ContentPlaceHolder1_lbPrice").css("display", "none");
                $("#ContentPlaceHolder1_tbPrice").css("display", "none");
            }
        });

        $("#ContentPlaceHolder1_cbRental").click(function() {
        if ($('#ContentPlaceHolder1_cbRental').attr('checked')) {
                $("#ContentPlaceHolder1_lbRent").css("display", "inline");
                $("#ContentPlaceHolder1_tbRent").css("display", "inline");
            } else {
                $("#ContentPlaceHolder1_lbRent").css("display", "none");
                $("#ContentPlaceHolder1_tbRent").css("display", "none");
            }
        });

    });

    function ValidatePrice(source, arguments) {
        if ($('#ContentPlaceHolder1_cbSale').attr('checked')) {
            if ($("#ContentPlaceHolder1_tbPrice").val().length > 0) {
                arguments.IsValid = true;
            } else {
                arguments.IsValid = false;
            }
        }
    }

    function ValidateRent(source, arguments) {
        if ($('#ContentPlaceHolder1_cbRental').attr('checked')) {
            if ($("#ContentPlaceHolder1_tbRent").val().length > 0) {
                arguments.IsValid = true;
            } else {
                arguments.IsValid = false;
            }
        }
    }

    initRTE("./rte/cbrte/images/", "./rte/cbrte/", "", true, false);

    function submitForm() {
        //make sure hidden and iframe values are in sync for all rtes before submitting form
        updateRTEs();
        //alert('Bingo' + document.form1.message.value + "<--")
        //return true;
    }
</script>
<div style="width:645px; margin:0 auto;">
    <div style="width:645px;text-align:center">
    <div>
         <asp:CheckBox ID="cbSale" runat="server" Text="Sale"/> <asp:CheckBox ID="cbRental" runat="server" Text="Rental"/> 
         <asp:CustomValidator ID="cvType" runat="server" 
             ErrorMessage="<img src='../images/alert.gif'>" Display="Dynamic" 
             onservervalidate="cvType_ServerValidate"></asp:CustomValidator>
    </div>
    <asp:Label ID="lbTown" runat="server" Text="Town:" CssClass="major"></asp:Label> 
        <asp:TextBox ID="tbCity" runat="server"  Width="100px" Font-Bold="True"></asp:TextBox> <asp:RequiredFieldValidator ID="rfvCity" runat="server" ErrorMessage="<img src='../images/alert.gif'>" 
        ControlToValidate="tbCity" Display="Dynamic"></asp:RequiredFieldValidator>
    <asp:Label ID="lbPrice" runat="server" Text="Price:" CssClass="major"></asp:Label> 
        <asp:TextBox ID="tbPrice" runat="server" Width="77px" Font-Bold="True"></asp:TextBox> <asp:CustomValidator
            ID="cvPrice" runat="server" ErrorMessage="<img src='../images/alert.gif'>" 
            ClientValidationFunction="ValidatePrice" Display="Dynamic"></asp:CustomValidator>
    <asp:RegularExpressionValidator ID="revPrice" runat="server" 
        ControlToValidate="tbPrice" Display="Dynamic" ErrorMessage="Invalid" 
        ValidationExpression="^[$]?\d+(,\d+)?$" CssClass="warning"></asp:RegularExpressionValidator>
        <asp:Label ID="lbRent" runat="server" Text="Rent:" CssClass="major"></asp:Label> 
        <asp:TextBox ID="tbRent" runat="server" Width="77px" Font-Bold="True"></asp:TextBox> <asp:CustomValidator
            ID="cvRent" runat="server" ErrorMessage="<img src='../images/alert.gif'>" 
            ClientValidationFunction="ValidateRent" Display="Dynamic"></asp:CustomValidator>
    <asp:RegularExpressionValidator ID="revRent" runat="server" 
        ControlToValidate="tbRent" Display="Dynamic" ErrorMessage="Invalid" 
        ValidationExpression="^[$]?\d+(,\d+)?$" CssClass="warning"></asp:RegularExpressionValidator>

    
    
        <asp:CheckBox ID="cbFeatured" runat="server" Text="Featured"/>
        &nbsp;&nbsp;
        Status:<asp:DropDownList ID="ddlStatus" runat="server">
            <asp:ListItem Text="Sale" Value="0"></asp:ListItem>
            <asp:ListItem Text="Under Contract" Value="1"></asp:ListItem>
            <asp:ListItem Text="Sold" Value="2"></asp:ListItem>
            <asp:ListItem Text="Leased" Value="3"></asp:ListItem>
        </asp:DropDownList>
    
    </div>
<div style="text-align:center;position:relative">
<asp:Image ID="imgStatus" runat="server" CssClass="status"/>
<asp:Literal ID="ltImageGallery" runat="server"></asp:Literal>
</div>

<table border="0" style="width:652px">
<tr>
<td align="center">
<asp:TextBox ID="tbSellingPoint" runat="server" Font-Bold="True" Font-Size="14px" Width="400px" CssClass="tbCenter" ForeColor="Red"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvSellingPoint" runat="server" 
            ErrorMessage="<img src='../images/alert.gif'>" ControlToValidate="tbSellingPoint"></asp:RequiredFieldValidator>
</td>
</tr>

<tr>
<td  align="center">
<table>
<tr>
<td align="right" class="heavy">Listing ID:</td><td><asp:TextBox ID="tbListingID" runat="server" Width="77px"></asp:TextBox>
<asp:RequiredFieldValidator ID="rfvListingID" runat="server" ErrorMessage="<img src='../images/alert.gif'>" 
        ControlToValidate="tbListingID" Display="Dynamic"></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator ID="revListingID" runat="server" 
        ControlToValidate="tbListingID" Display="Dynamic" ErrorMessage="#" 
        ValidationExpression="^\d+(\.\d+)?$"></asp:RegularExpressionValidator>
</td>
<td align="right" style="width:85px" class="heavy"># of Images:</td><td><asp:TextBox ID="tbNumOfImages" runat="server" Width="33px"></asp:TextBox>
<asp:RequiredFieldValidator ID="rfvNumOfImages" runat="server" ErrorMessage="<img src='../images/alert.gif'>" 
        ControlToValidate="tbNumOfImages" Display="Dynamic"></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator ID="revNumOfImages" runat="server" 
        ControlToValidate="tbNumOfImages" Display="Dynamic" ErrorMessage="#" 
        ValidationExpression="^\d+(\.\d+)?$"></asp:RegularExpressionValidator>
</td>
</tr>
</table>
</td>
</tr>

<tr>
<td align="center">
<table>
<tr>
<td align="right" class="heavy">Bed:</td><td><asp:TextBox ID="tbBed" runat="server" Width="33px"></asp:TextBox>
<asp:RequiredFieldValidator ID="rfvBed" runat="server" ErrorMessage="<img src='../images/alert.gif'>" 
        ControlToValidate="tbBed" Display="Dynamic"></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator ID="revBed" runat="server" 
        ControlToValidate="tbBed" Display="Dynamic" ErrorMessage="숫자를 넣어주세요" ForeColor="Red"
        ValidationExpression="^\d+(\.\d+)?$"></asp:RegularExpressionValidator>
</td>
<td align="right" class="heavy">Bath:</td><td><asp:TextBox ID="tbBath" runat="server" Width="33px"></asp:TextBox>
<asp:RequiredFieldValidator ID="rfvBath" runat="server" ErrorMessage="<img src='../images/alert.gif'>" 
        ControlToValidate="tbBath" Display="Dynamic"></asp:RequiredFieldValidator>
</td>
<td align="right" class="heavy">Style:</td><td>
    <asp:DropDownList ID="ddlStyle" runat="server">
        <asp:ListItem Text="Select One" Value="0"></asp:ListItem>
        <asp:ListItem Text="Bi-Level" Value="Bi-Level"></asp:ListItem>
        <asp:ListItem Text="Cape Cod" Value="Cape Cod"></asp:ListItem>
        <asp:ListItem Text="Colonial" Value="Colonial"></asp:ListItem>
        <asp:ListItem Text="Condo" Value="Condo"></asp:ListItem>
        <asp:ListItem Text="Contemporary" Value="Contemporary"></asp:ListItem>
        <asp:ListItem Text="Co-op" Value="Co-op"></asp:ListItem>
        <asp:ListItem Text="House" Value="House"></asp:ListItem>
        <asp:ListItem Text="Ranch" Value="Ranch"></asp:ListItem>
        <asp:ListItem Text="Split Level" Value="Split Level"></asp:ListItem>
        <asp:ListItem Text="Townhouse" Value="Townhouse"></asp:ListItem>
    </asp:DropDownList> 
    <asp:CustomValidator ID="cvStyle" runat="server" 
        ErrorMessage="<img src='../images/alert.gif'>" ControlToValidate="ddlStyle" 
        onservervalidate="cvStyle_ServerValidate"></asp:CustomValidator>
</td>
</tr>
</table>
</td>
</tr>

<tr>
<td align="center">
<table cellpadding="0" cellspacing="0">
<tr>
<td class="heavy">Address:</td>
<td>&nbsp;</td>
<td><asp:TextBox ID="tbAddress" runat="server" Width="257px"></asp:TextBox>
</td>
<td>&nbsp;</td>
<td class="heavy">Zip:</td>
<td>&nbsp;</td>
<td><asp:TextBox ID="tbZip" runat="server"  Width="77px"></asp:TextBox>
</td>
<td>&nbsp;</td>
</tr>
</table>
</td>
</tr>

<tr>
<td align="center">
<script language="JavaScript" type="text/javascript">
<!--
    //build new richTextEditor
    var rte1 = new richTextEditor('message');
    rte1.html = '<%=sContent%>';
    //rte1.toggleSrc = false;
    rte1.build();
//-->
</script>
</td>
</tr>

<tr>
<td align="center">
    <asp:Button ID="btnSave" runat="server" Text="Save" Width="300px" 
        onclick="btnSave_Click" onclientclick="submitForm()" />
</td>
</tr>

</table>


</div>

</asp:Content>

