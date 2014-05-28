<%@ Page Title="" Language="C#" MasterPageFile="~/Company.Master" AutoEventWireup="true" CodeBehind="Offices.aspx.cs" Inherits="CompanySite.Offices" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Menu ID="Menu2" runat="server" DataSourceID="SiteMapDataSource2" StaticDisplayLevels="3">
    </asp:Menu>
    <asp:SiteMapDataSource ID="SiteMapDataSource2" runat="server" StartingNodeOffset="2"/>
</asp:Content>
