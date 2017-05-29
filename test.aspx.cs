using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class test : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    [WebMethod]
    public static string LogUser()
    {
        string msg = string.Empty;
        //if (HttpContext.Current.Session["loggedIn"] == null)
        //{
            string ip = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (ip == null || ip.ToLower() == "unknown")
                ip = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            msg = ip;
            //System.Web.HttpContext.Current.Session["loggedIn"] = true;
        //}
        return msg;
    }
}