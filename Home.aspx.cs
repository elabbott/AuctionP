﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Data;
using System.Text;

public partial class Home : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        /*if (!this.Page.User.Identity.IsAuthenticated)
        {
            FormsAuthentication.RedirectToLoginPage();

        }*/
        if (!Page.IsPostBack)
        {
            try
            {
                //search_html = HttpContext.Current.Session["Search_HTML"].ToString();
                var search_string = Request.QueryString["search"].ToString();
                if (!String.IsNullOrEmpty(search_string))
                {
                    LabelCategory.Text = search_string;
                    Load_Search(search_string);
                }
                else
                {
                    All();
                }
            }
            catch (NullReferenceException)
            {
                All();
            }
        }
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

    protected void lbArt_Click(object sender, EventArgs e)
    {
        LabelCategory.Text = lbArt.Text;
        Load_Search(LabelCategory.Text);
    }

    protected void lbBooks_Click(object sender, EventArgs e)
    {
        LabelCategory.Text = lbBooks.Text;
        Load_Search(LabelCategory.Text);
    }

    protected void lbClothes_Click(object sender, EventArgs e)
    {
        LabelCategory.Text = lbClothes.Text;
        Load_Search(LabelCategory.Text);
    }

    protected void lbCrafts_Click(object sender, EventArgs e)
    {
        LabelCategory.Text = lbCrafts.Text;
        Load_Search(LabelCategory.Text);
    }

    protected void lbElectronics_Click(object sender, EventArgs e)
    {
        LabelCategory.Text = lbElectronics.Text;
        Load_Search(LabelCategory.Text);
    }

    protected void lbHomeGarden_Click(object sender, EventArgs e)
    {
        LabelCategory.Text = lbHomeGarden.Text;
        Load_Search(LabelCategory.Text);
    }

    protected void lbJewelry_Click(object sender, EventArgs e)
    {
        LabelCategory.Text = lbJewelry.Text;
        Load_Search(LabelCategory.Text);
    }

    protected void lbMusic_Click(object sender, EventArgs e)
    {
        LabelCategory.Text = lbMusic.Text;
        Load_Search(LabelCategory.Text);
    }

    protected void lbPetGoods_Click(object sender, EventArgs e)
    {
        LabelCategory.Text = lbPetGoods.Text;
        Load_Search(LabelCategory.Text);
    }

    protected void lbSportsGoods_Click(object sender, EventArgs e)
    {
        LabelCategory.Text = lbSportsGoods.Text;
        Load_Search(LabelCategory.Text);
    }

    protected void lbToys_Click(object sender, EventArgs e)
    {
        LabelCategory.Text = lbToys.Text;
        Load_Search(LabelCategory.Text);
    }

    protected void lbVideoGames_Click(object sender, EventArgs e)
    {
        LabelCategory.Text = lbVideoGames.Text;
        Load_Search(LabelCategory.Text);
    }
    protected void All()
    {
        LabelCategory.Text = "10 Most recent items";
        //var all = "%";
        Load_Search("recent");

    }

    protected void Load_Search(string search)
    {
        var dt = new DataTable();
        if (search.Equals("recent"))
        { 
            dt = GetRecentAuctions();
        }
        else
        {
            dt = GetData(search);
        }
        var html = new StringBuilder();
        html.Append("<table class=\"table\"");

        html.Append("<tr>");
        int i = 1;
        foreach (DataColumn column in dt.Columns)
        {
            if (i < 5)
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
            var auction_id = row[5];
            html.Append("<tr>");
            foreach (DataColumn column in dt.Columns)
            {
                var columnString = row[column.ColumnName].ToString();
                html.Append("<td>");
                //if (row[column.ColumnName].ToString().Contains(".com"))
                if (i == 1)
                {
                    html.Append("<a href='Item.aspx?id=" + auction_id + "'>" + columnString + "</a>");
                }
                else if(i==2)
                {
                    html.Append(String.Format("{0:C}", row[column.ColumnName]));
                }
                else if (i == 5 && CheckURLValid(columnString)) //column value check for fifth column <may be unnessarry> and then checks if link is valid url
                {
                    html.Append("<img src='" + columnString + "' width=\"275\" height=\"275\" />");
                }
                else if (i == 5 && !CheckURLValid(columnString))
                {
                    html.Append("<img src =\"noimage.jpg\"");
                }
                else if (i < 5)
                {
                    html.Append(columnString);
                }
                html.Append("</td>");
                i++;
            }
            html.Append("</tr>");
        }
        html.Append("</table>");

        PlaceHolderSearchResults.Controls.Add(new Literal { Text = html.ToString() });
    }

    private DataTable GetRecentAuctions()
    {
        var constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        var dt = new DataTable();
        using (var con = new MySqlConnection(constr))
        {
            var cmd = new MySqlCommand("SELECT Title, Current_High_Bid as `High Bid`, Date_Format(End_Date, '%W, %M %e') as `End Date`, Description, Image_URL AS Image, Auction_Id as `Select Auction` FROM Auction WHERE Open = 1 ORDER BY Create_Date DESC LIMIT 10", con);

            using (var adapter = new MySqlDataAdapter(cmd))
            {
                adapter.Fill(dt);
            }
            cmd.Connection.Close();
            return dt;
        }
    }

    private DataTable GetData(string search)
    {
        var constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        var dt = new DataTable();
        using (var con = new MySqlConnection(constr))
        {
            var cmd = new MySqlCommand("SELECT Title, Current_High_Bid as `High Bid`, Date_Format(End_Date, '%W, %M %e') as `End Date`, Description, Image_URL AS Image, Auction_Id as `Select Auction` FROM Auction WHERE Open = 1 AND (Category LIKE '" + search + "%' OR Title LIKE '" + search + "%')", con);

            using (var adapter = new MySqlDataAdapter(cmd))
            {
                adapter.Fill(dt);
            }
            cmd.Connection.Close();
            return dt;
        }
    }
    public static bool CheckURLValid(string source)
    {
        Uri uriResult;
        return Uri.TryCreate(source, UriKind.Absolute, out uriResult) && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
    }
}