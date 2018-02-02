using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team09LogicU.Models;
using Team09LogicU.App_Code.DAO;
using Team09LogicU.App_Code.UtilClass;
using System.Data;

namespace Team09LogicU.Pages
{
    public partial class SC_O_SOA : System.Web.UI.Page
    {
        DepartmentDAO dpd = new DepartmentDAO();
        SOADAO soaDAO = new SOADAO();
        List<SOAItems> soaList;
        string deptName;
        string deptid;
        decimal soaTotalPice;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (! IsPostBack)
            {
                BindDropdownlist();
            }
        }
        protected void BindDropdownlist()
        {
            ddlDepartment.DataSource = dpd.findAllDepartmentName();
            ddlDepartment.DataBind();        
        }
        protected void BindGridViewData(List<SOAItems> soaList)
        {
            soaTotalPice = 0;
            DataTable iTable = new DataTable("itemTable");
            iTable.Columns.Add(new DataColumn("itemID", typeof(string)));
            iTable.Columns.Add(new DataColumn("description", typeof(string)));
            iTable.Columns.Add(new DataColumn("soldQuantity", typeof(int)));
            iTable.Columns.Add(new DataColumn("unitPrice", typeof(decimal)));
            iTable.Columns.Add(new DataColumn("totalPrice", typeof(decimal)));
            foreach (SOAItems item in soaList)
            {
                soaTotalPice = soaTotalPice+ item.totalPrice;
                DataRow dr = iTable.NewRow();
                dr["itemID"] = item.itemID;
                dr["description"] = item.itemName;
                dr["soldQuantity"] = item.soldQuantity;
                dr["unitPrice"] = item.unitPrice;
                dr["totalPrice"] = item.totalPrice;
                iTable.Rows.Add(dr);
            }
            TotalPrice.Text = soaTotalPice.ToString();
            GridView_SOA.DataSource = iTable;
            GridView_SOA.DataBind();
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            deptName = ddlDepartment.SelectedItem.Text;
            deptid = dpd.findDepartmentIdByName(deptName);
            if (txtFrom.Text != "" || txtTo.Text != "")
            {
                DateTime startDate = Convert.ToDateTime(txtFrom.Text);
                DateTime endDate = Convert.ToDateTime(txtTo.Text);
                soaList = soaDAO.getSOAItems(deptid,startDate,endDate);
                BindGridViewData(soaList);
            }
            else
            {
                ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>win.alert('Notice', 'Date can't be empty!');</script>");
            }
        }
    }
}