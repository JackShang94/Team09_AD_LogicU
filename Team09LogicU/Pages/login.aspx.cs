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
            //if (Request.Cookies[TextBox1.Text] != null)
            //{
                
            //    TextBox1.Text = Request.Cookies[TextBox1.Text]["userid"].ToString();             
            //    TextBox2.Attributes.Add("value", Request.Cookies[TextBox1.Text]["password"].ToString());
            //    CheckBox1.Checked = true;
            //}
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
                if (CheckBox1.Checked)
                {
                    HttpCookie cookie = new HttpCookie(username);
                    DateTime dt = DateTime.Now;
                    TimeSpan ts = new TimeSpan(0, 0, 100, 0, 0);
                    cookie.Expires = dt.Add(ts);
                    cookie.Values.Add("userid", username);
                    cookie.Values.Add("password", password);
                    Response.AppendCookie(cookie);
                }
                goToRolePage(result[1]);
            }
            else if(result[0]==""){
                string message = "This user does not exist!";
            }
            else
            {
                string message = "Invalid username or password!";
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
                    Response.Redirect("SC_RO_RetrievalForms.aspx");
                    break;
                case "manager":
                    Response.Redirect("SM_ApproveAdjustment.aspx");            
                    break;
                case "supervisor":
                    Response.Redirect("SS_ViewAdjustmentDetail.aspx");
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