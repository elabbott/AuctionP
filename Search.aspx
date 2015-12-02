<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Search.aspx.cs" Inherits="Search" %>

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

        .auto-style6 {
            height: 20px;
            width: 20%;
            text-align: center;
        }

        .newStyle1 {
            font-family: Arial, Helvetica, sans-serif;
        }

        .auto-style8 {
            height: 20px;
            width: 20%;
            text-align: right;
        }

        .auto-style10 {
            text-decoration: underline;
        }

        .auto-style12 {
            text-decoration: underline;
            color: #0000FF;
            background-color: #FFFFFF;
        }

        .auto-style13 {
            color: #0000FF;
            background-color: #FFFFFF;
        }

        </style>
    <link href="Content/bootstrap-theme.css" rel="stylesheet" />
    <link href="Content/bootstrap-theme.min.css" rel="stylesheet" />
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <header>
            <nav class="navbar navbar-default">
                <div class="container-fluid">
                    <div class="navbar-header">
                        <img class="navbar-brand" src="AuctionPowers.jpg"/>
                    </div>
                    <div class="navbar-right">
                        <asp:LoginName ID="LoginName1" runat="server" Font-Bold = "true" />
                        <asp:LoginStatus ID="LoginStatus1" runat="server" />
                    </div>
                    <div>
                        <ul class="nav navbar-nav">
                            <li class="active"><a href="Home.aspx">Home</a></li>
                            <li><a href="Search.aspx">Search</a></li>
                            <li><a href="User.aspx">My Account</a></li>
                            <li>
                                <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox></li>
                            <li>
                                <asp:LinkButton ID="lbSearch" CssClass="btn btn-default" runat="server" OnClick="lbSearch_Click">Search</asp:LinkButton></li>
                        </ul>
                    </div>
                </div>
            </nav>
        </header>
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
        </form>
    <script src="Scripts/bootstrap.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="Scripts/jquery-1.9.1.js"></script>
    <script src="Scripts/jquery-1.9.1.intellisense.js"></script>
    <script src="Scripts/jquery-1.9.1.min.js"></script>
</body>
</html>
