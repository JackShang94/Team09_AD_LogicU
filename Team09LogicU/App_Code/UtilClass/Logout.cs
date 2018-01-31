using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Team09LogicU.App_Code.UtilClass
{
    public static class Logout 
    {
        public static void logoutUser()
        {
            HttpContext.Current.Session["loginID"] = "";
            HttpContext.Current.Session["loginRole"] = "";
            HttpContext.Current.Session["loginName"] = "";
            HttpContext.Current.Session["cart"] = "";
            HttpContext.Current.Session["adjvcart"] = "";
            HttpContext.Current.Response.Redirect("login.aspx");
        }
    }
}