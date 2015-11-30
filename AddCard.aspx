﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddCard.aspx.cs" Inherits="AddCard" %>

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

    <table style="width:100%;">
        <tr>
            <td class="auto-style6">
                <img class="auto-style11" src="AuctionPowers.jpg" />
            </td>
            <td class="auto-style2">
                <input id="Text1" class="auto-style7" type="text" /> <input id="Search" type="button" value="Search" />
            </td>
            <td class="auto-style8">
                <form id="form1" runat="server">
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
                Name:
                <asp:RequiredFieldValidator runat=server 
                    ControlToValidate=txtName
                    ErrorMessage="Name is required."> *
                </asp:RequiredFieldValidator>
                <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                <br />
                <br />
                Number:
                <asp:RequiredFieldValidator runat=server 
                    ControlToValidate=txtNum
                    ErrorMessage="Number is required."> *
                </asp:RequiredFieldValidator>
                <asp:TextBox ID="txtNum" runat="server"></asp:TextBox>
                <br />
                <br />
                CCV #:
                <asp:RequiredFieldValidator runat=server 
                    ControlToValidate=txtCCV
                    ErrorMessage="CCV is required."> *
                </asp:RequiredFieldValidator>
                <asp:TextBox ID="txtCCV" runat="server" Width="47px"></asp:TextBox>
                <br />
                <br />
                Expiration date:

                <asp:DropDownList ID="ddListMonth" runat="server">
                    <asp:ListItem>01</asp:ListItem>
                    <asp:ListItem>02</asp:ListItem>
                    <asp:ListItem>03</asp:ListItem>
                    <asp:ListItem>04</asp:ListItem>
                    <asp:ListItem>05</asp:ListItem>
                    <asp:ListItem>06</asp:ListItem>
                    <asp:ListItem>07</asp:ListItem>
                    <asp:ListItem>08</asp:ListItem>
                    <asp:ListItem>09</asp:ListItem>
                    <asp:ListItem>10</asp:ListItem>
                    <asp:ListItem>11</asp:ListItem>
                    <asp:ListItem>12</asp:ListItem>
                </asp:DropDownList>
&nbsp;/
                <asp:RequiredFieldValidator runat=server 
                    ControlToValidate=txtYear
                    ErrorMessage="Year is required."> *
                </asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator runat=server display=dynamic
                    ControlToValidate="txtYear" 
                    ErrorMessage="Year must be 2 digits." 
                    ValidationExpression="^[0-9]{2}$" />
                <asp:TextBox ID="txtYear" runat="server" Width="37px"></asp:TextBox>
                
                
                
                <br />
                <br />
                <asp:Button ID="btnAdd" runat="server" Text="Add card" OnClick="btnAdd_Click" />
&nbsp;
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CausesValidation="False" OnClick="btnCancel_Click" UseSubmitBehavior="False" ValidateRequestMode="Disabled" />
                </form>
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
</body>
</html>
