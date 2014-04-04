<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AssemblyInfo.aspx.cs" Inherits="AssemblyInfo.AssemblyInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="LabelHelloCs" runat="server"></asp:Label>
            <br />
            <br />
            <%  
                byte[] bytes = Encoding.UTF8.GetBytes("<label>Hello ASP.NET From aspx</label>");
                this.Context.Response.OutputStream.Write(bytes, 0, bytes.Length);           
            %>
            <br />
            <br />
            <asp:Label ID="LabelAssemblyInfo" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
