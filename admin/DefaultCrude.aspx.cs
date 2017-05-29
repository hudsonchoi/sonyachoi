using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        MLS myMLS = new MLS();
        ListingCollection lc = myMLS.getRents("edit");
        gvRents.DataSource = lc;
        gvRents.Columns[3].HeaderStyle.CssClass = "neutral";
        gvRents.DataBind();
        this.Master.Change_Nav("Admin");
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
        
        ListingCollection lc = (ListingCollection)(gvRents.DataSource);
        if ((ViewState["sortDirection"]!=null) && ((int)ViewState["sortDirection"] == (int)ListingSortDirection.ASC))
        {
            if (e.SortExpression.ToString() == "price")
            {
                lc.Sort("price", (int)ListingSortDirection.DESC);
                gvRents.Columns[3].HeaderStyle.CssClass = "desc";
                gvRents.Columns[3].ItemStyle.CssClass = "selected";
                gvRentsResetStyle(3);
            }
            else if (e.SortExpression.ToString() == "listing_id")
            {
                lc.Sort("listing_id", (int)ListingSortDirection.DESC);
                gvRents.Columns[0].HeaderStyle.CssClass = "desc";
                gvRents.Columns[0].ItemStyle.CssClass = "selected";
                gvRentsResetStyle(0);
            }
            else if (e.SortExpression.ToString() == "city")
            {
                lc.Sort("city", (int)ListingSortDirection.DESC);
                gvRents.Columns[2].HeaderStyle.CssClass = "desc";
                gvRents.Columns[2].ItemStyle.CssClass = "selected";
                gvRentsResetStyle(2);
            }
            ViewState["sortDirection"] = (int)ListingSortDirection.DESC;
        }
        else
        {
            if (e.SortExpression.ToString() == "price")
            {
                lc.Sort("price", (int)ListingSortDirection.ASC);
                gvRents.Columns[3].HeaderStyle.CssClass = "asc";
                gvRents.Columns[3].ItemStyle.CssClass = "selected";
                gvRentsResetStyle(3);
            }
            else if (e.SortExpression.ToString() == "listing_id")
            {
                lc.Sort("listing_id", (int)ListingSortDirection.ASC);
                gvRents.Columns[0].HeaderStyle.CssClass = "asc";
                gvRents.Columns[0].ItemStyle.CssClass = "selected";
                gvRentsResetStyle(0);
            }
            else if (e.SortExpression.ToString() == "city")
            {
                lc.Sort("city", (int)ListingSortDirection.ASC);
                gvRents.Columns[2].HeaderStyle.CssClass = "asc";
                gvRents.Columns[2].ItemStyle.CssClass = "selected";
                gvRentsResetStyle(2);
            }
            ViewState["sortDirection"] = (int)ListingSortDirection.ASC;
        }

        gvRents.DataSource = lc;
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
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (Request.QueryString["id"] != null){
                if (e.Row.Cells[0].Text == Request.QueryString["id"].ToString())
                {
                    e.Row.BackColor = Color.FromArgb(255, 233, 122);
                }
                
            }
            e.Row.Cells[9].Text = "<input type=\"button\" value=\" Delete \" onclick=\"AreYouSure("+e.Row.Cells[0].Text+")\">";
            //e.Row.Cells[8].Text = "<a href=\"delete.aspx?"+e.Row.Cells[0].Text +"\" onclick=\"return confirm(\'You sure you want to go there?');\">DELETE</a>";
        }
    }

    protected void gvRents_SelectedIndexChanged(object sender, EventArgs e)
    {
        int index = gvRents.SelectedIndex;
        string strKey = gvRents.Rows[gvRents.SelectedIndex].Cells[0].Text;
        //string strDataKey = gvRents.SelectedDataKey.Value.ToString();
        //Response.Redirect("edit.aspx?id=" + strDataKey);
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("add.aspx");
    }
    protected void btnSort_Click(object sender, EventArgs e)
    {
         foreach (GridViewRow gvr in this.gvRents.Rows)            
         {                
             TextBox tb = (TextBox)gvr.FindControl("tbSort");//if have control name 'TextBox1'                
             if (tb != null)                
             {                    //get textbox control's value of each row in gridview                   
                 string sort = tb.Text;
             }
             Label lbl = (Label)gvr.FindControl("lblID");
             if (lbl != null)
             {
                 string id = lbl.Text;
             }
         }

    }
}
