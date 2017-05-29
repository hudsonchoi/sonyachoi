using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
/// <summary>
/// Summary description for TrackingDAL
/// </summary>
public class TrackingDAL
{
    public static void InsertTracking(string country_name, string ip, string region_name, string city, string referral, string browser)
    {
        SqlConnection conn = null;
        SqlCommand cmd = null;

        using (conn = new SqlConnection(ConfigurationManager.ConnectionStrings["sonyachoiConnectionString"].ToString()))
        {
            conn.Open();
            using (cmd = new SqlCommand("InsertTracking", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("logdate", DateTime.Now);
                cmd.Parameters.AddWithValue("ip", ip);
                cmd.Parameters.AddWithValue("country_name", country_name);
                cmd.Parameters.AddWithValue("region_name", region_name);
                cmd.Parameters.AddWithValue("city", city);
                cmd.Parameters.AddWithValue("referral", referral);
                cmd.Parameters.AddWithValue("browser", browser);
                cmd.ExecuteNonQuery();
            }
        }

    }
}