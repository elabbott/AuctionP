﻿using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Net.Mail;
using System.Net;

public partial class Item : System.Web.UI.Page
{
    private int auction_id; //this value needs to be passed through the session
    private int user_id;
    private string username;
    private int user_id_owner;
    private int user_id_high_bid;
    private double current_high_bid;
    private double min_bid;
    private double buyout;
    private double bidderAvailableBalance;
    private bool open;
    private DateTime create_date;
    private DateTime end_date;
    private string description;
    private string image_url;
    //private User owner;
    private string title;
    private string category;
    //private Auction item;
    string item_url;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (loggedIn())
        {
            username = HttpContext.Current.User.Identity.Name;
            user_id = getUserId();
        }
        auction_id = Convert.ToInt32(Request.QueryString["id"]);
        item_url = Request.Url.AbsoluteUri;
        //auction_id = Convert.ToInt32(Session["auction_id"]);
        //Auction item = new Auction(auction_id, owner, min_bid, buyout, end_date, description, image_url, title, category);
        //var item = new Auction(auction_id, owner, min_bid, buyout, end_date, description, image_url, title, category);
        var item = Load_Auction(auction_id);
        item.Top_bid = current_high_bid;
        updateStats();
        showControls();
        
        imgItem.ImageUrl = image_url;
        lblTitle.Text = title;
        lblDescription.Text = description;
        
    }
    public void bid(double amount, int bidder_id)
    {
        if ((user_id != user_id_high_bid) && (user_id_high_bid != 0))
        {
            notifyBidderAboutOutbid();
        }
        int result;
        string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        using (MySqlConnection con = new MySqlConnection(constr))
        {
            updatePreviousHighBidder();
            //perform bid
            using (MySqlCommand cmd = new MySqlCommand("Bid"))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("Amount", amount);
                cmd.Parameters.AddWithValue("AuctionID", auction_id);
                cmd.Parameters.AddWithValue("BidderID", bidder_id);
                con.Open();
                result = Convert.ToInt32(cmd.ExecuteScalar());
                con.Close();
            }
            //update current bidder available balance
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;
                cmd.CommandText = "UPDATE User SET Available_Balance=Available_Balance-@amount WHERE User_Id=@user";
                cmd.Parameters.AddWithValue("@amount", amount);
                cmd.Parameters.AddWithValue("@user", bidder_id);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        //return result;
    }

    private void endAuction()
    {
        //update DB
        string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        using (MySqlConnection con = new MySqlConnection(constr))
        {
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE Auction SET Open=0, User_Id_High_Bid=@user, Current_High_Bid=@bid WHERE Auction_Id=@id";
                cmd.Parameters.AddWithValue("@id", auction_id);
                cmd.Parameters.AddWithValue("@user", user_id_high_bid);
                cmd.Parameters.AddWithValue("@bid", current_high_bid);
                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        notifySeller();
        notifyWinner();
        doTransactions();
    }

    private void doTransactions()
    {
        double amount = current_high_bid;

        string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        using (MySqlConnection con = new MySqlConnection(constr))
        {
            //update Seller balance
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE User SET Balance=Balance+@amount, Available_Balance=Available_Balance+@amount WHERE User_Id=@user";
                cmd.Parameters.AddWithValue("@amount", amount);
                cmd.Parameters.AddWithValue("@user", user_id_owner);
                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

            //update Buyer balance
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE User SET Balance=Balance-@amount, Available_Balance=Available_Balance-@amount WHERE User_Id=@user";
                cmd.Parameters.AddWithValue("@amount", amount);
                cmd.Parameters.AddWithValue("@user", user_id_high_bid);
                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }

    private void notifyWinner()
    {
        var constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        using (var con = new MySqlConnection(constr))
        {
            var cmd = new MySqlCommand("SELECT Email FROM User WHERE User_Id = " + user_id_high_bid, con);
            cmd.Connection.Open();

            object dbNullTesterObject;
            var winner = cmd.ExecuteScalar();
            var winner_email = winner.ToString();
            cmd.Connection.Close();
            var message = "<br /><br />You won the auction of " + title + "!<br /><br /><a href='" + item_url + "'>Link to item</a>";
            var subject = "Auction Won!";
            Send_Email(message, winner_email, subject);
        }
    }
    private void notifySeller()
    {
        var constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        using (var con = new MySqlConnection(constr))
        {
            var cmd = new MySqlCommand("SELECT Email FROM User WHERE User_Id = " + user_id_owner, con);
            cmd.Connection.Open();

            object dbNullTesterObject;
            var owner = cmd.ExecuteScalar();
            var owner_email = owner.ToString();
            cmd.Connection.Close();
            var message = "<br /><br />Your auction of " + title + " has been won for " + current_high_bid + "!<br /><br /><a href='" + item_url + "'>Link to item</a>";
            var subject = "Auction Over!";
            Send_Email(message, owner_email, subject);
        }
    }

    private void notifyBidderAboutOutbid()
    {
        var constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        using (var con = new MySqlConnection(constr))
        {
            var cmd = new MySqlCommand("SELECT Email FROM User WHERE User_Id = " + user_id_high_bid, con);
            cmd.Connection.Open();

            object dbNullTesterObject;
            var loser = cmd.ExecuteScalar();
            var loser_email = loser.ToString();
            cmd.Connection.Close();
            if (!String.IsNullOrEmpty(loser_email)) { 
            var message = "<br /><br />You have been outbid! <br /><br />Auction: " + title + "<br /><br /><a href='" + item_url + "'>Link to page.</a>";
            var subject = "Currently Outbid!";
            Send_Email(message, loser_email, subject);
            }
        }
    }

    private void Send_Email(string message, string sendTo, string subject)
    {
        using (MailMessage mm = new MailMessage("auctionpowers2015fall@gmail.com", sendTo))
        {
            mm.Subject = subject;
            string body = "Hello " + sendTo + ",";
            body += message;
            mm.Body = body;
            mm.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.EnableSsl = true;
            NetworkCredential NetworkCred = new NetworkCredential("auctionpowers2015fall@gmail.com", "auctionp1");
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = NetworkCred;
            smtp.Port = 587;
            smtp.Send(mm);
        }
    }
    private Auction Load_Auction(int auction_id)
    {
        var constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        using (var con = new MySqlConnection(constr))
        {
            var cmd = new MySqlCommand("SELECT Auction_Id, User_Id_Owner, User_Id_High_Bid, Current_High_Bid, Min_Bid, Buyout, Open, Create_Date, End_Date, Description, Image_URL, Category, Title FROM `auction_powers`.`Auction` WHERE Auction_ID = " + auction_id, con);
            cmd.Connection.Open();

            var auction = cmd.ExecuteReader();
            //user_id = id_of_user.GetInt32(0);
            object dbNullTesterObject;

            if (auction.Read())
            {
                user_id_owner = (int)auction["User_Id_Owner"];
                dbNullTesterObject = auction["User_Id_High_Bid"];
                user_id_high_bid = dbNullTesterObject == DBNull.Value ? 0 : Convert.ToInt32(dbNullTesterObject);
                //user_id_high_bid = (int)auction["User_Id_High_Bid"];
                dbNullTesterObject = auction["Current_High_Bid"];
                current_high_bid = dbNullTesterObject == DBNull.Value ? 0 : Convert.ToDouble(dbNullTesterObject);
                //current_high_bid = (Double)auction["Current_High_Bid"];
                min_bid = (Double)auction["Min_Bid"];
                dbNullTesterObject = auction["Buyout"];
                buyout = dbNullTesterObject == DBNull.Value ? 0 : Convert.ToDouble(dbNullTesterObject);
                //buyout = (Double)auction["Buyout"];
                open = (Boolean)auction["Open"];
                create_date = (DateTime)auction["Create_Date"] - new TimeSpan(5, 0, 0);
                end_date = (DateTime)auction["End_Date"];
                description = (string)auction["Description"];
                image_url = (string)auction["Image_URL"];
                category = (string)auction["Category"];
                title = (string)auction["Title"];
            }
            cmd.Connection.Close();
            Auction item = new Auction(auction_id, user_id_owner, min_bid, buyout, end_date, description, image_url, title, category);
            return item;
        }
    }

    protected void btnBuyOut_Click(object sender, EventArgs e)
    {
        buyOut();
        Response.Redirect("Item.aspx?id=" + auction_id);
    }

    private void buyOut()
    {
        updatePreviousHighBidder();
        current_high_bid = buyout;
        user_id_high_bid = user_id;
        endAuction();
    }

    protected void btnBid_Click(object sender, EventArgs e)
    {
        double amount = Convert.ToDouble(txtAmount.Text);

        bid(amount, user_id);
        //notifyBidders();
        Response.Redirect("Item.aspx?id=" + auction_id);
    }

    private bool isActive()
    {
        return ((open) && (end_date > DateTime.Now));
    }

    private void updateStats()
    {
        if (isActive())
        {
            if (current_high_bid > 0)
            {
                min_bid = current_high_bid + 0.01;
            }
            if (loggedIn())
            {
                if (user_id != user_id_owner)
                {
                    bidderAvailableBalance = getBidderAvailableBalance();
                }
            }
        }
        else
        {
            open = false;
        }
    }

    private void showBidControls(bool show)
    {
        if (show)
        {
            CompareValidator1.ValueToCompare = Convert.ToString(min_bid);
            CompareValidatorAvailableBalance.ValueToCompare = Convert.ToString(bidderAvailableBalance);
        }
        lblBidAmount.Text = "Bid amount: $";
        lblBidAmount.Visible = show;
        txtAmount.Enabled = show;
        txtAmount.Visible = show;
        btnBid.Enabled = show;
        btnBid.Visible = show;
    }

    private void showBuyOutControls(bool show)
    {
        if (show)
        {
            lblBuyOut.Text = "Or Buy Now for " + String.Format("{0:C}", buyout);
        }
        lblBuyOut.Enabled = show;
        lblBuyOut.Visible = show;
        btnBuyOut.Enabled = (bidderAvailableBalance >= buyout ? true : false);
        btnBuyOut.Visible = show;
    }

    private void showControls()
    {
        bool show_buyout = (isActive() && loggedIn() && (user_id != user_id_owner) && (buyout > 0));
        bool show_bid = (isActive() && loggedIn() && (user_id != user_id_owner));
        bool show_login_msg = (isActive() && !loggedIn() && (user_id != user_id_high_bid));
        if(show_login_msg)
        {
            lblLogIn.Text = "Please login to bid on item";
        }
        if (isActive())
        {
            TimeSpan left = new TimeSpan();
            left = end_date - DateTime.Now;
            lblTimeleft.Text = "Time left: " + left.Days + " days " + left.Hours + " hours " + left.Minutes + " minutes";
        }
        else
        {
            lblTimeleft.Text = "Auction ended.";
        }
        lblNextMinBid.Visible = isActive();
        showBidControls(show_bid);
        showBuyOutControls(show_buyout);
        lblHighBid.Text = String.Format("{0:C}", current_high_bid);
        lblNextMinBid.Text = "Next minimum bid: " + String.Format("{0:C}", min_bid);
    }

    private double getBidderAvailableBalance()
    {
        double result;

        var constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        using (MySqlConnection con = new MySqlConnection(constr))
        {
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT Available_Balance FROM User WHERE User_Id=@user";
                cmd.Parameters.AddWithValue("@user", user_id);
                cmd.Connection = con;
                con.Open();
                result = Convert.ToDouble(cmd.ExecuteScalar());
                con.Close();
            }
        }
        return result;
    }

    private void updatePreviousHighBidder()
    {
        string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        using (MySqlConnection con = new MySqlConnection(constr))
        {
            //update previous high bidder available balance
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;
                cmd.CommandText = "UPDATE User SET Available_Balance=Available_Balance+@amount WHERE User_Id=@user";
                cmd.Parameters.AddWithValue("@amount", current_high_bid);
                cmd.Parameters.AddWithValue("@user", user_id_high_bid);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }

    private int getUserId()
    {
        int result;
        string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        using (MySqlConnection con = new MySqlConnection(constr))
        {
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;
                cmd.CommandText = "SELECT User_Id FROM User WHERE Username=@user";
                cmd.Parameters.AddWithValue("@user", username);
                con.Open();
                result = Convert.ToInt32(cmd.ExecuteScalar());
                con.Close();
            }
        }
        return result;
    }

    private bool loggedIn()
    {
        return this.Page.User.Identity.IsAuthenticated;
        /*if (this.Page.User.Identity.IsAuthenticated)
        {
            FormsAuthentication.RedirectToLoginPage();
            
        }*/

    }
}