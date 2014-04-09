<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmpDetails.aspx.cs" Inherits="EmployeesList.EmpDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title></title>
    </head>
    <body>
        <form id="form1" runat="server">
            <div>
                <asp:DetailsView ID="DetailsViewEmployee" runat="server" AutoGenerateRows="true" AllowPaging="False" />
                <asp:HyperLink NavigateUrl="~/Employees.aspx" Text="Back to Employees" runat="server"></asp:HyperLink>
            </div>
        </form>
    </body>
</html>
