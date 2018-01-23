using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace Team09LogicU.App_Code.UtilClass
{
    public class Email
    {
        public void sendNewReqEmail(string staffName,string headName )
        {
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.Credentials = new System.Net.NetworkCredential
            (@"sateam09@gmail.com", "password!123");
            client.EnableSsl = true;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;

            MailMessage mm = new MailMessage("sateam09@gmail.com", "shangzhengxiang@163.com");
            mm.Subject = "New Requisition  Attention !";
            mm.IsBodyHtml = true;
            mm.Body = "Dear " +headName+"<br/>"+ "&nbsp&nbspPlease note that there has been a new requisition added by the staff " + staffName + " in your department for your attention. "
                   + "<br/>"  + "You may access your requisitions by logging onto the Stationary Store system.";

            client.Send(mm);         
        }        


    }
}