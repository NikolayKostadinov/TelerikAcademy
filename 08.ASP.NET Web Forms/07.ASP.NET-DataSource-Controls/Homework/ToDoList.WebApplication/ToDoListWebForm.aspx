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
                TypeName="ToDoList.WebApplication.CategoryDataProvider"
                DataObjectTypeName="ToDoList.Data.Models.Category"
                DeleteMethod="DeleteCategory"
                InsertMethod="InsertCategory"
                UpdateMethod="UpdateCategory">
            </asp:ObjectDataSource>
            <fieldset>
                <legend>Categories</legend>
                <asp:ListView ID="ListViewCategories" runat="server"
                    DataSourceID="ObjectDataSourceCategories"
                    ItemType="ToDoList.Data.Models.Category"
                    DataKeyNames="CategoryId">
                    <EditItemTemplate>
                        <tr class="edit-template">
                            <td class="image-buttons">
                                <asp:ImageButton class="image-button" ID="UpdateButton" runat="server" CommandName="Update" Text="Update" ImageUrl="~/images/update.png" ToolTip="Update" Height="20px" Width="20px" OnUnload="UpdateButton_Unload"/>
                                <asp:ImageButton class="image-button" ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancel" ImageUrl="~/images/cancel.png" ToolTip="Cancel" Height="20px" Width="20px" />
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
                            <td class="image-buttons">
                                <asp:ImageButton class="image-button" ID="InsertButton" runat="server" CommandName="Insert" ImageUrl="~/images/insert.png" OnClick="InsertButton_Click1" Text="Insert" Height="20px" Width="20px" />
                                <asp:ImageButton class="image-button" ID="CancelButton" runat="server" CommandName="Cancel" ImageUrl="~/images/cancel.png" OnClick="InsertButton_Click1" Text="Clear" Height="20px" Width="20px"  />
                            </td>
                            <td>
                                <asp:TextBox ID="NameTextBox" runat="server" Text='<%# Bind("Name") %>' />
                            </td>
                        </tr>
                    </InsertItemTemplate>
                    <ItemTemplate>
                        <tr class="item-template">
                            <td class="image-buttons">
                                <asp:ImageButton class="image-button" ID="SelectButton" runat="server" CommandName="Select" Text="Select" ImageUrl="~/images/select.png" ToolTip="Select" Height="20px" Width="20px" />
                                <asp:ImageButton class="image-button" ID="EditButton" runat="server" CommandName="Edit" Text="Edit" ImageUrl="~/images/Edit.png" ToolTip="Edit" Height="20px" Width="20px" />
                                <asp:ImageButton class="image-button" ID="DeleteButton" runat="server" CommandName="Delete" Text="Delete" ImageUrl="~/images/Delete.png" ToolTip="Delete" Height="20px" Width="20px" />
                            </td>
                            <td>
                                <asp:Label ID="NameLabel" runat="server" Text='<%# Eval("Name") %>' />
                            </td>
                        </tr>
                    </ItemTemplate>
                    <LayoutTemplate>
                        <asp:ImageButton class="image-button" ID="AddNewButton" runat="server" OnClick="AddNewButton_Click" ImageUrl="~/images/insert.png" Height="20px" Width="20px" />
                        <asp:Label ID="LabelInsert" runat="server" AssociatedControlID="AddNewButton">Create New Category</asp:Label>
                        <table runat="server">
                            <tr runat="server">
                                <td runat="server">
                                    <table id="itemPlaceholderContainer" runat="server" style="">
                                        <tr runat="server" style="">
                                            <th runat="server"></th>
                                            <th runat="server"></th>
                                        </tr>
                                        <tr id="itemPlaceholder" runat="server">
                                        </tr>
                                        <tr runat="server">
                                            <td runat="server" style="" colspan="2">
                                                <asp:DataPager ID="DataPagerCategories" PageSize="3" runat="server">
                                                    <Fields>
                                                        <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
                                                        <asp:NumericPagerField />
                                                        <asp:NextPreviousPagerField ButtonType="Button" ShowLastPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
                                                    </Fields>
                                                </asp:DataPager>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </LayoutTemplate>
                    <SelectedItemTemplate>
                        <tr class="selected-template">
                            <td class="image-buttons">
                                <asp:ImageButton class="image-button" ID="SelectButton" runat="server" CommandName="Select" Text="Select" ImageUrl="~/images/select.png" ToolTip="Select" Height="20px" Width="20px" />
                                <asp:ImageButton class="image-button" ID="EditButton" runat="server" CommandName="Edit" Text="Edit" ImageUrl="~/images/Edit.png" ToolTip="Edit" Height="20px" Width="20px" />
                                <asp:ImageButton class="image-button" ID="DeleteButton" runat="server" CommandName="Delete" CommandArgument="<%# new ToDoList.Data.Models.Category() { CategoryId=Item.CategoryId }%>" Text="Delete" ImageUrl="~/images/Delete.png" ToolTip="Delete" Height="20px" Width="20px" />
                            </td>
                            <td>
                                <asp:Label ID="NameLabel" runat="server" Text='<%# Eval("Name") %>' />
                            </td>
                        </tr>
                    </SelectedItemTemplate>
                </asp:ListView>
            </fieldset>
            <asp:ObjectDataSource
                ID="ObjectDataSourceTodo"
                runat="server"
                DataObjectTypeName="ToDoList.Data.Models.Todo"
                DeleteMethod="DeleteTodo" InsertMethod="InsertTodo"
                SelectMethod="GetAllToDos"
                TypeName="ToDoList.WebApplication.ToDoDataProvider"
                UpdateMethod="UpdateToDo">
                <SelectParameters>
                    <asp:ControlParameter Name="CategoryId" ControlID="ListViewCategories" PropertyName="SelectedValue" DbType="Int32" />
                </SelectParameters>
            </asp:ObjectDataSource>
            <fieldset>
                <legend>ToDo List</legend>
                <asp:ListView ID="ListViewTodo"
                    runat="server"
                    DataSourceID="ObjectDataSourceTodo"
                    InsertItemPosition="None"
                    ItemType="ToDoList.Data.Models.Todo"
                    DataKeyNames="TodoId" >
                    <EditItemTemplate>
                        <tr class="edit-template">
                            <td class="image-buttons">
                                <asp:ImageButton class="image-button" ID="UpdateButton" runat="server" CommandName="Update" Text="Update" ImageUrl="~/images/update.png" ToolTip="Update" Height="20px" Width="20px" />
                                <asp:ImageButton class="image-button" ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancel" ImageUrl="~/images/cancel.png" ToolTip="Cancel" Height="20px" Width="20px" />
                            </td>
                            <td>
                                <asp:DropDownList ID="DropDownListCategory" runat="server"
                                    DataSourceID="ObjectDataSourceCategories"
                                    DataTextField="Name"
                                    DataValueField="CategoryId"
                                    SelectedValue="<%# BindItem.CategoryId %>" AppendDataBoundItems="true">
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:TextBox ID="TitleTextBox" runat="server" Text='<%# BindItem.Title %>' />
                            </td>
                            <td class="todo-body">
                                <asp:TextBox ID="BobyTextBox" CssClass="todo-body-text" runat="server" Text='<%# BindItem.Boby %>' TextMode="MultiLine" />
                            </td>
                            <td>
                                <asp:Calendar ID="CalendarEditDateOfLastChange" runat="server" SelectedDate="<%# BindItem.DateOfLastChange %>" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399" Height="200px" Width="220px">
                                    <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
                                    <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
                                    <OtherMonthDayStyle ForeColor="#999999" />
                                    <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                                    <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
                                    <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px" Font-Bold="True" Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
                                    <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
                                    <WeekendDayStyle BackColor="#CCCCFF" />
                                </asp:Calendar>
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
                            <td class="image-buttons">
                                <asp:ImageButton class="image-button" ID="InsertButton" runat="server" CommandName="Insert" ImageUrl="~/images/insert.png" OnClick="InsertToDoButton_Click" Text="Insert" Height="20px" Width="20px" />
                                <asp:ImageButton class="image-button" ID="CancelButton" runat="server" CommandName="Cancel" ImageUrl="~/images/cancel.png" OnClick="CancelButton_Click" Text="Clear" Height="20px" Width="20px" />
                            </td>
                            <td>
                                <asp:DropDownList ID="DropDownListCategory" runat="server"
                                    DataSourceID="ObjectDataSourceCategories"
                                    DataTextField="Name"
                                    DataValueField="CategoryId"
                                    SelectedValue="<%# BindItem.CategoryId %>" AppendDataBoundItems="true">
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:TextBox ID="TitleTextBox" runat="server" Text='<%# BindItem.Title %>' />
                            </td>
                            <td class="todo-body">
                                <asp:TextBox ID="BobyTextBox" CssClass="todo-body-text" runat="server" Text='<%# BindItem.Boby %>' TextMode="MultiLine" />
                            </td>
                            <td>
                                <asp:Calendar ID="CalendarInsertDateOfLastChange" runat="server" SelectedDate="<%# BindItem.DateOfLastChange %>" VisibleDate="<%# DateTime.Now %>" OnPreRender="CalendarInsertDateOfLastChange_PreRender"
                                    BackColor="White" BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399" Height="200px" Width="220px" >
                                    <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
                                    <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
                                    <OtherMonthDayStyle ForeColor="#999999" />
                                    <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                                    <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
                                    <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px" Font-Bold="True" Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
                                    <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
                                    <WeekendDayStyle BackColor="#CCCCFF" />
                                </asp:Calendar>
                            </td>
                        </tr>
                    </InsertItemTemplate>
                    <ItemTemplate>
                        <tr class="item-template">
                            <td class="image-buttons">
                                <asp:ImageButton class="image-button" ID="SelectButton" runat="server" CommandName="Select" Text="Select" ImageUrl="~/images/select.png" ToolTip="Select" Height="20px" Width="20px" />
                                <asp:ImageButton class="image-button" ID="EditButton" runat="server" CommandName="Edit" Text="Edit" ImageUrl="~/images/Edit.png" ToolTip="Edit" Height="20px" Width="20px" />
                                <asp:ImageButton class="image-button" ID="DeleteButton" runat="server" CommandName="Delete" Text="Delete" ImageUrl="~/images/Delete.png" ToolTip="Delete" Height="20px" Width="20px" />
                            </td>
                            <td>
                                <%#: Item.Category.Name %>
                            </td>
                            <td>
                                <%#: Item.Title %> 
                            </td>
                            <td class="todo-body">
                                <%#: Item.Boby %>
                            </td>
                            <td>
                                <%#: Item.DateOfLastChange.HasValue ? Item.DateOfLastChange.Value.ToString("dd.MM.yyyy"):"" %>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <LayoutTemplate>
                        <asp:ImageButton class="image-button" ID="AddNewToDoButton" runat="server" OnClick="AddNewToDoButton_Click" ImageUrl="~/images/insert.png" Height="20px" Width="20px" />
                        <asp:Label ID="LabelInsert" runat="server" AssociatedControlID="AddNewToDoButton">Create New ToDo</asp:Label>
                        <table runat="server">
                            <tr runat="server">
                                <td runat="server">
                                    <table id="itemPlaceholderContainer" runat="server" border="0" style="">
                                        <tr runat="server" class="todo-headers">
                                            <th runat="server"></th>
                                            <th runat="server">Category</th>
                                            <th runat="server">Title</th>
                                            <th runat="server">Boby</th>
                                            <th runat="server">DateOfLastChange</th>
                                        </tr>
                                        <tr id="itemPlaceholder" runat="server">
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr runat="server">
                                <td runat="server" style="">
                                    <asp:DataPager ID="DataPagerTodos" runat="server" PageSize="5">
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
                        <tr class="selected-template">
                            <td class="image-buttons">
                                <asp:ImageButton class="image-button" ID="SelectButton" runat="server" CommandName="Select" Text="Select" ImageUrl="~/images/select.png" ToolTip="Select" Height="20px" Width="20px" />
                                <asp:ImageButton class="image-button" ID="EditButton" runat="server" CommandName="Edit" Text="Edit" ImageUrl="~/images/Edit.png" ToolTip="Edit" Height="20px" Width="20px" />
                                <asp:ImageButton class="image-button" ID="DeleteButton" runat="server" CommandName="Delete" Text="Delete" ImageUrl="~/images/Delete.png" ToolTip="Delete" Height="20px" Width="20px" />
                            </td>
                            <td>
                                <%#: Item.Category.Name %>
                            </td>
                            <td>
                                <asp:Label ID="TitleLabel" runat="server" Text='<%# Item.Title %>' />
                            </td>
                            <td class="todo-body">
                                <asp:Label ID="BobyLabel" runat="server" Text='<%#: Item.Boby %>' />
                            </td>
                            <td>
                                <%#: Item.DateOfLastChange.HasValue ? Item.DateOfLastChange.Value.ToString("dd.MM.yyyy"):"" %>
                            </td>
                        </tr>
                    </SelectedItemTemplate>
                </asp:ListView>
            </fieldset>
        </div>
    </form>
</body>
</html>
