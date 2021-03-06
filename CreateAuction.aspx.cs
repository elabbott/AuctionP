﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;

public partial class CreateAuction : System.Web.UI.Page
{
    private string category;
    private string title;
    private string imageURL;
    private string description;
    private DateTime end_date;
    private double? min_bid;
    private double? buyout;
    private string username;
    private int user_id;
    private int auction_id;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.User.Identity.IsAuthenticated)
        {
            FormsAuthentication.RedirectToLoginPage();
        }
        username = HttpContext.Current.User.Identity.Name;
        string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        using (MySqlConnection con = new MySqlConnection(constr))
        {
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT User_Id FROM User WHERE Username=@name";
                cmd.Parameters.AddWithValue("@name", username);
                cmd.Connection = con;
                con.Open();
                user_id = Convert.ToInt32(cmd.ExecuteScalar());
                con.Close();
            }
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("User.aspx");
    }

    protected void btnCreate_Click(object sender, EventArgs e)
    {
        category = ddListCategory.SelectedValue;
        title = txtTitle.Text.Trim();
        imageURL = txtImage.Text.Trim();
        if(!checkImgURL(imageURL))
        {
            txtImage.Text = "Invalid image URL";
            RegularExpressionValidatorImgURL.IsValid = false;
        }
        if (Page.IsValid)
        {
            description = txtDescription.Text.Trim();
            DateTime now = DateTime.Now;
            int days = int.Parse(ddListDuration.SelectedValue);
            TimeSpan duration = new System.TimeSpan(days, 0, 0, 0);
            end_date = now.Add(duration);

            if (txtMinBid.Text != String.Empty)
            {
                min_bid = double.Parse(txtMinBid.Text.Trim());
            }
            else
            {
                min_bid = 0.01;
            }

            if (txtBuyout.Text != String.Empty)
            {
                buyout = double.Parse(txtBuyout.Text);
            }
            else
            {
                buyout = null;
            }
            createAuction();
            //Session["auction_id"] = auction_id;
            Response.Redirect("Item.aspx?id=" + Convert.ToString(auction_id));
        }
    }

    protected void createAuction()
    {
        string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        using (MySqlConnection con = new MySqlConnection(constr))
        {
            using (MySqlCommand cmd = new MySqlCommand("New_Auction"))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("OwnerID", user_id);
                cmd.Parameters.AddWithValue("MinBid", min_bid);
                cmd.Parameters.AddWithValue("Buyout", buyout);
                cmd.Parameters.AddWithValue("EndDate", end_date);
                cmd.Parameters.AddWithValue("Description", description);
                cmd.Parameters.AddWithValue("Image", imageURL);
                cmd.Parameters.AddWithValue("ItemCategory", category);
                cmd.Parameters.AddWithValue("ItemTitle", title);
                con.Open();
                auction_id = Convert.ToInt32(cmd.ExecuteScalar());
                con.Close();
            }
        }
    }

    private bool checkImgURL(string url)
    {
        HttpWebResponse response = null;
        var request = (HttpWebRequest)WebRequest.Create(url);
        bool result = true;
        try
        {
            response = (HttpWebResponse)request.GetResponse();
        }
        catch (WebException)
        {
            return false;
        }
        finally
        {
            if (response != null)
            {
                response.Close();
            }
        }
        return result;
    }
}