using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            FormsAuthentication.RedirectFromLoginPage(tbUsername.Text, false);   
        }
    }
    protected void cvInvalid_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (tbUsername.Text.Equals("sonyachoi") && tbPassword.Text.Equals("sunhwa1986"))
        {
            args.IsValid = true;
        }
        else
        {
            args.IsValid = false;
        }

    }
}