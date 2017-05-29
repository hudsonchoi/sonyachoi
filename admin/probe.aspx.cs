using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_probe : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Person p = new Person { Data = "Bingo" };
        List<Person> people = new List<Person>();
        people.Add(p);
        ListView1.DataSource = people;
        ListView1.DataBind();

    }
}

public class Person
{
    public string Data { get; set; }
}