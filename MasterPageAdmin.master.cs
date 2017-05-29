using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPageAdmin : System.Web.UI.MasterPage
{
    public string strNav;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    public void Change_Nav(string _strNav)
    {
        strNav = _strNav;
    }

}
