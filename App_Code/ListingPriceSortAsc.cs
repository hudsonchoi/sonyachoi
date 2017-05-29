using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ListingPriceSort2
/// </summary>
public class ListingPriceSortAsc : IComparer<Listing>
{
    public int Compare(Listing l1, Listing l2)
    {
        return l2.price.CompareTo(l1.price);
    }
}
