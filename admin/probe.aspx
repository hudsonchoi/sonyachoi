﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="probe.aspx.cs" Inherits="admin_probe" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ListView ID="ListView1" runat="server">
            <ItemTemplate>
            <asp:Label runat="server" Text='<%# Eval("data") %>'></asp:Label>
            </ItemTemplate>
        </asp:ListView>
    </div>
    </form>
</body>
</html>
