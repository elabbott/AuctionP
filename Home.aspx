<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Home" %>

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
        .auto-style16 {
            width: 210px;
            height: 200px;
            color: #0000FF;
            text-decoration: underline;
        }
        .auto-style17 {
            height: 156px;
        }
        .auto-style18 {
            width: 247px;
            height: 201px;
            color: #0000FF;
            text-decoration: underline;
        }
        .auto-style19 {
            width: 203px;
            height: 200px;
            color: #0000FF;
            text-decoration: underline;
        }
        .auto-style20 {
            width: 216px;
            height: 200px;
            color: #0000FF;
            text-decoration: underline;
        }
        .auto-style21 {
            width: 202px;
            height: 200px;
            color: #0000FF;
            text-decoration: underline;
        }
        .auto-style23 {
            width: 200px;
            height: 200px;
            color: #0000FF;
            text-decoration: underline;
        }
        .auto-style24 {
            height: 156px;
            text-decoration: underline;
        }
    </style>
</head>
<body>
    <table style="width:100%;">
        <tr>
            <td class="auto-style6">
                <img class="auto-style11" src="AuctionPowers.jpg" /></td>
            <td class="auto-style2">
                <input id="Text1" class="auto-style7" type="text" /> <input id="Search" type="button" value="Search" /></td>
            <td class="auto-style8">
            <form id="form1" runat="server">
            <div>
            Welcome
            <asp:LoginName ID="LoginName1" runat="server" Font-Bold = "true" />
            <br />
            <br />
            <asp:LoginStatus ID="LoginStatus1" runat="server" />
            </div>
            </form>
        </tr>
        <tr>
            <td class="auto-style3"><span class="newStyle1">&nbsp;<span class="auto-style10"><strong>Categories</strong><br />
                <br />
                <span class="auto-style13">Art</span><br class="auto-style13" />
                <br class="auto-style13" />
                <span class="auto-style13">Books</span><br class="auto-style13" />
                <br class="auto-style13" />
                <span class="auto-style13">Clothes</span></span><br class="auto-style12" />
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
                <span class="auto-style12">Video Games</span></td>
            <td class="auto-style4" colspan="2">
                <h2><span class="newStyle1">Latest Items</h2>
                <table style="border: medium solid #CCFF66; width:100%;" border="1">
                <tr>
                    <td class="auto-style24" style="border: medium dotted #CCFF66"><span class="auto-style14">Phone Projector</span><br class="auto-style14" />
                        <img class="auto-style23" src="http://i.ebayimg.com/00/s/NDk1WDQ5NQ==/z/Nf8AAOSwa39UsBh4/$_1.JPG?set_id=2" /></td>
                    <td class="auto-style17" style="border: medium dotted #CCFF66"><span class="auto-style14">LED Faucet Light</span><br class="auto-style14" />
                        <img class="auto-style23" src="http://i.ebayimg.com/00/s/MzAwWDMwMA==/z/9g0AAOSwdpxUV9-u/$_1.JPG?set_id=2" /></td>
                    <td class="auto-style17" style="border: medium dotted #CCFF66"><span class="auto-style14">Suitcase Table</span><br class="auto-style14" />
                        <img class="auto-style16" src="http://i.ebayimg.com/00/s/MjgxWDMwMA==/z/XU0AAOSw~1FUV9~S/$_1.JPG?set_id=2" /></td>
                </tr>
                <tr>
                    <td class="auto-style10" style="border: medium dotted #CCFF66"><span class="auto-style14">Death Star Ice Tray</span><br class="auto-style14" />
                        <img class="auto-style18" src="http://i.ebayimg.com/00/s/MjQ4WDMwMA==/z/vMsAAOSwLa9UV9~t/$_1.JPG?set_id=2" /></td>
                    <td style="border: medium dotted #CCFF66"><span class="auto-style14">Sushi Roller</span><br class="auto-style14" />
                        <img class="auto-style23" src="http://i.ebayimg.com/00/s/MzAwWDMwMA==/z/CJYAAOSwGWNUV-BC/$_1.JPG?set_id=2" /></td>
                    <td style="border: medium dotted #CCFF66"><span class="auto-style14">IPhone Bottle Opener</span><br class="auto-style14" />
                        <img class="auto-style16" src="http://i.ebayimg.com/00/s/MzEyWDQ2OA==/z/GuEAAOSwabhUV-Cl/$_1.JPG?set_id=2" /></td>
                </tr>
                <tr>
                    <td class="auto-style10" style="border: medium dotted #CCFF66"><span class="auto-style14">Credit Card Sized Survival Knife</span><br class="auto-style14" />
                        <img class="auto-style19" src="http://i.ebayimg.com/00/s/Mjk3WDMwMA==/z/28wAAOSwLa9UV-DT/$_1.JPG?set_id=2" /></td>
                    <td style="border: medium dotted #CCFF66"><span class="auto-style14">Vegetable Pencil Peeler</span><br class="auto-style14" />
                        <img class="auto-style20" src="http://i.ebayimg.com/00/s/Mjc2WDMwMA==/z/LJAAAOSwabhUV-Er/$_1.JPG?set_id=2" /></td>
                    <td style="border: medium dotted #CCFF66"><span class="auto-style14">Samsung Galaxy Gear Smart Watch</span><br class="auto-style14" />
                        <img class="auto-style21" src="http://i.ebayimg.com/00/s/NDY4WDQ2OA==/z/E-MAAOSwrx5UV-HO/$_1.JPG?set_id=2" /></td>
                </tr>
                </table>
            </td>
        </tr>
        </table>
</body>
</html>
