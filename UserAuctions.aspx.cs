using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserAuctions : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.User.Identity.IsAuthenticated)
        {
            FormsAuthentication.RedirectToLoginPage();
        }
        Load_Auctions();
    }

    protected void Load_Auctions()
    {
        var user_id = 0;
        var username = HttpContext.Current.User.Identity.Name;

        var constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        using (var con = new MySqlConnection(constr))
        {
            var cmd = new MySqlCommand("SELECT user_id FROM auction_powers.User WHERE username = '" + username + "'", con);
            cmd.Connection.Open();

            var id_of_user = cmd.ExecuteScalar();

            //user_id = id_of_user.GetInt32(0);
            if (id_of_user != null && id_of_user != DBNull.Value)
            {
                user_id = (int)id_of_user;
            }
            
            cmd.Connection.Close();

            cmd = new MySqlCommand("SELECT Auction_ID, User_Id_Owner, User_Id_High_Bid, Current_High_Bid, Min_Bid, Buyout, Open, Create_Date, End_Date, Description, Image_URL, Category, Title FROM Auction WHERE User_Id_Owner = '" + user_id + "'", con);

            var adapter = new MySqlDataAdapter(cmd);

            var dt = new DataTable();

            adapter.Fill(dt);

            gvAuctions.DataSource = dt;

            gvAuctions.DataBind();

            cmd.Connection.Close();
        }
    }
}