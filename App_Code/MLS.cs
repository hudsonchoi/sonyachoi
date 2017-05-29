using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for MLS
/// </summary>
[Serializable()]
public class MLS
{

	public MLS()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public ListingCollection getFeaturedListings(string target)
    {
        ds_mainTableAdapters.listingTableAdapter listingTA = new ds_mainTableAdapters.listingTableAdapter();
        ds_main.listingDataTable listingDT = listingTA.GetFeaturedListing();
        ListingCollection lc = new ListingCollection();

        ds_mainTableAdapters.x_listing_typeTableAdapter x_listing_typeTA = new ds_mainTableAdapters.x_listing_typeTableAdapter();

        for (int i = 0; i < listingDT.Rows.Count; i++)
        {
            //sbCode.Append(listingDT.Rows[i]["listing_id"] + ":" + listingDT.Rows[i]["num_of_images"]);
            Listing l = new Listing();
            l.listing_id = Convert.ToInt32(listingDT.Rows[i]["listing_id"]);
            if (listingDT.Rows[i]["price"].ToString()!= ""){
                l.price = String.Format("{0:$0,0}", Convert.ToDecimal(listingDT.Rows[i]["price"].ToString()));
            }
            
            l.city = listingDT.Rows[i]["city"].ToString();
            l.selling_point = listingDT.Rows[i]["selling_point"].ToString();

            StringBuilder sbCode = new StringBuilder();
            for (int j = 1; j <= Convert.ToInt32(listingDT.Rows[i]["num_of_images"]); j++)
            {
                sbCode.Append("<script>var img" + listingDT.Rows[i]["listing_id"] + "_" + j + "_" +
                   listingDT.Rows[i]["listing_id"] + "Sized = false</script>");
            }

            sbCode.Append("<script>");
            sbCode.Append("var AllDone" + listingDT.Rows[i]["listing_id"] + " = false;");
            sbCode.Append("function MyNav() {");
            sbCode.Append("imgL" + listingDT.Rows[i]["listing_id"] + " = new Image();");
            sbCode.Append("imgL" + listingDT.Rows[i]["listing_id"] +
                ".src = \"/images/buttons/NavLeft.gif\";");
            sbCode.Append("imgL" + listingDT.Rows[i]["listing_id"] + "On = new Image();");
            sbCode.Append("imgL" + listingDT.Rows[i]["listing_id"] +
                "On.src = \"/images/buttons/NavLeftOn.gif\";");
            sbCode.Append("imgR" + listingDT.Rows[i]["listing_id"] + " = new Image();");
            sbCode.Append("imgR" + listingDT.Rows[i]["listing_id"] +
                ".src = \"/images/buttons/NavRight.gif\";");
            sbCode.Append("imgR" + listingDT.Rows[i]["listing_id"] + "On = new Image();");
            sbCode.Append("imgR" + listingDT.Rows[i]["listing_id"] +
                "On.src = \"/images/buttons/NavRight.gif\";");
            sbCode.Append("}");

            sbCode.Append("function Prepare" + listingDT.Rows[i]["listing_id"] + "(){");
            sbCode.Append("img" + listingDT.Rows[i]["listing_id"] + "_1_" + listingDT.Rows[i]["listing_id"] + " = new Image();");
            //sbCode.Append("img" + listingDT.Rows[i]["listing_id"] + "_1_" + listingDT.Rows[i]["listing_id"] +
            //    ".src = \"http://www.priv.njmls.xmlsweb.com//Images/MLS_Photos/320/" + listingDT.Rows[i]["path"] + "/" +
            //    listingDT.Rows[i]["listing_id"] + ".1.jpg?ts=" + listingDT.Rows[i]["ts"] + "\";");
            sbCode.Append("img" + listingDT.Rows[i]["listing_id"] + "_1_" + listingDT.Rows[i]["listing_id"] +
                ".src = \"http://pxlimages.xmlsweb.com/NJMLS/M/Images/" + listingDT.Rows[i]["listing_id"] + ".1.jpg\";");
        
            sbCode.Append("img" + listingDT.Rows[i]["listing_id"] + "_1_" + listingDT.Rows[i]["listing_id"] + ".title = \"\";}");

            sbCode.Append("function TurnOn(strImg)	{");
            sbCode.Append("strImgStatus = strImg + \"On\";");
            sbCode.Append("}");
            sbCode.Append("function TurnOff(strImg)	{");
            sbCode.Append("}");

            sbCode.Append("function LoadImages" + listingDT.Rows[i]["listing_id"] + "()	{");
            for (int j = 2; j <= Convert.ToInt32(listingDT.Rows[i]["num_of_images"]); j++)
            {
                sbCode.Append("img" + listingDT.Rows[i]["listing_id"] + "_" + j + "_" + listingDT.Rows[i]["listing_id"] + " = new Image();");
                //sbCode.Append("img" + listingDT.Rows[i]["listing_id"] + "_" + j + "_" + listingDT.Rows[i]["listing_id"] + ".src = \"http://www.priv.njmls.xmlsweb.com/Images/MLS_Photos/320/" + listingDT.Rows[i]["path"] + "/" + listingDT.Rows[i]["listing_id"] + "." + j + ".jpg\";");
                sbCode.Append("img" + listingDT.Rows[i]["listing_id"] + "_" + j + "_" + listingDT.Rows[i]["listing_id"] + ".src = \"http://pxlimages.xmlsweb.com/NJMLS/M/Images/" + listingDT.Rows[i]["listing_id"] + "." + j + ".jpg\";");
                sbCode.Append("img" + listingDT.Rows[i]["listing_id"] + "_" + j + "_" + listingDT.Rows[i]["listing_id"] + ".title = \"\";");
            }
            sbCode.Append("AllDone" + listingDT.Rows[i]["listing_id"] + " =true;");
            sbCode.Append("}");


            sbCode.Append("function GoForward" + listingDT.Rows[i]["listing_id"] + "(strImg,strSpan)	{");
            sbCode.Append("if (AllDone" + listingDT.Rows[i]["listing_id"] + ") {");
            sbCode.Append("switch (document.getElementById(strImg).src)	{");
            for (int j = 1; j <= Convert.ToInt32(listingDT.Rows[i]["num_of_images"]); j++)
            {
                sbCode.Append("case img" + listingDT.Rows[i]["listing_id"] + "_" + j + "_" + listingDT.Rows[i]["listing_id"] + ".src:");
                if (j < Convert.ToInt32(listingDT.Rows[i]["num_of_images"]))
                {
                    sbCode.Append("document.getElementById(strImg).src = img" + listingDT.Rows[i]["listing_id"] + "_" + (j + 1) + "_" + listingDT.Rows[i]["listing_id"] + ".src;");
                    //sbCode.Append("document.getElementById(strSpan).innerText = \" Caption " + j + "\";");
                    //sbCode.Append("document.getElementById(strSpan).textContent = \" Caption " + j + "\";");
                    sbCode.Append("document.getElementById(\"I" + listingDT.Rows[i]["listing_id"] + "\").innerText = \"" + (j + 1) + "\";");
                    sbCode.Append("document.getElementById(\"I" + listingDT.Rows[i]["listing_id"] + "\").textContent = \"" + (j + 1) + "\";");
                }
                else
                {
                    sbCode.Append("document.getElementById(strImg).src = img" + listingDT.Rows[i]["listing_id"] + "_" + 1 + "_" + listingDT.Rows[i]["listing_id"] + ".src;");
                    //sbCode.Append("document.getElementById(strSpan).innerText = \" Caption " + j + "\";");
                    //sbCode.Append("document.getElementById(strSpan).textContent = \" Caption " + j + "\";");
                    sbCode.Append("document.getElementById(\"I" + listingDT.Rows[i]["listing_id"] + "\").innerText = \"" + 1 + "\";");
                    sbCode.Append("document.getElementById(\"I" + listingDT.Rows[i]["listing_id"] + "\").textContent = \"" + 1 + "\";");
                }
                sbCode.Append("break;");
            }
            sbCode.Append("}}else{");
            sbCode.Append("LoadImages" + listingDT.Rows[i]["listing_id"] + "();");
            sbCode.Append("GoForward" + listingDT.Rows[i]["listing_id"] + "(strImg,strSpan);");
            sbCode.Append("}}");


            sbCode.Append("function GoBackward" + listingDT.Rows[i]["listing_id"] + "(strImg,strSpan){");
            sbCode.Append("if (AllDone" + listingDT.Rows[i]["listing_id"] + "){");
            sbCode.Append("switch (document.getElementById(strImg).src)	{");
            for (int j = 1; j <= Convert.ToInt32(listingDT.Rows[i]["num_of_images"]); j++)
            {
                sbCode.Append("case img" + listingDT.Rows[i]["listing_id"] + "_" + j + "_" + listingDT.Rows[i]["listing_id"] + ".src:");
                if (j == 1)
                {
                    sbCode.Append("document.getElementById(strImg).src = img" + listingDT.Rows[i]["listing_id"] + "_" + listingDT.Rows[i]["num_of_images"] + "_" + listingDT.Rows[i]["listing_id"] + ".src;");
                    //sbCode.Append("document.getElementById(strSpan).innerText = \" CAPTION " + j + " \";");
                    //sbCode.Append("document.getElementById(strSpan).textContent = \" CAPTION " + j + " \";");
                    sbCode.Append("document.getElementById(\"I" + listingDT.Rows[i]["listing_id"] + "\").innerText = \"" + listingDT.Rows[i]["num_of_images"] + "\";");
                    sbCode.Append("document.getElementById(\"I" + listingDT.Rows[i]["listing_id"] + "\").textContent = \"" + listingDT.Rows[i]["num_of_images"] + "\";");
                }
                else
                {
                    sbCode.Append("document.getElementById(strImg).src = img" + listingDT.Rows[i]["listing_id"] + "_" + (j - 1) + "_" + listingDT.Rows[i]["listing_id"] + ".src;");
                    //sbCode.Append("document.getElementById(strSpan).innerText = \" CAPTION " + j + " \";");
                    //sbCode.Append("document.getElementById(strSpan).textContent = \" CAPTION " + j + " \";");
                    sbCode.Append("document.getElementById(\"I" + listingDT.Rows[i]["listing_id"] + "\").innerText = \"" + (j - 1) + "\";");
                    sbCode.Append("document.getElementById(\"I" + listingDT.Rows[i]["listing_id"] + "\").textContent = \"" + (j - 1) + "\";");

                }
                sbCode.Append("break;");
            }

            sbCode.Append("}}else{");
            sbCode.Append("LoadImages" + listingDT.Rows[i]["listing_id"] + "();");
            sbCode.Append("GoBackward" + listingDT.Rows[i]["listing_id"] + "(strImg,strSpan);");
            sbCode.Append("}}");

            sbCode.Append("MyNav();");
            sbCode.Append("Prepare" + listingDT.Rows[i]["listing_id"] + "();");
            sbCode.Append("LoadImages" + listingDT.Rows[i]["listing_id"] + "();");
            sbCode.Append("</script>");

            sbCode.Append("<table noresize width=\"323\" height=\"243\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">");
            sbCode.Append("<tr><td colspan=\"3\" valign=\"middle\" align=\"center\">");
            sbCode.Append("<div class=\"frame\">");
            sbCode.Append("<table cellspacing=\"0\" cellpadding=\"0\" width=\"320\" height=\"240\" border=\"3\" noresize bgcolor=\"#F0F0F0\"><tr>");
            sbCode.Append("<td align=\"center\" valign=\"middle\">");

            ds_main.x_listing_typeDataTable x_listing_TypeDT = x_listing_typeTA.GetDataByListingID(Convert.ToInt32(listingDT.Rows[i]["listing_id"]));
            foreach (ds_main.x_listing_typeRow r in x_listing_TypeDT.Rows)
            {
                if (r.type_id == 100)
                {
                    l.price = String.Format("{0:$0,0}", Convert.ToDecimal(r.price.ToString()));
                    sbCode.Append("<a href=\""+target+".aspx?id=" + listingDT.Rows[i]["listing_id"] + "&type_id="+r.type_id+"\" title=\"클릭하시면 확대됩니다\">");
                    break;
                }
                else if (r.type_id == 200)
                {
                    l.price = String.Format("{0:$0,0}", Convert.ToDecimal(r.price.ToString())) + "/month";
                    sbCode.Append("<a href=\"" + target + ".aspx?id=" + listingDT.Rows[i]["listing_id"] + "&type_id=" + r.type_id + "\" title=\"클릭하시면 확대됩니다\">");
                }
            }


            //sbCode.Append("<img src=\"http://www.priv.njmls.xmlsweb.com/Images/MLS_Photos/320/" + listingDT.Rows[i]["path"] + "/" + listingDT.Rows[i]["listing_id"] + ".1.jpg?ts=" + listingDT.Rows[i]["ts"] + "\" onError=\"src='http://www.priv.njmls.xmlsweb.com/Images/MLS_Photos/NoPhoto.1.jpg'\" id=\"Photo" + listingDT.Rows[i]["listing_id"] + "\" border=0></a></td></tr>");
            sbCode.Append("<img src=\"http://pxlimages.xmlsweb.com/NJMLS/M/Images/" + listingDT.Rows[i]["listing_id"] + ".1.jpg\" onError=\"src='http://www.priv.njmls.xmlsweb.com/Images/MLS_Photos/NoPhoto.1.jpg'\" id=\"Photo" + listingDT.Rows[i]["listing_id"] + "\" border=0></a></td></tr>");
            sbCode.Append("</table></div></td></tr>");
            //sbCode.Append("<tr class=np><td colspan=\"3\" align=\"center\" valign=\"middle\">&nbsp;</td></tr>");
            //sbCode.Append("<tr class=np><td colspan=\"3\" align=\"center\" valign=\"middle\"><span class=\"ImageDescription\" id=\"ImageDescription" + listingDT.Rows[i]["listing_id"] + "\">&nbsp;FRONT&nbsp;</span></td></tr>");
            sbCode.Append("<tr class=np><td align=\"center\"><table border=\"0\"><tr><td size=\"30\" height=\"25\">");
            sbCode.Append("<img src=\"/images/buttons/NavLeft.gif\" title=\"\" name=\"imgL" + listingDT.Rows[i]["listing_id"] + "\" onMouseOver=\"\" onMouseOut=\"\" onClick=\"GoBackward" + listingDT.Rows[i]["listing_id"] + "('Photo" + listingDT.Rows[i]["listing_id"] + "','ImageDescription" + listingDT.Rows[i]["listing_id"] + "');\" WIDTH=\"19\" HEIGHT=\"19\" class=\"nav\"></td>");
            sbCode.Append("<td align=\"center\"><span class=\"I\">&nbsp;Image&nbsp;</span><span class=\"I\" id=\"I" + listingDT.Rows[i]["listing_id"] + "\">1</span><span class=\"I\">&nbsp;of&nbsp;" + listingDT.Rows[i]["num_of_images"] + "&nbsp;</span></td>");
            sbCode.Append("<td size=\"30\" align=\"right\"><img src=\"/images/buttons/NavRight.gif\" title=\"\" name=\"imgR" + listingDT.Rows[i]["listing_id"] + "\" onMouseOver=\"\" onMouseOut=\"\" onClick=\"GoForward" + listingDT.Rows[i]["listing_id"] + "('Photo" + listingDT.Rows[i]["listing_id"] + "','ImageDescription" + listingDT.Rows[i]["listing_id"] + "');\" WIDTH=\"19\" HEIGHT=\"19\" class=\"nav\"></td>");
            sbCode.Append("</tr></table></td></tr></table>");



            l.image_gallery = sbCode.ToString();



            //if (listingDT.Rows[i]["price"].ToString() != "")
            //{
            //    l.price = String.Format("{0:$0,0}", Convert.ToDecimal(listingDT.Rows[i]["price"].ToString()));
            //}

            if (listingDT.Rows[i]["city"].ToString() != "")
            {
                l.city = listingDT.Rows[i]["city"].ToString();
            }
            if (listingDT.Rows[i]["selling_point"].ToString() != "")
            {
                l.selling_point = listingDT.Rows[i]["selling_point"].ToString();
            }
            if (listingDT.Rows[i]["style"].ToString() != "")
            {
                l.style = listingDT.Rows[i]["style"].ToString();
            }
            if (listingDT.Rows[i]["bed"].ToString() != "")
            {
                l.bed = Convert.ToByte(listingDT.Rows[i]["bed"].ToString());
            }
            if (listingDT.Rows[i]["bath"].ToString() != "")
            {
                l.bath = listingDT.Rows[i]["bath"].ToString();
            }

            if (listingDT.Rows[i]["status"].ToString() == "0")
            {
                l.status_image = "/images/sale.png";
            }
            else if (listingDT.Rows[i]["status"].ToString() == "1")
            {
                l.status_image = "/images/undercontract.png";
            }
            else if (listingDT.Rows[i]["status"].ToString() == "2")
            {
                l.status_image = "/images/sold.png";
            }
            else if (listingDT.Rows[i]["status"].ToString() == "3")
            {
                l.status_image = "/images/leased.png";
            }
            lc.Add(l);
        }

        return lc;
    }

    public ListingCollection getRents(string strLinkTo)
    {
        ds_mainTableAdapters.listingTableAdapter listingTA = new ds_mainTableAdapters.listingTableAdapter();
        ds_main.listingDataTable listingDT = listingTA.GetData();
        ListingCollection lc = new ListingCollection();

        for (int i = 0; i < listingDT.Rows.Count; i++)
        {
            //sbCode.Append(listingDT.Rows[i]["listing_id"] + ":" + listingDT.Rows[i]["num_of_images"]);
            Listing l = new Listing();
            l.listing_id = Convert.ToInt32(listingDT.Rows[i]["listing_id"]);
            if (i == listingDT.Rows.Count - 1)
            {
                l.down_style = "display:none";
            }
            else
            {
                l.next_listing_id = Convert.ToInt32(listingDT.Rows[i + 1]["listing_id"]);
            }
            if (i == 0)
            {
                l.up_style = "display:none";
            }
            else
            {
                l.prev_listing_id = Convert.ToInt32(listingDT.Rows[i - 1]["listing_id"]);
            }
 


            StringBuilder sbCode = new StringBuilder();
            for (int j = 1; j <= Convert.ToInt32(listingDT.Rows[i]["num_of_images"]); j++)
            {
                sbCode.Append("<script>var img" + listingDT.Rows[i]["listing_id"] + "_" + j + "_" +
                   listingDT.Rows[i]["listing_id"] + "Sized = false</script>");
            }

            sbCode.Append("<script>");
            sbCode.Append("var AllDone" + listingDT.Rows[i]["listing_id"] + " = false;");
            sbCode.Append("function MyNav() {");
            sbCode.Append("imgL" + listingDT.Rows[i]["listing_id"] + " = new Image();");
            sbCode.Append("imgL" + listingDT.Rows[i]["listing_id"] +
                ".src = \"/images/buttons/NavLeft.gif\";");
            sbCode.Append("imgL" + listingDT.Rows[i]["listing_id"] + "On = new Image();");
            sbCode.Append("imgL" + listingDT.Rows[i]["listing_id"] +
                "On.src = \"/images/buttons/NavLeftOn.gif\";");
            sbCode.Append("imgR" + listingDT.Rows[i]["listing_id"] + " = new Image();");
            sbCode.Append("imgR" + listingDT.Rows[i]["listing_id"] +
                ".src = \"/images/buttons/NavRight.gif\";");
            sbCode.Append("imgR" + listingDT.Rows[i]["listing_id"] + "On = new Image();");
            sbCode.Append("imgR" + listingDT.Rows[i]["listing_id"] +
                "On.src = \"/images/buttons/NavRight.gif\";");
            sbCode.Append("}");

            sbCode.Append("function Prepare" + listingDT.Rows[i]["listing_id"] + "(){");
            sbCode.Append("img" + listingDT.Rows[i]["listing_id"] + "_1_" + listingDT.Rows[i]["listing_id"] + " = new Image();");
            sbCode.Append("img" + listingDT.Rows[i]["listing_id"] + "_1_" + listingDT.Rows[i]["listing_id"] +
                ".src = \"http://www.priv.njmls.xmlsweb.com/Images/MLS_Photos/Thumbnails/" + listingDT.Rows[i]["path"] + "/" +
                listingDT.Rows[i]["listing_id"] + ".1.jpg?ts=" + listingDT.Rows[i]["ts"] + "\";");


            sbCode.Append("img" + listingDT.Rows[i]["listing_id"] + "_1_" + listingDT.Rows[i]["listing_id"] + ".title = \"\";}");

            sbCode.Append("function TurnOn(strImg)	{");
            sbCode.Append("strImgStatus = strImg + \"On\";");
            sbCode.Append("}");
            sbCode.Append("function TurnOff(strImg)	{");
            sbCode.Append("}");

            sbCode.Append("function LoadImages" + listingDT.Rows[i]["listing_id"] + "()	{");
            for (int j = 2; j <= Convert.ToInt32(listingDT.Rows[i]["num_of_images"]); j++)
            {
                sbCode.Append("img" + listingDT.Rows[i]["listing_id"] + "_" + j + "_" + listingDT.Rows[i]["listing_id"] + " = new Image();");
                sbCode.Append("img" + listingDT.Rows[i]["listing_id"] + "_" + j + "_" + listingDT.Rows[i]["listing_id"] + ".src = \"http://www.priv.njmls.xmlsweb.com/Images/MLS_Photos/Thumbnails/" + listingDT.Rows[i]["path"] + "/" + listingDT.Rows[i]["listing_id"] + "." + j + ".jpg\";");
                sbCode.Append("img" + listingDT.Rows[i]["listing_id"] + "_" + j + "_" + listingDT.Rows[i]["listing_id"] + ".title = \"\";");
            }
            sbCode.Append("AllDone" + listingDT.Rows[i]["listing_id"] + " =true;");
            sbCode.Append("}");


            sbCode.Append("function GoForward" + listingDT.Rows[i]["listing_id"] + "(strImg,strSpan)	{");
            sbCode.Append("if (AllDone" + listingDT.Rows[i]["listing_id"] + ") {");
            sbCode.Append("switch (document.getElementById(strImg).src)	{");
            for (int j = 1; j <= Convert.ToInt32(listingDT.Rows[i]["num_of_images"]); j++)
            {
                sbCode.Append("case img" + listingDT.Rows[i]["listing_id"] + "_" + j + "_" + listingDT.Rows[i]["listing_id"] + ".src:");
                if (j < Convert.ToInt32(listingDT.Rows[i]["num_of_images"]))
                {
                    sbCode.Append("document.getElementById(strImg).src = img" + listingDT.Rows[i]["listing_id"] + "_" + (j + 1) + "_" + listingDT.Rows[i]["listing_id"] + ".src;");
                    //sbCode.Append("document.getElementById(strSpan).innerText = \" Caption " + j + "\";");
                    //sbCode.Append("document.getElementById(strSpan).textContent = \" Caption " + j + "\";");
                    sbCode.Append("document.getElementById(\"I" + listingDT.Rows[i]["listing_id"] + "\").innerText = \"" + (j + 1) + "\";");
                    sbCode.Append("document.getElementById(\"I" + listingDT.Rows[i]["listing_id"] + "\").textContent = \"" + (j + 1) + "\";");
                }
                else
                {
                    sbCode.Append("document.getElementById(strImg).src = img" + listingDT.Rows[i]["listing_id"] + "_" + 1 + "_" + listingDT.Rows[i]["listing_id"] + ".src;");
                    //sbCode.Append("document.getElementById(strSpan).innerText = \" Caption " + j + "\";");
                    //sbCode.Append("document.getElementById(strSpan).textContent = \" Caption " + j + "\";");
                    sbCode.Append("document.getElementById(\"I" + listingDT.Rows[i]["listing_id"] + "\").innerText = \"" + 1 + "\";");
                    sbCode.Append("document.getElementById(\"I" + listingDT.Rows[i]["listing_id"] + "\").textContent = \"" + 1 + "\";");
                }
                sbCode.Append("break;");
            }
            sbCode.Append("}}else{");
            sbCode.Append("LoadImages" + listingDT.Rows[i]["listing_id"] + "();");
            sbCode.Append("GoForward" + listingDT.Rows[i]["listing_id"] + "(strImg,strSpan);");
            sbCode.Append("}}");


            sbCode.Append("function GoBackward" + listingDT.Rows[i]["listing_id"] + "(strImg,strSpan){");
            sbCode.Append("if (AllDone" + listingDT.Rows[i]["listing_id"] + "){");
            sbCode.Append("switch (document.getElementById(strImg).src)	{");
            for (int j = 1; j <= Convert.ToInt32(listingDT.Rows[i]["num_of_images"]); j++)
            {
                sbCode.Append("case img" + listingDT.Rows[i]["listing_id"] + "_" + j + "_" + listingDT.Rows[i]["listing_id"] + ".src:");
                if (j == 1)
                {
                    sbCode.Append("document.getElementById(strImg).src = img" + listingDT.Rows[i]["listing_id"] + "_" + listingDT.Rows[i]["num_of_images"] + "_" + listingDT.Rows[i]["listing_id"] + ".src;");
                    //sbCode.Append("document.getElementById(strSpan).innerText = \" CAPTION " + j + " \";");
                    //sbCode.Append("document.getElementById(strSpan).textContent = \" CAPTION " + j + " \";");
                    sbCode.Append("document.getElementById(\"I" + listingDT.Rows[i]["listing_id"] + "\").innerText = \"" + listingDT.Rows[i]["num_of_images"] + "\";");
                    sbCode.Append("document.getElementById(\"I" + listingDT.Rows[i]["listing_id"] + "\").textContent = \"" + listingDT.Rows[i]["num_of_images"] + "\";");
                }
                else
                {
                    sbCode.Append("document.getElementById(strImg).src = img" + listingDT.Rows[i]["listing_id"] + "_" + (j - 1) + "_" + listingDT.Rows[i]["listing_id"] + ".src;");
                    //sbCode.Append("document.getElementById(strSpan).innerText = \" CAPTION " + j + " \";");
                    //sbCode.Append("document.getElementById(strSpan).textContent = \" CAPTION " + j + " \";");
                    sbCode.Append("document.getElementById(\"I" + listingDT.Rows[i]["listing_id"] + "\").innerText = \"" + (j - 1) + "\";");
                    sbCode.Append("document.getElementById(\"I" + listingDT.Rows[i]["listing_id"] + "\").textContent = \"" + (j - 1) + "\";");

                }
                sbCode.Append("break;");
            }

            sbCode.Append("}}else{");
            sbCode.Append("LoadImages" + listingDT.Rows[i]["listing_id"] + "();");
            sbCode.Append("GoBackward" + listingDT.Rows[i]["listing_id"] + "(strImg,strSpan);");
            sbCode.Append("}}");

            sbCode.Append("MyNav();");
            sbCode.Append("Prepare" + listingDT.Rows[i]["listing_id"] + "();");
            sbCode.Append("LoadImages" + listingDT.Rows[i]["listing_id"] + "();");
            sbCode.Append("</script>");

            sbCode.Append("<table noresize width=\"160\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">");
            sbCode.Append("<tr><td colspan=\"3\" valign=\"middle\" align=\"center\">");
            sbCode.Append("<table cellspacing=\"0\" cellpadding=\"0\" width=\"160\" border=\"1\" noresize bgcolor=\"#F0F0F0\"><tr>");
            sbCode.Append("<td align=\"center\" valign=\"middle\">");
            sbCode.Append("<a href=\"" + strLinkTo + ".aspx?id=" + listingDT.Rows[i]["listing_id"] + "\"><img src=\"http://www.priv.njmls.xmlsweb.com/Images/MLS_Photos/Thumbnails/" + listingDT.Rows[i]["path"] + "/" + listingDT.Rows[i]["listing_id"] + ".1.jpg?ts=" + listingDT.Rows[i]["ts"] + "\" onError=\"src='http://www.priv.njmls.xmlsweb.com/Images/MLS_Photos/Thumbnails/NoPhoto.1.jpg'\" id=\"Photo" + listingDT.Rows[i]["listing_id"] + "\" border=0></a></td></tr>");
            sbCode.Append("</table></td></tr>");
            //sbCode.Append("<tr class=np><td colspan=\"3\" align=\"center\" valign=\"middle\">&nbsp;</td></tr>");
            //sbCode.Append("<tr class=np><td colspan=\"3\" align=\"center\" valign=\"middle\"><span class=\"ImageDescription\" id=\"ImageDescription" + listingDT.Rows[i]["listing_id"] + "\">&nbsp;FRONT&nbsp;</span></td></tr>");
            sbCode.Append("<tr class=np><td size=\"30\" height=\"25\">");
            sbCode.Append("<img src=\"/images/buttons/NavLeft.gif\" title=\"\" name=\"imgL" + listingDT.Rows[i]["listing_id"] + "\" onMouseOver=\"\" onMouseOut=\"\" onClick=\"GoBackward" + listingDT.Rows[i]["listing_id"] + "('Photo" + listingDT.Rows[i]["listing_id"] + "','ImageDescription" + listingDT.Rows[i]["listing_id"] + "');\" WIDTH=\"19\" HEIGHT=\"19\" class=\"nav\"></td>");
            sbCode.Append("<td align=\"center\"><span class=\"I\">&nbsp;Image&nbsp;</span><span class=\"I\" id=\"I" + listingDT.Rows[i]["listing_id"] + "\">1</span><span class=\"I\">&nbsp;of&nbsp;" + listingDT.Rows[i]["num_of_images"] + "&nbsp;</span></td>");
            sbCode.Append("<td size=\"30\" align=\"right\"><img src=\"/images/buttons/NavRight.gif\" title=\"\" name=\"imgR" + listingDT.Rows[i]["listing_id"] + "\" onMouseOver=\"\" onMouseOut=\"\" onClick=\"GoForward" + listingDT.Rows[i]["listing_id"] + "('Photo" + listingDT.Rows[i]["listing_id"] + "','ImageDescription" + listingDT.Rows[i]["listing_id"] + "');\" WIDTH=\"19\" HEIGHT=\"19\" class=\"nav\"></td>");
            sbCode.Append("</tr></table>");

            l.image_gallery = sbCode.ToString();
            if (listingDT.Rows[i]["price"].ToString() != "")
            {
                l.price = String.Format("{0:$0,0}", Convert.ToDecimal(listingDT.Rows[i]["price"].ToString()));
            }
            if (listingDT.Rows[i]["city"].ToString() != "")
            {
                l.city = listingDT.Rows[i]["city"].ToString();
            }
            if (listingDT.Rows[i]["selling_point"].ToString() != "")
            {
                l.selling_point = listingDT.Rows[i]["selling_point"].ToString();
            }
            if (listingDT.Rows[i]["style"].ToString() != "")
            {
                l.style = listingDT.Rows[i]["style"].ToString();
            }
            if (listingDT.Rows[i]["bed"].ToString() != "")
            {
                l.bed = Convert.ToByte(listingDT.Rows[i]["bed"].ToString());
            }
            if (listingDT.Rows[i]["bath"].ToString() != "")
            {
                l.bath = listingDT.Rows[i]["bath"].ToString();
            }

            if (listingDT.Rows[i]["sort"].ToString() != "")
            {
                l.sort = Convert.ToInt32(listingDT.Rows[i]["sort"].ToString());
            }

            if (listingDT.Rows[i]["featured"].ToString() != "")
            {
                l.featured = Convert.ToBoolean(listingDT.Rows[i]["featured"].ToString());
            }

            if (listingDT.Rows[i]["status"].ToString() != "")
            {
                l.status = Convert.ToInt32(listingDT.Rows[i]["status"].ToString());
            }
            lc.Add(l);
        }

        return lc;
    }

    public List<Listing> getListingsByTypeID(int typeID, string strLinkTo)
    {
        ds_mainTableAdapters.listingTableAdapter listingTA = new ds_mainTableAdapters.listingTableAdapter();
        ds_main.listingDataTable listingDT = listingTA.GetDataByTypeID(typeID);
        return getData4FrontEnd(listingDT, strLinkTo, typeID);
    }

    public List<Listing> getFeaturedListingsToAdmin()
    {
        ds_mainTableAdapters.listingTableAdapter listingTA = new ds_mainTableAdapters.listingTableAdapter();
        ds_main.listingDataTable listingDT = listingTA.GetFeaturedListing();
        return getData4FrontEnd(listingDT, "edit", 0);

    }

    public List<Listing> getData4FrontEnd(ds_main.listingDataTable listingDT, string strLinkTo, int typeID)
    {
        List<Listing> lListing = new List<Listing>();
        for (int i = 0; i < listingDT.Rows.Count; i++)
        {
            //sbCode.Append(listingDT.Rows[i]["listing_id"] + ":" + listingDT.Rows[i]["num_of_images"]);
            Listing l = new Listing();
            l.listing_id = Convert.ToInt32(listingDT.Rows[i]["listing_id"]);
            if (i == listingDT.Rows.Count - 1)
            {
                l.down_style = "display:none";
            }
            else
            {
                l.next_listing_id = Convert.ToInt32(listingDT.Rows[i + 1]["listing_id"]);
            }
            if (i == 0)
            {
                l.up_style = "display:none";
            }
            else
            {
                l.prev_listing_id = Convert.ToInt32(listingDT.Rows[i - 1]["listing_id"]);
            }



            StringBuilder sbCode = new StringBuilder();
            for (int j = 1; j <= Convert.ToInt32(listingDT.Rows[i]["num_of_images"]); j++)
            {
                sbCode.Append("<script>var img" + listingDT.Rows[i]["listing_id"] + "_" + j + "_" +
                   listingDT.Rows[i]["listing_id"] + "Sized = false</script>");
            }

            sbCode.Append("<script>");
            sbCode.Append("var AllDone" + listingDT.Rows[i]["listing_id"] + " = false;");
            sbCode.Append("function MyNav() {");
            sbCode.Append("imgL" + listingDT.Rows[i]["listing_id"] + " = new Image();");
            sbCode.Append("imgL" + listingDT.Rows[i]["listing_id"] +
                ".src = \"/images/buttons/NavLeft.gif\";");
            sbCode.Append("imgL" + listingDT.Rows[i]["listing_id"] + "On = new Image();");
            sbCode.Append("imgL" + listingDT.Rows[i]["listing_id"] +
                "On.src = \"/images/buttons/NavLeftOn.gif\";");
            sbCode.Append("imgR" + listingDT.Rows[i]["listing_id"] + " = new Image();");
            sbCode.Append("imgR" + listingDT.Rows[i]["listing_id"] +
                ".src = \"/images/buttons/NavRight.gif\";");
            sbCode.Append("imgR" + listingDT.Rows[i]["listing_id"] + "On = new Image();");
            sbCode.Append("imgR" + listingDT.Rows[i]["listing_id"] +
                "On.src = \"/images/buttons/NavRight.gif\";");
            sbCode.Append("}");

            sbCode.Append("function Prepare" + listingDT.Rows[i]["listing_id"] + "(){");
            sbCode.Append("img" + listingDT.Rows[i]["listing_id"] + "_1_" + listingDT.Rows[i]["listing_id"] + " = new Image();");
            //sbCode.Append("img" + listingDT.Rows[i]["listing_id"] + "_1_" + listingDT.Rows[i]["listing_id"] +
            //    ".src = \"http://www.priv.njmls.xmlsweb.com/Images/MLS_Photos/Thumbnails/" + listingDT.Rows[i]["path"] + "/" +
            //    listingDT.Rows[i]["listing_id"] + ".1.jpg?ts=" + listingDT.Rows[i]["ts"] + "\";");

            sbCode.Append("img" + listingDT.Rows[i]["listing_id"] + "_1_" + listingDT.Rows[i]["listing_id"] +
                ".src = \"http://pxlimages.xmlsweb.com/NJMLS/T/Images/"  +
                listingDT.Rows[i]["listing_id"] + ".1.jpg\";");


            sbCode.Append("img" + listingDT.Rows[i]["listing_id"] + "_1_" + listingDT.Rows[i]["listing_id"] + ".title = \"\";}");

            sbCode.Append("function TurnOn(strImg)	{");
            sbCode.Append("strImgStatus = strImg + \"On\";");
            sbCode.Append("}");
            sbCode.Append("function TurnOff(strImg)	{");
            sbCode.Append("}");

            sbCode.Append("function LoadImages" + listingDT.Rows[i]["listing_id"] + "()	{");
            for (int j = 2; j <= Convert.ToInt32(listingDT.Rows[i]["num_of_images"]); j++)
            {
                sbCode.Append("img" + listingDT.Rows[i]["listing_id"] + "_" + j + "_" + listingDT.Rows[i]["listing_id"] + " = new Image();");
                //sbCode.Append("img" + listingDT.Rows[i]["listing_id"] + "_" + j + "_" + listingDT.Rows[i]["listing_id"] + ".src = \"http://www.priv.njmls.xmlsweb.com/Images/MLS_Photos/Thumbnails/" + listingDT.Rows[i]["path"] + "/" + listingDT.Rows[i]["listing_id"] + "." + j + ".jpg\";");
                sbCode.Append("img" + listingDT.Rows[i]["listing_id"] + "_" + j + "_" + listingDT.Rows[i]["listing_id"] + ".src = \"http://pxlimages.xmlsweb.com/NJMLS/T/Images/" + listingDT.Rows[i]["listing_id"] + "." + j + ".jpg\";");
                sbCode.Append("img" + listingDT.Rows[i]["listing_id"] + "_" + j + "_" + listingDT.Rows[i]["listing_id"] + ".title = \"\";");
            }
            sbCode.Append("AllDone" + listingDT.Rows[i]["listing_id"] + " =true;");
            sbCode.Append("}");


            sbCode.Append("function GoForward" + listingDT.Rows[i]["listing_id"] + "(strImg,strSpan)	{");
            sbCode.Append("if (AllDone" + listingDT.Rows[i]["listing_id"] + ") {");
            sbCode.Append("switch (document.getElementById(strImg).src)	{");
            for (int j = 1; j <= Convert.ToInt32(listingDT.Rows[i]["num_of_images"]); j++)
            {
                sbCode.Append("case img" + listingDT.Rows[i]["listing_id"] + "_" + j + "_" + listingDT.Rows[i]["listing_id"] + ".src:");
                if (j < Convert.ToInt32(listingDT.Rows[i]["num_of_images"]))
                {
                    sbCode.Append("document.getElementById(strImg).src = img" + listingDT.Rows[i]["listing_id"] + "_" + (j + 1) + "_" + listingDT.Rows[i]["listing_id"] + ".src;");
                    //sbCode.Append("document.getElementById(strSpan).innerText = \" Caption " + j + "\";");
                    //sbCode.Append("document.getElementById(strSpan).textContent = \" Caption " + j + "\";");
                    sbCode.Append("document.getElementById(\"I" + listingDT.Rows[i]["listing_id"] + "\").innerText = \"" + (j + 1) + "\";");
                    sbCode.Append("document.getElementById(\"I" + listingDT.Rows[i]["listing_id"] + "\").textContent = \"" + (j + 1) + "\";");
                }
                else
                {
                    sbCode.Append("document.getElementById(strImg).src = img" + listingDT.Rows[i]["listing_id"] + "_" + 1 + "_" + listingDT.Rows[i]["listing_id"] + ".src;");
                    //sbCode.Append("document.getElementById(strSpan).innerText = \" Caption " + j + "\";");
                    //sbCode.Append("document.getElementById(strSpan).textContent = \" Caption " + j + "\";");
                    sbCode.Append("document.getElementById(\"I" + listingDT.Rows[i]["listing_id"] + "\").innerText = \"" + 1 + "\";");
                    sbCode.Append("document.getElementById(\"I" + listingDT.Rows[i]["listing_id"] + "\").textContent = \"" + 1 + "\";");
                }
                sbCode.Append("break;");
            }
            sbCode.Append("}}else{");
            sbCode.Append("LoadImages" + listingDT.Rows[i]["listing_id"] + "();");
            sbCode.Append("GoForward" + listingDT.Rows[i]["listing_id"] + "(strImg,strSpan);");
            sbCode.Append("}}");


            sbCode.Append("function GoBackward" + listingDT.Rows[i]["listing_id"] + "(strImg,strSpan){");
            sbCode.Append("if (AllDone" + listingDT.Rows[i]["listing_id"] + "){");
            sbCode.Append("switch (document.getElementById(strImg).src)	{");
            for (int j = 1; j <= Convert.ToInt32(listingDT.Rows[i]["num_of_images"]); j++)
            {
                sbCode.Append("case img" + listingDT.Rows[i]["listing_id"] + "_" + j + "_" + listingDT.Rows[i]["listing_id"] + ".src:");
                if (j == 1)
                {
                    sbCode.Append("document.getElementById(strImg).src = img" + listingDT.Rows[i]["listing_id"] + "_" + listingDT.Rows[i]["num_of_images"] + "_" + listingDT.Rows[i]["listing_id"] + ".src;");
                    //sbCode.Append("document.getElementById(strSpan).innerText = \" CAPTION " + j + " \";");
                    //sbCode.Append("document.getElementById(strSpan).textContent = \" CAPTION " + j + " \";");
                    sbCode.Append("document.getElementById(\"I" + listingDT.Rows[i]["listing_id"] + "\").innerText = \"" + listingDT.Rows[i]["num_of_images"] + "\";");
                    sbCode.Append("document.getElementById(\"I" + listingDT.Rows[i]["listing_id"] + "\").textContent = \"" + listingDT.Rows[i]["num_of_images"] + "\";");
                }
                else
                {
                    sbCode.Append("document.getElementById(strImg).src = img" + listingDT.Rows[i]["listing_id"] + "_" + (j - 1) + "_" + listingDT.Rows[i]["listing_id"] + ".src;");
                    //sbCode.Append("document.getElementById(strSpan).innerText = \" CAPTION " + j + " \";");
                    //sbCode.Append("document.getElementById(strSpan).textContent = \" CAPTION " + j + " \";");
                    sbCode.Append("document.getElementById(\"I" + listingDT.Rows[i]["listing_id"] + "\").innerText = \"" + (j - 1) + "\";");
                    sbCode.Append("document.getElementById(\"I" + listingDT.Rows[i]["listing_id"] + "\").textContent = \"" + (j - 1) + "\";");

                }
                sbCode.Append("break;");
            }

            sbCode.Append("}}else{");
            sbCode.Append("LoadImages" + listingDT.Rows[i]["listing_id"] + "();");
            sbCode.Append("GoBackward" + listingDT.Rows[i]["listing_id"] + "(strImg,strSpan);");
            sbCode.Append("}}");

            sbCode.Append("MyNav();");
            sbCode.Append("Prepare" + listingDT.Rows[i]["listing_id"] + "();");
            sbCode.Append("LoadImages" + listingDT.Rows[i]["listing_id"] + "();");
            sbCode.Append("</script>");

            sbCode.Append("<table noresize width=\"160\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">");
            sbCode.Append("<tr><td colspan=\"3\" valign=\"middle\" align=\"center\">");
            sbCode.Append("<table cellspacing=\"0\" cellpadding=\"0\" width=\"160\" height=\"120\" border=\"1\" noresize bgcolor=\"#F0F0F0\"><tr>");
            sbCode.Append("<td align=\"center\" valign=\"middle\">");
            if (listingDT.Rows[i]["status"].ToString() == "1")
            {
               sbCode.Append("<div style='text-align:center; width:160px; position:relative'>");
               sbCode.Append("<img style='position:absolute; top:80px; left:100px' src='/images/undercontract_small.png' />");
            }
            else if (listingDT.Rows[i]["status"].ToString() == "2")
            {
                sbCode.Append("<div style='text-align:center; width:160px; position:relative'>");
                sbCode.Append("<img style='position:absolute; top:80px; left:100px' src='/images/sold_small.png' />");
            }
            else if (listingDT.Rows[i]["status"].ToString() == "3")
            {
                sbCode.Append("<div style='text-align:center; width:160px; position:relative'>");
                sbCode.Append("<img style='position:absolute; top:80px; left:100px' src='/images/leased_small.png' />");
            }
            if (typeID != 0)
            {
                sbCode.Append("<a href=\"" + strLinkTo + ".aspx?id=" + listingDT.Rows[i]["listing_id"] + "&type_id=" + typeID + "\" title=\"클릭하시면 확대됩니다\">");
            }
            else
            {
                sbCode.Append("<a href=\"" + strLinkTo + ".aspx?id=" + listingDT.Rows[i]["listing_id"] + "\" title=\"클릭하시면 확대됩니다\">");
            }

            //sbCode.Append("<img src=\"http://www.priv.njmls.xmlsweb.com/Images/MLS_Photos/Thumbnails/" + listingDT.Rows[i]["path"] + "/" + listingDT.Rows[i]["listing_id"] + ".1.jpg?ts=" + listingDT.Rows[i]["ts"] + "\" onError=\"src='http://www.priv.njmls.xmlsweb.com/Images/MLS_Photos/Thumbnails/NoPhoto.1.jpg'\" id=\"Photo" + listingDT.Rows[i]["listing_id"] + "\" border=0></a>");
            sbCode.Append("<img src=\"http://pxlimages.xmlsweb.com/NJMLS/T/Images/"  + listingDT.Rows[i]["listing_id"] + ".1.jpg\" onError=\"src='http://www.priv.njmls.xmlsweb.com/Images/MLS_Photos/Thumbnails/NoPhoto.1.jpg'\" id=\"Photo" + listingDT.Rows[i]["listing_id"] + "\" border=0></a>");
            if ((listingDT.Rows[i]["status"].ToString() == "1") || (listingDT.Rows[i]["status"].ToString() == "2"))
            {
                sbCode.Append("</div>");
            }
            sbCode.Append("</td></tr>");
            sbCode.Append("</table></td></tr>");
            //sbCode.Append("<tr class=np><td colspan=\"3\" align=\"center\" valign=\"middle\">&nbsp;</td></tr>");
            //sbCode.Append("<tr class=np><td colspan=\"3\" align=\"center\" valign=\"middle\"><span class=\"ImageDescription\" id=\"ImageDescription" + listingDT.Rows[i]["listing_id"] + "\">&nbsp;FRONT&nbsp;</span></td></tr>");
            sbCode.Append("<tr class=np><td size=\"30\" height=\"25\">");
            sbCode.Append("<img src=\"/images/buttons/NavLeft.gif\" title=\"\" name=\"imgL" + listingDT.Rows[i]["listing_id"] + "\" onMouseOver=\"\" onMouseOut=\"\" onClick=\"GoBackward" + listingDT.Rows[i]["listing_id"] + "('Photo" + listingDT.Rows[i]["listing_id"] + "','ImageDescription" + listingDT.Rows[i]["listing_id"] + "');\" WIDTH=\"19\" HEIGHT=\"19\" class=\"nav\"></td>");
            sbCode.Append("<td align=\"center\"><span class=\"I\">&nbsp;Image&nbsp;</span><span class=\"I\" id=\"I" + listingDT.Rows[i]["listing_id"] + "\">1</span><span class=\"I\">&nbsp;of&nbsp;" + listingDT.Rows[i]["num_of_images"] + "&nbsp;</span></td>");
            sbCode.Append("<td size=\"30\" align=\"right\"><img src=\"/images/buttons/NavRight.gif\" title=\"\" name=\"imgR" + listingDT.Rows[i]["listing_id"] + "\" onMouseOver=\"\" onMouseOut=\"\" onClick=\"GoForward" + listingDT.Rows[i]["listing_id"] + "('Photo" + listingDT.Rows[i]["listing_id"] + "','ImageDescription" + listingDT.Rows[i]["listing_id"] + "');\" WIDTH=\"19\" HEIGHT=\"19\" class=\"nav\"></td>");
            sbCode.Append("</tr></table>");

            l.image_gallery = sbCode.ToString();
            if (listingDT.Rows[i]["price"].ToString() != "")
            {
                l.price = String.Format("{0:$0,0}", Convert.ToDecimal(listingDT.Rows[i]["price"].ToString()));
            }
            if (listingDT.Rows[i]["city"].ToString() != "")
            {
                l.city = listingDT.Rows[i]["city"].ToString();
            }
            if (listingDT.Rows[i]["selling_point"].ToString() != "")
            {
                l.selling_point = listingDT.Rows[i]["selling_point"].ToString();
            }
            if (listingDT.Rows[i]["style"].ToString() != "")
            {
                l.style = listingDT.Rows[i]["style"].ToString();
            }
            if (listingDT.Rows[i]["bed"].ToString() != "")
            {
                l.bed = Convert.ToByte(listingDT.Rows[i]["bed"].ToString());
            }
            if (listingDT.Rows[i]["bath"].ToString() != "")
            {
                l.bath = listingDT.Rows[i]["bath"].ToString();
            }

            //if (listingDT.Rows[i]["sort"].ToString() != "")
            //{
            //    l.sort = Convert.ToInt32(listingDT.Rows[i]["sort"].ToString());
            //}

            if (listingDT.Rows[i]["featured"].ToString() != "")
            {
                l.featured = Convert.ToBoolean(listingDT.Rows[i]["featured"].ToString());
            }

            if (listingDT.Rows[i]["status"].ToString() != "")
            {
                l.status = Convert.ToInt32(listingDT.Rows[i]["status"].ToString());
            }
            lListing.Add(l);
        }

        return lListing;
    }

    public Listing getListingByID(int ID)
    {
        ds_mainTableAdapters.listingTableAdapter listingTA = new ds_mainTableAdapters.listingTableAdapter();
        ds_main.listingDataTable listingDT = listingTA.GetDataByID(ID);
        //Literal1.Text = listingDT.Rows[0]["listing_id"].ToString()+"<br/>"+ 
        //    listingDT.Rows[0]["num_of_images"]+ "<br/>" +
        //    listingDT.Rows[0]["path"] + "<br/>" +
        //    listingDT.Rows[0]["ts"];

        Listing l = new Listing();

        l.listing_id = Convert.ToInt32(listingDT.Rows[0]["listing_id"]);
        l.number_of_images = Convert.ToInt32(listingDT.Rows[0]["num_of_images"].ToString());
        l.path = listingDT.Rows[0]["path"].ToString();
        l.ts = listingDT.Rows[0]["ts"].ToString();

        StringBuilder sbCode = new StringBuilder();
        for (int j = 1; j <= Convert.ToInt32(listingDT.Rows[0]["num_of_images"]); j++)
        {
            sbCode.Append("<script>var img" + listingDT.Rows[0]["listing_id"] + "_" + j + "_" +
               listingDT.Rows[0]["listing_id"] + "Sized = false</script>");
        }

        sbCode.Append("<script>");
        sbCode.Append("var AllDone" + listingDT.Rows[0]["listing_id"] + " = false;");
        sbCode.Append("function MyNav() {");
        sbCode.Append("imgL" + listingDT.Rows[0]["listing_id"] + " = new Image();");
        sbCode.Append("imgL" + listingDT.Rows[0]["listing_id"] +
            ".src = \"/images/buttons/NavLeft.gif\";");
        sbCode.Append("imgL" + listingDT.Rows[0]["listing_id"] + "On = new Image();");
        sbCode.Append("imgL" + listingDT.Rows[0]["listing_id"] +
            "On.src = \"/images/buttons/NavLeftOn.gif\";");
        sbCode.Append("imgR" + listingDT.Rows[0]["listing_id"] + " = new Image();");
        sbCode.Append("imgR" + listingDT.Rows[0]["listing_id"] +
            ".src = \"/images/buttons/NavRight.gif\";");
        sbCode.Append("imgR" + listingDT.Rows[0]["listing_id"] + "On = new Image();");
        sbCode.Append("imgR" + listingDT.Rows[0]["listing_id"] +
            "On.src = \"/images/buttons/NavRight.gif\";");
        sbCode.Append("}");

        sbCode.Append("function Prepare" + listingDT.Rows[0]["listing_id"] + "(){");
        sbCode.Append("img" + listingDT.Rows[0]["listing_id"] + "_1_" + listingDT.Rows[0]["listing_id"] + " = new Image();");
        //sbCode.Append("img" + listingDT.Rows[0]["listing_id"] + "_1_" + listingDT.Rows[0]["listing_id"] +
        //    ".src = \"http://www.priv.njmls.xmlsweb.com/Images/MLS_Photos/" +
        //    listingDT.Rows[0]["listing_id"] + ".1.jpg?ts=" + listingDT.Rows[0]["ts"] + "\";");

        //sbCode.Append("img" + listingDT.Rows[0]["listing_id"] + "_1_" + listingDT.Rows[0]["listing_id"] +
        //    ".src = \"http://www.priv.njmls.xmlsweb.com//Images/MLS_Photos/Large/" + listingDT.Rows[0]["path"] + "/" +
        //    listingDT.Rows[0]["listing_id"] + ".1.jpg?ts=" + listingDT.Rows[0]["ts"] + "\";");
        
        sbCode.Append("img" + listingDT.Rows[0]["listing_id"] + "_1_" + listingDT.Rows[0]["listing_id"] +
    ".src = \"http://pxlimages.xmlsweb.com/NJMLS/H/Images/" + listingDT.Rows[0]["listing_id"] + ".1.jpg\";");


        sbCode.Append("img" + listingDT.Rows[0]["listing_id"] + "_1_" + listingDT.Rows[0]["listing_id"] + ".title = \"\";}");

        sbCode.Append("function TurnOn(strImg)	{");
        sbCode.Append("strImgStatus = strImg + \"On\";");
        sbCode.Append("}");
        sbCode.Append("function TurnOff(strImg)	{");
        sbCode.Append("}");

        sbCode.Append("function LoadImages" + listingDT.Rows[0]["listing_id"] + "()	{");
        for (int j = 2; j <= Convert.ToInt32(listingDT.Rows[0]["num_of_images"]); j++)
        {
            sbCode.Append("img" + listingDT.Rows[0]["listing_id"] + "_" + j + "_" + listingDT.Rows[0]["listing_id"] + " = new Image();");
            //sbCode.Append("img" + listingDT.Rows[0]["listing_id"] + "_" + j + "_" + listingDT.Rows[0]["listing_id"] + ".src = \"http://www.priv.njmls.xmlsweb.com//Images/MLS_Photos/Large/" + listingDT.Rows[0]["path"] + "/" + listingDT.Rows[0]["listing_id"] + "." + j + ".jpg\";");
            sbCode.Append("img" + listingDT.Rows[0]["listing_id"] + "_" + j + "_" + listingDT.Rows[0]["listing_id"] + ".src = \"http://pxlimages.xmlsweb.com/NJMLS/H/Images/" + listingDT.Rows[0]["listing_id"] + "." + j + ".jpg\";");
            sbCode.Append("img" + listingDT.Rows[0]["listing_id"] + "_" + j + "_" + listingDT.Rows[0]["listing_id"] + ".title = \"\";");
        }
        sbCode.Append("AllDone" + listingDT.Rows[0]["listing_id"] + " =true;");
        sbCode.Append("}");


        sbCode.Append("function GoForward" + listingDT.Rows[0]["listing_id"] + "(strImg,strSpan)	{");
        //sbCode.Append("alert(document.getElementById(strImg).src);");
        sbCode.Append("if (AllDone" + listingDT.Rows[0]["listing_id"] + ") {");
        //sbCode.Append("alert(img" + listingDT.Rows[0]["listing_id"] + "_" + 1 + "_" + listingDT.Rows[0]["listing_id"] + ".src);");
        
        sbCode.Append("switch (document.getElementById(strImg).src)	{");
        //sbCode.Append("case test:");
        //sbCode.Append("case img" + listingDT.Rows[0]["listing_id"] + "_" + 1 + "_" + listingDT.Rows[0]["listing_id"] + ".src:");
        //sbCode.Append("alert('case img" + listingDT.Rows[0]["listing_id"] + "_" + 1 + "_" + listingDT.Rows[0]["listing_id"] + ".src')");
        //sbCode.Append("alert('Good')");
        
        for (int j = 1; j <= Convert.ToInt32(listingDT.Rows[0]["num_of_images"]); j++)
        {
            sbCode.Append("case img" + listingDT.Rows[0]["listing_id"] + "_" + j + "_" + listingDT.Rows[0]["listing_id"] + ".src:");
            //sbCode.Append("alert('case img" + listingDT.Rows[0]["listing_id"] + "_" + j + "_" + listingDT.Rows[0]["listing_id"] + ".src'");
            //sbCode.Append("alert('Good')");
            if (j < Convert.ToInt32(listingDT.Rows[0]["num_of_images"]))
            {
                sbCode.Append("document.getElementById(strImg).src = img" + listingDT.Rows[0]["listing_id"] + "_" + (j + 1) + "_" + listingDT.Rows[0]["listing_id"] + ".src;");
                //sbCode.Append("document.getElementById(strSpan).innerText = \" Caption " + j + "\";");
                //sbCode.Append("document.getElementById(strSpan).textContent = \" Caption " + j + "\";");
                sbCode.Append("document.getElementById(\"I" + listingDT.Rows[0]["listing_id"] + "\").innerText = \"" + (j + 1) + "\";");
                sbCode.Append("document.getElementById(\"I" + listingDT.Rows[0]["listing_id"] + "\").innerText = \"" + (j + 1) + "\";");
            }
            else
            {
                sbCode.Append("document.getElementById(strImg).src = img" + listingDT.Rows[0]["listing_id"] + "_" + 1 + "_" + listingDT.Rows[0]["listing_id"] + ".src;");
                //sbCode.Append("document.getElementById(strSpan).innerText = \" Caption " + j + "\";");
                //sbCode.Append("document.getElementById(strSpan).textContent = \" Caption " + j + "\";");
                sbCode.Append("document.getElementById(\"I" + listingDT.Rows[0]["listing_id"] + "\").innerText = \"" + 1 + "\";");
                sbCode.Append("document.getElementById(\"I" + listingDT.Rows[0]["listing_id"] + "\").innerText = \"" + 1 + "\";");
            }
            sbCode.Append("break;");
        }
        sbCode.Append("}");
        sbCode.Append("}else{");
        //sbCode.Append("alert('Hmmm')");
        sbCode.Append("LoadImages" + listingDT.Rows[0]["listing_id"] + "();");
        sbCode.Append("GoForward" + listingDT.Rows[0]["listing_id"] + "(strImg,strSpan);");
        sbCode.Append("}}");


        sbCode.Append("function GoBackward" + listingDT.Rows[0]["listing_id"] + "(strImg,strSpan){");
        sbCode.Append("if (AllDone" + listingDT.Rows[0]["listing_id"] + "){");
        sbCode.Append("switch (document.getElementById(strImg).src)	{");
        for (int j = 1; j <= Convert.ToInt32(listingDT.Rows[0]["num_of_images"]); j++)
        {
            sbCode.Append("case img" + listingDT.Rows[0]["listing_id"] + "_" + j + "_" + listingDT.Rows[0]["listing_id"] + ".src:");
            if (j == 1)
            {
                sbCode.Append("document.getElementById(strImg).src = img" + listingDT.Rows[0]["listing_id"] + "_" + listingDT.Rows[0]["num_of_images"] + "_" + listingDT.Rows[0]["listing_id"] + ".src;");
                //sbCode.Append("document.getElementById(strSpan).innerText = \" CAPTION " + j + " \";");
                //sbCode.Append("document.getElementById(strSpan).textContent = \" CAPTION " + j + " \";");
                sbCode.Append("document.getElementById(\"I" + listingDT.Rows[0]["listing_id"] + "\").innerText = \"" + listingDT.Rows[0]["num_of_images"] + "\";");
                sbCode.Append("document.getElementById(\"I" + listingDT.Rows[0]["listing_id"] + "\").textContent = \"" + listingDT.Rows[0]["num_of_images"] + "\";");
            }
            else
            {
                sbCode.Append("document.getElementById(strImg).src = img" + listingDT.Rows[0]["listing_id"] + "_" + (j - 1) + "_" + listingDT.Rows[0]["listing_id"] + ".src;");
                //sbCode.Append("document.getElementById(strSpan).innerText = \" CAPTION " + j + " \";");
                //sbCode.Append("document.getElementById(strSpan).textContent = \" CAPTION " + j + " \";");
                sbCode.Append("document.getElementById(\"I" + listingDT.Rows[0]["listing_id"] + "\").innerText = \"" + (j - 1) + "\";");
                sbCode.Append("document.getElementById(\"I" + listingDT.Rows[0]["listing_id"] + "\").textContent = \"" + (j - 1) + "\";");

            }
            sbCode.Append("break;");
        }

        sbCode.Append("}}else{");
        sbCode.Append("LoadImages" + listingDT.Rows[0]["listing_id"] + "();");
        sbCode.Append("GoBackward" + listingDT.Rows[0]["listing_id"] + "(strImg,strSpan);");
        sbCode.Append("}}");

        sbCode.Append("MyNav();");
        sbCode.Append("Prepare" + listingDT.Rows[0]["listing_id"] + "();");
        sbCode.Append("LoadImages" + listingDT.Rows[0]["listing_id"] + "();");
        sbCode.Append("</script>");

        sbCode.Append("<table width=\"640\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">");
        sbCode.Append("<tr><td colspan=\"3\" valign=\"middle\" align=\"center\">");
        sbCode.Append("<table cellspacing=\"0\" cellpadding=\"0\" width=\"640\" height=\"479\" border=\"2\" noresize bgcolor=\"#F0F0F0\"><tr>");
        sbCode.Append("<td align=\"center\" valign=\"middle\">");
        //sbCode.Append("<img src=\"http://www.priv.njmls.xmlsweb.com/Images/MLS_Photos/" + listingDT.Rows[0]["listing_id"] + ".1.jpg?ts=" + listingDT.Rows[0]["ts"] + "\" onError=\"src='http://www.priv.njmls.xmlsweb.com/Images/MLS_Photos/NoPhoto.1.jpg'\" id=\"Photo" + listingDT.Rows[0]["listing_id"] + "\" border=0></td></tr>");
        //sbCode.Append("<img src=\"http://www.priv.njmls.xmlsweb.com//Images/MLS_Photos/Large/" + listingDT.Rows[0]["path"] + "/" + listingDT.Rows[0]["listing_id"] + ".1.jpg?ts=" + listingDT.Rows[0]["ts"] + "\" onError=\"src='http://www.priv.njmls.xmlsweb.com/Images/MLS_Photos/NoPhoto.1.jpg'\" id=\"Photo" + listingDT.Rows[0]["listing_id"] + "\" border=0></td></tr>");
        sbCode.Append("<img src=\"http://pxlimages.xmlsweb.com/NJMLS/H/Images/" + listingDT.Rows[0]["listing_id"] + ".1.jpg\" onError=\"src='http://www.priv.njmls.xmlsweb.com/Images/MLS_Photos/NoPhoto.1.jpg'\" id=\"Photo" + listingDT.Rows[0]["listing_id"] + "\" border=0 width=\"640\"></td></tr>");

        //sbCode.Append("<img src=\"http://www.priv.njmls.xmlsweb.com//Images/MLS_Photos/320/" + listingDT.Rows[i]["path"] + "/" + listingDT.Rows[i]["listing_id"] + ".1.jpg?ts=" + listingDT.Rows[i]["ts"] + "\" onError=\"src='http://www.priv.njmls.xmlsweb.com/Images/MLS_Photos/NoPhoto.1.jpg'\" id=\"Photo" + listingDT.Rows[i]["listing_id"] + "\" border=0></a></td></tr>");
 
        
        sbCode.Append("</table></td></tr>");
        //sbCode.Append("<tr class=np><td colspan=\"3\" align=\"center\" valign=\"middle\">&nbsp;</td></tr>");
        //sbCode.Append("<tr class=np><td colspan=\"3\" align=\"center\" valign=\"middle\"><span class=\"ImageDescription\" id=\"ImageDescription" + listingDT.Rows[0]["listing_id"] + "\">&nbsp;FRONT&nbsp;</span></td></tr>");
        sbCode.Append("<tr class=np><td align=\"center\"><table border=\"0\"><tr><td size=\"30\" height=\"25\">");
        sbCode.Append("<img src=\"/images/buttons/NavLeft.gif\" title=\"\" name=\"imgL" + listingDT.Rows[0]["listing_id"] + "\" onMouseOver=\"\" onMouseOut=\"\" onClick=\"GoBackward" + listingDT.Rows[0]["listing_id"] + "('Photo" + listingDT.Rows[0]["listing_id"] + "','ImageDescription" + listingDT.Rows[0]["listing_id"] + "');\" WIDTH=\"19\" HEIGHT=\"19\" class=\"nav\"></td>");
        sbCode.Append("<td align=\"center\"><span class=\"I\">&nbsp;Image&nbsp;</span><span class=\"I\" id=\"I" + listingDT.Rows[0]["listing_id"] + "\">1</span><span class=\"I\">&nbsp;of&nbsp;" + listingDT.Rows[0]["num_of_images"] + "&nbsp;</span></td>");
        sbCode.Append("<td size=\"30\" align=\"right\"><img src=\"/images/buttons/NavRight.gif\" title=\"\" name=\"imgR" + listingDT.Rows[0]["listing_id"] + "\" onMouseOver=\"\" onMouseOut=\"\" onClick=\"GoForward" + listingDT.Rows[0]["listing_id"] + "('Photo" + listingDT.Rows[0]["listing_id"] + "','ImageDescription" + listingDT.Rows[0]["listing_id"] + "');\" WIDTH=\"19\" HEIGHT=\"19\" class=\"nav\"></td>");
        sbCode.Append("</td></tr></table></td></tr></table>");

        l.image_gallery = sbCode.ToString();


        //if (listingDT.Rows[0]["price"].ToString() != "")
        //{
          //  l.price = String.Format("{0:$0,0}", Convert.ToDecimal(listingDT.Rows[0]["price"].ToString()));
        //}
        if (listingDT.Rows[0]["city"].ToString() != "")
        {
            l.city = listingDT.Rows[0]["city"].ToString();
        }
        if (listingDT.Rows[0]["selling_point"].ToString()!="")
        {
            l.selling_point = listingDT.Rows[0]["selling_point"].ToString();
        }
        if (listingDT.Rows[0]["bed"].ToString() != "")
        {
            l.bed = Convert.ToByte(listingDT.Rows[0]["bed"].ToString());
        }
        if (listingDT.Rows[0]["bath"].ToString() != "")
        {
            l.bath = listingDT.Rows[0]["bath"].ToString();
        }
        if (listingDT.Rows[0]["style"].ToString() != "")
        {
            l.style = listingDT.Rows[0]["style"].ToString();
        }
        if (listingDT.Rows[0]["address"].ToString() != "")
        {
            l.address = listingDT.Rows[0]["address"].ToString();
        }
        if (listingDT.Rows[0]["zip"].ToString() != "")
        {
            l.zip = listingDT.Rows[0]["zip"].ToString();
        }
        if (listingDT.Rows[0]["description"].ToString()!="")
        {
            l.description = listingDT.Rows[0]["description"].ToString();
        }

        ds_mainTableAdapters.x_listing_typeTableAdapter x_listing_typeTA = new ds_mainTableAdapters.x_listing_typeTableAdapter();
        ds_main.x_listing_typeDataTable x_listing_typeDT = x_listing_typeTA.GetDataByListingID(ID);
        foreach (ds_main.x_listing_typeRow r in x_listing_typeDT.Rows)
        {
            if (r["type_id"].ToString() == "100")
            {
                l.sale = true;
                if (r["price"].ToString() != "")
                {
                    l.price = String.Format("{0:$0,0}", Convert.ToDecimal(r["price"].ToString()));
                }
            }
            if (r["type_id"].ToString() == "200")
            {
                l.rental = true;
                if (r["price"].ToString() != "")
                {
                    l.rent = String.Format("{0:$0,0}", Convert.ToDecimal(r["price"].ToString()));
                }
            }

        }
        if (listingDT.Rows[0]["featured"].ToString() != "")
        {
            l.featured = Convert.ToBoolean(listingDT.Rows[0]["featured"].ToString());
        }

        if (listingDT.Rows[0]["status"].ToString() != "")
        {
            l.status = Convert.ToInt32(listingDT.Rows[0]["status"].ToString());
        }
        return l;
    }

    public void SwapSort(int from, int to, int type)
    {
        int iPlaceHolder = 0;

        ds_mainTableAdapters.x_listing_typeTableAdapter x_listing_typeTA = new ds_mainTableAdapters.x_listing_typeTableAdapter();
        ds_main.x_listing_typeDataTable x_listing_typeDT = x_listing_typeTA.GetDataByListingIDTypeID(to, type);

        if (x_listing_typeDT.Rows[0]["sort"].ToString() != "")
        {
            iPlaceHolder = Convert.ToInt32(x_listing_typeDT.Rows[0]["sort"].ToString());
        }

        x_listing_typeDT = x_listing_typeTA.GetDataByListingIDTypeID(from, type);
        if (x_listing_typeDT.Rows[0]["sort"].ToString() != "")
        {
            x_listing_typeTA.UpdateSortByListingIDTypeID(Convert.ToInt32(x_listing_typeDT.Rows[0]["sort"].ToString()), to, type);
            x_listing_typeTA.UpdateSortByListingIDTypeID(iPlaceHolder, from, type);
        }

        //ds_mainTableAdapters.listingTableAdapter listingTA = new ds_mainTableAdapters.listingTableAdapter();
        //ds_main.listingDataTable listingDT = listingTA.GetDataByID(to);

        //if (listingDT.Rows[0]["sort"].ToString() != "")
        //{
        //    iPlaceHolder = Convert.ToInt32(listingDT.Rows[0]["sort"].ToString());
        //}
        //listingDT = listingTA.GetDataByID(from);
        //if (listingDT.Rows[0]["sort"].ToString() != "")
        //{
        //    listingTA.UpdateSortByID(Convert.ToInt32(listingDT.Rows[0]["sort"].ToString()), to);
        //    listingTA.UpdateSortByID(iPlaceHolder, from);
        //}        
    }

    public void SwapFeaturedSort(int from, int to, string type)
    {
        int iPlaceHolder = 0;
        ds_mainTableAdapters.listingTableAdapter listingTA = new ds_mainTableAdapters.listingTableAdapter();
        ds_main.listingDataTable listingDT = listingTA.GetDataByID(to);
        if (listingDT.Rows[0]["featured_sort"].ToString() != "")
        {
            iPlaceHolder = Convert.ToInt32(listingDT.Rows[0]["featured_sort"].ToString());
        }
        listingDT = listingTA.GetDataByID(from);
        if (listingDT.Rows[0]["featured_sort"].ToString() != "")
        {
            listingTA.UpdateFeaturedSortByID(Convert.ToInt32(listingDT.Rows[0]["featured_sort"].ToString()), to);
            listingTA.UpdateFeaturedSortByID(iPlaceHolder, from);
        }
    }

    public static int getMaxSortByTypeID(int ID)
    {
        int result = 0;
        SqlConnection conn = null;
        SqlCommand cmd = null;
        SqlDataReader reader = null;
        try
        {
            using (conn = new SqlConnection(ConfigurationManager.ConnectionStrings["sonyachoiConnectionString"].ToString()))
            {
                conn.Open();
                using (cmd = new SqlCommand("GetMaxSortByListingTypeID", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("typeID", ID);
                    reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    if (reader.Read())
                        result = Convert.ToInt32(reader[0].ToString());
                }
            }
        }
        catch (Exception ex)
        {
        }
        return result;
    }

    public static int getMaxFeaturedSort()
    {
        int result = 0;
        SqlConnection conn = null;
        SqlCommand cmd = null;
        SqlDataReader reader = null;
        try
        {
            using (conn = new SqlConnection(ConfigurationManager.ConnectionStrings["sonyachoiConnectionString"].ToString()))
            {
                conn.Open();
                using (cmd = new SqlCommand("GetMaxFeaturedSort", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    if (reader.Read())
                        result = Convert.ToInt32(reader[0].ToString());
                }
            }
        }
        catch (Exception ex)
        {
        }
        return result;
    }

    public static void InsertModifiedDate()
    {
        SqlConnection conn = null;
        SqlCommand cmd = null;
        try
        {
            using (conn = new SqlConnection(ConfigurationManager.ConnectionStrings["sonyachoiConnectionString"].ToString()))
            {
                conn.Open();
                using (cmd = new SqlCommand("InsertEditHistory", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("DateModified", DateTime.Now);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        catch (Exception ex)
        {
        }
    }

    public static DateTime GetMostRecentModifiedDate()
    {
        DateTime result = new DateTime();
        SqlConnection conn = null;
        SqlCommand cmd = null;
        SqlDataReader reader = null;
        try
        {
            using (conn = new SqlConnection(ConfigurationManager.ConnectionStrings["sonyachoiConnectionString"].ToString()))
            {
                conn.Open();
                using (cmd = new SqlCommand("GetMostRecentModifiedDate", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    if (reader.Read())
                        //result = Convert.ToInt32(reader[0].ToString());
                        result = reader.GetDateTime(0);
                }
            }
        }
        catch (Exception ex)
        {
        }
        return result;
    }
}
