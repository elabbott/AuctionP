<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CreateAuction.aspx.cs" Inherits="CreateAuction" %>

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
            width: 651px;
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
                <asp:ValidationSummary runat=server 
                    HeaderText="There were errors on the page:" />
                <h3 class="newStyle2">Describe your item</h3>
                <p class="newStyle2">Category:
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="ddListCategory" ForeColor="Red" Operator="NotEqual" ValueToCompare="None">*</asp:CompareValidator>
&nbsp;<asp:DropDownList ID="ddListCategory" runat="server">
                        <asp:ListItem Value="None">-Choose Category-</asp:ListItem>
                        <asp:ListItem>Art</asp:ListItem>
                        <asp:ListItem>Book</asp:ListItem>
                        <asp:ListItem>Clothes</asp:ListItem>
                        <asp:ListItem>Crafts</asp:ListItem>
                        <asp:ListItem>Electronics</asp:ListItem>
                        <asp:ListItem>Home &amp; Garden</asp:ListItem>
                        <asp:ListItem>Jewelry</asp:ListItem>
                        <asp:ListItem>Music</asp:ListItem>
                        <asp:ListItem>Pet Goods</asp:ListItem>
                        <asp:ListItem>Sports Goods</asp:ListItem>
                        <asp:ListItem>Toys</asp:ListItem>
                        <asp:ListItem>Video Games</asp:ListItem>
                    </asp:DropDownList>
                </p>
            <p class="newStyle2">
                    Title:
                <asp:RequiredFieldValidator runat=server 
                    ControlToValidate=txtTitle
                    ErrorMessage="Title is required." ForeColor="Red"> *
                </asp:RequiredFieldValidator>
                    <asp:TextBox ID="txtTitle" runat="server" Width="433px"></asp:TextBox>
                </p>
                <p class="newStyle2">
                    Image url:
                <asp:RequiredFieldValidator runat=server 
                    ControlToValidate=txtImage
                    ErrorMessage="Image URL is required." ForeColor="Red"> *
                </asp:RequiredFieldValidator>
                    <asp:TextBox ID="txtImage" runat="server" Width="405px"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorImgURL" runat="server" ControlToValidate="txtImage" ErrorMessage="Invalid URL" ForeColor="Red" ValidationExpression="http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&amp;=]*)?"></asp:RegularExpressionValidator>
                </p>
                <p class="newStyle2">
                    <asp:RequiredFieldValidator runat=server 
                        ControlToValidate=txtDescription
                        ErrorMessage="Description is required." ForeColor="Red"> *
                    </asp:RequiredFieldValidator>
                    Description:    <p class="newStyle2">
                    <asp:TextBox ID="txtDescription" runat="server" Height="160px" Width="488px"></asp:TextBox>
                </p>
                <h3 class="newStyle2">Select duration</h3>
                <p class="newStyle2">
                    <asp:DropDownList ID="ddListDuration" runat="server">
                        <asp:ListItem Value="3">3 days</asp:ListItem>
                        <asp:ListItem Value="5">5 days</asp:ListItem>
                        <asp:ListItem Value="7">7 days</asp:ListItem>
                    </asp:DropDownList>
                </p>
                    <h3 class="newStyle2">Select price (optional)</h3>
                <p class="newStyle2">Starting price:
                    <asp:TextBox ID="txtMinBid" runat="server"></asp:TextBox>
                <p class="newStyle2">Buyout price:
                    <asp:TextBox ID="txtBuyout" runat="server"></asp:TextBox>
                </p>
                <p class="newStyle2">
                    <asp:Button ID="btnCreate" runat="server" OnClick="btnCreate_Click" Text="Create Auction" />
&nbsp;
                    <asp:Button ID="btnCancel" runat="server" CausesValidation="False" OnClick="btnCancel_Click" Text="Cancel" />
                </p>
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
