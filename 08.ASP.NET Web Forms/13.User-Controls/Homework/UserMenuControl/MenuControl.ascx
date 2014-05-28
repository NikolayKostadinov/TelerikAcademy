<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MenuControl.ascx.cs" Inherits="UserMenuControl.MenuControl" %>
<ul class="LinkMenu">
    <asp:DataList ID="MenuDataList" runat="server">
        <ItemTemplate>
                <a href='<%# Eval("Url") %>' style='<%# this.ColorAsString +" font:" + this.Font %>'>
                    <%#Eval("Title") %>
                </a>
        </ItemTemplate>
    </asp:DataList>
</ul>
