using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ListingCitySortAsc
/// </summary>
public class ListingStyleSortAsc : IComparer<Listing>
{
    public int Compare(Listing l1, Listing l2)
    {
        return l1.style.CompareTo(l2.style);
    }
}

