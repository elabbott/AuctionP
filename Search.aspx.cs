using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Search : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            All();
        }
    }

    protected void lbArt_Click(object sender, EventArgs e)
    {
        LabelCategory.Text = lbArt.Text;
        Load_Search(LabelCategory.Text);
    }

    protected void lbBooks_Click(object sender, EventArgs e)
    {
        LabelCategory.Text = lbBooks.Text;
        Load_Search(LabelCategory.Text);
    }

    protected void lbClothes_Click(object sender, EventArgs e)
    {
        LabelCategory.Text = lbClothes.Text;
        Load_Search(LabelCategory.Text);
    }

    protected void lbCrafts_Click(object sender, EventArgs e)
    {
        LabelCategory.Text = lbCrafts.Text;
        Load_Search(LabelCategory.Text);
    }

    protected void lbElectronics_Click(object sender, EventArgs e)
    {
        LabelCategory.Text = lbElectronics.Text;
        Load_Search(LabelCategory.Text);
    }

    protected void lbHomeGarden_Click(object sender, EventArgs e)
    {
        LabelCategory.Text = lbHomeGarden.Text;
        Load_Search(LabelCategory.Text);
    }

    protected void lbJewelry_Click(object sender, EventArgs e)
    {
        LabelCategory.Text = lbJewelry.Text;
        Load_Search(LabelCategory.Text);
    }

    protected void lbMusic_Click(object sender, EventArgs e)
    {
        LabelCategory.Text = lbMusic.Text;
        Load_Search(LabelCategory.Text);
    }

    protected void lbPetGoods_Click(object sender, EventArgs e)
    {
        LabelCategory.Text = lbPetGoods.Text;
        Load_Search(LabelCategory.Text);
    }

    protected void lbSportsGoods_Click(object sender, EventArgs e)
    {
        LabelCategory.Text = lbSportsGoods.Text;
        Load_Search(LabelCategory.Text);
    }

    protected void lbToys_Click(object sender, EventArgs e)
    {
        LabelCategory.Text = lbToys.Text;
        Load_Search(LabelCategory.Text);
    }

    protected void lbVideoGames_Click(object sender, EventArgs e)
    {
        LabelCategory.Text = lbVideoGames.Text;
        Load_Search(LabelCategory.Text);
    }
    protected void All()
    {
        LabelCategory.Text = "All";
        var all = "_";
        Load_Search(all);

    }
    //protected void Load_Search1(string search)
    //{
    //    var constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
    //    using (var con = new MySqlConnection(constr))
    //    {
    //        var cmd = new MySqlCommand("SELECT Title, Current_High_Bid as High, Date_Format(End_Date, '%W, %M %e') as Date, Description, Image_URL FROM Auction WHERE Category Like '" + search + "'", con);

    //        var adapter = new MySqlDataAdapter(cmd);

    //        var dt = new DataTable();

    //        adapter.Fill(dt);

    //        GridView1.DataSource = dt;

    //        GridView1.DataBind();

    //        cmd.Connection.Close();
    //    }
    //}
    protected void Load_Search(string search)
    {
        var dt = GetData(search);
        var html = new StringBuilder();
        html.Append("<table class=\"table\"");

        html.Append("<tr>");

        foreach(DataColumn column in dt.Columns)
        {
            html.Append("<th>");
            html.Append(column.ColumnName);
            html.Append("</th>");
        }
        html.Append("</tr>");

        foreach (DataRow row in dt.Rows)
        {
            var i = 1; // this keeps track which column we are on, reference select statement in GetData() for corresponding column values
            html.Append("<tr>");
            foreach(DataColumn column in dt.Columns)
            {
                var columnString = row[column.ColumnName].ToString();
                html.Append("<td>");
                //if (row[column.ColumnName].ToString().Contains(".com"))
                if (i == 5 && CheckURLValid(columnString)) //column value check for fifth column <may be unnessarry> and then checks if link is valid url
                {
                    html.Append("<img src='" + columnString + "'/>");
                }
                else if (i == 5 && !CheckURLValid(columnString))
                {
                    html.Append("<img src =\"noimage.jpg\"");
                }
                else
                {
                    html.Append(columnString);
                }
                html.Append("</td>");
                i++;
            }
            html.Append("</tr>");
        }
        html.Append("</table>");

        PlaceHolderSearchResults.Controls.Add(new Literal { Text = html.ToString() });
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        var search = txtSearch.Text;
        Load_Search(search);
    }
    private DataTable GetData(string search)
    {
        var constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        using (var con = new MySqlConnection(constr))
        {
            var cmd = new MySqlCommand("SELECT Title, Current_High_Bid as Bid, Date_Format(End_Date, '%W, %M %e') as Date, Description, Image_URL FROM Auction WHERE Open = true AND (Category = '" + search + "' OR Title Like '" + search + "')", con);

            var adapter = new MySqlDataAdapter(cmd);

            var dt = new DataTable();

            adapter.Fill(dt);
            return dt;
        }
    }
    public static bool CheckURLValid(string source)
    {
        Uri uriResult;
        return Uri.TryCreate(source, UriKind.Absolute, out uriResult) && uriResult.Scheme == Uri.UriSchemeHttp;
    }
    protected void lbSearch_Click(object sender, EventArgs e)
    {

    }
}