using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AddCard : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }


    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("User.aspx");
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        string name = txtName.Text;
        string number = txtNum.Text;
        string ccv = txtCCV.Text;
        string date = ddListMonth.Text + txtYear.Text;

        //need stored procedure for inserting credit card
    }
}