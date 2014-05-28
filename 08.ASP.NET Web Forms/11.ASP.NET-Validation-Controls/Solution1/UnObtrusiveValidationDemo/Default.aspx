<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="UnObtrusiveValidationDemo.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title></title>

    </head>
    <body>
        <form id="form1" runat="server">
            <div>
                <asp:TextBox runat="server" ID="txt" />
                <asp:RequiredFieldValidator ErrorMessage="txt is required" ControlToValidate="txt" runat="server" Text="hbouybyubo" Display="Dynamic" EnableClientScript="true" />
                <asp:Button Text="Send info" runat="server" />
            </div>
        </form>
        <script src="Scripts/validators.js"></script>
    </body>
</html>
