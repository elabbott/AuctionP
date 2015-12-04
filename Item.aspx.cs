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

    protected void Page_Load(object sender, EventArgs e)
    {
        username = HttpContext.Current.User.Identity.Name;
        auction_id = Convert.ToInt32(Request.QueryString["id"]);
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

        //auction_id = Convert.ToInt32(Session["auction_id"]);
        //Auction item = new Auction(auction_id, owner, min_bid, buyout, end_date, description, image_url, title, category);
        //var item = new Auction(auction_id, owner, min_bid, buyout, end_date, description, image_url, title, category);
        var item = Load_Auction(auction_id);
        item.Top_bid = current_high_bid;

        if (isActive())
        {
            updateAuction();
            showControls();
        }
        else
        {
            open = false;
            //endAuction(auction_id, user_id_owner, user_id_high_bid);
        }
 
        lblHighBid.Text = String.Format("{0:C}", item.Top_bid);
        imgItem.ImageUrl = image_url;
        lblTitle.Text = title;
        lblDescription.Text = description;
        
    }
    public void bid(double amount, int bidder_id)
    {
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

    private void endAuction(int auction_id, int owner_id, int top_bidder_id)
    {
        //update DB
        string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        using (MySqlConnection con = new MySqlConnection(constr))
        {
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE Auction SET Open=0 WHERE Auction_Id=@id";
                cmd.Parameters.AddWithValue("@id", auction_id);
                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        //notifySeller(owner_id);
        //notifyWinner(top_bidder_id);
        //notifyBidders();
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
        updatePreviousHighBidder();
        current_high_bid = buyout;
        user_id_high_bid = user_id;
        endAuction(auction_id, user_id_owner, user_id);
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
        bool result = true;

        if(end_date.CompareTo(DateTime.Now) < 0)
        {
            result = false;
        }

        return result;
    }

    private void updateAuction()
    {
        if (current_high_bid > 0)
        {
            min_bid = current_high_bid + 0.01;
        }
    }

    private void showControls()
    {
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
            bidderAvailableBalance = getBidderAvailableBalance();

            if (buyout != 0)
            {
                lblBuyOut.Text = "Or Buy Now for " + String.Format("{0:C}", buyout);
                lblBuyOut.Visible = true;
                btnBuyOut.Enabled = true;
                if (bidderAvailableBalance >= buyout)
                {
                    btnBuyOut.Visible = true;
                }
            }
            CompareValidator1.ValueToCompare = Convert.ToString(min_bid);
            CompareValidatorAvailableBalance.ValueToCompare = Convert.ToString(bidderAvailableBalance);
        }
        lblNextMinBid.Text = String.Format("{0:C}",min_bid);
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
}