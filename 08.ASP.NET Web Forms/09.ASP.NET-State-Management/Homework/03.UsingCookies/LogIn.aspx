<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="_03.UsingCookies.LogIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox ID="tbUserName" runat="server" />
        <asp:Button ID="btnLogin" Text ="Login" runat="server" OnClick="btnLogin_Click" />
    </div>
    </form>
</body>
</html>
