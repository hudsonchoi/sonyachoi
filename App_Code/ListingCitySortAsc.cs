using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ListingCitySortAsc
/// </summary>
public class ListingCitySortAsc : IComparer<Listing>
{
    public int Compare(Listing l1, Listing l2)
    {
        return l1.city.CompareTo(l2.city);
    }
}

