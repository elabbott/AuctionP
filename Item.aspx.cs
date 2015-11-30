using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Item : System.Web.UI.Page
{
    protected int auction_id;
    protected int user_id_owner;
    protected int user_id_high_bid;
    protected double current_high_bid;
    protected double min_bid;
    protected double buyout;
    protected bool open;
    protected DateTime create_date;
    protected DateTime end_date;
    protected string description;
    protected string image_url;
    protected User owner;

    protected void Page_Load(object sender, EventArgs e)
    {
        Auction item = new Auction(auction_id, owner, min_bid, buyout, end_date, description, image_url);
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
}