using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserAuctions : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.User.Identity.IsAuthenticated)
        {
            FormsAuthentication.RedirectToLoginPage();
        }
        Load_Auctions();
    }

    //protected void Load_Auctions2()
    //{
    //    var constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
    //    using (var con = new MySqlConnection(constr))
    //    {
    //        var user_id = Get_Authenticated_User_ID();

    //        var cmd = new MySqlCommand("SELECT Auction_ID, User_Id_Owner, User_Id_High_Bid, Current_High_Bid, Min_Bid, Buyout, Open, Create_Date, End_Date, Description, Image_URL, Category, Title FROM Auction WHERE User_Id_Owner = '" + user_id + "'", con);

    //        var adapter = new MySqlDataAdapter(cmd);

    //        var dt = new DataTable();

    //        adapter.Fill(dt);

    //        gvAuctions.DataSource = dt;

    //        gvAuctions.DataBind();

    //        cmd.Connection.Close();

    //    }
    //}
    protected int Get_Authenticated_User_ID()
    {
        var user_id = 0;
        var username = HttpContext.Current.User.Identity.Name;

        var constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        using (var con = new MySqlConnection(constr))
        {
            var cmd = new MySqlCommand("SELECT user_id FROM auction_powers.User WHERE username = '" + username + "'", con);
            cmd.Connection.Open();

            var id_of_user = cmd.ExecuteScalar();

            //user_id = id_of_user.GetInt32(0);
            if (id_of_user != null && id_of_user != DBNull.Value)
            {
                user_id = (int)id_of_user;
            }

            cmd.Connection.Close();
        }

        return user_id;
    }
    protected void Load_Auctions()
    {
        var user_id = Get_Authenticated_User_ID();
        var dt = GetDataForAuctions();
        var html = new StringBuilder();
        html.Append("<table class=\"table\"");

        html.Append("<tr>");

        foreach (DataColumn column in dt.Columns)
        {
            html.Append("<th>");
            html.Append(column.ColumnName);
            html.Append("</th>");
        }
        html.Append("</tr>");

        foreach (DataRow row in dt.Rows)
        {
            //var i = 1; // this keeps track which column we are on, reference select statement in GetData() for corresponding column values
            html.Append("<tr>");
            foreach (DataColumn column in dt.Columns)
            {
                var columnString = row[column.ColumnName].ToString();
                html.Append("<td>");
                //if (row[column.ColumnName].ToString().Contains(".com"))
                //if (i == 5 && CheckURLValid(columnString)) //column value check for fifth column <may be unnessarry> and then checks if link is valid url
                //{
                //    html.Append("<img src='" + columnString + "'/>");
                //}
                //else if (i == 5 && !CheckURLValid(columnString))
                //{
                //    html.Append("<img src =\"noimage.jpg\"");
                //}
                //else if (i == 6)
                //{
                //    var lbGoToAuction = new LinkButton();
                //    lbGoToAuction.Text = "Go To Auction Page";
                //    HttpContext.Current.Session["auction_id"] = columnString;
                //    lbGoToAuction.PostBackUrl = "Items.aspx";
                //    html.Append("");
                //}
                //else
                //{
                html.Append(columnString);
                //}
                html.Append("</td>");
                //i++;
            }
            html.Append("</tr>");
        }
        html.Append("</table>");

        PlaceHolderUserAuctions.Controls.Add(new Literal { Text = html.ToString() });

    }
    protected static bool CheckURLValid(string source)
    {
        Uri uriResult;
        return Uri.TryCreate(source, UriKind.Absolute, out uriResult) && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
    }
    protected DataTable GetDataForAuctions()
    {
        var constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        var dt = new DataTable();
        using (var con = new MySqlConnection(constr))
        {
            var user_id = Get_Authenticated_User_ID();

            var cmd = new MySqlCommand("SELECT Auction_ID, User_Id_Owner, User_Id_High_Bid, Current_High_Bid, Min_Bid, Buyout, Open, Create_Date, End_Date, Description, Category, Title FROM Auction WHERE User_Id_Owner = '" + user_id + "'", con);

            using (var adapter = new MySqlDataAdapter(cmd))
            {
                adapter.Fill(dt);
            }
            cmd.Connection.Close();
            return dt;
        }
    }
}