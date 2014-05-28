<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebFotoAlbum.Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxControlToolkit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="main.css" rel="stylesheet" />
    <script src="scripts/jquery-2.1.1.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label Text="Това от долу е AJAX!!!" runat="server" />
            <AjaxControlToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
            </AjaxControlToolkit:ToolkitScriptManager>
            <div class="Image">
                <asp:Image ID="Image" runat="server"
                    ImageUrl="~/images/1.jpg" alt="Picture"
                    Height="300px"
                    Width="400px" OnClick="image_Click" />
            </div>

            <AjaxControlToolkit:SlideShowExtender ID="SlideShowExtender1" runat="server"
                TargetControlID="image"
                SlideShowServiceMethod="GetSlides"
                Enabled="true"
                AutoPlay="true"
                ImageTitleLabelID="imageTitle"
                NextButtonID="nextButton"
                PlayButtonText="Play"
                StopButtonText="Stop"
                PreviousButtonID="prevButton"
                PlayButtonID="playButton"
                Loop="true"
                SlideShowAnimationType="SlideRight">
            </AjaxControlToolkit:SlideShowExtender>
            <div class="Image">
                <asp:Label ID="imageTitle" runat="server"></asp:Label>
                <asp:Button ID="prevButton" runat="server" Text="Previous" />
                <asp:Button ID="playButton" runat="server" Text="" />
                <asp:Button ID="nextButton" runat="server" Text="Next" />
            </div>
        </div>
    </form>
    <script type="text/javascript" src="Scripts/zoommodal.js"></script>
</body>
</html>
