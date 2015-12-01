using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Item : System.Web.UI.Page
{
    private int auction_id; //this value needs to be passed through the session
    private int user_id_owner;
    private int user_id_high_bid;
    private double current_high_bid;
    private double min_bid;
    private double buyout;
    private bool open;
    private DateTime create_date;
    private DateTime end_date;
    private string description;
    private string image_url;
    private User owner;
    private string title;
    private string category;
    //private Auction item;

    protected void Page_Load(object sender, EventArgs e)
    {
        //Auction item = new Auction(auction_id, owner, min_bid, buyout, end_date, description, image_url, title, category);
        //var item = new Auction(auction_id, owner, min_bid, buyout, end_date, description, image_url, title, category);
        var item = Load_Auction(auction_id);
        item.Top_bid = current_high_bid;
        lblHighBid.Text = item.Top_bid.ToString("0.00");

        if(item.Min_bid == 0)
        {
            lblNextMinBid.Text = (item.Top_bid + 0.01).ToString("0.00");
        }
        else
        {
            lblNextMinBid.Text = (item.Top_bid + item.Min_bid).ToString("0.00");
        }
    }
    public void bid(double amount, User bidder)
    {
        throw new NotImplementedException();
    }

    private void endAuction( int auction_id, int owner_id, int top_bidder_id)
    {
        notifySeller(owner_id);
        notifyWinner(top_bidder_id);
        notifyBidders();
        doTransactions();
    }

    private void doTransactions()
    {
        throw new NotImplementedException();
    }

    private void notifyWinner(int top_bidder_id)
    {
        throw new NotImplementedException();
    }

    private void notifySeller(int owner_id)
    {
        throw new NotImplementedException();
    }

    private void notifyBidders()
    {
        throw new NotImplementedException();
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
            user_id_owner = (int)auction["User_Id_Owner"];
            user_id_high_bid = (int)auction["User_Id_High_Bid"];
            current_high_bid = (Double)auction["Current_High_Bid"];
            min_bid = (Double)auction["Min_Bid"];
            buyout = (Double)auction["Buyout"];
            open = (Boolean)auction["Open"];
            create_date = (DateTime)auction["Create_Date"];
            end_date = (DateTime)auction["End_Date"];
            description = (string)auction["Description"];
            image_url = (string)auction["Image_URL"];
            category = (string)auction["Category"];
            title = (string)auction["Title"];
            cmd.Connection.Close();
            Auction item = new Auction(auction_id, owner, min_bid, buyout, end_date, description, image_url, title, category);
            return item;
        }
    }
}