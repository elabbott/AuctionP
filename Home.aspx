<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Home" MasterPageFile="~/MasterPage.Master"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">

            <div>
                <h2><span class="newStyle1">Search Results for
                    <asp:Label ID="LabelCategory" runat="server" Text="Newest 10 Auctions"></asp:Label>
                    </span></h2>
                <div class="table-responsive">
                    <asp:PlaceHolder ID="PlaceHolderSearchResults" runat="server"></asp:PlaceHolder>
                </div>
            </div>

</asp:Content>
