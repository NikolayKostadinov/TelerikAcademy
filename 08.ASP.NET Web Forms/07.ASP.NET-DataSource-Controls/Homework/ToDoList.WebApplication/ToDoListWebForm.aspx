<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ToDoListWebForm.aspx.cs" Inherits="ToDoList.WebApplication.ToDoListWebForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title></title>
        <link href="main.css" rel="stylesheet" />
    </head>
    <body>
        <form id="form1" runat="server">
            <div>

                <asp:ObjectDataSource ID="ObjectDataSourceCategories" runat="server"
                    SelectMethod="GetAllCategories" 
                    TypeName="ToDoList.WebApplication.ToDoDataProvider" 
                    DataObjectTypeName="ToDoList.Data.Models.Category" 
                    DeleteMethod="DeleteCategory" 
                    InsertMethod="InsertCategory" 
                    UpdateMethod="UpdateCategory">
                </asp:ObjectDataSource>
                <fieldset>
                    <legend>Categories</legend>
                <asp:ListView ID="ListView1" runat="server" 
                    DataSourceID="ObjectDataSourceCategories" 
                    ItemType="ToDoList.Data.Models.Category"
                    DataKeyNames="CategoryId">
                    <EditItemTemplate>
                        <tr class="edit-template">
                            <td>
                                <asp:ImageButton ID="UpdateButton" runat="server" CommandName="Update" Text="Update" ImageUrl="~/images/update.png" ToolTip="Update" Height="20px" Width ="20px"/>
                                <asp:ImageButton ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancel" ImageUrl="~/images/cancel.png" ToolTip="Cancel" Height="20px" Width ="20px"/>
                            </td>
                            <td>
                                <asp:TextBox ID="NameTextBox" runat="server" Text='<%# Bind("Name") %>' />
                            </td>
                        </tr>
                    </EditItemTemplate>
                    <EmptyDataTemplate>
                        <table runat="server" style="">
                            <tr>
                                <td>No data was returned.</td>
                            </tr>
                        </table>
                    </EmptyDataTemplate>
                    <InsertItemTemplate>
                        <tr class="insert-template">
                            <td>
                                <asp:ImageButton ID="InsertButton" runat="server" CommandName="Insert" ImageUrl="~/images/insert.png" OnClick="InsertButton_Click1" Text="Insert" Height="20px" Width ="20px" />
                                <asp:ImageButton ID="CancelButton" runat="server" CommandName="Cancel" ImageUrl="~/images/cancel.png" Text="Clear" Height="20px" Width ="20px"/>
                            </td>
                            <td>
                                <asp:TextBox ID="NameTextBox" runat="server" Text='<%# Bind("Name") %>' />
                            </td>
                        </tr>
                    </InsertItemTemplate>
                    <ItemTemplate>
                        <tr class="item-template">
                            <td>
                                <asp:ImageButton ID="SelectButton" runat="server" CommandName="Select" Text="Select" ImageUrl ="~/images/select.png" ToolTip="Select" Height="20px" Width ="20px"/>
                                <asp:ImageButton ID="EditButton" runat="server" CommandName="Edit" Text="Edit" ImageUrl ="~/images/Edit.png" ToolTip="Edit" Height="20px" Width ="20px"/>
                                <asp:ImageButton ID="DeleteButton" runat="server" CommandName="Delete" Text="Delete" ImageUrl ="~/images/Delete.png" ToolTip="Delete" Height="20px" Width ="20px"/>
                            </td>
                            <td>
                                <asp:Label ID="NameLabel" runat="server" Text='<%# Eval("Name") %>' />
                            </td>
                        </tr>
                    </ItemTemplate>
                    <LayoutTemplate>
                        <asp:ImageButton ID="InsertButton" runat="server" OnClick="InsertButton_Click" ImageUrl="~/images/insert.png" Height="20px" Width ="20px" /> 
                        <asp:Label ID="LabelInsert" runat="server" AssociatedControlID="InsertButton">Create New Category</asp:Label>
                        <table runat="server">
                            <tr runat="server">
                                <td runat="server">
                                    <table id="itemPlaceholderContainer" runat="server" border="0" style="">
                                        <tr runat="server" style="">
                                            <th runat="server"></th>
                                            <th runat="server"></th>
                                        </tr>
                                        <tr id="itemPlaceholder" runat="server">
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </LayoutTemplate>
                    <SelectedItemTemplate>
                        <tr style="">
                            <td>
                                <asp:ImageButton ID="SelectButton" runat="server" CommandName="Select" Text="Select" ImageUrl ="~/images/select.png" ToolTip="Select" Height="20px" Width ="20px"/>
                                <asp:ImageButton ID="EditButton" runat="server" CommandName="Edit" Text="Edit" ImageUrl ="~/images/Edit.png" ToolTip="Edit" Height="20px" Width ="20px"/>
                                <asp:ImageButton ID="DeleteButton" runat="server" CommandName="Delete" CommandArgument="<%# new ToDoList.Data.Models.Category() { CategoryId=Item.CategoryId }%>" Text="Delete" ImageUrl ="~/images/Delete.png" ToolTip="Delete" Height="20px" Width ="20px"/>
                            </td>
                            <td>
                                <asp:Label ID="NameLabel" runat="server" Text='<%# Eval("Name") %>' />
                            </td>
                        </tr>
                    </SelectedItemTemplate>
                </asp:ListView>
                </fieldset>
                <asp:Label ID="Messages" Text="" runat="server" />
            </div>
        </form>
    </body>
</html>
