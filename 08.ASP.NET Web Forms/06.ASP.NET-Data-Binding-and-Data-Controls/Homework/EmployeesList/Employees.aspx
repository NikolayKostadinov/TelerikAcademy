<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Employees.aspx.cs" Inherits="EmployeesList.Employees" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title></title>
    </head>
    <body>
        <form id="form1" runat="server">
            <div>
                <asp:GridView ID="GridViewEmployees" runat="server" AutoGenerateColumns="False" 
                              AllowPaging="True" PageSize="3" DataKeyNames="EmployeeID" OnPageIndexChanging="GridViewEmployees_PageIndexChanging" >
                    <Columns>
                        <asp:HyperLinkField 
                            HeaderText="Employee's Name" 
                            DataNavigateUrlFields="EmployeeID" 
                            DataNavigateUrlFormatString="EmpDetails.aspx?id={0}" 
                            DataTextField="FullName" 
                            />
                    </Columns>
                </asp:GridView>
            </div>
        </form>
    </body>
</html>
