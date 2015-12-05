<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddCard.aspx.cs" Inherits="AddCard" MasterPageFile="~/MasterPage.Master"%>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style type="text/css">
        .auto-style25 {
            width: 4px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
    <table style="width:100%;">
        <tr>
            <td class="auto-style6">
                
            </td>
            <td class="auto-style2">
               
            </td>
            <td class="auto-style8">
                <div>
               
                </div>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">
                
                <br />
                <hr />
                <br />
                </td>
            <td class="auto-style4">
                <asp:ValidationSummary runat="server" 
                    HeaderText="There were errors on the page:" ForeColor="Red" />
                <table>
                    <tr>
                        <td>Name:</td>
                        <td><asp:RequiredFieldValidator runat="server" ControlToValidate="txtName" ErrorMessage="Name is required." ForeColor="Red" ID="validatorName"> *
                </asp:RequiredFieldValidator><asp:TextBox ID="txtName" runat="server" CausesValidation="True"></asp:TextBox></td>
                    </tr>
                    </table>
                <div>
                    <br />
                </div>
                <table>
                    <tr>
                        <td>Number:</td>
                        <td><asp:RequiredFieldValidator runat="server" ControlToValidate="txtNum" ErrorMessage="Valid card number is required." ForeColor="Red" ID="validatorNum"> *
                </asp:RequiredFieldValidator>
                <asp:TextBox ID="txtNum" runat="server" CausesValidation="True" MaxLength="16"></asp:TextBox></td>
                    </tr>
                </table>
                <div>
                    <br />
                </div>
                    <table>
                    <tr>
                        <td>CCV #:</td>
                        <td><asp:RequiredFieldValidator runat="server" ControlToValidate="txtCCV" ErrorMessage="Valid CCV is required." ForeColor="Red" ID="validatorCCV"> *
                </asp:RequiredFieldValidator>
                <asp:TextBox ID="txtCCV" MaxLength="3" runat="server" Width="47px" CausesValidation="True"></asp:TextBox></td>
                    </tr>
                    </table>
                <table>
                    <tr>
                        <td>
                            Expiration date: <asp:RequiredFieldValidator ID="validatorMonth" runat="server" ErrorMessage="Valid expiration month required" ControlToValidate="ddListMonth" ForeColor="Red">*</asp:RequiredFieldValidator>
                            <asp:DropDownList ID="ddListMonth" runat="server">
                                <asp:ListItem>1</asp:ListItem>
                                <asp:ListItem>2</asp:ListItem>
                                <asp:ListItem>3</asp:ListItem>
                                <asp:ListItem>4</asp:ListItem>
                                <asp:ListItem>5</asp:ListItem>
                                <asp:ListItem>6</asp:ListItem>
                                <asp:ListItem>7</asp:ListItem>
                                <asp:ListItem>8</asp:ListItem>
                                <asp:ListItem>9</asp:ListItem>
                                <asp:ListItem>10</asp:ListItem>
                                <asp:ListItem>11</asp:ListItem>
                                <asp:ListItem>12</asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="validatorYear" runat="server" ErrorMessage="Expiration year required" ControlToValidate="ddListYear" ForeColor="Red">*</asp:RequiredFieldValidator>
                            <asp:DropDownList ID="ddListYear" runat="server"></asp:DropDownList>
                        </td>
                    </tr>
                </table>
                &nbsp;<div>
                    <br />
                </div>
                <asp:Button CssClass="btn btn-default" ID="btnAdd" runat="server" Text="Add card" OnClick="btnAdd_Click" />
&nbsp;
                <asp:Button CssClass="btn btn-default" ID="btnCancel" runat="server" Text="Cancel" CausesValidation="False" OnClick="btnCancel_Click" UseSubmitBehavior="False" ValidateRequestMode="Disabled" />
                
            </td>
            <td class="auto-style18">
                <br />
                <br />
            </td>
        </tr>
        </table>
</asp:Content>
