using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail; 

public partial class probe : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string strHandledMessage = String.Empty;
        strHandledMessage += "test" + Environment.NewLine + Environment.NewLine;
        System.Net.Mail.SmtpClient smtpClient = new System.Net.Mail.SmtpClient();
        NetworkCredential basicCredential = new NetworkCredential("info@sonyachoi.com", "sunhwa1986");  
        System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();

        System.Net.Mail.MailAddress fromAddress = new System.Net.Mail.MailAddress("webmaster@sonyachoi.com", "Debugger");
        smtpClient.Host = "localhost";
        smtpClient.Port = 26;
        smtpClient.UseDefaultCredentials = false; 
        smtpClient.Credentials = basicCredential;
        message.From = fromAddress;
        message.To.Add(tbRecepient.Text);
        message.Subject = "test";
       
        //message.Body = Server.GetLastError().InnerException.Message.ToString();
        message.Body = strHandledMessage;
        try
        {
            smtpClient.Send(message);
        }
        catch(Exception ex) {
            Response.Write(ex.Message); 
        } 
    }
}