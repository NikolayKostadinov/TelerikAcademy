<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CarSelection.aspx.cs" Inherits="CarShop.CarSelection" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title>Car Shop</title>
        <link href="main.css" rel="stylesheet" />
    </head>
    <body>
        <form id="form1" runat="server">
            <asp:Panel ID="PanelCarParameters" GroupingText="Car Parameters Selection" runat="server">
                <asp:Panel ID="PanelProducerModel" GroupingText="Producer &amp; Model Info" runat="server">
                    <asp:Label Text="Producer" ID="LabelProducer" runat="server" AssociatedControlID="DropDownListProducer"/>
                    <asp:DropDownList ID="DropDownListProducer" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownListProducer_SelectedIndexChanged">
                    </asp:DropDownList>
                    <asp:Label Text="Model" ID="LabelModel" runat="server" AssociatedControlID="DropDownListModel"/>
                    <asp:DropDownList ID="DropDownListModel" runat="server" AutoPostBack="true">
                    </asp:DropDownList>
                </asp:Panel>
                <asp:Panel ID="PanelExtras" GroupingText="Extras" runat="server">
                    <asp:CheckBoxList ID="CheckBobListExtras" runat="server" RepeatDirection ="Horizontal" RepeatColumns="3">
                    </asp:CheckBoxList>
                </asp:Panel>
                <asp:Panel ID="PanelEngineType" GroupingText="Type Of Engine" runat="server">
                    <asp:RadioButtonList runat="server" ID="RadioButtonListEngineType" RepeatDirection="Horizontal">
                    </asp:RadioButtonList>
                </asp:Panel>
                <asp:Button ID="ButtonSubmit" Text="Submit" runat="server" OnClick="ButtonSubmit_Click" />
            </asp:Panel>
            <asp:Literal ID="Result" Text="" runat="server" />
        </form>
    </body>
</html>
