using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;

public partial class admin_Default2 : System.Web.UI.Page
{
    public string sContent = string.Empty;//For email blaster
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            MLS mls = new MLS();
            Listing l = mls.getListingByID(Convert.ToInt32(Request.QueryString["id"].ToString()));
            tbSellingPoint.Text = l.selling_point;
            ltImageGallery.Text = l.image_gallery;

            tbListingID.Text = l.listing_id.ToString();
            tbNumOfImages.Text = l.number_of_images.ToString();
            //tbTimeStamp.Text = l.ts;
            //tbPath.Text = l.path.ToString();
            tbBed.Text = l.bed.ToString();
            if (l.bath != null)
            {
                tbBath.Text = l.bath.ToString();
            }
            //tbStyle.Text = l.style;
            if (l.style != null)
            {
                ddlStyle.SelectedValue = l.style.ToString();
            }
            tbAddress.Text = l.address;
            tbCity.Text = l.city;
            tbZip.Text = l.zip;
            if (l.description != null)
            {
                sContent = RTESafe(l.description);
            }
            if (l.sale)
            {
                cbSale.Checked = true;
                tbPrice.Text = l.price;
            }

            if (l.rental)
            {
                cbRental.Checked = true;
                tbRent.Text = l.rent;
            }

            if (l.featured)
            {
                cbFeatured.Checked = true;
            }

            ddlStatus.SelectedValue = l.status.ToString();

            if (l.status == 0)
            {
                imgStatus.ImageUrl = "/images/sale.png";
            }
            else if (l.status == 1)
            {
                imgStatus.ImageUrl = "/images/undercontract_large.png";
            }
            else if (l.status == 2)
            {
                imgStatus.ImageUrl = "/images/sold_large.png";
            }
            else if (l.status == 3)
            {
                imgStatus.ImageUrl = "/images/leased_large.png";
            }
        }
        this.Master.Change_Nav("<a href=\"./\">Admin</a> :: Edit");
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            ds_mainTableAdapters.listingTableAdapter listingTA = new ds_mainTableAdapters.listingTableAdapter();
            ds_main.listingDataTable listingDT = listingTA.GetDataByID(Convert.ToInt32(Request.QueryString["id"].ToString()));
            listingDT.Rows[0]["selling_point"] = tbSellingPoint.Text;
            //listingDT.Rows[0]["price"] = tbPrice.Text.Replace("$", "");
            listingDT.Rows[0]["listing_id"] = tbListingID.Text;
            listingDT.Rows[0]["num_of_images"] = tbNumOfImages.Text;
            //listingDT.Rows[0]["ts"] = tbTimeStamp.Text;
            //listingDT.Rows[0]["path"] = tbPath.Text;
            listingDT.Rows[0]["bed"] = tbBed.Text;
            listingDT.Rows[0]["bath"] = tbBath.Text;
            listingDT.Rows[0]["style"] = ddlStyle.SelectedValue;
            listingDT.Rows[0]["address"] = tbAddress.Text;
            listingDT.Rows[0]["city"] = tbCity.Text;
            listingDT.Rows[0]["zip"] = tbZip.Text;
            Debug.WriteLine(RTESafe(Request.Form["message"].ToString()));
            listingDT.Rows[0]["description"] = RTESafe(Request.Form["message"].ToString());
            //bool featuredUpdated = false;
            if (cbFeatured.Checked)
            {
                //if (listingDT.Rows[0]["featured"].ToString() == "")
                //{
                //    featuredUpdated = true;
                //}
                //else
                //{
                //    if (!Convert.ToBoolean(listingDT.Rows[0]["featured"].ToString()))
                //    {
                //        featuredUpdated = true;
                //    }
                //}
                listingDT.Rows[0]["featured"] = 1;
                listingDT.Rows[0]["featured_sort"] = MLS.getMaxFeaturedSort() + 1;
            }
            else
            {
                //if (listingDT.Rows[0]["featured"].ToString() == "")
                //{
                //    featuredUpdated = false;
                //}
                //else
                //{
                //    if (Convert.ToBoolean(listingDT.Rows[0]["featured"].ToString()))
                //    {
                //        featuredUpdated = true;
                //    }
                //}
                listingDT.Rows[0]["featured"] = 0;
            }

            listingDT.Rows[0]["status"] = ddlStatus.SelectedValue;



            listingTA.Update(listingDT);

            int sort = 0;
            ds_mainTableAdapters.x_listing_typeTableAdapter x_listing_typeTA = new ds_mainTableAdapters.x_listing_typeTableAdapter();
           
            if (cbSale.Checked)
            {
                ds_main.x_listing_typeDataTable x_listing_typeDT = x_listing_typeTA.GetDataByListingIDTypeID(Convert.ToInt32(tbListingID.Text), 100);
                if (x_listing_typeDT.Rows.Count > 0)
                {
                    x_listing_typeDT.Rows[0]["price"] = Convert.ToDecimal(tbPrice.Text.Replace("$", ""));
                    x_listing_typeTA.Update(x_listing_typeDT);
                }
                else//Not listed as 'Sale'. So add it!
                {
                    x_listing_typeTA.InsertData(Convert.ToInt32(Request.QueryString["id"].ToString()),
                                            100,
                                            Convert.ToDecimal(tbPrice.Text.Replace("$", "")),
                                            MLS.getMaxSortByTypeID(100) + 1);
                }
            }
            else
            {
                x_listing_typeTA.DeleteXListingTypeByListingIDTypeID(Convert.ToInt32(Request.QueryString["id"].ToString()), 100);
            }

            if (cbRental.Checked)
            {
                ds_main.x_listing_typeDataTable x_listing_typeDT = x_listing_typeTA.GetDataByListingIDTypeID(Convert.ToInt32(tbListingID.Text), 200);
                if (x_listing_typeDT.Rows.Count > 0)
                {
                    x_listing_typeDT.Rows[0]["price"] = Convert.ToDecimal(tbRent.Text.Replace("$", ""));
                    x_listing_typeTA.Update(x_listing_typeDT);
                }
                else//Not listed as 'Rental'. So add it!
                {
                    x_listing_typeTA.InsertData(Convert.ToInt32(Request.QueryString["id"].ToString()),
                                            200,
                                            Convert.ToDecimal(tbRent.Text.Replace("$", "")),
                                            MLS.getMaxSortByTypeID(200) + 1);
                }
            }
            else
            {
                x_listing_typeTA.DeleteXListingTypeByListingIDTypeID(Convert.ToInt32(Request.QueryString["id"].ToString()), 200);
            }

            MLS.InsertModifiedDate();
            
            
            //ds_main.x_listing_typeDataTable x_listing_typeDT = x_listing_typeTA.GetDataByListingID(Convert.ToInt32(tbListingID.Text));
            //if (x_listing_typeDT.Rows.Count > 0)
            //    sort = Convert.ToInt32(x_listing_typeDT.Rows[0]["sort"].ToString());
                    
            //x_listing_typeTA.DeleteXListingTypeByListingID(Convert.ToInt32(Request.QueryString["id"].ToString()));

            //if (cbSale.Checked)
            //{
            //    x_listing_typeTA.InsertData(Convert.ToInt32(Request.QueryString["id"].ToString()),
            //                                100,
            //                                Convert.ToDecimal(tbPrice.Text.Replace("$", "")),
            //                                MLS.getMaxSortByTypeID(100) + 1);

            //    //ds_main.x_listing_typeDataTable x_listing_typeDT = new ds_main.x_listing_typeDataTable();
            //    //ds_main.x_listing_typeRow x_listing_TypeR = x_listing_typeDT.Newx_listing_typeRow();
            //    //x_listing_TypeR.listing_id = Convert.ToInt32(Request.QueryString["id"].ToString());
            //    //x_listing_TypeR.type_id = 100;
            //    //x_listing_TypeR.price = Convert.ToDecimal(tbPrice.Text.Replace("$", ""));
            //    //x_listing_TypeR.sort = MLS.getMaxSortByTypeID(100)+1;
            //    //x_listing_typeDT.Addx_listing_typeRow(x_listing_TypeR);
            //    //x_listing_typeTA.Update(x_listing_typeDT);
            //}

            //if (cbRental.Checked)
            //{
            //    x_listing_typeTA.InsertData(Convert.ToInt32(Request.QueryString["id"].ToString()),
            //                200,
            //                Convert.ToDecimal(tbPrice.Text.Replace("$", "")),
            //                MLS.getMaxSortByTypeID(200) + 1);

            //    //ds_main.x_listing_typeDataTable x_listing_typeDT = new ds_main.x_listing_typeDataTable();
            //    //ds_main.x_listing_typeRow x_listing_TypeR = x_listing_typeDT.Newx_listing_typeRow();
            //    //x_listing_TypeR.listing_id = Convert.ToInt32(Request.QueryString["id"].ToString());
            //    //x_listing_TypeR.type_id = 200;
            //    //x_listing_TypeR.sort = MLS.getMaxSortByTypeID(200) + 1;
            //    //x_listing_TypeR.price = Convert.ToDecimal(tbRent.Text.Replace("$", ""));
            //    //x_listing_typeDT.Addx_listing_typeRow(x_listing_TypeR);
            //    //x_listing_typeTA.Update(x_listing_typeDT);

            //}
            


            //ds_main.x_listing_typeDataTable x_listing_typeDT = x_listing_typeTA.GetDataByListingID(Convert.ToInt32(Request.QueryString["id"].ToString()));
            ////x_listing_typeDT.Rows[0]["price"] = "100";

            //foreach (ds_main.x_listing_typeRow r in x_listing_typeDT.Rows)
            //{
            //    if (r["type_id"].ToString() == "100")
            //    {
            //        if (cbSale.Checked)
            //        {
            //            r["price"] = tbPrice.Text.Replace("$", "");
            //        }
            //    }

            //    if (r["type_id"].ToString() == "200")
            //    {
            //        if (cbRental.Checked)
            //        {
            //            r["price"] = tbRent.Text.Replace("$", "");
            //        }
            //    }
            //}

            //x_listing_typeTA.Update(x_listing_typeDT);
            //if (featuredUpdated)
            //{
            //    Response.Redirect("./");
            //}
            //else if (cbSale.Checked)
            if (cbSale.Checked)
            {
                Response.Redirect("./listings.aspx?type_id=100&id=" + Request.QueryString["id"].ToString());
            }
            else if (cbRental.Checked)
            {
                Response.Redirect("./listings.aspx?type_id=200&id=" + Request.QueryString["id"].ToString());
            }

        }
        
    }
    protected void cvStyle_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (args.Value == "0")
        {
            args.IsValid = false;
        }
        else
        {
            args.IsValid = true;
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

    public string RTESafe(string strText)
    {

        string tmpString = string.Empty;
        tmpString = strText.Trim();
        //tmpString = tmpString.Replace(" ", "");
        tmpString = tmpString.Replace("\r", "");
        tmpString = tmpString.Replace("\n", "");
        tmpString = tmpString.Replace("\t", "");

        //convert all types of single quotes
        tmpString = tmpString.Replace((char)145, (char)39);
        tmpString = tmpString.Replace((char)146, (char)39);
        tmpString = tmpString.Replace("'", "&#39;");

        //convert all types of double quotes
        tmpString = tmpString.Replace((char)147, (char)34);
        tmpString = tmpString.Replace((char)148, (char)34);

        return tmpString;
    }
}
