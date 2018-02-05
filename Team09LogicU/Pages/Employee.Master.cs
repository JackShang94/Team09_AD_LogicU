using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team09LogicU.App_Code.UtilClass;
using Team09LogicU.App_Code.DAO;


namespace Team09LogicU.pages
{
    public partial class Employee : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string loginRole = Session["loginRole"].ToString();
            if (loginRole=="emp" || loginRole =="rep")
            {
                Label1.Text = Session["loginName"].ToString();
                string loginID = Session["loginID"].ToString();
                img.Src = "../picture/" + loginID + ".jpg";
                NotificationDAO nDAO = new NotificationDAO();
                var deptNotifications = nDAO.getNewDeptNotificationByID(loginID);
                notificationNum.Text = deptNotifications.Count.ToString();
            }
            else
            {
                Response.Redirect("login.aspx");
            }
        }

        protected void Logout_Click(object sender, EventArgs e)
        {
            Logout.logoutUser();
        }
    }
}