<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Item.aspx.cs" Inherits="Item" MasterPageFile="~/MasterPage.Master"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
    <style>

th, td {
    padding: 5px;
    text-align: left;    
}
        </style>
    <table align="center">
        <tr><td rowspan="4"><asp:Image ID="imgItem" Height="400" runat="server" /></td>
            <th><h2><asp:Label ID="lblTitle" Font-Bold="true" runat="server"></asp:Label></h2></th>
        </tr>
        <tr><td><asp:Label ID="lblDescription" runat="server"></asp:Label>
            <br /><br /><b><asp:Label ID="lblTimeleft" runat="server"></asp:Label></b>
        </td></tr>
        <tr><td><b>Highest Bid:</b> <asp:Label ID="lblHighBid" runat="server"></asp:Label>
            <br /><b><asp:Label ID="lblNextMinBid" runat="server"></asp:Label></b></td></tr>
        <tr><td><b><asp:Label ID="lblBidAmount" runat="server"></asp:Label></b><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtAmount" ForeColor="Red">*</asp:RequiredFieldValidator>
                <asp:TextBox ID="txtAmount" runat="server"></asp:TextBox><asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtAmount" ErrorMessage="Must be valid dollar amount" ForeColor="Red" ValidationExpression="^\d+(\.\d{2})?$"></asp:RegularExpressionValidator>
            <br />
            <asp:Button ID="btnBid" runat="server" OnClick="btnBid_Click" Text="Bid" />
            <br /><br />
                <asp:Label ID="lblLogIn" runat="server"></asp:Label>
                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtAmount" ErrorMessage="Must be at least minimum bid amount" ForeColor="Red" Operator="GreaterThanEqual" Type="Double"></asp:CompareValidator>
                <br />
                <asp:CompareValidator ID="CompareValidatorAvailableBalance" runat="server" ControlToValidate="txtAmount" ErrorMessage="Must be no greater than Available Balance" ForeColor="Red" Operator="LessThanEqual" Type="Double"></asp:CompareValidator>
                <br />
                <asp:Label ID="lblBuyOut" runat="server" Visible="False"></asp:Label>
                <br />
                <asp:Button ID="btnBuyOut" runat="server" Enabled="False" OnClick="btnBuyOut_Click" Text="Buy Now" Visible="False" CausesValidation="False" />
            </td>
        </tr>
    </table>
</asp:Content>