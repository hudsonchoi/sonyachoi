using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

/// <summary>
/// Summary description for geo
/// </summary>
[DataContract]
public class Geo
{
    [DataMember]
    public string ip { get; set; }
    [DataMember]
    public string country_code { get; set; }
    [DataMember]
    public string country_name { get; set; }
    [DataMember]
    public string region_code { get; set; }
    [DataMember]
    public string region_name { get; set; }
    [DataMember]
    public string city { get; set; }
    [DataMember]
    public string zipcode { get; set; }
    [DataMember]
    public double latitude { get; set; }
    [DataMember]
    public double longitude { get; set; }
    [DataMember]
    public string metro_code { get; set; }
    [DataMember]
    public string areacode { get; set; }

}