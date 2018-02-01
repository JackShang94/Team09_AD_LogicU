using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team09LogicU.Models;
using Team09LogicU.App_Code.DAO;
using Team09LogicU.App_Code.UtilClass;

namespace Team09LogicU.Pages
{
    public partial class SS_TrendAnalysisReport : System.Web.UI.Page
    {
        DepartmentDAO dpd = new DepartmentDAO();

        protected void Page_Load(object sender, EventArgs e)
        {

            string data = "[" +
         "['Element', 'Density']," +
         "['Copper', 8.94], " +
         "['Silver', 10.49], " +
         "['Platinum', 21.45]" +
      "]";

            chartData.InnerHtml = "<script>var chart1Data =" + data + ";</script>";
            BindDropdownlist();
        }

        protected List<Disbursement> getDisbursementListByDept(string deptID)
        {
            List<Disbursement> dList = new List<Disbursement>();


            return dList;
        }

        protected void BindDropdownlist()
        {
            dept_dropList.DataSource = dpd.findAllDepartmentName();
            dept_dropList.DataBind();
        }
    }
}