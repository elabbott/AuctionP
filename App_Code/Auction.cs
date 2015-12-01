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
    private int owner_id;
    private Account top_bidder;
    private double top_bid;
    private double min_bid;
    private double buyout_price;
    private DateTime end_time;
    private bool auction_open;
    private string description;
    private string img_url;
    private List<Account> bidders;
    private string category;
    private string title;


    public string Title
    {
        get
        {
            return title;
        }
        set
        {
            title = value;
        }
    }
    public string Category
    {
        get
        {
            return category;
        }
        set
        {
            category = value;
        }
    }

    public int Id
    {
        get
        {
            return id;
        }
    }

    public int Owner_Id
    {
        get
        {
            return owner_id;
        }
    }

    public Account Top_bidder
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

    public List<Account> Bidders
    {
        get
        {
            return bidders;
        }
    }
    #endregion

    public Auction(int id, int owner, double min_bid, double buyout_price, DateTime end_time, string description, string img_url, string title, string category)
    {
        this.id = id;
        this.owner_id = owner;
        this.min_bid = min_bid;
        this.buyout_price = buyout_price;
        this.end_time = end_time;
        this.description = description;
        this.img_url = img_url;
        this.Title = title;
        this.Category = category;

        this.auction_open = true;
        this.bidders = new List<Account>();
    }


}