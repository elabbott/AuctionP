<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Item.aspx.cs" Inherits="Item" %>

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
        }

        .auto-style10 {
            text-decoration: underline;
        }

        .auto-style11 {
            width: 200px;
            height: 200px;
        }

        .auto-style12 {
            text-decoration: underline;
            color: #0000FF;
            background-color: #FFFFFF;
        }

        .auto-style13 {
            color: #0000FF;
            background-color: #FFFFFF;
        }

        .auto-style14 {
            text-decoration: underline;
            color: #0000FF;
        }
        .auto-style15 {
            width: 500px;
            height: 397px;
        }
        .auto-style16 {
            height: 397px;
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
                    &nbsp;<span class="auto-style10"><strong>Categories</strong><br />
                        <br />
                        <span class="auto-style13">Art</span><br class="auto-style13" />
                        <br class="auto-style13" />
                        <span class="auto-style13">Books</span><br class="auto-style13" />
                        <br class="auto-style13" />
                        <span class="auto-style13">Clothes</span>
                    </span><br class="auto-style12" />
                    <br class="auto-style12" />
                    <span class="auto-style12">Crafts</span><br class="auto-style12" />
                    <br class="auto-style12" />
                    <span class="auto-style12">Electronics</span><br class="auto-style12" />
                    <br class="auto-style12" />
                    <span class="auto-style12">Home &amp; Garden</span><br class="auto-style12" />
                    <br class="auto-style12" />
                    <span class="auto-style12">Jewelry</span><br class="auto-style12" />
                    <br class="auto-style12" />
                    <span class="auto-style12">Music</span><br class="auto-style12" />
                    <br class="auto-style12" />
                    <span class="auto-style12">Pet Goods</span><br class="auto-style12" />
                    <br class="auto-style12" />
                    <span class="auto-style12">Sports Goods</span><br class="auto-style12" />
                    <br class="auto-style12" />
                    <span class="auto-style12">Toys</span><br class="auto-style12" />
                    <br class="auto-style12" />
                    <span class="auto-style12">Video Games</span>
            </td>
            <td colspan="2" style="vertical-align: top;">
                <h2><span class="newStyle1">&nbsp;<asp:Label ID="lblTitle" runat="server"></asp:Label>
                    </span></h2>
                <p>
                    <table style="width:100%;" border="1">
                        <tr>
                            <td class="auto-style15" style="border: thin solid #000000">
                                <asp:Image ID="imgItem" runat="server" />
                            </td>
                            <td style="border: thin solid #000000" class="auto-style16"><span class="newStyle1">Highest Bid: $<asp:Label ID="lblHighBid" runat="server"></asp:Label>
                                <br />
                                <br />
                                Next Minimum Bid: $<asp:Label ID="lblNextMinBid" runat="server"></asp:Label>
                                <br />
                                <br />
                                $<input id="txtBidAmount" type="text" />
                                <input id="btnBid" type="button" value="Bid" /><br />
                                <br />
                                <asp:Label ID="lblBuyOut" runat="server" Visible="False"></asp:Label>
                                <br />
                                <asp:Button ID="btnBuyOut" runat="server" Enabled="False" OnClick="btnBuyOut_Click" Text="Buy Now" Visible="False" />
                                <br />
                                &nbsp;<br />
                                <hr />
                                <br />
                                <span class="auto-style14">Edit Auction</span><br class="auto-style14" />
                                <br class="auto-style14" />
                                <span class="auto-style14">Delete Auction</span></span></td>
                        </tr>
                        <asp:Label ID="lblDescription" runat="server"></asp:Label>
                    </table>
                </p>
            </td>
        </tr>
        </table>
    </form>
</body>
</html>
