<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Home" MasterPageFile="~/MasterPage.Master"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
        <div class="navbar-form navbar-left">
                <ul class="nav nav-pills nav-stacked">
                    <li>
                        <asp:LinkButton ID="lbArt" runat="server" OnClick="lbArt_Click">Art</asp:LinkButton>
                    </li>
                    <li>
                        <asp:LinkButton ID="lbBooks" runat="server" OnClick="lbBooks_Click">Books</asp:LinkButton>
                    </li>
                    <li>
                        <asp:LinkButton ID="lbClothes" runat="server" OnClick="lbClothes_Click">Clothes</asp:LinkButton>
                    </li>
                    <li>
                        <asp:LinkButton ID="lbCrafts" runat="server" OnClick="lbCrafts_Click">Crafts</asp:LinkButton>
                    </li>
                    <li>
                        <asp:LinkButton ID="lbElectronics" runat="server" OnClick="lbElectronics_Click">Electronics</asp:LinkButton>
                    </li>
                    <li>
                        <asp:LinkButton ID="lbHomeGarden" runat="server" OnClick="lbHomeGarden_Click">Home & Garden</asp:LinkButton>
                    </li>
                    <li>
                        <asp:LinkButton ID="lbJewelry" runat="server" OnClick="lbJewelry_Click">Jewelry</asp:LinkButton>
                    </li>
                    <li>
                        <asp:LinkButton ID="lbMusic" runat="server" OnClick="lbMusic_Click">Music</asp:LinkButton>
                    </li>
                    <li>
                        <asp:LinkButton ID="lbPetGoods" runat="server" OnClick="lbPetGoods_Click">Pet Goods</asp:LinkButton>
                    </li>
                    <li>
                        <asp:LinkButton ID="lbSportsGoods" runat="server" OnClick="lbSportsGoods_Click">Sports Goods</asp:LinkButton>
                    </li>
                    <li>
                        <asp:LinkButton ID="lbToys" runat="server" OnClick="lbToys_Click">Toys</asp:LinkButton>
                    </li>
                    <li>
                        <asp:LinkButton ID="lbVideoGames" runat="server" OnClick="lbVideoGames_Click">Video Games</asp:LinkButton>
                    </li>
                </ul>
        </div>
            <div>
                <h2><span class="newStyle1">Search Results for
                    <asp:Label ID="LabelCategory" runat="server" Text="Label"></asp:Label>
                    </span></h2>
                <div class="table-responsive">
                    <asp:PlaceHolder ID="PlaceHolderSearchResults" runat="server"></asp:PlaceHolder>
                </div>
            </div>

</asp:Content>
