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
    public partial class login : System.Web.UI.Page
    {
        LoginDAO loginDAO;
        protected void Page_Load(object sender, EventArgs e)
        {
            loginDAO = new LoginDAO();
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string username = TextBox1.Text;
            string password = TextBox2.Text;
            string hashstring = new Encrypt().encryptString(password);
            string[] result = loginDAO.getUser(username);
            if (hashstring == result[2])
            {
                Session["loginID"] = result[0];
                Session["loginRole"] = result[1];
                Session["loginName"] = result[3];
                goToRolePage(result[1]);
            }
            else if (result[0] == "")
            {
                 message.Text = "This user does not exist!";
            }
            else
            {
                 message.Text = "Invalid username or password!";
            }

        }

        protected void goToRolePage(string role)
        {
            switch (role)
            {
                case "rep":
                    Response.Redirect("Emp_MyRequisition.aspx");
                    break;
                case "emp":
                    Response.Redirect("Emp_MyRequisition.aspx");
                    break;
                case "head":
                    Response.Redirect("DH_ViewPendingRequisition.aspx");
                    break;
                case "clerk":
                    Response.Redirect("SC_dashboard.aspx");
                    break;
                case "manager":
                    Response.Redirect("SM_dashboard.aspx");
                    break;
                case "supervisor":
                    Response.Redirect("SS_dashboard.aspx");
                    break;
                case "delegeteHead":
                    Response.Redirect("DH_ViewPendingRequisition.aspx");
                    break;
                case "outOfOfficeHead":
                    Response.Redirect("DH_DelegateHeadRole.aspx");
                    break;
                default:
                    Response.Redirect("login.aspx");
                    break;
            }
        }
    }
}