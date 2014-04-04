<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RandomGenerator.aspx.cs" Inherits="HtmlServerControllsRandomGenerator.RandomGenerator" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title></title>
    </head>
    <body>
        <form id="form1" runat="server">
            <div>
                <label>Generate random number</label>
                <br />
                <label for="inputValueFrom">from:</label>
                <input type="text" id="inputValueFrom" runat="server" />
                <br />
                <label for="inputValueTo">to:</label>
                <input type="text" id="inputValueTo" runat="server" />
                <br />
                <button id="Submit" title="Submit" name="Submit" runat="server" onserverclick="Submit_ServerClick">Submit</button>
                <br />
                <hr />
                <label id="Result" runat="server"></label>
            </div>
        </form>
    </body>
</html>
