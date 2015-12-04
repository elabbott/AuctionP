<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Item.aspx.cs" Inherits="Item" MasterPageFile="~/MasterPage.Master"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
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
                            <td style="border: thin solid #000000" class="auto-style16"><span class="newStyle1">Highest Bid: <asp:Label ID="lblHighBid" runat="server"></asp:Label>
                                <br />
                                <br />
                                Next Minimum Bid: <asp:Label ID="lblNextMinBid" runat="server"></asp:Label>
                                <br />
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtAmount" ErrorMessage="Must be valid dollar amount" ForeColor="Red" ValidationExpression="^\d+\.\d{2}$"></asp:RegularExpressionValidator>
                                <br />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtAmount" ErrorMessage="RequiredFieldValidator" ForeColor="Red">*</asp:RequiredFieldValidator>
                                <asp:TextBox ID="txtAmount" runat="server"></asp:TextBox>
&nbsp;<asp:Button ID="btnBid" runat="server" OnClick="btnBid_Click" Text="Bid" />
                                <br />
                                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtAmount" ErrorMessage="Must be at least minimum bid amount" ForeColor="Red" Operator="GreaterThanEqual" Type="Double"></asp:CompareValidator>
                                <br />
                                <asp:CompareValidator ID="CompareValidatorAvailableBalance" runat="server" ControlToValidate="txtAmount" ErrorMessage="Must be no greater than Available Balance" ForeColor="Red" Operator="LessThanEqual" Type="Double"></asp:CompareValidator>
                                <br />
                                <asp:Label ID="lblBuyOut" runat="server" Visible="False"></asp:Label>
                                <br />
                                <asp:Button ID="btnBuyOut" runat="server" Enabled="False" OnClick="btnBuyOut_Click" Text="Buy Now" Visible="False" CausesValidation="False" />
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
</asp:Content>