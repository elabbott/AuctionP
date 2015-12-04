using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Web.Security;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            //put stuff that you only want to hit when the page loads the first time
        }
    }
    //method is allowing values not in db through and is returning a null value on correct values problem lies in the stored procedure
    protected void ValidateUser(object sender, EventArgs e)
    {
        int userId = 0;
        object dbNullTesterObject;
        string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        using (MySqlConnection con = new MySqlConnection(constr))
        {
            using (MySqlCommand cmd = new MySqlCommand("Validate_User"))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("Username", Login2.UserName);
                cmd.Parameters.AddWithValue("Pass", Login2.Password);
                cmd.Connection = con;
                con.Open();
                dbNullTesterObject = cmd.ExecuteScalar();
                con.Close();
                userId = dbNullTesterObject == DBNull.Value ? 0 : Convert.ToInt32(dbNullTesterObject); // fancy check making sure we dont pull back null values and break the page
                //userId = Convert.ToInt32(cmd.ExecuteScalar());
                //con.Close();
            }
            switch (userId)
            {
                case 0:
                    Login2.FailureText = "Error with stored procedure\nUserId: " + userId;
                    break;
                case -1:
                    Login2.FailureText = "Username and/or password is incorrect.";
                    break;
                case -2:
                    Login2.FailureText = "User Account has not been activated.";
                    break;
                default:
                    Session["userID"] = userId;
                    FormsAuthentication.RedirectFromLoginPage(Login2.UserName, Login2.RememberMeSet);
                    break;
            }
        }
    }
}