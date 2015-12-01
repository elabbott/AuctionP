<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Search.aspx.cs" Inherits="Search" %>

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
        .auto-style23 {
            width: 200px;
            height: 200px;
            color: #0000FF;
            text-decoration: underline;
        }
        .auto-style24 {
            font-family: Arial, Helvetica, sans-serif;
            width: 500px;
            border: thin solid black;
        }
        .auto-style25 {
            color: #000000;
        }
        .auto-style21 {
            width: 202px;
            height: 200px;
            color: #0000FF;
            text-decoration: underline;
        }
        .auto-style26 {
            width: 100%;
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
                    Watcha searchin&#39; for
                <asp:LoginName ID="LoginName1" runat="server" Font-Bold = "true" />
                    ?<br />
                <br />
                <asp:LoginStatus ID="LoginStatus1" runat="server" />
                </div>
                
            </td>
        </tr>
        <tr>
            <td class="auto-style3" style="vertical-align: top;">
                <span class="newStyle1">&nbsp;<span class="auto-style10"><strong>Categories</strong><br />
                </span>
                    <br />
                    
                    <asp:LinkButton ID="lbArt" runat="server" OnClick="lbArt_Click">Art</asp:LinkButton>
                    <br />
                    <br class="auto-style13" />
                    <asp:LinkButton ID="lbBooks" runat="server" OnClick="lbBooks_Click">Books</asp:LinkButton>
                    <br />
                    <br />
                    <asp:LinkButton ID="lbClothes" runat="server" OnClick="lbClothes_Click">Clothes</asp:LinkButton>
                    <br />
                    <br class="auto-style12" />
                    <asp:LinkButton ID="lbCrafts" runat="server" OnClick="lbCrafts_Click">Crafts</asp:LinkButton>
                    <br />
                    <br class="auto-style12" />
                    <asp:LinkButton ID="lbElectronics" runat="server" OnClick="lbElectronics_Click">Electronics</asp:LinkButton>
                    <br />
                    <br class="auto-style12" />
                    <asp:LinkButton ID="lbHomeGarden" runat="server" OnClick="lbHomeGarden_Click">Home & Garden</asp:LinkButton>
                    <br />
                    <br class="auto-style12" />
                    <asp:LinkButton ID="lbJewelry" runat="server" OnClick="lbJewelry_Click">Jewelry</asp:LinkButton>
                    <br />
                    <br class="auto-style12" />
                    <asp:LinkButton ID="lbMusic" runat="server" OnClick="lbMusic_Click">Music</asp:LinkButton>
                    <br />
                    <br class="auto-style12" />
                    <asp:LinkButton ID="lbPetGoods" runat="server" OnClick="lbPetGoods_Click">Pet Goods</asp:LinkButton>
                    <br />
                    <br class="auto-style12" />
                    <asp:LinkButton ID="lbSportsGoods" runat="server" OnClick="lbSportsGoods_Click">Sports Goods</asp:LinkButton>
                    <br />
                    <br class="auto-style12" />
                    <asp:LinkButton ID="lbToys" runat="server" OnClick="lbToys_Click">Toys</asp:LinkButton>
                    <br />
                    <br class="auto-style12" />
                    <asp:LinkButton ID="lbVideoGames" runat="server" OnClick="lbVideoGames_Click">Video Games</asp:LinkButton>
                    
                </span>
            </td>
            <td colspan="2" style="vertical-align: top;">
                <h2><span class="newStyle1">Search Results for
                    <asp:Label ID="LabelCategory" runat="server" Text="Label"></asp:Label>
&nbsp;<asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
                        <AlternatingRowStyle BackColor="White" />
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                    </asp:GridView>
                    </span></h2>
                <div>
                    <table style="width:100%;" border="1" class="auto-style26">
                        <tr>
                            <td class="auto-style24" style="border: thin solid #000000;"><span class="newStyle1">LED Faucet Light<br />
                        <img class="auto-style23" src="http://i.ebayimg.com/00/s/MzAwWDMwMA==/z/9g0AAOSwdpxUV9-u/$_1.JPG?set_id=2" /></td>
                            <td class="newStyle1" style="border: thin solid #000000;">Owner: <em><span class="auto-style14">Username<br />
                                <br />
                                </span></em><span class="auto-style25">Highest Bid: $12.00<br />
                                <br />
                                End Time: 11/2/2015</span></td>
                        </tr>
                        <tr>
                            <td class="auto-style24" style="border: thin solid #000000;">Waterproof Bluetooth Speaker<br />
                                <img src="http://i.ebayimg.com/00/s/NDY4WDQ2OQ==/z/Ev4AAOSwBP9UV-N4/$_1.JPG?set_id=2" class="auto-style11" /></td>
                            <td class="newStyle1" style="border: thin solid #000000;">Owner: <em><span class="auto-style14">Username<br />
                                <br />
                                </span></em><span class="auto-style25">Highest Bid: $18.50<br />
                                <br />
                                End Time: 11/10/2015</span></td>
                        </tr>
                        <tr>
                            <td class="auto-style24" style="border: thin solid #000000;"><span class="newStyle1"><span class="auto-style25">Samsung Galaxy Gear Smart Watch<br />
                                </span><img class="auto-style21" src="http://i.ebayimg.com/00/s/NDY4WDQ2OA==/z/E-MAAOSwrx5UV-HO/$_1.JPG?set_id=2" /></td>
                            <td class="newStyle1" style="border: thin solid #000000;">Owner: <em><span class="auto-style14">Username<br />
                                <br />
                                </span></em><span class="auto-style25">Highest Bid: $72.86<br />
                                <br />
                                End Time: 11/15/2015</span></td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
        </table>
        </form>
</body>
</html>
