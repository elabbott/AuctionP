<%@ Page Language="C#" AutoEventWireup="true" CodeFile="User.aspx.cs" Inherits="UserPage" MasterPageFile="~/MasterPage.Master" %>

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
    <div>
        <table style="width:100%;">
        <tr>
            <td class="auto-style25">
                
            </td>
            <td class="auto-style8">
               
            </td>
        </tr>
        <tr>
            <td class="auto-style26">
                <span class="newStyle1">
                    <span class="auto-style10">
                
                        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/UserAuctions.aspx">Your Items on Auction</asp:HyperLink>
                        <br />
                        <br />
                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/UserBids.aspx">Your current Bids</asp:HyperLink>
                        <br />
                        <br />
                        <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/UserBids.aspx?opt=won">Auctions You've Won</asp:HyperLink>
                        <br />
                        <br />
                        <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/CreateAuction.aspx">Create New Auction</asp:HyperLink>
                        <br />
</span></span></td>
            <td class="auto-style4">
                <h2 class="newStyle2">Account Information</h2>
                <p class="newStyle2">&nbsp;</p>
                <p class="newStyle2">
                    <b>Account Balance:</b> <asp:Label ID="lblBalance" runat="server"></asp:Label>
                    <br />
                    <b>Outstanding bids:</b> <asp:Label ID="lblCurrentBids" runat="server"></asp:Label>
                    <hr />
                    <b>Available Balance:</b> <asp:Label ID="lblAvailableBalance" runat="server"></asp:Label>
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
                    <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="txtAmount" Enabled="False" ErrorMessage="Amount must be no more than available Account Balance" ForeColor="Red" Type="Double"></asp:CompareValidator>
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
                <p class="auto-style27">
                    <a href="AddCard.aspx">Add Credit Card</a></p>
            </td>
        </tr>
        </table>
    </div>
</asp:Content>

