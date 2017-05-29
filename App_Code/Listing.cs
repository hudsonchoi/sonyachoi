using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for MLS
/// </summary>
public class Listing
{
    private int _listing_id;
    private int _next_listing_id;
    private int _prev_listing_id;
    private string _image_gallery;
    private string _selling_point;
    private string _city;
    private string _price;
    private string _rent;
    private string _style;
    private byte _bed;
    private string _bath;
    private int _number_of_images;
    private string _path;
    private string _ts;
    private string _address;
    private string _zip;
    private string _description;
    private int _sort;
    private bool _featured;
    private int _status;
    private string _up_style;
    private string _down_style;
    private bool _sale;
    private bool _rental;
    private string _status_image;

    public Listing()
	{
		//
		// TODO: Add constructor logic here
		//
	}


    public int listing_id
    {
        get { return _listing_id; }
        set { _listing_id = value; }
    }

    public int next_listing_id
    {
        get { return _next_listing_id; }
        set { _next_listing_id = value; }
    }

    public int prev_listing_id
    {
        get { return _prev_listing_id; }
        set { _prev_listing_id = value; }
    }

    public string image_gallery
    {
        get { return _image_gallery; }
        set { _image_gallery = value; } 
    }

    public string selling_point
    {
        get { return _selling_point;}
        set { _selling_point = value; } 
    }

    public string city
    {
        get { return _city; }
        set { _city = value; }
    }

    public string price
    {
        get { return _price; }
        set { _price = value; }
    }

    public string rent
    {
        get { return _rent; }
        set { _rent = value; }
    }

    public string style
    {
        get { return _style; }
        set { _style = value; }
    }

    public byte bed
    {
        get { return _bed; }
        set { _bed = value; }
    }

    public string bath
    {
        get { return _bath; }
        set { _bath = value; }
    }

    public int number_of_images
    {
        get { return _number_of_images; }
        set { _number_of_images = value; }
    }

    public string path
    {
        get { return _path; }
        set { _path = value; }
    }

    public string ts
    {
        get { return _ts; }
        set { _ts = value; }
    }

    public string address
    {
        get { return _address; }
        set { _address = value; }
    }

    public string zip
    {
        get { return _zip; }
        set { _zip = value; }
    }

    public string description
    {
        get { return _description; }
        set { _description = value; }
    }

    public int sort
    {
        get { return _sort; }
        set { _sort = value; }
    }

    public int status
    {
        get { return _status; }
        set { _status = value; }
    }

    public bool featured
    {
        get { return _featured; }
        set { _featured = value; }
    }

    public string up_style
    {
        get { return _up_style; }
        set { _up_style = value; }
    }

    public string down_style
    {
        get { return _down_style; }
        set { _down_style = value; }
    }

    public bool sale
    {
        get { return _sale; }
        set { _sale = value; }
    }

    public bool rental
    {
        get { return _rental; }
        set { _rental = value; }
    }

    public string status_image
    {
        get {return _status_image;}
        set {_status_image = value;}
    }
}
