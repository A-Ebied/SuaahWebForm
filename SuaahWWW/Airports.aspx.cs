using System;
using System.Web.UI.WebControls;

public partial class Airport : System.Web.UI.Page
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

    protected void DetailsView1_PageIndexChanging(object sender, DetailsViewPageEventArgs e)
    {

    }

    protected void DetailsView1_ItemUpdated(object sender, DetailsViewUpdatedEventArgs e)
    {
        GridView1.DataBind();
        GridView1.SelectRow(-1);
    }

    protected void DetailsView1_ItemInserted(object sender, DetailsViewInsertedEventArgs e)
    {
        GridView1.DataBind();
        GridView1.SelectRow(-1);
    }

    protected void DetailsView1_ItemDeleted(object sender, DetailsViewDeletedEventArgs e)
    {
        GridView1.DataBind();
        GridView1.SelectRow(-1);
    }
}