using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Class1
/// </summary>
public class User
{
    #region Attributes/Private Variables
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
    #endregion
    public User(string username, string password, string email, string address, string city, string state, string zipcode, string first_name, string last_name)
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
	}
    public User(string username, string password, string email)
    {
        this.Username = username;
        this.Password = password;
        this.Email = email;
    }
    //this doesn't belong here
    //public void Create_User(User user)
    //{
    //    MySQLClient add_user = new MySQLClient("173.194.241.131","auction_powers", "root", "root");
    //    string value = user.Username + ", " + user.Email + ", " + user.Password + ", " + user.Address + ", " + user.City + ", " + user.State + ", " + user.Zipcode + ", " + user.First_name + ", " + user.Last_name;
    //    add_user.Insert("user", "first_name, last_name, username, password, email, phone, address, city, state, zipcode", value);
    //}

    #region Properties
    public int Id
    {
        get { return id; }
        set { id = value; } // should never really be used
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
    #endregion

}