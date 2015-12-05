<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CreateAuction.aspx.cs" Inherits="CreateAuction" MasterPageFile="~/MasterPage.Master"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style type="text/css">
        .auto-style25 {
            height: 20px;
            width: 18%;
            text-align: center;
            vertical-align: top;
        }
        .auto-style26 {
            width: 18%;
            text-align: center;
            vertical-align: top;
        }
        .auto-style27 {
            width: 210px;
            height: 24px;
            color: #0000FF;
            text-decoration: underline;
        }
        .auto-style28 {
            width: 210px;
            height: 22px;
            color: #0000FF;
            text-decoration: underline;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
    <table align="center">
        <tr>
            <td class=".auto-style25">
                <asp:ValidationSummary runat=server 
                    HeaderText="There were errors on the page:" />
                <h3 class="newStyle2">Describe your item</h3>
                <p class="newStyle2">Category:
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="ddListCategory" ForeColor="Red" Operator="NotEqual" ValueToCompare="None">*</asp:CompareValidator>
&nbsp;<asp:DropDownList ID="ddListCategory" runat="server">
                        <asp:ListItem Value="None">-Choose Category-</asp:ListItem>
                        <asp:ListItem>Art</asp:ListItem>
                        <asp:ListItem>Books</asp:ListItem>
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
        </tr>
        </table>
</asp:Content>