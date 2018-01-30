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

        public void sendFeedBackEmailToEmployee(string employeeName, string headName, string requisitionDate, string requisitionStatus)
        {
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.Credentials = new System.Net.NetworkCredential
            (@"sateam09@gmail.com", "password!123");
            client.EnableSsl = true;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;

            MailMessage mm = new MailMessage("sateam09@gmail.com", "shangzhengxiang@163.com");           
            mm.Subject = "Requisition  Status Update Attention !";
            mm.IsBodyHtml = true;
            mm.Body = "Dear " + employeeName + ",<br/><br/>" + "&nbsp;&nbsp;&nbsp; Please note that your requisition in "+ requisitionDate + " has been <font style='font - family:verdana; color: red'> " + requisitionStatus + "</font> by  head " + headName + " in your department. "
                   + "<br/>" + "&nbsp;&nbsp;&nbsp; You may access your requisitions by logging onto the Stationary Store system."
                   + " <br/><br/>Thank you.<br/>The Logic U Stationary Department team.";

            client.Send(mm);
        }

        public void sendRepNotificationToEmployee(string staffName,string headName)
        {
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.Credentials = new System.Net.NetworkCredential
            (@"sateam09@gmail.com", "password!123");
            client.EnableSsl = true;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;

            MailMessage mm = new MailMessage("sateam09@gmail.com", "shangzhengxiang@163.com");
            mm.Subject = "Representative  Attention !";
            mm.IsBodyHtml = true;
            mm.Body = "Dear " + staffName + ",<br/><br/>" + "&nbsp;&nbsp;&nbsp; Please note that your head " + headName+ " in your department has assigned you as department representative. "
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

        public void sendAdjustmentEmailToSupervisor(string clerkName, string supervisorName)
        {
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.Credentials = new System.Net.NetworkCredential
            (@"sateam09@gmail.com", "password!123");
            client.EnableSsl = true;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;

            MailMessage mm = new MailMessage("sateam09@gmail.com", "shangzhengxiang@163.com");
            mm.Subject = "New Adjustment Voucher  Attention !";
            mm.IsBodyHtml = true;
            mm.Body = "Dear " + supervisorName + ",<br/><br/>" + "&nbsp;&nbsp;&nbsp; Please note that there has been a new Adjustment Voucher added by the clerk " + clerkName + " in your store for your attention. "
                   + "<br/>" + "&nbsp;&nbsp;&nbsp; You may access your requisitions by logging onto the Stationary Store system."
                   + " <br/><br/>Thank you.<br/>The Logic U Stationary Department team.";

            client.Send(mm);
        }

        public void sendAdjustmentEmailToManager(string supervisorName, string managerName)
        {
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.Credentials = new System.Net.NetworkCredential
            (@"sateam09@gmail.com", "password!123");
            client.EnableSsl = true;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;

            MailMessage mm = new MailMessage("sateam09@gmail.com", "shangzhengxiang@163.com");
            mm.Subject = "New Adjustment Voucher  Attention !";
            mm.IsBodyHtml = true;
            mm.Body = "Dear " + managerName + ",<br/><br/>" + "&nbsp;&nbsp;&nbsp; Please note that there has been a new Adjustment Voucher added by the supervisor " + supervisorName + " in your store for your attention. "
                   + "<br/>" + "&nbsp;&nbsp;&nbsp; You may access your adjustment voucher by logging onto the Stationary Store system."
                   + " <br/><br/>Thank you.<br/>The Logic U Stationary Department team.";

            client.Send(mm);
        }

        public void sendDelegateEmailToEmployee(string staffName,string headName,string fromDate,string toDate)
        {
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.Credentials = new System.Net.NetworkCredential
            (@"sateam09@gmail.com", "password!123");
            client.EnableSsl = true;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;

            MailMessage mm = new MailMessage("sateam09@gmail.com", "shangzhengxiang@163.com");
            mm.Subject = "Delegate  Attention !";
            mm.IsBodyHtml = true;
            mm.Body = "Dear " + staffName + ",<br/><br/>" + "&nbsp;&nbsp;&nbsp; Please note that you have been delegated as department head by  " + headName + " in your department. "
                   + "<br/>" + "&nbsp;&nbsp;&nbsp; You may access your notification by logging onto the Stationary Store system."
                   + " <br/><br/>Thank you.<br/>The Logic U Stationary Department team.";

            client.Send(mm);
        }
    }
}