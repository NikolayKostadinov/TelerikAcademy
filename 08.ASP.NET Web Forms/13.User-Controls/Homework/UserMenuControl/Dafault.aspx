<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dafault.aspx.cs" Inherits="UserMenuControl.Dafault" %>

<%@ Register Src="~/MenuControl.ascx" TagPrefix="uc1" TagName="MenuControl" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <uc1:MenuControl runat="server" ID="MenuControl" FontColor="#66FF33" Font="bold 20px Arial;" />
    </div>
    </form>
</body>
</html>
