<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SumOfNumbers.aspx.cs" Inherits="SumOfNumbers.SumOfNumbers" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title></title>
    </head>
    <body>
        <form id="form1" runat="server">
            <div style="height: 95px">

                <asp:TextBox ID="firstNumber" runat="server" CausesValidation="True" Width="110px"></asp:TextBox>
                &nbsp;
                <asp:Label ID="labePlus" runat="server" Text="+"></asp:Label>
                &nbsp;
                <asp:TextBox ID="secondNumber" runat="server"></asp:TextBox>
                &nbsp;
                <asp:Label ID="labelResult" runat="server" Text="="></asp:Label>
                <br />
                &nbsp;
                <asp:Button ID="btnCalculate" runat="server" Text="Calculate" ToolTip="Calculates the sun of two numbers" OnClick="btnCalculate_Click" />

            </div>
        </form>
    </body>
</html>
