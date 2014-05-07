<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UsingSessionObject.aspx.cs" Inherits="UsingSessionObject.UsingSessionObject" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Session Object</title>
    <link href="main.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox ID="tbInput" runat="server" CssClass="inline"/>
        <asp:Button ID="btnSubmit" Text="Submit" runat="server" OnClick="BtnSubmit_Click" CssClass="inline"/>
        <br/>
        <hr />
        <asp:Label ID="lbOutput" runat="server" />  
    </div>
    </form>
</body>
</html>
