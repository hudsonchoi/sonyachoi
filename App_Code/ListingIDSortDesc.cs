﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ListingIDSortDesc
/// </summary>
public class ListingIDSortDesc : IComparer<Listing>
{
    public int Compare(Listing l1, Listing l2)
    {
        return l1.listing_id.CompareTo(l2.listing_id);
    }
}
