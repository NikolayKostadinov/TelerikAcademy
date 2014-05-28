<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebChat.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="main.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:Timer ID="Timer1" runat="server" Interval="500" OnTick="Timer1_Tick">
        </asp:Timer>
        <asp:TextBox ID="TextBoxMessage" runat="server" Width="630px"></asp:TextBox>
        <asp:Button ID="ButtonSend" runat="server" Text="Send" Width="95px" OnClick="ButtonSend_Click" />
        <asp:UpdatePanel ID="UpdatePanelChat" runat="server">
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
            </Triggers>
            <ContentTemplate>
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server"
                    DataObjectTypeName="WebChat.Message"
                    InsertMethod="Insert"
                    SelectMethod="GetAll"
                    TypeName="WebChat.MessageRepository"></asp:ObjectDataSource>
                <asp:ListView ID="ListViewMessages" runat="server" ItemType="WebChat.Message" DataSourceID="ObjectDataSource1">
                    <ItemTemplate>
                        <span class="time-stamp"><%# Item.MessageDateTime%></span><span class="message"><%# Item.MessageText %></span>
                        <br />
                    </ItemTemplate>
                </asp:ListView>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
