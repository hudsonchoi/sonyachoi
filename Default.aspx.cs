using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Text;
using System.Web.Services;
using System.Threading;
using System.Net;
using System.Runtime.Serialization.Json;
using System.IO;

public partial class _Default : System.Web.UI.Page
{
    public string referral = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        MLS mls = new MLS();
        dlFeaturedListings.DataSource = mls.getFeaturedListings("listing");
        dlFeaturedListings.DataBind();

        if (Request.UrlReferrer != null)
            referral = Request.UrlReferrer.ToString();

        //ltrFeatures.Text = "<h1>"+sbCode.ToString()+"</h1>";
    }

    [WebMethod]
    public static void LogUser(string referral)
    {
        if (HttpContext.Current.Session["loggedIn"] == null)
        {
            string ip = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (ip == null || ip.ToLower() == "unknown")
                ip = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];

            var url = "http://freegeoip.net/json/" + ip;
            var client = new WebClient();
            var content = client.DownloadString(url);

            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Geo));
            Geo geo = new Geo();
            using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(content)))
            {
                geo = (Geo)serializer.ReadObject(ms);
            }

            TrackingDAL.InsertTracking(geo.country_name, ip, geo.region_name, geo.city, referral, HttpContext.Current.Request.Browser.Platform + "::::" + HttpContext.Current.Request.UserAgent);

            System.Web.HttpContext.Current.Session["loggedIn"] = true;
        }
    }
}
