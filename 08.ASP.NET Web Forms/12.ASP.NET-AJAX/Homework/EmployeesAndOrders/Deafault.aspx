<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Deafault.aspx.cs" Inherits="EmployeesAndOrders.Deafault" %>

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
        <asp:EntityDataSource ID="EntityDataSourceEmployees" runat="server"
            ConnectionString="name=NorthwindEntities"
            DefaultContainerName="NorthwindEntities"
            EnableDelete="True"
            EnableFlattening="False"
            EnableInsert="True"
            EnableUpdate="True"
            EntitySetName="Employees">
        </asp:EntityDataSource>
        <asp:EntityDataSource ID="EntityDataSourceOrders" runat="server"
            ConnectionString="name=NorthwindEntities"
            DefaultContainerName="NorthwindEntities"
            EnableDelete="True"
            EnableFlattening="False"
            EnableInsert="True"
            EnableUpdate="True"
            EntitySetName="Orders"
            Where="it.EmployeeID=@EmplID">
            <WhereParameters>
                <asp:ControlParameter Name="EmplID" ControlID="Employee" DbType="Int32" />
            </WhereParameters>
        </asp:EntityDataSource>
        <asp:UpdatePanel ID="UP" runat="server">
            <ContentTemplate>
                <asp:GridView ID="Employee" runat="server"
                    AllowPaging="True" AllowSorting="True"
                    AutoGenerateColumns="False"
                    DataKeyNames="EmployeeID"
                    DataSourceID="EntityDataSourceEmployees"
                    OnSelectedIndexChanged="EmployeeID_SelectedIndexChanged">
                    <Columns>
                        <asp:CommandField ShowSelectButton="True" />
                        <asp:BoundField DataField="EmployeeID" HeaderText="EmployeeID" ReadOnly="True" SortExpression="EmployeeID" />
                        <asp:BoundField DataField="LastName" HeaderText="LastName" SortExpression="LastName" />
                        <asp:BoundField DataField="FirstName" HeaderText="FirstName" SortExpression="FirstName" />
                        <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
                    </Columns>
                    <EmptyDataTemplate>
                        No Data Found
                    </EmptyDataTemplate>
                    <SelectedRowStyle CssClass="selected" />
                </asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>
     
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:GridView ID="GridViewOrders" runat="server" AllowPaging="True" AllowSorting="True" DataSourceID="EntityDataSourceOrders">
                </asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="UP">
            <ProgressTemplate>
                <img src="loading.gif" class="updating" />
            </ProgressTemplate>
        </asp:UpdateProgress>

    </form>
</body>
</html>
