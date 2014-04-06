<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentForm.aspx.cs" Inherits="StudentRegistrationForm.StudentForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title>Student System</title>
        <link href="style.css" rel="stylesheet" />
    </head>
    <body>
        <form id="form1" runat="server">
            <div style="height: 433px">

                <asp:Panel ID="PanelStudent" runat="server" GroupingText="Student's data" Width="317px" CssClass="panels">
                    <asp:Label ID="LabelFirstName" runat="server" AssociatedControlID="TextBoxFirstName" Text="First name" CssClass="student" ></asp:Label>
                    <asp:TextBox ID="TextBoxFirstName" runat="server" CssClass="inputstudent name"></asp:TextBox>
                    <br />
                    <br />                   
                    <asp:Label ID="LabelLastName" runat="server" AssociatedControlID="TextBoxLastName" Text="Last name" CssClass="student"></asp:Label>
                    <asp:TextBox ID="TextBoxLastName" runat="server" CssClass="inputstudent name"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Label ID="LabelFacultyNumber" runat="server" AssociatedControlID="TextBoxFacultyNumber" Text="Faculty number" CssClass="student" ></asp:Label>
                    <asp:TextBox ID="TextBoxFacultyNumber" runat="server" CssClass="inputstudent"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Label Text="University" AssociatedControlID ="DropDownListUniversity" runat="server" CssClass="student" ID ="LabelUniversity"/>
                    <asp:DropDownList ID ="DropDownListUniversity" runat="server" CssClass="inputstudent" AutoPostBack="True" OnSelectedIndexChanged="DropDownListUniversity_SelectedIndexChanged">
                    </asp:DropDownList>
                    <br />
                </asp:Panel>
                <asp:Panel ID="PanelSpecialties" runat="server" Width="320px" CssClass ="panels" GroupingText="Specialties" Height="244px" >
                    <asp:ListBox ID="ListBoxSpecialty" runat="server" Width="287px" Height="140px" SelectionMode="Multiple"></asp:ListBox>
                </asp:Panel>
            </div>
        </form>
    </body>
</html>
