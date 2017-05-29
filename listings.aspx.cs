using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class listings : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        MLS myMLS = new MLS();
        //ListingCollection lc = myMLS.getRents("listing");
        //gvRents.DataSource = lc;
        if (Request.QueryString["type_id"] != null)
        {
            gvRents.DataSource = myMLS.getListingsByTypeID(Convert.ToInt32(Request.QueryString["type_id"].ToString()), "listing").FindAll(a => a.city != null && a.price != null);
            //gvRents.DataSource = myMLS.getListingsByTypeID(Convert.ToInt32(Request.QueryString["type_id"].ToString()), "listing");
            gvRents.Columns[3].HeaderStyle.CssClass = "neutral";
            gvRents.DataBind();
        }
        
    }

    //Ready-Made code to enable sort and paging
    private string GridViewSortDirection
    {
        get { return ViewState["SortDirection"] as string ?? "ASC"; }
        set { ViewState["SortDirection"] = value; }
    }



    private string GridViewSortExpression
    {
        get { return ViewState["SortExpression"] as string ?? string.Empty; }
        set { ViewState["SortExpression"] = value; }
    }

    private string GetSortDirection()
    {
        switch (GridViewSortDirection)
        {
            case "ASC":
                GridViewSortDirection = "DESC";
                break;
            case "DESC":
                GridViewSortDirection = "ASC";
                break;
        }
        return GridViewSortDirection;
    }

    /*
    protected void gvReport_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvReport.DataSource = SortDataTable(gvReport.DataSource as DataTable, true);
        gvReport.PageIndex = e.NewPageIndex;
        gvReport.DataBind();
        emptyTheFileds();
    }

    protected DataView SortDataTable(DataTable dataTable, bool isPageIndexChanging)
    {

        if (dataTable != null)
        {
            DataView dataView = new DataView(dataTable);
            if (GridViewSortExpression != string.Empty)
            {
                if (isPageIndexChanging)
                {
                    dataView.Sort = string.Format("{0} {1}", GridViewSortExpression, GridViewSortDirection);
                }
                else
                {
                    dataView.Sort = string.Format("{0} {1}", GridViewSortExpression, GetSortDirection());
                }
            }
            return dataView;
        }
        else
        {
            return new DataView();
        }

    }
    */

    protected void gvRentsResetStyle(int iExcept)
    {
        for (int i = 0; i < gvRents.Columns.Count; i++)
        {
            if (i != iExcept)
            {
                gvRents.Columns[i].HeaderStyle.CssClass = "neutral";
                gvRents.Columns[i].ItemStyle.CssClass = "neutral";
            }
        }
    }
    protected void gvRents_Sorting(object sender, GridViewSortEventArgs e)
    {
        GridViewSortExpression = e.SortExpression;

        //ListingCollection lc = (ListingCollection)(gvRents.DataSource);
        List<Listing> Listings = (List<Listing>)(gvRents.DataSource);
        if ((ViewState["sortDirection"] != null) && ((int)ViewState["sortDirection"] == (int)ListingSortDirection.ASC))
        {
            if (e.SortExpression.ToString() == "price")
            {
                ListingPriceSortDesc pSort = new ListingPriceSortDesc();
                Listings.Sort(pSort);
                //lc.Sort("price", (int)ListingSortDirection.DESC);
                gvRents.Columns[3].HeaderStyle.CssClass = "desc";
                gvRents.Columns[3].ItemStyle.CssClass = "selected";
                gvRentsResetStyle(3);
            }
                   
            else if (e.SortExpression.ToString() == "listing_id")
            {
                ListingIDSortDesc iSort = new ListingIDSortDesc();
                Listings.Sort(iSort);
                //lc.Sort("listing_id", (int)ListingSortDirection.DESC);
                gvRents.Columns[0].HeaderStyle.CssClass = "desc";
                gvRents.Columns[0].ItemStyle.CssClass = "selected";
                gvRentsResetStyle(0);
            }
            else if (e.SortExpression.ToString() == "city")
            {
                ListingCitySortDesc cSort = new ListingCitySortDesc();
                Listings.Sort(cSort);
                //lc.Sort("city", (int)ListingSortDirection.DESC);
                gvRents.Columns[2].HeaderStyle.CssClass = "desc";
                gvRents.Columns[2].ItemStyle.CssClass = "selected";
                gvRentsResetStyle(2);
            }
            else if (e.SortExpression.ToString() == "style")
            {
                ListingStyleSortDesc sSort = new ListingStyleSortDesc();
                Listings.Sort(sSort);
                //lc.Sort("city", (int)ListingSortDirection.ASC);
                gvRents.Columns[5].HeaderStyle.CssClass = "desc";
                gvRents.Columns[5].ItemStyle.CssClass = "selected";
                gvRentsResetStyle(5);
            }
            else if (e.SortExpression.ToString() == "bed")
            {
                ListingBedSortDesc bdSort = new ListingBedSortDesc();
                Listings.Sort(bdSort);
                //lc.Sort("city", (int)ListingSortDirection.ASC);
                gvRents.Columns[6].HeaderStyle.CssClass = "desc";
                gvRents.Columns[6].ItemStyle.CssClass = "selected";
                gvRentsResetStyle(6);
            }
            else if (e.SortExpression.ToString() == "bath")
            {
                ListingBathSortDesc btSort = new ListingBathSortDesc();
                Listings.Sort(btSort);
                //lc.Sort("city", (int)ListingSortDirection.ASC);
                gvRents.Columns[7].HeaderStyle.CssClass = "desc";
                gvRents.Columns[7].ItemStyle.CssClass = "selected";
                gvRentsResetStyle(7);
            }
            
            ViewState["sortDirection"] = (int)ListingSortDirection.DESC;
        }
        else
        {
            if (e.SortExpression.ToString() == "price")
            {
                //lc.Sort("price", (int)ListingSortDirection.ASC);
                ListingPriceSortAsc pSort = new ListingPriceSortAsc();
                Listings.Sort(pSort);
                gvRents.Columns[3].HeaderStyle.CssClass = "asc";
                gvRents.Columns[3].ItemStyle.CssClass = "selected";
                gvRentsResetStyle(3);
            }   
            else if (e.SortExpression.ToString() == "listing_id")
            {
                //lc.Sort("listing_id", (int)ListingSortDirection.ASC);
                ListingIDSortAsc iSort = new ListingIDSortAsc();
                Listings.Sort(iSort);
                gvRents.Columns[0].HeaderStyle.CssClass = "asc";
                gvRents.Columns[0].ItemStyle.CssClass = "selected";
                gvRentsResetStyle(0);
            }
            else if (e.SortExpression.ToString() == "city")
            {
                ListingCitySortAsc cSort = new ListingCitySortAsc();
                Listings.Sort(cSort);
                //lc.Sort("city", (int)ListingSortDirection.ASC);
                gvRents.Columns[2].HeaderStyle.CssClass = "asc";
                gvRents.Columns[2].ItemStyle.CssClass = "selected";
                gvRentsResetStyle(2);
            }
            else if (e.SortExpression.ToString() == "style")
            {
                ListingStyleSortAsc sSort = new ListingStyleSortAsc();
                Listings.Sort(sSort);
                //lc.Sort("city", (int)ListingSortDirection.ASC);
                gvRents.Columns[5].HeaderStyle.CssClass = "asc";
                gvRents.Columns[5].ItemStyle.CssClass = "selected";
                gvRentsResetStyle(5);
            }
            else if (e.SortExpression.ToString() == "bed")
            {
                ListingBedSortAsc bdSort = new ListingBedSortAsc();
                Listings.Sort(bdSort);
                //lc.Sort("city", (int)ListingSortDirection.ASC);
                gvRents.Columns[6].HeaderStyle.CssClass = "asc";
                gvRents.Columns[6].ItemStyle.CssClass = "selected";
                gvRentsResetStyle(6);
            }
            else if (e.SortExpression.ToString() == "bath")
            {
                ListingBathSortAsc btSort = new ListingBathSortAsc();
                Listings.Sort(btSort);
                //lc.Sort("city", (int)ListingSortDirection.ASC);
                gvRents.Columns[7].HeaderStyle.CssClass = "asc";
                gvRents.Columns[7].ItemStyle.CssClass = "selected";
                gvRentsResetStyle(7);
            }
            ViewState["sortDirection"] = (int)ListingSortDirection.ASC;
        }

        gvRents.DataSource = Listings;
        gvRents.DataBind();
        //if (e.SortDirection.ToString() 'price'){
        //}
        /*
        GridViewSortExpression = e.SortExpression;
        int pageIndex = gvRents.PageIndex;
        gvRents.DataSource = SortDataTable(gvReport.DataSource as DataTable, false);
        gvRents.DataBind();
        gvRents.PageIndex = pageIndex;
        */
    }

    protected void gvRents_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Width = 80;
    }
}
