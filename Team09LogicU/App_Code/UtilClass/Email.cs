using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace Team09LogicU.App_Code.UtilClass
{
    public class Email
    {
        public void sendNewReqEmailToHead(string staffName,string headName )
        {
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.Credentials = new System.Net.NetworkCredential
            (@"sateam09@gmail.com", "password!123");
            client.EnableSsl = true;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;

            MailMessage mm = new MailMessage("sateam09@gmail.com", "shangzhengxiang@163.com");
            mm.Subject = "New Requisition  Attention !";
            mm.IsBodyHtml = true;
            mm.Body = "Dear " +headName+ ",<br/><br/>" + "&nbsp;&nbsp;&nbsp; Please note that there has been a new requisition added by the staff " + staffName + " in your department for your attention. "
                   + "<br/>" + "&nbsp;&nbsp;&nbsp; You may access your requisitions by logging onto the Stationary Store system." 
                   + " <br/><br/>Thank you.<br/>The Logic U Stationary Department team.";

            client.Send(mm);         
        }        

        public void sendDisbursementEmailToRep(string repName, string disbursementDate, string collectionPoint)
        {
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.Credentials = new System.Net.NetworkCredential
            (@"sateam09@gmail.com", "password!123");
            client.EnableSsl = true;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;

            MailMessage mm = new MailMessage("sateam09@gmail.com", "shangzhengxiang@163.com");
            mm.Subject = "Disbursement list for " + disbursementDate + " ready for collection";
            mm.IsBodyHtml = true;
            mm.Body = "Dear " + repName + ",<br/><br/>&nbsp;&nbsp;&nbsp;  Please note that the disbursement for the week of "
                    + disbursementDate+ " is ready for collection.<br/> &nbsp;&nbsp;&nbsp; Please remember to meet the store representative at the<font style='font - family:verdana; color: red'> "
                        + collectionPoint + " .</font><br/><br/>Thank you.<br/>The Logic U Stationary Department team.";

            client.Send(mm);
        }



    }
}