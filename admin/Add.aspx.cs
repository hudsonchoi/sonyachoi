using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_Add : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Master.Change_Nav("<a href=\"./\">Admin</a> :: Add");
        if (!IsPostBack)
        {
            if (Request.QueryString["type_id"] != null)
            {
                if (Request.QueryString["type_id"].ToString().Equals("100"))
                {
                    cbSale.Checked = true;
                }
                else if (Request.QueryString["type_id"].ToString().Equals("200"))
                {
                    cbRental.Checked = true;
                }
            }
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            ds_mainTableAdapters.listingTableAdapter listingTA = new ds_mainTableAdapters.listingTableAdapter();
            ds_main.listingDataTable listingDT = new ds_main.listingDataTable();
            ds_main.listingRow listingR = listingDT.NewlistingRow();

            listingR["listing_id"] = tbListingID.Text;
            listingR["num_of_images"] = tbNumOfImages.Text;
            //listingR["ts"] = tbTimeStamp.Text;
            //listingR["path"] = tbPath.Text;
            listingDT.Rows.Add(listingR);

            listingTA.Update(listingDT);

            if (cbSale.Checked)
            {
                ds_mainTableAdapters.x_listing_typeTableAdapter x_listing_typeTA = new ds_mainTableAdapters.x_listing_typeTableAdapter();
                ds_main.x_listing_typeDataTable x_listing_typeDT = new ds_main.x_listing_typeDataTable();
                ds_main.x_listing_typeRow x_listing_typeR = x_listing_typeDT.Newx_listing_typeRow();
                x_listing_typeR.listing_id = Convert.ToInt32(tbListingID.Text);
                x_listing_typeR.type_id = 100;
                x_listing_typeR.sort = MLS.getMaxSortByTypeID(100) + 1;
                x_listing_typeDT.Rows.Add(x_listing_typeR);
                x_listing_typeTA.Update(x_listing_typeDT);

            }

            if (cbRental.Checked)
            {
                ds_mainTableAdapters.x_listing_typeTableAdapter x_listing_typeTA = new ds_mainTableAdapters.x_listing_typeTableAdapter();
                ds_main.x_listing_typeDataTable x_listing_typeDT = new ds_main.x_listing_typeDataTable();
                ds_main.x_listing_typeRow x_listing_typeR = x_listing_typeDT.Newx_listing_typeRow();
                x_listing_typeR.listing_id = Convert.ToInt32(tbListingID.Text);
                x_listing_typeR.type_id = 200;
                x_listing_typeR.sort = MLS.getMaxSortByTypeID(200) + 1;
                x_listing_typeDT.Rows.Add(x_listing_typeR);
                x_listing_typeTA.Update(x_listing_typeDT);

            }

            if (cbSale.Checked)
            {
                Response.Redirect("./listings.aspx?type_id=100");
            }
            else if (cbRental.Checked)
            {
                Response.Redirect("./listings.aspx?type_id=200");
            }
        }
    }

    protected void cvType_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (cbRental.Checked || cbSale.Checked)
        {
            args.IsValid = true;
        }
        else
        {
            args.IsValid = false;
        }
    }
}
