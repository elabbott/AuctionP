using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

        }
    }

    protected void lbSearch_Click(object sender, EventArgs e)
    {
        var search = txtSearch.Text;
        Perform_Search(search);
    }
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
    protected void Perform_Search(string search)
    {
        HttpContext.Current.Response.Redirect("Search.aspx?search=" + search);
        //var dt = GetData(search);
        //var html = new StringBuilder();
        //html.Append("<table class=\"table\"");

        //html.Append("<tr>");

        //foreach (DataColumn column in dt.Columns)
        //{
        //    html.Append("<th>");
        //    html.Append(column.ColumnName);
        //    html.Append("</th>");
        //}
        //html.Append("</tr>");

        //foreach (DataRow row in dt.Rows)
        //{
        //    var i = 1; // this keeps track which column we are on, reference select statement in GetData() for corresponding column values
        //    var auction_id = row[5];
        //    html.Append("<tr>");
        //    foreach (DataColumn column in dt.Columns)
        //    {
        //        var columnString = row[column.ColumnName].ToString();
        //        html.Append("<td>");
        //        //if (row[column.ColumnName].ToString().Contains(".com"))
        //        if (i == 1)
        //        {
        //            html.Append("<a href='Item.aspx?id=" + auction_id + "'>" + columnString + "</a>");
        //        }
        //        if (i == 5 && CheckURLValid(columnString)) 
        //        {
        //            html.Append("<img src='" + columnString + "' width=\"275\" height=\"275\" />");
        //        }
        //        else if (i == 5 && !CheckURLValid(columnString))
        //        {
        //            html.Append("<img src =\"noimage.jpg\"");
        //        }
        //        else if (i == 6)
        //        {
        //            var lbGoToAuction = new LinkButton();
        //            lbGoToAuction.Text = "Go To Auction Page";
        //            HttpContext.Current.Session["auction_id"] = columnString;
        //            lbGoToAuction.PostBackUrl = "Items.aspx";
        //            html.Append("");
        //        }
        //        else
        //        {
        //            html.Append(columnString);
        //        }
        //        html.Append("</td>");
        //        i++;
        //    }
        //    html.Append("</tr>");
        //}
        //html.Append("</table>");

        ////PlaceHolderSearchResults.Controls.Add(new Literal { Text = html.ToString() });

        //HttpContext.Current.Session["Search_HTML"] = html;

    }
    //protected static bool CheckURLValid(string source)
    //{
    //    Uri uriResult;
    //    return Uri.TryCreate(source, UriKind.Absolute, out uriResult) && uriResult.Scheme == Uri.UriSchemeHttp;
    //}
    //private DataTable GetData(string search)
    //{
    //    var constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
    //    var dt = new DataTable();
    //    using (var con = new MySqlConnection(constr))
    //    {
    //        var cmd = new MySqlCommand("SELECT Title, Current_High_Bid as `High Bid`, Date_Format(End_Date, '%W, %M %e') as `End Date`, Description, Image_URL AS Image, Auction_Id as `Select Auction` FROM Auction WHERE Open = 1 AND (Category LIKE '%" + search + "%' OR Title LIKE '%" + search + "%')", con);

    //        using (var adapter = new MySqlDataAdapter(cmd))
    //        {
    //            adapter.Fill(dt);
    //        }
    //        cmd.Connection.Close();
    //        return dt;
    //    }
    //}
}
