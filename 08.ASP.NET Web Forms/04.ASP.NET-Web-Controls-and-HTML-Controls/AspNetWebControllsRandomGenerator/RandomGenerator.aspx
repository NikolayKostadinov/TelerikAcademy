<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RandomGenerator.aspx.cs" Inherits="AspNetWebControllsRandomGenerator.RandomGenerator" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title></title>
    </head>
    <body>
        <form id="form1" runat="server">
            <div>
                <asp:Label runat="server">Generate random number</asp:Label>
                <br />
                <asp:Label runat ="server" for="inputValueFrom">from:</asp:Label>
                <asp:TextBox type="text" id="inputValueFrom" runat="server" />
                <br />
                <asp:Label runat ="server" for="inputValueTo">to:</asp:Label>
                <asp:TextBox type="text" id="inputValueTo" runat="server" />
                <br />
                <asp:Button id="Submit" Text ="Submit" runat="server" OnClick ="Submit_Click" />
                <br />
                <hr />
                <asp:Label  id="Result" runat="server"></asp:Label>
            </div>
        </form>
    </body>
</html>
