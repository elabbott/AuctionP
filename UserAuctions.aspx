<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserAuctions.aspx.cs" Inherits="UserAuctions" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <header>
            <nav class="navbar navbar-default">
                <div class="container-fluid">
                    <div class="navbar-header">
                        <img class="navbar-brand" src="AuctionPowers.jpg"/>
                    </div>
                    <div>
                        <ul class="nav navbar-nav">
                            <li class="active"><a href="Home.aspx">Home</a></li>
                            <li><a href="Search.aspx">Search</a></li>
                            <li><a href="User.aspx">User.aspx</a></li>
                            <li>
                                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></li>
                            <li>
                                <asp:LinkButton ID="lbSearch" CssClass="btn btn-primary" runat="server" OnClick="lbSearch_Click">Search</asp:LinkButton></li>
                        </ul>
                    </div>
                </div>
            </nav>
        </header>
    <div>
        <asp:GridView ID="gvAuctions" runat="server"></asp:GridView>
    </div>
    </form>
</body>
</html>
