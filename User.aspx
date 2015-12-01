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
</head>
<body>
    <form id="form1" runat="server">
    <table style="width:100%;">
        <tr>
            <td class="auto-style6">
                <img class="auto-style11" src="AuctionPowers.jpg" />
            </td>
            <td class="auto-style2">
                <input id="Text1" class="auto-style7" type="text" /> <input id="Search" type="button" value="Search" />
            </td>
            <td class="auto-style8">
                <div>
                Welcome
                <asp:LoginName ID="LoginName1" runat="server" Font-Bold = "true" />
                <br />
                <br />
                <asp:LoginStatus ID="LoginStatus1" runat="server" />
                </div>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">
                <span class="newStyle1">
                    <span class="auto-style10"><strong>Your Items On Auction</strong><br />
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
                    Account Balance: $<asp:Label ID="lblBalance" runat="server"></asp:Label>
                </p>
                <p class="newStyle2">
                    &nbsp;</p>
                <p class="newStyle2">
                    <h3>Deposit / withdraw funds</h3>
                    Choose card:
                    <asp:RequiredFieldValidator runat=server 
                        ControlToValidate=ddListCard
                        ErrorMessage="Credit card is required."> *
                    </asp:RequiredFieldValidator>
                    <asp:DropDownList ID="ddListCard" runat="server" OnSelectedIndexChanged="ddListCard_SelectedIndexChanged">
                    </asp:DropDownList>
                <p class="newStyle2">
                    <asp:RequiredFieldValidator runat=server 
                        ControlToValidate=txtAmount
                        ErrorMessage="Amount is required."> *
                    </asp:RequiredFieldValidator>
                    Amount: <asp:TextBox ID="txtAmount" runat="server" Width="89px"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtAmount" Display="Dynamic" ErrorMessage="Must be valid dollar amount" ValidationExpression="^\d+(\.\d{2})?$"></asp:RegularExpressionValidator>
                </p>
                <p class="newStyle2">
                    <asp:Button ID="btnDeposit" runat="server" Text="Deposit" OnClick="btnDeposit_Click" />
                &nbsp;
                    <asp:Button ID="btnWithdraw" runat="server" Text="Withdraw" />
                </p>
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
</body>
</html>
