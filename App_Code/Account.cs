using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Account held by user. Contains available funds to be applied to bids.
/// </summary>
public class Account
{
    #region Atributes
    private int id;
    private string username;
    private string email;
    private string password;
    private DateTime created_date;
    private string address;
    private string city;
    private string state;
    private string zipcode;
    private string first_name;
    private string last_name;
    private double balance;
    private double available_balance;
    private List<CreditCard> cards;
    private List<UserReview> reviews;
    private bool enabled;

    public int Id
    {
        get
        {
            return id;
        }
        set
        {
            id = value;
        }
    }

    public double Balance
    {
        get
        {
            return balance;
        }
    }

    public double Available_balance
    {
        get
        {
            return available_balance;
        }

        set
        {
            available_balance = value;
        }
    }

    public string Username
    {
        get { return username; }
        set { username = value; }
    }
    public string Password
    {
        get { return password; }
        set { password = value; }
    }
    public string Email
    {
        get { return email; }
        set { email = value; }
    }
    public string Last_name
    {
        get { return last_name; }
        set { last_name = value; }
    }
    public string First_name
    {
        get { return first_name; }
        set { first_name = value; }
    }
    public string Zipcode
    {
        get { return zipcode; }
        set { zipcode = value; }
    }
    public string State
    {
        get { return state; }
        set { state = value; }
    }
    public string City
    {
        get { return city; }
        set { city = value; }
    }
    public string Address
    {
        get { return address; }
        set { address = value; }
    }
    public DateTime Created_date
    {
        get { return created_date; }
        set { created_date = value; }//should never really be used
    }

    public List<UserReview> Reviews
    {
        get
        {
            return reviews;
        }
    }

    public bool Enabled
    {
        get
        {
            return enabled;
        }

        set
        {
            enabled = value;
        }
    }
    #endregion

    public Account(string username, string password, string email, string address, string city, string state, string zipcode, string first_name, string last_name)
    {
        this.username = username;
        this.password = password;
        this.email = email;
        this.address = address;
        this.city = city;
        this.state = state;
        this.zipcode = zipcode;
        this.first_name = first_name;
        this.last_name = last_name;

        this.cards = new List<CreditCard>();
        this.reviews = new List<UserReview>();
    }

    public Account(string username, string password, string email)
    {
        this.Username = username;
        this.Password = password;
        this.Email = email;
    }

    public void withdraw(double amount)
    {
        this.balance -= amount;
    }

    public void deposit(double amount)
    {
        this.balance += amount;
    }
}