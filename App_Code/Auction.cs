using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Auction
/// </summary>
public class Auction
{
    #region Attributes
    private int id;
    private User owner;
    private int item_id;
    private User top_bidder;
    private double top_bid;
    private double min_bid;
    private double buyout_price;
    private DateTime end_time;
    private bool auction_open;
    private string description;
    private string img_url;
    private List<User> bidders;

    public int Id
    {
        get
        {
            return id;
        }
    }

    public User Owner
    {
        get
        {
            return owner;
        }
    }

    public int Item_id
    {
        get
        {
            return item_id;
        }
    }

    public User Top_bidder
    {
        get
        {
            return top_bidder;
        }

        set
        {
            top_bidder = value;
        }
    }


    public double Top_bid
    {
        get
        {
            return top_bid;
        }

        set
        {
            top_bid = value;
        }
    }

    public double Min_bid
    {
        get
        {
            return min_bid;
        }
    }

    public double Buyout_price
    {
        get
        {
            return buyout_price;
        }
    }

    public DateTime End_time
    {
        get
        {
            return end_time;
        }
    }

    public bool Auction_open
    {
        get
        {
            return auction_open;
        }
    }

    public string Description
    {
        get
        {
            return description;
        }
    }

    public string Img_url
    {
        get
        {
            return img_url;
        }
    }

    public List<User> Bidders
    {
        get
        {
            return bidders;
        }
    }
    #endregion

    public Auction(int id, User owner, int item_id, double min_bid, double buyout_price,
        DateTime end_time, string description, string img_url)
    {
        this.id = id;
        this.owner = owner;
        this.item_id = item_id;
        this.min_bid = min_bid;
        this.buyout_price = buyout_price;
        this.end_time = end_time;
        this.description = description;
        this.img_url = img_url;

        this.auction_open = true;
        this.bidders = new List<User>();
    }

    public void bid(double amount, User bidder)
    {
        Top_bid = amount;
        Top_bidder = bidder;
        if (amount == buyout_price)
        {
            this.endAuction();
        }
        else
        {
            this.notifyBidders();
            if (!bidders.Contains(bidder))
            {
                bidders.Add(bidder);
            }
        }
    }

    private void endAuction()
    {
        this.auction_open = false;
        this.notifySeller();
        this.notifyWinner();
        this.notifyBidders();
    }

    private void notifyWinner()
    {
        this.notifyWinner(this.Top_bidder.Id);
    }

    private void notifyWinner(int winner_id)
    {
        // Magic goes here
    }
 
    private void notifySeller()
    {
        this.notifySeller(this.Owner.Id);
    }

    private void notifySeller(int owner_id)
    {
        // Magic goes here
    }

    private void notifyBidders()
    {
        foreach (User bidder in Bidders)
        {
            this.notifyBidders(bidder.Id);
        }
    }

    private void notifyBidders(int bidder_id)
    {
        // Magic goes here
    }
}