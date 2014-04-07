<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Copier.aspx.cs" Inherits="Copier.Copier" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title></title>
    </head>
    <body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="TextBoxInput" runat="server"></asp:TextBox>
            <asp:Button Id="ButtonCopy" Text="Copy" runat="server" OnClick="ButtonCopy_Click"/>
            <br />
            <asp:Label ID="TextBoxCopy" runat="server" />  
        </div>
    </form>
</html>
