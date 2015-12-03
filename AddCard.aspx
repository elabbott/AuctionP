<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddCard.aspx.cs" Inherits="AddCard" MasterPageFile="~/MasterPage.Master"%>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

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
                        <td><asp:RequiredFieldValidator runat="server" ControlToValidate="txtName" ErrorMessage="Name is required." ForeColor="Red"> *
                </asp:RequiredFieldValidator><asp:TextBox ID="txtName" runat="server" CausesValidation="True"></asp:TextBox></td>
                    </tr>
                    </table>
                <div>
                    <br />
                </div>
                <table>
                    <tr>
                        <td>Number:</td>
                        <td><asp:RequiredFieldValidator runat="server" ControlToValidate="txtNum" ErrorMessage="Number is required." ForeColor="Red"> *
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
                        <td><asp:RequiredFieldValidator runat="server" ControlToValidate="txtCCV" ErrorMessage="CCV is required." ForeColor="Red"> *
                </asp:RequiredFieldValidator>
                <asp:TextBox ID="txtCCV" MaxLength="4" runat="server" Width="47px" CausesValidation="True"></asp:TextBox></td>
                    </tr>
                    </table>
                <div>
                    <br />
                </div>
                <table>
                    <tr>
                        <td>Expiration date: </td>
                        <td><input type="text" id="datepicker" runat="server"/></td>
                    </tr>
                </table>
                <div>
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
