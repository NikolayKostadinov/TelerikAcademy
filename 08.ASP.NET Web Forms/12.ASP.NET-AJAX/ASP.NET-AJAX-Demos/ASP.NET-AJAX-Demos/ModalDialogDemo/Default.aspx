<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ModalDialogDemo.Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title>AJAX Control Toolkit</title>
  <script type="text/javascript">
      var launch = false;
      function launchModal() {
          launch = true;
      }

      function pageLoad() {
          if (launch) {
              $find("mpe").show();
          }
      }
  </script>
</head>
<body>
  <form id="form1" runat="server">
    <asp:ScriptManager ID="asm" runat="server" />
    <div>
      <asp:Button ID="ClientButton" runat="server" Text="Launch Modal Popup (Client)" />
      <asp:Button ID="ServerButton" runat="server" Text="Launch Modal Popup (Server)" OnClick="ServerButton_Click" />
    </div>
    <asp:Panel ID="ModalPanel" runat="server" Width="500px">
      ASP.NET AJAX is a free framework for quickly creating a new generation of more efficient,
      more interactive and highly-personalized Web experiences that work across all the
      most popular browsers.<br />
      <asp:Button ID="OKButton" runat="server" Text="Close" />
    </asp:Panel>
    <ajaxToolkit:ModalPopupExtender ID="mpe" runat="server"
      TargetControlId="ClientButton" PopupControlID="ModalPanel" OkControlID="OKButton" />
  </form>
</body>
</html>

