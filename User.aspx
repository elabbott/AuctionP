<%@ Page Language="C#" AutoEventWireup="true" CodeFile="User.aspx.cs" Inherits="UserPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta charset="utf-8" />
    <style type="text/css">
        
        .auto-style2 {
            height: 20px;
            width: 60%;
            text-align: center;
            vertical-align: top;
        }

        .auto-style3 {
            width: 20%;
            text-align: center;
            vertical-align: top;
        }

        .auto-style4 {
            width: 60%;
            vertical-align: top;
        }

        .auto-style6 {
            height: 20px;
            width: 20%;
            text-align: center;
        }

        .auto-style7 {
            width: 400px;
        }

        .newStyle1 {
            font-family: Arial, Helvetica, sans-serif;
        }

        .auto-style8 {
            height: 20px;
            width: 20%;
            text-align: right;
            vertical-align: top;
        }

        .auto-style10 {
            text-decoration: underline;
        }

        .auto-style11 {
            width: 200px;
            height: 200px;
        }

        .newStyle2 {
            font-family: Arial, Helvetica, sans-serif;
        }
        .auto-style16 {
            font-family: Arial, Helvetica, sans-serif;
            color: #0000FF;
            text-decoration: underline;
        }
        .auto-style18 {
            width: 20%;
            text-align: center;
            vertical-align: top;
            font-family: Arial, Helvetica, sans-serif;
        }
        .auto-style19 {
            width: 200px;
            height: 198px;
        }
        .auto-style20 {
            width: 200px;
            height: 112px;
        }
        .auto-style21 {
            width: 200px;
            height: 197px;
        }
        .auto-style22 {
            width: 200px;
            height: 201px;
        }
        .auto-style23 {
            color: #FF0000;
        }
        .auto-style24 {
            color: #009933;
        }
    </style>
    <link href="Content/bootstrap-theme.css" rel="stylesheet" />
    <link href="Content/bootstrap-theme.min.css" rel="stylesheet" />
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
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
    <table style="width:100%;">
        <tr>
            <td class="auto-style2">
                <input id="Text1" class="auto-style7" type="text" /> <input id="Search" type="button" value="Search" />
            </td>
            <td class="auto-style8">
                <div>
                Welcome
                <asp:LoginName ID="LoginName1" runat="server" Font-Bold = "true" />
                <br />
                <br />
                    
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Home.aspx">Home</asp:HyperLink>
                    |<asp:LoginStatus ID="LoginStatus1" runat="server" OnLoggingOut="LoginStatus1_LoggingOut" />

                </div>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">
                <span class="newStyle1">
                    <span class="auto-style10">
                
                        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/UserAuctions.aspx">Your Items on Auction</asp:HyperLink>
                <br />
                        <br />
                <img class="auto-style19" src="http://i.ebayimg.com/00/s/NDY4WDQ2OQ==/z/Ev4AAOSwBP9UV-N4/$_1.JPG?set_id=2" /><br />
                    </span>$18.50<br />
                <hr />
                <br />
                <img class="auto-style20" src="http://i.ebayimg.com/00/s/MjY3WDQ2OA==/z/emIAAOSwGWNUV-Oa/$_1.JPG?set_id=2" /><br />
                $6.46</td>
            <td class="auto-style4">
                <h2 class="newStyle2">Account Information</h2>
                <p class="newStyle2">&nbsp;</p>
                <p class="newStyle2">
                    <b>Account Balance:</b> $<asp:Label ID="lblBalance" runat="server"></asp:Label>
                </p>
                <p class="newStyle2">
                    &nbsp;</p>
                <hr />
                    <h3>Deposit / withdraw funds</h3>
                    Choose card:
                    <asp:DropDownList ID="ddListCard" runat="server" OnSelectedIndexChanged="ddListCard_SelectedIndexChanged">
                    </asp:DropDownList>
                &nbsp;<asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="ddListCard" ErrorMessage="Must select card" ForeColor="Red" Operator="NotEqual" ValueToCompare="0"></asp:CompareValidator>
                <p class="newStyle2">
                    Amount: $<asp:TextBox ID="txtAmount" runat="server" Width="94px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtAmount" ForeColor="Red">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtAmount" ErrorMessage="Valid dollar amount required" ForeColor="Red" ValidationExpression="^\d+(\.\d{2})?$"></asp:RegularExpressionValidator>
                </p>
                <p class="newStyle2">
                    <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="txtAmount" Enabled="False" ErrorMessage="Amount must be no more than Account Balance" ForeColor="Red"></asp:CompareValidator>
                </p>
                <p class="newStyle2">
                    <asp:RadioButtonList ID="rdBtnType" runat="server" OnSelectedIndexChanged="rdBtnType_SelectedIndexChanged">
                        <asp:ListItem>Deposit</asp:ListItem>
                        <asp:ListItem>Withdraw</asp:ListItem>
                    </asp:RadioButtonList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="rdBtnType" ErrorMessage="Must select transaction type" ForeColor="Red"></asp:RequiredFieldValidator>
                </p>
                <p class="newStyle2">
                &nbsp;<asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" />
                </p>
                <p class="newStyle2">
                    &nbsp;</p>
                <p class="auto-style16">
                    <a href="AddCard.aspx">Add Credit Card</a></p>
                <hr />
                <p class="auto-style16">
                    <a href="CreateAuction.aspx">Create an Auction</a></p>
            </td>
            <td class="auto-style18"><strong><span class="auto-style10">Items You&#39;ve Bid On</span><br />
                <br />
                <img class="auto-style21" src="http://i.ebayimg.com/00/s/NDY4WDQ2OA==/z/iioAAOSwBP9UV-b3/$_1.JPG?set_id=2" /><br />
                </strong><span class="auto-style23">$5.80</span><hr />
                <br />
                <img class="auto-style22" src="http://i.ebayimg.com/00/s/NjI1WDYyNQ==/z/XxwAAOSwzOxUV-XA/$_1.JPG?set_id=2" /><br />
                <span class="auto-style24">$17.23</span><br />
            </td>
        </tr>
        </table>
        </form>
    <script src="Scripts/bootstrap.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="Scripts/jquery-1.9.1.js"></script>
    <script src="Scripts/jquery-1.9.1.intellisense.js"></script>
    <script src="Scripts/jquery-1.9.1.min.js"></script>
</body>
</html>
