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
    private int owner_id;
    private double balance;
    private double available_balance;
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

    public int Owner_id
    {
        get
        {
            return owner_id;
        }

        set
        {
            owner_id = value;
        }
    }

    public double Balance
    {
        get
        {
            return balance;
        }

        set
        {
            balance = value;
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



    public Account(int id, int owner_id, double balance)
    {
        // Constructor with initial balance given
        this.id = id;
        this.owner_id = owner_id;
        this.balance = balance;
        this.available_balance = balance;
        // Not sure how 'enabled' logic is being handled
        // Initializing it to 'false' for now
        this.enabled = false;
    }

    public Account(int id, int owner_id)
    {
        // Constructor with no initial balance given
        this.id = id;
        this.owner_id = owner_id;
        this.balance = 0.0;
        this.available_balance = 0.0;
        // Not sure how 'enabled' logic is being handled
        // Initializing it to 'false' for now
        this.enabled = false;
    }

    public void withdraw(double amount)
    {
        Balance -= amount;
    }

    public void deposit(double amount)
    {
        Balance += amount;
    }
}