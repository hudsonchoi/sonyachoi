using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

public partial class listing : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        MLS mls = new MLS();
        Listing l = mls.getListingByID(Convert.ToInt32(Request.QueryString["id"].ToString()));
        if (l.selling_point != null)
        {
            ltSellingPoint.Text = l.selling_point;
        }
        ltImageGallery.Text = l.image_gallery;

        if (Request.QueryString["type_id"] == "100")
        {
            ltPrice.Text = l.price;
        }
        else if (Request.QueryString["type_id"] == "200")
        {
            ltPrice.Text = l.rent + "/month";
        }

        ltBed.Text = l.bed.ToString();
        ltBath.Text = l.bath.ToString();
        if (l.style != null)
        {
            ltStyle.Text = l.style.ToString();
        }

        if (l.city != null)
        {
            ltCity.Text = l.city;
        }

        if (l.description != null)
        {
            ltDescription.Text = l.description;
        }

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
}
