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
    public partial class SS_AssignClerk : System.Web.UI.Page
    {
        CollectionPointDAO collectionDAO = new CollectionPointDAO();
        StoreStaffDAO storeStaffDAO = new StoreStaffDAO();
        DisbursementDAO disDAO = new DisbursementDAO();
        DepartmentDAO dDAO = new DepartmentDAO();
        CollectionPointDAO cDAO = new CollectionPointDAO();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                this.BindGrid();
                this.BindDDL();
               
            }

        }

        protected void BindGrid()
        {
            List<Disbursement> disList = new List<Disbursement>();
            disList = disDAO.getAllAwaitingDisbursement();

            List<AssignClerkGridView> list = new List<AssignClerkGridView>();

            for (int i = 0; i < disList.Count(); i++)
            {
                list.Add(new AssignClerkGridView());

                list[i].CollectionPointName = dDAO.getCollectionPointbyDepartmentId(disList[i].deptID);

                list[i].DeptID = disList[i].deptID;

                list[i].Status = disList[i].status;

            }

            GridView_AssignClerk.DataSource = list;
            GridView_AssignClerk.DataBind();
        }

        protected void BindDDL()
        {
            string supervisor = (string)Session["loginID"];
            List<CollectionPoint> collectionlist = collectionDAO.getAllCollectionPoint();
            List<StoreStaff> storestafflist = storeStaffDAO.getallStoreStaff();
            List<string> staff = new List<string>();
            List<string> collection = new List<string>();
            foreach (StoreStaff s in storestafflist)
            {
                string staffrole = s.role;
                if (staffrole == "clerk")
                    staff.Add(s.storeStaffID); 
            }
           

            dropdownlist1.Items.Clear();
                dropdownlist1.DataSource = staff;
                dropdownlist1.AppendDataBoundItems = true;
                dropdownlist1.DataBind();
           
            dropdownlist2.Items.Clear();
                dropdownlist2.DataSource = staff;
                dropdownlist2.AppendDataBoundItems = true;
                dropdownlist2.DataBind();
           
            dropdownlist3.Items.Clear();
                dropdownlist3.DataSource = staff;
                dropdownlist3.AppendDataBoundItems = true;
                dropdownlist3.DataBind();
          
            dropdownlist4.Items.Clear();
                dropdownlist4.DataSource = staff;
                dropdownlist4.AppendDataBoundItems = true;
                dropdownlist4.DataBind();
           
            dropdownlist5.Items.Clear();
                dropdownlist5.DataSource = staff;
                dropdownlist5.AppendDataBoundItems = true;
                dropdownlist5.DataBind();
           
            dropdownlist6.Items.Clear();
                dropdownlist6.DataSource = staff;
                dropdownlist6.AppendDataBoundItems = true;
                dropdownlist6.DataBind();
                foreach (CollectionPoint c in collectionlist)
                {
                    collection.Add(c.description);
                }
                Label_CollectionPoint1.Text = collection[0];
                Label_CollectionPoint2.Text = collection[1];
                Label_CollectionPoint3.Text = collection[2];
                Label_CollectionPoint4.Text = collection[3];
                Label_CollectionPoint5.Text = collection[4];
                Label_CollectionPoint6.Text = collection[5];


        }

        protected void Btn_Approve_Click(object sender, EventArgs e)
        {
            string supervisor = (string)Session["loginID"];
          
            {
                collectionDAO.updatecollection(dropdownlist1.Text, Label_CollectionPoint1.Text);
                collectionDAO.updatecollection(dropdownlist2.Text, Label_CollectionPoint2.Text);
                collectionDAO.updatecollection(dropdownlist3.Text, Label_CollectionPoint3.Text);
                collectionDAO.updatecollection(dropdownlist4.Text, Label_CollectionPoint4.Text);
                collectionDAO.updatecollection(dropdownlist5.Text, Label_CollectionPoint5.Text);
                collectionDAO.updatecollection(dropdownlist6.Text, Label_CollectionPoint6.Text);
            }
        }


    }


}