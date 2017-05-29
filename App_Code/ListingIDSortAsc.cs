using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ListingIDSortAsc
/// </summary>
public class ListingIDSortAsc : IComparer<Listing>
{
    public int Compare(Listing l1, Listing l2)
    {
        return l2.listing_id.CompareTo(l1.listing_id);
    }
}
