using System;

public partial class Airline : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Page_PreRender(object sender, EventArgs e)
    {
        if (GridView1.SelectedRow == null)
        {
            DetailsView1.Visible = false;
        }
        else
        {
            DetailsView1.Visible = true;
        }
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void DetailsView1_ItemUpdated(object sender, System.Web.UI.WebControls.DetailsViewUpdatedEventArgs e)
    {
        GridView1.DataBind();
        GridView1.SelectRow(-1);
    }

    protected void DetailsView1_ItemInserted(object sender, System.Web.UI.WebControls.DetailsViewInsertedEventArgs e)
    {
        GridView1.DataBind();
        GridView1.SelectRow(-1);
    }

    protected void DetailsView1_ItemDeleted(object sender, System.Web.UI.WebControls.DetailsViewDeletedEventArgs e)
    {
        GridView1.DataBind();
        GridView1.SelectRow(-1);
    }
}