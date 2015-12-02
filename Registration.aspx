<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Registration.aspx.cs" Inherits="Registration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        body
        {
            font-family: Arial;
            font-size: 10pt;
        }
        input
        {
            width: 200px;
        }
        table
        {
            border: 1px solid #ccc;
        }
        table th
        {
            background-color: #F7F7F7;
            color: #333;
            font-weight: bold;
        }
        table th, table td
        {
            padding: 5px;
            border-color: #ccc;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <header>
            <nav class="navbar navbar-default">
                <div class="container-fluid">
                    <div class="navbar-header">
                        <img class="navbar-brand" src="AuctionPowers.jpg"/>
                    </div>
                    <div>
                        <ul class="nav navbar-nav">
                            <li class="active"><a href="Home.aspx">Home</a></li>
                            <li><a href="Search.aspx">Search</a></li>
                            <li><a href="User.aspx">User.aspx</a></li>
                            <li>
                                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></li>
                            <li>
                                <asp:LinkButton ID="lbSearch" CssClass="btn btn-primary" runat="server" OnClick="lbSearch_Click">Search</asp:LinkButton></li>
                        </ul>
                    </div>
                </div>
            </nav>
        </header>
    <table style="border-collapse: separate; border-spacing: 10px;">
        <tr>
            <th colspan="3">
                Registration
            </th>
        </tr>
        <tr>
            <td>
                Username
            </td>
            <td>
                <asp:TextBox ID="txtUsername" runat="server" />
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ErrorMessage="Required" ForeColor="Red" ControlToValidate="txtUsername"
                    runat="server" />
                <asp:RegularExpressionValidator Display = "Dynamic" ControlToValidate = "txtUsername" ID="RegularExpressionValidator2" 
                    ValidationExpression = "^[\s\S]{4,16}$" runat="server" ErrorMessage="Minimum 4 and Maximum 16 characters required."></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td>
                Password
            </td>
            <td>
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" />
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ErrorMessage="Required" ForeColor="Red" ControlToValidate="txtPassword"
                    runat="server" />
                <asp:RegularExpressionValidator Display = "Dynamic" ControlToValidate = "txtPassword" ID="RegularExpressionValidator3" 
                    ValidationExpression = "^[\s\S]{8,32}$" runat="server" ErrorMessage="Minimum 8 and Maximum 32 characters required."></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td>
                Confirm Password
            </td>
            <td>
                <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" />
            </td>
            <td>
                <asp:CompareValidator ID="CompareValidator1" ErrorMessage="Passwords do not match." ForeColor="Red" ControlToCompare="txtPassword"
                    ControlToValidate="txtConfirmPassword" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                Email
            </td>
            <td>
                <asp:TextBox ID="txtEmail" runat="server" />
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ErrorMessage="Required" Display="Dynamic" ForeColor="Red"
                    ControlToValidate="txtEmail" runat="server" />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                    ControlToValidate="txtEmail" ForeColor="Red" ErrorMessage="Invalid email address." />
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <asp:Button ID="Button1" Text="Submit" runat="server" OnClick="RegisterUser2" />
                <!--<asp:Button ID="btnConfirm" runat="server" Text="Login" PostBackUrl="~/Login.aspx" /> -->
            </td>
            <td>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
