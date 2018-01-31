using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team09LogicU.App_Code.UtilClass;
using Team09LogicU.App_Code.DAO;
using Team09LogicU.Models;

namespace Team09LogicU.pages
{
    public partial class Emp_Notification : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string loginID = Session["loginID"].ToString();
            NotificationDAO nDAO = new NotificationDAO();
            List<DeptNotification> nList = nDAO.getAllDeptNotificationByID(loginID);
            notice_Repeater.DataSource = nList;
            notice_Repeater.DataBind();
            foreach (DeptNotification item in nList)
            {
                nDAO.setDeptNotificationStatusAsOld(item.notificationID);
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {

        }
    }
}