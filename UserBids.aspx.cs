﻿using MySql.Data.MySqlClient;
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

public partial class UserBids : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.User.Identity.IsAuthenticated)
        {
            FormsAuthentication.RedirectToLoginPage();
        }
        
        String option = Request.QueryString["opt"];
        int open = 1;
        if ((option != null) && (option.Equals("won")))
        {
            open = 0;
        }
        Load_Auctions(open);
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
    protected void Load_Auctions(int open)
    {
        var user_id = Get_Authenticated_User_ID();
        var dt = GetDataForAuctions(open);
        var html = new StringBuilder();
        html.Append("<table class=\"table\"");

        html.Append("<tr>");

        var i = 1;
        foreach (DataColumn column in dt.Columns)
        {
            if (i < 7)
            {
                html.Append("<th>");
                html.Append(column.ColumnName);
                html.Append("</th>");
            }
            i++;
        }
        html.Append("</tr>");

        foreach (DataRow row in dt.Rows)
        {
            i = 1; // this keeps track which column we are on, reference select statement in GetData() for corresponding column values
            html.Append("<tr>");
            foreach (DataColumn column in dt.Columns)
            {
                var columnString = row[column.ColumnName].ToString();
                html.Append("<td>");
                if (i == 1)
                {
                    html.Append("<a href='Item.aspx?id=" + row[6].ToString() + "'>" + columnString + "</a>");
                }
                else if(i == 4)
                {
                    html.Append(String.Format("{0:C}", row[3]));
                }
                else if(i == 5)
                {
                    html.Append(String.Format("{0:C}", row[4]));
                }
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
                else if (i < 7)
                {
                    html.Append(columnString);
                    html.Append("</td>");
                }
                i++;
            }
            html.Append("</tr>");
        }
        html.Append("</table>");

        PlaceHolderUserBids.Controls.Add(new Literal { Text = html.ToString() });

    }
    protected static bool CheckURLValid(string source)
    {
        Uri uriResult;
        return Uri.TryCreate(source, UriKind.Absolute, out uriResult) && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
    }
    protected DataTable GetDataForAuctions(int open)
    {
        var constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        var dt = new DataTable();
        using (var con = new MySqlConnection(constr))
        {
            var user_id = Get_Authenticated_User_ID();
            var cmd = new MySqlCommand("SELECT Title, Category, Description, Current_High_Bid, Buyout, End_Date, Auction_Id FROM Auction WHERE Open=@open AND User_Id_High_Bid = '" + user_id + "'", con);
            cmd.Parameters.AddWithValue("@open", open);
            using (var adapter = new MySqlDataAdapter(cmd))
            {
                adapter.Fill(dt);
            }
            cmd.Connection.Close();
            return dt;
        }
    }
}