<%@ Page Language="C#" AutoEventWireup="true" CodeFile="probe.aspx.cs" Inherits="probe" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Button ID="Button1" runat="server" Text="Send a test email" 
            onclick="Button1_Click" />
    
    &nbsp;to
        <asp:TextBox ID="tbRecepient" runat="server"></asp:TextBox>
    
    </div>
    </form>
</body>
</html>
