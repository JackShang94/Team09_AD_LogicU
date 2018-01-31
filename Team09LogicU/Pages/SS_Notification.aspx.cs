using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team09LogicU.App_Code.UtilClass;
using Team09LogicU.App_Code.DAO;
using Team09LogicU.Models;

namespace Team09LogicU.Pages
{
    public partial class SS_Notification : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string loginID = Session["loginID"].ToString();
            NotificationDAO nDAO = new NotificationDAO();
            List<StoreNotification> nList = nDAO.getAllStoreNotificationByID(loginID);
            notice_Repeater.DataSource = nList;
            notice_Repeater.DataBind();
            foreach (StoreNotification item in nList)
            {
                nDAO.setStoreNotificationStatusAsOld(item.notificationID);
            }
        }
    }
}