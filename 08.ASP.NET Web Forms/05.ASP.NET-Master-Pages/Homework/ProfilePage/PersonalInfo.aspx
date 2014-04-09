<%@ Page Title="Personal Info" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="PersonalInfo.aspx.cs" Inherits="ProfilePage.PersonalInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="styles/personalinfo.css" rel="stylesheet" />
    <style type="text/css">
        #picontainer {
            width: 977px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
    <div id="picontainer">
        <img style="width: 6em" src="images/ProfilePicture.png" alt="Nikolay Kostadinov's Picture" />
        <div class="terms">
            <dl>
                <dt>Name:</dt>                <dd>Nikolay Kostadinov</dd>
                <dt>Birthday:</dt>
                <dd><time datetime="1977-11-24">24-Nov-1977</time></dd>
                <dt>Occupation:</dt>
                <dd>IT Manager</dd>
                <dt>Area of occupation:</dt>
                <dd>IT</dd>
            </dl>
        </div>
    </div>
</asp:Content>
