<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="_04.DeleteViewStateFromClient.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title>Deleting view state</title>
        <script src="scripts/jquery-2.1.0.js"></script>
    </head>
    <body>
        <form id="form1" runat="server">
            <div>
                <asp:TextBox ID="tbTest" runat="server" />
                <asp:Button ID="btnSubmit" Text="Submit" runat="server" OnClick="Unnamed_Click" />
            </div>
        </form>
        <script>
            $(document).ready( function () {
                $("#__VIEWSTATE").remove();
            }());
        </script>
    </body>
</html>
