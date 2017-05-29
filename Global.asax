<%@ Application Language="C#" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e) 
    {
        // Code that runs on application startup

    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //  Code that runs on application shutdown

    }
        
    void Application_Error(object sender, EventArgs e) 
    {
        string strHandledMessage = String.Empty;
        if (Server.GetLastError().ToString().IndexOf("does not exist") >= 0)
        {
            Response.Redirect("./404.aspx");
        }
        else
        {

            HttpBrowserCapabilities br = Request.Browser;

            strHandledMessage = "GetLastError.InnerException.Message: " + Server.GetLastError().InnerException.Message.ToString() +
                Environment.NewLine + Environment.NewLine +
                "GetLastError.InnerException.StackTrace: " + Server.GetLastError().InnerException.StackTrace.ToString() +
                Environment.NewLine + Environment.NewLine +
                "The client ip: " + Request.ServerVariables["REMOTE_ADDR"] +
                Environment.NewLine + Environment.NewLine +
                "GetLastError.Message: " + Server.GetLastError().Message.ToString() +
                Environment.NewLine + Environment.NewLine +
                "Page: " + Request.ServerVariables["SCRIPT_NAME"] +
                Environment.NewLine + Environment.NewLine +
                "Server: " + Request.ServerVariables["SERVER_NAME"] +
                Environment.NewLine + Environment.NewLine +
                "Local Address: " + Request.ServerVariables["LOCAL_ADDR"] +
                 Environment.NewLine + Environment.NewLine +
                "Browser: " + br.Browser.ToString() + " : " + br.Version.ToString();

            if (Request.UrlReferrer != null)
            {
                strHandledMessage += Environment.NewLine + Environment.NewLine +
               "Referrer: " + Request.UrlReferrer.ToString();
            }

            if (Request.QueryString != null)
            {
                strHandledMessage += Environment.NewLine + Environment.NewLine +
               "Query String: " + Request.QueryString.ToString();
            }


            strHandledMessage += Environment.NewLine + Environment.NewLine;
            System.Net.Mail.SmtpClient smtpClient = new System.Net.Mail.SmtpClient();
            System.Net.NetworkCredential basicCredential = new System.Net.NetworkCredential("info@sonyachoi.com", "sunhwa1986");  
            System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();
            try
            {
                System.Net.Mail.MailAddress fromAddress = new System.Net.Mail.MailAddress("webmaster@sonyachoi.com", "Debugger");
                smtpClient.Host = System.Configuration.ConfigurationManager.AppSettings["SMTPServer"].ToString();
                smtpClient.Port = 26;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = basicCredential;
                message.From = fromAddress;
                message.To.Add("hudsonchoi@gmail.com");
                message.Subject = "Sonyachoi.com : Error on " + Request.ServerVariables["SCRIPT_NAME"];
                //message.Body = Server.GetLastError().InnerException.Message.ToString();
                message.Body = strHandledMessage;
                smtpClient.Send(message);
            }
            catch (Exception ex)
            {
                //lblStatus.Text = "Send Email Failed." + ex.Message;
            }

            Response.Redirect("/error.aspx");

        }

    }

    void Session_Start(object sender, EventArgs e) 
    {

    }

    void Session_End(object sender, EventArgs e) 
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.

    }
       
</script>
