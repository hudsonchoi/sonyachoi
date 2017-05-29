using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ListingPriceSort
/// </summary>
public class ListingPriceSortDesc : IComparer<Listing>
{
    public int Compare(Listing l1, Listing l2)
    {
        return l1.price.CompareTo(l2.price);
    }

}
