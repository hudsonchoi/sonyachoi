﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ListingBathSortAsc
/// </summary>
public class ListingBedSortAsc : IComparer<Listing>
{
    public int Compare(Listing l1, Listing l2)
    {
        return l2.bed.CompareTo(l1.bed);
    }
}
