<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebChat._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ObjectDataSource ID="ObjectDataSourceMessages" runat="server"
        DataObjectTypeName="WebChat.Models.ChatMessage"
        DeleteMethod="Delete"
        SelectMethod="All"
        TypeName="WebChat.Repositories.MessagesRepository"></asp:ObjectDataSource>
    <asp:ListView ID="ListViewMessages" runat="server"
        DataSourceID="ObjectDataSourceMessages"
        InsertItemPosition="LastItem"
        ItemType="WebChat.Models.ChatMessage"
        DataKeyNames="MessageId"
        OnItemDataBound="ListViewMessages_ItemDataBound">
        <EditItemTemplate>
            <tr style="background-color: #FFCC66; color: #000080;">
                <td>
                    <asp:TextBox ID="MessageIdTextBox" runat="server" Text='<%# Item.MessageId %>' Enabled="false" />
                </td>
                <td></td>
                <td>
                    <asp:TextBox ID="MessageTextBox" runat="server" Text='<%# Item.MessageText %>' />
                </td>
                <td></td>
                <td>
                    <asp:Button ID="UpdateButton" runat="server" OnClick="UpdateButton_Click" Text="Update" />
                    <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancel" />
                </td>
            </tr>
        </EditItemTemplate>
        <EmptyDataTemplate>
            <table runat="server" style="background-color: #FFFFFF; border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px;">
                <tr>
                    <td>No data was returned.</td>
                </tr>
            </table>
        </EmptyDataTemplate>
        <InsertItemTemplate>
            <tr style="">
                <td></td>
                <td></td>
                <td>
                    <asp:TextBox ID="MessageTextBox" runat="server" />
                </td>
                <td>
                    <asp:Button ID="InsertButton" runat="server" Text="Insert" OnClick="InsertButton_Click" />
                    <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Clear" />
                </td>
            </tr>
        </InsertItemTemplate>
        <ItemTemplate>
            <tr style="background-color: #FFFBD6; color: #333333;">
                <td>
                    <%#: Item.MessageId%>
                </td>
                <td>
                    <%#: Item.MessageDateTime %>
                </td>
                <td>
                    <%#: Item.MessageText %>
                </td>
                <td>
                    <%#: Item.User != null ? Item.User.FirstName + " " + Item.User.LastName : string.Empty %>
                </td>
                <td>
                    <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
                    <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="Delete" />
                </td>
            </tr>
        </ItemTemplate>
        <LayoutTemplate>
            <table runat="server">
                <tr runat="server">
                    <td runat="server">
                        <table id="itemPlaceholderContainer" runat="server" border="1" style="background-color: #FFFFFF; border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px; font-family: Verdana, Arial, Helvetica, sans-serif;">
                            <tr runat="server" style="background-color: #FFFBD6; color: #333333;">
                                <th runat="server">MessageId</th>
                                <th runat="server">MessageDateTime</th>
                                <th runat="server">MessageText</th>
                                <th runat="server">User</th>
                                <th runat="server"></th>
                            </tr>
                            <tr id="itemPlaceholder" runat="server">
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr runat="server">
                    <td runat="server" style="text-align: center; background-color: #FFCC66; font-family: Verdana, Arial, Helvetica, sans-serif; color: #333333;">
                        <asp:DataPager ID="DataPager1" runat="server">
                            <Fields>
                                <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
                                <asp:NumericPagerField />
                                <asp:NextPreviousPagerField ButtonType="Button" ShowLastPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
                            </Fields>
                        </asp:DataPager>
                    </td>
                </tr>
            </table>
        </LayoutTemplate>
        <SelectedItemTemplate>
            <tr style="background-color: #FFCC66; font-weight: bold; color: #000080;">
                <td>
                    <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="Delete" />
                    <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
                </td>
                <td>
                    <asp:Label ID="MessageIdLabel" runat="server" Text='<%# Eval("MessageId") %>' />
                </td>
                <td>
                    <asp:Label ID="MessageDateTimeLabel" runat="server" Text='<%# Eval("MessageDateTime") %>' />
                </td>
                <td>
                    <asp:Label ID="MessageTextLabel" runat="server" Text='<%# Eval("MessageText") %>' />
                </td>
                <td>
                    <asp:Label ID="UserIdLabel" runat="server" Text='<%# Eval("UserId") %>' />
                </td>
                <td>
                    <asp:Label ID="UserLabel" runat="server" Text='<%# Eval("User") %>' />
                </td>
            </tr>
        </SelectedItemTemplate>
    </asp:ListView>
</asp:Content>
