<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="RegisterForm.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title></title>
        <link href="main.css" rel="stylesheet" />
        <script src="Scripts/jquery-2.1.0.js"></script>
    </head>
    <body>
        <form id="form1" runat="server">
            <div>
                <fieldset>
                    <legend>Registration form</legend>
                    <%-- , password, repeat password, first name, last name, age, email, local address, phone and an “I accept” option--%>
                    <asp:Label Text="User Name" runat="server" AssociatedControlID="tbUserName"/>
                    <asp:TextBox runat="server" ID="tbUserName" CssClass="tb"/>
                    <asp:RequiredFieldValidator ErrorMessage="*" ControlToValidate="tbUserName" runat="server" CssClass="error" Display="Dynamic" />
                    <asp:RegularExpressionValidator
                        ID="tbUserNameValidator" 
                        ErrorMessage="*"
                        Text="<br/>The user name must be atleast six simbol long <br/>and must have atleast one letter!"
                        ControlToValidate="tbUserName" runat="server" CssClass="error"
                        ValidationExpression="([a-zA-Z]+?\d*).{5,}" Display="Dynamic" />
                    <br/>
                    <asp:Label Text="Password" runat="server" AssociatedControlID="tbPassWord"/>
                    <asp:TextBox runat="server" ID="tbPassWord" CssClass="tb"/>
                    <br/>
                    <asp:Label Text="Repeat Password" runat="server" AssociatedControlID="tbRepeatPassword"/>
                    <asp:TextBox runat="server" ID="tbRepeatPassword" CssClass="tb"/>
                    <br/>
                    <asp:Label Text="First Name" runat="server" AssociatedControlID="tbFirstName"/>
                    <asp:TextBox runat="server" ID="tbFirstName" CssClass="tb"/>
                    <br/>
                    <asp:Label Text="Last Name" runat="server" AssociatedControlID="tbLastName"/>
                    <asp:TextBox runat="server" ID="tbLastName" CssClass="tb"/>
                    <br/>
                    <asp:Label Text="Age" runat="server" AssociatedControlID="tbAge"/>
                    <asp:TextBox runat="server" ID="tbAge" CssClass="tb"/>
                    <br/>
                    <asp:Label Text="e-mail" runat="server" AssociatedControlID="tbEmail"/>
                    <asp:TextBox runat="server" ID="tbEmail" CssClass="tb" />
                    <br/>
                    <asp:Label Text="Address" runat="server" AssociatedControlID="tbLocalAddress"/>
                    <asp:TextBox runat="server" ID="tbLocalAddress" CssClass="tb" />
                    <br/>
                    <asp:CheckBox Text="I accept" runat="server" ID="chkAccept" />
                    <asp:Button ID ="Submit" Text="Submin" runat="server" />
                </fieldset>
            </div>
        </form>
    </body>
</html>
