<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Employees.aspx.cs" Inherits="EmployeesRepeater.Employees" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title>Employees List</title>
        <link href="main.css" rel="stylesheet" />
    </head>
    <body>
        <form id="form1" runat="server">
            <div>
                <asp:Repeater ID="RepeaterEmployees" runat="server" ItemType="EmployeesRepeater.Models.Employee">
                    <ItemTemplate>
                        <h3><%#: Item.FullName %></h3>
                        <ul>
                            <li>
                                <span class="term">Title: </span>
                                <span><%#: Item.Title%></span>
                            </li>
                            <li>
                                <span class="term">TitleOfCourtesy: </span>
                                <span><%#: Eval("TitleOfCourtesy")%></span>
                            </li>
                            <li>
                                <span class="term">BirthDate: </span>
                                <span><%#: Eval("BirthDate")%></span>
                            </li>
                            <li>
                                <span class="term">HireDate: </span>
                                <span><%#: Eval("HireDate")%></span>
                            </li>
                            <li>
                                <span class="term">Address: </span>
                                <span><%#: Eval("Address")%></span>
                            </li>
                            <li>
                                <span class="term">City: </span>
                                <span><%#: Eval("City")%></span>
                            </li>
                            <li>
                                <span class="term">Region: </span>
                                <span><%#: Eval("Region")%></span>
                            </li>
                            <li>
                                <span class="term">PostalCode: </span>
                                <span><%#: Eval("PostalCode")%></span>
                            </li>
                            <li>
                                <span class="term">Country: </span>
                                <span class="term"><%#: Eval("Country")%></span>
                            </li>
                            <li>
                                <span class="term">HomePhone: </span>
                                <span><%#: Eval("HomePhone")%></span>
                            </li>
                            <li>
                                <span class="term">Extension: </span>
                                <span><%#: Eval("Extension")%></span>
                            </li>
                            <li>
                                <span class="term">Notes: </span>
                                <span><%#: Eval("Notes")%></span>
                            </li>
                            <li>
                                <span class="term">ReportsTo: </span>
                                <span><%#: Eval("ReportsTo")%></span>
                            </li>
                            <li>
                                <span class="term">PhotoPath: </span>
                                <span><%#: Eval("PhotoPath")%></span>
                            </li>
                        </ul>
                    </ItemTemplate>
                    <SeparatorTemplate>
                        <hr />
                    </SeparatorTemplate>
                </asp:Repeater>
            </div>
        </form>
    </body>
</html>
