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
    protected void Perform_Search(string search)
    {
        var dt = GetData(search);
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
            var i = 1; // this keeps track which column we are on, reference select statement in GetData() for corresponding column values
            html.Append("<tr>");
            foreach (DataColumn column in dt.Columns)
            {
                var columnString = row[column.ColumnName].ToString();
                html.Append("<td>");
                //if (row[column.ColumnName].ToString().Contains(".com"))
                if (i == 5 && CheckURLValid(columnString)) //column value check for fifth column <may be unnessarry> and then checks if link is valid url
                {
                    html.Append("<img src='" + columnString + "'/>");
                }
                else if (i == 5 && !CheckURLValid(columnString))
                {
                    html.Append("<img src =\"noimage.jpg\"");
                }
                else if (i == 6)
                {
                    var lbGoToAuction = new LinkButton();
                    lbGoToAuction.Text = "Go To Auction Page";
                    HttpContext.Current.Session["auction_id"] = columnString;
                    lbGoToAuction.PostBackUrl = "Items.aspx";
                    html.Append("");
                }
                else
                {
                    html.Append(columnString);
                }
                html.Append("</td>");
                i++;
            }
            html.Append("</tr>");
        }
        html.Append("</table>");

        //PlaceHolderSearchResults.Controls.Add(new Literal { Text = html.ToString() });

        HttpContext.Current.Session["Search_HTML"] = html;
        HttpContext.Current.Response.Redirect("Search.aspx");
    }
    public static bool CheckURLValid(string source)
    {
        Uri uriResult;
        return Uri.TryCreate(source, UriKind.Absolute, out uriResult) && uriResult.Scheme == Uri.UriSchemeHttp;
    }
    private DataTable GetData(string search)
    {
        var constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        using (var con = new MySqlConnection(constr))
        {
            var cmd = new MySqlCommand("SELECT Title, Current_High_Bid as `High Bid`, Date_Format(End_Date, '%W, %M %e') as `End Date`, Description, Image_URL AS Image, Auction_Id FROM Auction WHERE Open = 1 AND (Category LIKE '%" + search + "%' OR Title LIKE '%" + search + "%')", con);

            var adapter = new MySqlDataAdapter(cmd);

            var dt = new DataTable();

            adapter.Fill(dt);
            return dt;
        }
    }
}
