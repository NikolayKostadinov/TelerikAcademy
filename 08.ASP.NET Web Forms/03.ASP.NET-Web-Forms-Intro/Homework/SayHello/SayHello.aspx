<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SayHello.aspx.cs" Inherits="SayHello.SayHello" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="height: 227px">
        
        <asp:Label ID="LabelName" runat="server" AssociatedControlID="TextBoxName" Text="Enter your name:"></asp:Label>
        &nbsp;
        <asp:TextBox ID="TextBoxName" runat="server"></asp:TextBox>
        &nbsp;
        <asp:Button ID="ButtonSubmit" runat="server" Text="Submit" OnClick="ButtonSubmit_Click" />
        <br />
        <br />
        <asp:Label ID="LabelHello" runat="server"></asp:Label>
        
    </div>
    </form>
</body>
</html>
