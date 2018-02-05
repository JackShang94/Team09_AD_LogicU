using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team09LogicU.App_Code.DAO;
using Team09LogicU.App_Code.UtilClass;

using Team09LogicU.Models;

namespace Team09LogicU.Pages
{
    public partial class SC_dashboard : System.Web.UI.Page
    {
        DepartmentDAO dpd = new DepartmentDAO();
        DashBoardDAO dashBoardDAO = new DashBoardDAO();
        TrendAnalysisReportDAO reportDAO = new TrendAnalysisReportDAO();
        DateTime loginDate = DateTime.Now;
        string deptName;
        string deptid;

        string dataChart;
        string pieChartData;
        string deptRepChartData;
        string outstandingChartData;

        protected void Page_Load(object sender, EventArgs e)
        {           
            if (!IsPostBack)
            {
                /////Line Chart Data
                BindDropdownlist();
                deptName = dept_dropList.SelectedItem.Text;
                deptid = dpd.findDepartmentIdByName(deptName);
                dataChart = getBarChartDataByDeptID(deptid);
            }
            string loginID = Session["loginID"].ToString();
            NotificationDAO nDAO = new NotificationDAO();
            List<StoreNotification> nList = nDAO.getAllStoreNotificationByID(loginID);
            notice_Repeater.DataSource = nList;
            notice_Repeater.DataBind();
            foreach (StoreNotification item in nList)
            {
                nDAO.setStoreNotificationStatusAsOld(item.notificationID);
            }
            deptName = dept_dropList.SelectedItem.Text;
            deptid = dpd.findDepartmentIdByName(deptName);
            ////Pie Chart Data
            pieChartData = getPieChartData();

            ////DepartmentRep Table Chart Data
            deptRepChartData = getDeptRepChartData();

            ////Outstanding Chart Data
            outstandingChartData = getOutstandingChartData(deptid);

            chartData.InnerHtml = "<script>var dataChart =" + dataChart + "; var pieData = " +
    pieChartData + "; var deptRepData = " + deptRepChartData +
    "; var outstandingData = " + outstandingChartData + ";</script>";
        }

        protected string getOutstandingChartData(string deptid)
        {
            List<OutstandingChartData> oList = new List<OutstandingChartData>();
            oList = dashBoardDAO.getOutstandingChartData(deptid);
            string data = "[" +
            "['Item Name','Reorder Level','Oustanding Quantity'],";
            foreach (var item in oList)
            {
                data = data + "['" + item.itemName + "'," + item.reorderLevel + "," + item.outstandingQty + "],";
            }
            data = data + "]";
            return data;
        }

        protected string getDeptRepChartData()
        {
            List<DeptRepChartData> dRepList = new List<DeptRepChartData>();
            dRepList = dashBoardDAO.getDeptRepChartData();
            string data = "[" +
            "['Department Name','Rep name','Email'],";
            foreach (var item in dRepList)
            {
                data = data + "['" + item.deptID + "','" + item.repName +"','"+item.email+ "'],";
            }
            data = data + "]";
            return data;
        }

        protected string getPieChartData()
        {
            List<PieChartData> plist = dashBoardDAO.getPieChartData();
            string data = "[" +
            "['Catagory','Quantity On Hand'],";
            foreach (var item in plist)
            {
                data = data + "['" + item.catagory + "'," + item.qtyOnHand  + "],";
            }
            data = data + "]";
            return data;
        }

        protected string getBarChartDataByDeptID(string deptid)
        {
            string month1 = loginDate.ToString("Y");
            string month2 = loginDate.AddMonths(-1).ToString("Y");
            string month3 = loginDate.AddMonths(-2).ToString("Y");
            string data = "[" +
            "['Description','" + month1 + "','" + month2 + "','" + month3 + "'],";

            List<TrendAnalysisItem> tItemList = reportDAO.getTrendAnalysisItems(deptid, loginDate);
            foreach (TrendAnalysisItem item in tItemList)
            {
                data = data + "['" + item.ItemName + "'," + item.month1Quantity + "," + item.month2Quantity + "," + item.month3Quantity + "],";
            }
            data = data + "]";
            return data;
        }

        protected void deptDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            deptName = dept_dropList.SelectedItem.Text;
            deptid = dpd.findDepartmentIdByName(deptName);
            ////Line Chart Data
            dataChart = getBarChartDataByDeptID(deptid);
            
            ////Outstanding Chart Data
            outstandingChartData = getOutstandingChartData(deptid);
            chartData.InnerHtml = "<script>var dataChart =" + dataChart + "; var pieData = " +
                    pieChartData + "; var deptRepData = " + deptRepChartData +
                    "; var outstandingData = " + outstandingChartData + ";</script>";

        }

        protected void BindDropdownlist()
        {
            dept_dropList.DataSource = dpd.findAllDepartmentName();
            dept_dropList.DataBind();
        }
    }
}