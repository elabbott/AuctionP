using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Credit card associated with a user
/// </summary>
public class CreditCard
{
    #region Attributes
    private int id;
    private int owner_id;
    private String number;
    private String name;
    private DateTime expiry_date;

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

    public string Number
    {
        get
        {
            return number;
        }

        set
        {
            number = value;
        }
    }

    public string Name
    {
        get
        {
            return name;
        }

        set
        {
            name = value;
        }
    }

    public DateTime Expiry_date
    {
        get
        {
            return expiry_date;
        }

        set
        {
            expiry_date = value;
        }
    }
    #endregion

    public CreditCard(int id, int owner_id, String number, String name, DateTime expiry_date)
    {
        this.id = id;
        this.owner_id = owner_id;
        this.number = number;
        this.name = name;
        this.expiry_date = expiry_date;
    }
}