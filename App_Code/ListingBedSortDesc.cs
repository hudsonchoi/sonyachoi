﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ListingBathSortDesc
/// </summary>
public class ListingBedSortDesc : IComparer<Listing>
{
    public int Compare(Listing l1, Listing l2)
    {
        return l1.bed.CompareTo(l2.bed);
    }
}
