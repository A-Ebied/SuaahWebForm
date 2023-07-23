using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Hotel : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        GridView1.Caption = "<br /> <h2>Hotels Details</h2> <br /> ";
        GridView2.Caption = "<br /> <h2>Rooms of the Hotel</h2> <br /> ";
        GridView3.Caption = "<br /> <h2>Services of Room</h2> <br /> ";
    }
}