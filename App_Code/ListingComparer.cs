using System;
using System.Collections;
using System.Text;

/// <summary>
/// Summary description for ArticleComparer
/// </summary>
public class ListingComparer
{
    public ListingComparer()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public class PriceComparer : IComparer
    {
        private int iDirection;
        public PriceComparer(int _iDirection)
        {
            iDirection = _iDirection;
        }

        public int Compare(object x, object y)
        {
            Listing l1 = x as Listing;
            Listing l2 = y as Listing;

            switch (iDirection)
            {
                case (int)ListingSortDirection.ASC:
                    return l1.price.CompareTo(l2.price);
                case (int)ListingSortDirection.DESC:
                    return l2.price.CompareTo(l1.price);
                default:
                    return 0;

            }
        }
    }

    public class ListingIDComparer : IComparer
    {
        private int iDirection;
        public ListingIDComparer(int _iDirection)
        {
            iDirection = _iDirection;
        }

        public int Compare(object x, object y)
        {
            Listing l1 = x as Listing;
            Listing l2 = y as Listing;

            switch (iDirection)
            {
                case (int)ListingSortDirection.ASC:
                    return l1.listing_id.CompareTo(l2.listing_id);
                case (int)ListingSortDirection.DESC:
                    return l2.listing_id.CompareTo(l1.listing_id);
                default:
                    return 0;

            }
        }
    }

    public class CityComparer : IComparer
    {
        private int iDirection;
        public CityComparer(int _iDirection)
        {
            iDirection = _iDirection;
        }

        public int Compare(object x, object y)
        {
            Listing l1 = x as Listing;
            Listing l2 = y as Listing;

            switch (iDirection)
            {
                case (int)ListingSortDirection.ASC:
                    return l1.city.CompareTo(l2.city);
                case (int)ListingSortDirection.DESC:
                    return l2.city.CompareTo(l1.city);
                default:
                    return 0;

            }
        }
    }
}

public enum ListingSortDirection
{
    ASC = 0,
    DESC = 1

}
