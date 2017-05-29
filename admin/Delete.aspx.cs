using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_Delete : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["id"].ToString() != ""){
            ds_mainTableAdapters.listingTableAdapter listingTA = new ds_mainTableAdapters.listingTableAdapter();
            listingTA.DeleteQuery(Convert.ToInt32(Request.QueryString["id"].ToString()));

            if (Request.QueryString["type_id"] != null)
            {
                Response.Redirect("./listings.aspx?type_id=" + Request.QueryString["type_id"]);
            }
            else
            {
                Response.Redirect("./");
            }

            
        }
    }
}
