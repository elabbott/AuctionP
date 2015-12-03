﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Search : System.Web.UI.Page
{
    private string search_html;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {
            try
            {
                search_html = HttpContext.Current.Session["Search_HTML"].ToString();
                Load_Search(search_html);
            }
            catch(NullReferenceException)
            {
                All();
            }
        }
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
        LabelCategory.Text = "All";
        //var all = "%";
        Load_Search("");

    }
    //protected void Load_Search1(string search)
    //{
    //    var constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
    //    using (var con = new MySqlConnection(constr))
    //    {
    //        var cmd = new MySqlCommand("SELECT Title, Current_High_Bid as High, Date_Format(End_Date, '%W, %M %e') as Date, Description, Image_URL FROM Auction WHERE Category Like '" + search + "'", con);

    //        var adapter = new MySqlDataAdapter(cmd);

    //        var dt = new DataTable();

    //        adapter.Fill(dt);

    //        GridView1.DataSource = dt;

    //        GridView1.DataBind();

    //        cmd.Connection.Close();
    //    }
    //}
    protected void Load_Search(string search)
    {
        var dt = GetData(search);
        var html = new StringBuilder();
        html.Append("<table class=\"table\"");

        html.Append("<tr>");

        foreach(DataColumn column in dt.Columns)
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
            foreach(DataColumn column in dt.Columns)
            {
                var columnString = row[column.ColumnName].ToString();
                html.Append("<td>");
                //if (row[column.ColumnName].ToString().Contains(".com"))
                if (i == 5 && CheckURLValid(columnString)) //column value check for fifth column <may be unnessarry> and then checks if link is valid url
                {
                    html.Append("<img src='" + columnString + "' width=\"275\" height=\"275\" />");
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

        PlaceHolderSearchResults.Controls.Add(new Literal { Text = html.ToString() });
    }
    
    private DataTable GetData(string search)
    {
        var constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        var dt = new DataTable();
        using (var con = new MySqlConnection(constr))
        {
            var cmd = new MySqlCommand("SELECT Title, Current_High_Bid as `High Bid`, Date_Format(End_Date, '%W, %M %e') as `End Date`, Description, Image_URL AS Image, Auction_Id as `Select Auction` FROM Auction WHERE Open = 1 AND (Category LIKE '%" + search + "%' OR Title LIKE '%" + search + "%')", con);

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