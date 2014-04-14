<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WorldWebForm.aspx.cs" Inherits="WorldWebApplication.WorldWebForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>World Web System</title>
    <link href="main.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div id="wrapper">
            <asp:EntityDataSource ID="EntityDataSourceContinents" runat="server"
                ConnectionString="name=WorldEntities"
                DefaultContainerName="WorldEntities"
                EnableFlattening="False" EntitySetName="Continents" />

            <asp:ListBox ID="ListBoxContinents" runat="server"
                AutoPostBack="True"
                DataSourceID="EntityDataSourceContinents"
                DataTextField="Name"
                DataValueField="ContinentId"
                Rows="7" />

            <asp:EntityDataSource ID="EntityDataSourceCountries" runat="server"
                ConnectionString="name=WorldEntities"
                DefaultContainerName="WorldEntities"
                EnableFlattening="False"
                EnableInsert="True"
                EntitySetName="Countries"
                Include="Continent, Cities"
                Where="it.ContinentId=@ContID" EnableDelete="True" EnableUpdate="True">
                <WhereParameters>
                    <asp:ControlParameter Name="ContID" Type="Int32"
                        ControlID="ListBoxContinents" />
                </WhereParameters>
            </asp:EntityDataSource>

            <asp:EntityDataSource ID="EntityDataSourceTowns" runat="server"
                ConnectionString="name=WorldEntities"
                DefaultContainerName="WorldEntities"
                EnableDelete="True"
                EnableFlattening="False"
                EnableInsert="True"
                EnableUpdate="True"
                EntitySetName="Cities"
                Include="Countries"
                Where="it.CountryCode=@CCode">
                <WhereParameters>
                    <asp:ControlParameter Name="CCode"
                        ControlID="GridViewCountries" PropertyName="SelectedValue" DbType="String" />
                </WhereParameters>
            </asp:EntityDataSource>

            <asp:GridView ID="GridViewCountries" runat="server"
                AutoGenerateColumns="False"
                BackColor="White"
                BorderColor="#DEDFDE"
                BorderStyle="None"
                BorderWidth="1px"
                CellPadding="4"
                DataKeyNames="Code"
                DataSourceID="EntityDataSourceCountries"
                ForeColor="Black"
                GridLines="Vertical"
                ItemType="WorldWebApplication.Country"
                AllowPaging="True"
                AllowSorting="True"
                PageSize="7"
                EditRowStyle-BackColor="Wheat"
                OnRowCommand="GridViewCountries_RowCommand">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:CommandField ShowDeleteButton="True" ShowSelectButton="True" ShowEditButton="true" />
                    <asp:BoundField DataField="Code" HeaderText="Code" ReadOnly="True" SortExpression="Code" />
                    <asp:TemplateField HeaderText="Flag">
                        <ItemTemplate>
                            <img src="data:image/png;base64,<%#:Item.Flag !=null?Convert.ToBase64String(Item.Flag):"" %> " style="height: 20px; width: 20px;" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:FileUpload runat="server"
                                ID="FileUploadFlag"
                                filebytes="<%# BindItem.Flag %>" />
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                    <asp:BoundField DataField="ContinentId" HeaderText="ContinentId" SortExpression="ContinentId" />
                    <asp:BoundField DataField="Region" HeaderText="Region" SortExpression="Region" />
                    <asp:BoundField DataField="SurfaceArea" HeaderText="SurfaceArea" SortExpression="SurfaceArea" />
                    <asp:BoundField DataField="IndepYear" HeaderText="IndepYear" SortExpression="IndepYear" />
                    <asp:BoundField DataField="Population" HeaderText="Population" SortExpression="Population" />
                    <asp:BoundField DataField="LifeExpectancy" HeaderText="LifeExpectancy" SortExpression="LifeExpectancy" />
                    <asp:BoundField DataField="GNP" HeaderText="GNP" SortExpression="GNP" />
                    <asp:BoundField DataField="GNPOld" HeaderText="GNPOld" SortExpression="GNPOld" />
                    <asp:BoundField DataField="LocalName" HeaderText="LocalName" SortExpression="LocalName" />
                    <asp:BoundField DataField="GovernmentForm" HeaderText="GovernmentForm" SortExpression="GovernmentForm" />
                    <asp:BoundField DataField="HeadOfState" HeaderText="HeadOfState" SortExpression="HeadOfState" />
                    <asp:TemplateField HeaderText="Capital">
                        <ItemTemplate><%#: Item.City!=null ? Item.City.Name : String.Empty %></ItemTemplate>
                        <EditItemTemplate>
                            <asp:DropDownList ID="DropDownListCapital" runat="server"
                                DataSourceID="EntityDataSourceTowns"
                                DataTextField="Name"
                                DataValueField="Id"
                                SelectedValue="<%# BindItem.Capital %>" AppendDataBoundItems="true">
                            </asp:DropDownList>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Code2" HeaderText="Code2" SortExpression="Code2" />
                </Columns>

                <EditRowStyle BackColor="Wheat"></EditRowStyle>
                <EmptyDataTemplate>
                    Choose a Continent
                </EmptyDataTemplate>
                <FooterStyle BackColor="#CCCC99" />
                <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                <RowStyle BackColor="#F7F7DE" />
                <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#FBFBF2" />
                <SortedAscendingHeaderStyle BackColor="#848384" />
                <SortedDescendingCellStyle BackColor="#EAEAD3" />
                <SortedDescendingHeaderStyle BackColor="#575357" />
            </asp:GridView>

            <asp:ListView ID="ListViewTowns" runat="server"
                DataSourceID="EntityDataSourceTowns"
                ItemType="WorldWebApplication.City"
                DataKeyNames="Id"
                InsertItemPosition="None">
                <ItemTemplate>
                    <tr style="">
                        <td>
                            <asp:Button ID="EditButton" runat="server"
                                CommandName="Edit" Text="Edit" />
                            <asp:Button ID="ButtonDelete" runat="server"
                                CommandName="Delete" Text="Delete" />
                        </td>
                        <td><%#: Item.Name %></td>
                        <td><%#: Item.District %></td>
                        <td><%#: Item.Population %></td>
                        <td><%#: Item.Country != null ? Item.Country.Name : "" %></td>
                    </tr>
                </ItemTemplate>
                <EmptyDataTemplate>
                    <table runat="server" style="">
                        <tr>
                            <td>No data was returned.</td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
                <EditItemTemplate>
                    <tr style="">
                        <td>
                            <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="Update" />
                            <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancel" />
                        </td>
                        <td>
                            <asp:TextBox ID="NameTextBox" runat="server" Text='<%# BindItem.Name %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="DistrictTextBox" runat="server" Text='<%# BindItem.District %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="PopulationTextBox" runat="server" Text='<%# BindItem.Population %>' />
                        </td>
                        <td>
                            <asp:DropDownList ID="CountryDropDownList" runat="server"
                                DataSourceID="EntityDataSourceCountries"
                                DataTextField="Name"
                                DataValueField="Code"
                                SelectedValue="<%# BindItem.CountryCode %>" AppendDataBoundItems="true">
                                <asp:ListItem Text="" Value="">
                                </asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <tr style="">
                        <td>
                            <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="Insert" />
                            <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Clear" />
                        </td>
                        <td>
                            <asp:TextBox ID="NameTextBox" runat="server" Text='<%# Bind("Name") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="DistrictTextBox" runat="server" Text='<%# Bind("District") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="PopulationTextBox" runat="server" Text='<%# Bind("Population") %>' />
                        </td>
                        <td>
                            <asp:DropDownList ID="CountryDropDownList" runat="server"
                                DataSourceID="EntityDataSourceCountries"
                                DataTextField="Name"
                                DataValueField="Code"
                                SelectedValue="<%# BindItem.CountryCode %>" AppendDataBoundItems="true">
                                <asp:ListItem Text="" Value="">
                                </asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                </InsertItemTemplate>
                <LayoutTemplate>
                    <table runat="server">
                        <tr runat="server">
                            <td runat="server">
                                <table id="itemPlaceholderContainer" runat="server" border="0" style="">
                                    <tr runat="server" style="">
                                        <th runat="server"></th>
                                        <th runat="server">Name</th>
                                        <th runat="server">District</th>
                                        <th runat="server">Population</th>
                                        <th runat="server">Country</th>
                                    </tr>
                                    <tr id="itemPlaceholder" runat="server">
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr runat="server">
                            <td>
                                <asp:Button ID="btnInsertRecord" Text="Insert" OnClick="btnInsertRecord_Click" runat="server" />
                            </td>

                            <%--<td runat="server" style="">
                                <asp:DataPager ID="DataPager1" runat="server">
                                    <Fields>
                                        <asp:NextPreviousPagerField
                                            ButtonType="Button"
                                            ShowFirstPageButton="True"
                                            ShowLastPageButton="True"/>
                                    </Fields>
                                </asp:DataPager>
                            </td>--%>
                        </tr>
                    </table>
                </LayoutTemplate>
            </asp:ListView>
        </div>
    </form>
</body>
</html>
