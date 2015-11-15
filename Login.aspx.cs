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

    }
    protected void ValidateUser(object sender, EventArgs e)
    {
        int userId = 0;
        string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        using (MySqlConnection con = new MySqlConnection(constr))
        {
            using (MySqlCommand cmd = new MySqlCommand("Validate_User"))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("_Username", Login1.UserName);
                cmd.Parameters.AddWithValue("_Password", Login1.Password);
                cmd.Connection = con;
                con.Open();
                userId = Convert.ToInt32(cmd.ExecuteScalar());
                con.Close();
            }
            switch (userId)
            {
                case -1:
                    Login1.FailureText = "Username and/or password is incorrect.";
                    break;
                case -2:
                    Login1.FailureText = "Account has not been activated.";
                    break;
                default:
                    FormsAuthentication.RedirectFromLoginPage(Login1.UserName, Login1.RememberMeSet);
                    break;
            }
        }
    }
}