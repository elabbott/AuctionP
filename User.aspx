﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="User.aspx.cs" Inherits="UserPage" MasterPageFile="~/MasterPage.Master" %>

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
</span></span></td>
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
                
            </td>
        </tr>
        </table>
    </div>
</asp:Content>

