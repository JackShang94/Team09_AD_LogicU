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
    public partial class SC_ViewDepartment : System.Web.UI.Page
    {
        DepartmentDAO depDAO = new DepartmentDAO();
        DeptStaffDAO depstaffDAO = new DeptStaffDAO();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.BindGrid();
            }
        }
        protected void BindGrid()
        {
           
            List<Department> deplist = new List<Department>();
            deplist = depDAO.findAll();
            DataTable iTable = new DataTable("itemTable");
            iTable.Columns.Add(new DataColumn("deptID", typeof(string)));
            iTable.Columns.Add(new DataColumn("deptName", typeof(string)));
            iTable.Columns.Add(new DataColumn("staffName", typeof(string)));
            iTable.Columns.Add(new DataColumn("phone", typeof(string)));
            iTable.Columns.Add(new DataColumn("fax", typeof(string)));
            iTable.Columns.Add(new DataColumn("headName", typeof(string)));
            iTable.Columns.Add(new DataColumn("collectionPointID", typeof(string)));
            iTable.Columns.Add(new DataColumn("reqName", typeof(string)));
            
            foreach (Department i in deplist)
            {                           
                DataRow dr = iTable.NewRow();
                DeptStaff HEADSTAFF = depstaffDAO.findStaffByStaffID(i.headStaffID);
                DeptStaff REPSTAFFID = depstaffDAO.findStaffByStaffID(i.repStaffID);
                DeptStaff CONTACTNAME = depstaffDAO.findStaffByStaffID(i.contactStaffID);
               
                dr["deptID"] = i.deptID;
                dr["deptName"] = i.deptName;
                dr["staffName"] = CONTACTNAME.staffName;
                dr["phone"] = i.phone;
                dr["fax"] = i.fax;
                dr["headName"] = HEADSTAFF.staffName;
                dr["collectionPointID"] = i.collectionPointID;
                dr["reqName"] = REPSTAFFID.staffName;
                iTable.Rows.Add(dr);
            }

            GridView_DepList.DataSource = iTable;
            GridView_DepList.DataBind();
        }

    }
}