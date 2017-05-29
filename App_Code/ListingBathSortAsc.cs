using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ListingBathSortAsc
/// </summary>
public class ListingBathSortAsc : IComparer<Listing>
{
    public int Compare(Listing l1, Listing l2)
    {
        return l2.bath.CompareTo(l1.bath);
    }
}
