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
    }

    public int Owner_id
    {
        get
        {
            return owner_id;
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

    /* Not sure we'll have a use case for this

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
    */
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
        this.balance -= amount;
    }

    public void deposit(double amount)
    {
        this.balance += amount;
    }
}