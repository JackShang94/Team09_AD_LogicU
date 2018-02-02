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
        TrendAnalysisReportDAO reportDAO = new TrendAnalysisReportDAO();
        DateTime loginDate = DateTime.Now;
        string deptName;
        string deptid;
        
        string dataChart;

        protected void Page_Load(object sender, EventArgs e)
        {
     
            if (!IsPostBack)
            {
                BindDropdownlist();
                deptName = dept_dropList.SelectedItem.Text;
                deptid = dpd.findDepartmentIdByName(deptName);
                dataChart = getBarChartDataByDeptID(deptid);
                chartData.InnerHtml = "<script>var chartData =" + dataChart + ";</script>";
            }
        }

        protected string getBarChartDataByDeptID(string deptid)
        {
            string data = "[" +
            "['Descroption','Month1','Month2','Month3'],";

            List<TrendAnalysisItem> tItemList =  reportDAO.getTrendAnalysisItems(deptid, loginDate);
            foreach (TrendAnalysisItem item in tItemList)
            {
                data = data + "['" + item.ItemName + "'," + item.month1Quantity+","+item.month2Quantity+","+item.month3Quantity + "],";
            }
            data = data + "]";
            return data;
        }

        protected void deptDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            deptName = dept_dropList.SelectedItem.Text;
            deptid = dpd.findDepartmentIdByName(deptName);
            dataChart = getBarChartDataByDeptID(deptid);
            chartData.InnerHtml = "<script>var chartData =" + dataChart + ";</script>";

        }

        protected void BindDropdownlist()
        {
            dept_dropList.DataSource = dpd.findAllDepartmentName();
            dept_dropList.DataBind();
        }
    }
}