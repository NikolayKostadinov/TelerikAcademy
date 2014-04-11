<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GameBoard.aspx.cs" Inherits="TicTacToeGame.GameBoard" EnableSessionState="True" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title>Tic Tac Toe Game</title>
        <link href="style.css" rel="stylesheet" />
    </head>
    <body>
        <form id="form1" runat="server">
            <div>
                <asp:Panel ID="PanelMarkSelection" runat="server">
                    <asp:Label Text="Mark X" runat="server" AssociatedControlID="RadioButtonX" />
                    <asp:RadioButton ID="RadioButtonX" runat="server" Checked="True" GroupName="MarkRadios" OnCheckedChanged ="RadioButton_CheckedChanged" AutoPostBack="true" />
                    <asp:Label Text="Mark O" runat="server" AssociatedControlID="RadioButtonO" />
                    <asp:RadioButton ID="RadioButtonO" runat="server" GroupName="MarkRadios" OnCheckedChanged ="RadioButton_CheckedChanged" AutoPostBack="true"/>
                </asp:Panel>
                <div id="Buttons" runat="server">
                    <asp:button text=" " runat="server" ID="Button0" CommandArgument="0" OnClick="Button_Click" CssClass="button"/>
                    <asp:button text=" " runat="server" ID="Button1" CommandArgument="1" OnClick="Button_Click" CssClass="button"/>
                    <asp:button text=" " runat="server" ID="Button2" CommandArgument="2" OnClick="Button_Click" CssClass="button"/><br />
                    <asp:button text=" " runat="server" ID="Button3" CommandArgument="3" OnClick="Button_Click" CssClass="button"/>
                    <asp:button text=" " runat="server" ID="Button4" CommandArgument="4" OnClick="Button_Click" CssClass="button"/>
                    <asp:button text=" " runat="server" ID="Button5" CommandArgument="5" OnClick="Button_Click" CssClass="button"/><br />
                    <asp:button text=" " runat="server" ID="Button6" CommandArgument="6" OnClick="Button_Click" CssClass="button"/>
                    <asp:button text=" " runat="server" ID="Button7" CommandArgument="7" OnClick="Button_Click" CssClass="button"/>
                    <asp:button text=" " runat="server" ID="Button8" CommandArgument="8" OnClick="Button_Click" CssClass="button"/>
                </div>
                <asp:Label ID="LabelMessage" Text="" runat="server" />
                <asp:Button ID="ButtonNewGame" Text="NewGame" runat="server" OnClick="ButtonNewGame_Click" />
            </div>
        </form>
    </body>
</html>
