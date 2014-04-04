<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="PageLifecycle.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Button ID="ButtonOk" runat="server" Text="Ok" 
            onclick ="ButtonOK_Click" oninit ="ButtonOK_Init" onload="ButtonOK_Load" OnPreRender ="ButtonOK_PreRender"/>
    </div>
    </form>
</body>
</html>
