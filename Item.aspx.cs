using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
    private bool open;
    private DateTime create_date;
    private DateTime end_date;
    private string description;
    private string image_url;
    //private User owner;
    private string title;
    private string category;
    //private Auction item;

    protected void Page_Load(object sender, EventArgs e)
    {
        username = HttpContext.Current.User.Identity.Name;
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
                user_id = Convert.ToInt32(cmd.ExecuteScalar());
                con.Close();
            }
        }

        auction_id = Convert.ToInt32(Session["auction_id"]);
        //Auction item = new Auction(auction_id, owner, min_bid, buyout, end_date, description, image_url, title, category);
        //var item = new Auction(auction_id, owner, min_bid, buyout, end_date, description, image_url, title, category);
        var item = Load_Auction(auction_id);
        item.Top_bid = current_high_bid;
        if(current_high_bid > 0)
        {
            min_bid = current_high_bid + 0.01;
        }
        lblHighBid.Text = item.Top_bid.ToString("0.00");
        lblNextMinBid.Text = min_bid.ToString("0.00");
        imgItem.ImageUrl = image_url;
        lblTitle.Text = title;
        lblDescription.Text = description;
        CompareValidator1.ValueToCompare = Convert.ToString(min_bid);
        if (user_id == user_id_owner)
        {
            txtAmount.Enabled = false;
            txtAmount.Visible = false;
            btnBid.Enabled = false;
            btnBid.Visible = false;
            lblBuyOut.Visible = false;
            btnBuyOut.Enabled = false;
            btnBuyOut.Visible = false;
        }
        else
        {
            if (buyout != 0)
            {
                lblBuyOut.Text = "Or Buy Now for $" + Convert.ToString(buyout);
                lblBuyOut.Visible = true;
                btnBuyOut.Enabled = true;
                btnBuyOut.Visible = true;
            }
        }
    }
    public void bid(double amount, int bidder_id)
    {
        int result;
        string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        using (MySqlConnection con = new MySqlConnection(constr))
        {
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
        }
        //return result;
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
                create_date = (DateTime)auction["Create_Date"];
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
    }

    private void buyOut()
    {
        throw new NotImplementedException();
    }

    protected void btnBid_Click(object sender, EventArgs e)
    {
        double amount = Convert.ToDouble(txtAmount.Text);

        bid(amount, user_id);
        Response.Redirect("Item.aspx");
    }
}