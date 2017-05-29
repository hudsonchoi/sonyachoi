using System;
using System.Collections;
using System.Data;
using System.Configuration;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
/// <summary>
/// Summary description for ArticleCollection
/// </summary>
[Serializable()]
public class ListingCollection : CollectionBase
{
    public ListingCollection()
    {
    }

    public int Add(Listing l)
    {
        return base.List.Add(l);
    }

    public void Remove(Listing l)
    {
        base.List.Remove(l);
    }

    public Listing this[int index]
    {
        get { return (Listing)base.List[index]; }
        set { base.List[index] = value; }
    }

    
    public void Sort(string strExpression, int iDirection)
    {

        if (strExpression == "price")
        {
            ListingComparer.PriceComparer priceComparer = new ListingComparer.PriceComparer(iDirection);
            InnerList.Sort(priceComparer);
        }
        else if (strExpression == "listing_id")
        {
            ListingComparer.ListingIDComparer listingIDComparer = new ListingComparer.ListingIDComparer(iDirection);
            InnerList.Sort(listingIDComparer);
        }
        else if (strExpression == "city")
        {
            ListingComparer.CityComparer cityComparer = new ListingComparer.CityComparer(iDirection);
            InnerList.Sort(cityComparer);
        }
        //else if (strExpression == "creationDate")
        //{
        //    cdComparer = new ArticleComparer.CreationDateComparer(iDirection);
        //    InnerList.Sort(cdComparer);
        //}
    }
    
}
