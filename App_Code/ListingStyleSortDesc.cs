using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ListingCitySortDesc
/// </summary>
public class ListingStyleSortDesc : IComparer<Listing>
{
    public int Compare(Listing l1, Listing l2)
    {
        return l2.style.CompareTo(l1.style);
    }
}
