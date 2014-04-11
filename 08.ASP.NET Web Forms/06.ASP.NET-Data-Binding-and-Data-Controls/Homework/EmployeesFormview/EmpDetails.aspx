<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmpDetails.aspx.cs" Inherits="EmployeesFormview.EmpDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title></title>
    </head>
    <body>
        <form id="form1" runat="server">
            <div>
                <asp:FormView ID="FormViewEmployeeDetails" runat="server">
                    <ItemTemplate>
                        <h3><%#: Eval("FullName")%></h3>
                        <table border="0">
                            <tr>
                                <td>Title</td>
                                <td><%#: Eval("Title")%></td>
                            </tr>
                            <tr>
                                <td>TitleOfCourtesy</td>
                                <td><%#: Eval("TitleOfCourtesy")%></td>
                            </tr>
                            <tr>
                                <td>BirthDate</td>
                                <td><%#: Eval("BirthDate")%></td>
                            </tr>
                            <tr>
                                <td>HireDate</td>
                                <td><%#: Eval("HireDate")%></td>
                            </tr>
                            <tr>
                                <td>Address</td>
                                <td><%#: Eval("Address")%></td>
                            </tr>
                            <tr>
                                <td>City</td>
                                <td><%#: Eval("City")%></td>
                            </tr>
                            <tr>
                                <td>Region</td>
                                <td><%#: Eval("Region")%></td>
                            </tr>
                            <tr>
                                <td>PostalCode</td>
                                <td><%#: Eval("PostalCode")%></td>
                            </tr>
                            <tr>
                                <td>Country</td>
                                <td><%#: Eval("Country")%></td>
                            </tr>
                            <tr>
                                <td>HomePhone</td>
                                <td><%#: Eval("HomePhone")%></td>
                            </tr>
                            <tr>
                                <td>Extension</td>
                                <td><%#: Eval("Extension")%></td>
                            </tr>
                            <tr>
                                <td>Notes</td>
                                <td><%#: Eval("Notes")%></td>
                            </tr>
                            <tr>
                                <td>ReportsTo</td>
                                <td><%#: Eval("ReportsTo")%></td>
                            </tr>
                            <tr>
                                <td>PhotoPath</td>
                                <td><%#: Eval("PhotoPath")%></td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:FormView>
                <asp:HyperLink NavigateUrl="~/Employees.aspx" Text="Back to Employees" runat="server"></asp:HyperLink>
            </div>
        </form>
    </body>
</html>
