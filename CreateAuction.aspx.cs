using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CreateAuction : System.Web.UI.Page
{
    protected string title;
    protected string imageURL;
    protected string description;
    protected string end_date;
    protected string min_bid;
    protected string buyout;

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("User.aspx");
    }

    protected void btnCreate_Click(object sender, EventArgs e)
    {
        title = txtTitle.Text;
        imageURL = txtImage.Text;
        description = txtDescription.Text;
        DateTime now = DateTime.Now;
        int days = int.Parse(ddListDuration.SelectedValue);
        TimeSpan duration = new System.TimeSpan(days, 0, 0, 0);
        DateTime end = now.Add(duration);
        end_date = end.ToString();

        if(txtMinBid.Text != null)
        {
            min_bid = txtMinBid.Text;
        }
        else
        {
            min_bid = "0";
        }

        if(txtBuyout.Text != null)
        {
            buyout = txtBuyout.Text;
        }
        else
        {
            buyout = "0";
        }

        createAuction();

    }

    protected void createAuction()
    {
        //DB magic goes here
    }
}