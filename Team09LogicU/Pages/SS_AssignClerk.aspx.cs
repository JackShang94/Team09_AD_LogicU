﻿using System;
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

            List<CollectionPoint> collectionlist = collectionDAO.getAllCollectionPoint();
            for (int i = 0; i < list.Count(); i++)
            {
                if (list[i].CollectionPointName.Contains(collectionlist[0].description))
                {
                    dropdownlist1.Enabled = true;
                    dropdownlist1.BackColor = System.Drawing.Color.White;
                }

                if (list[i].CollectionPointName.Contains(collectionlist[1].description))
                {
                    dropdownlist2.Enabled = true;
                    dropdownlist2.BackColor = System.Drawing.Color.White;
                }

                if (list[i].CollectionPointName.Contains(collectionlist[2].description))
                {
                    dropdownlist3.Enabled = true;
                    dropdownlist3.BackColor = System.Drawing.Color.White;
                }

                if (list[i].CollectionPointName.Contains(collectionlist[3].description))
                {
                    dropdownlist4.Enabled = true;
                    dropdownlist4.BackColor = System.Drawing.Color.White;
                }

                if (list[i].CollectionPointName.Contains(collectionlist[4].description))
                {
                    dropdownlist5.Enabled = true;
                    dropdownlist5.BackColor = System.Drawing.Color.White;
                }

                if (list[i].CollectionPointName.Contains(collectionlist[5].description))
                {
                    dropdownlist6.Enabled = true;
                    dropdownlist6.BackColor = System.Drawing.Color.White;
                }

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


            foreach (StoreStaff s in storestafflist)
            {
                string staffrole = s.role;
                if (staffrole == "clerk")
                    staff.Add(s.storeStaffName);
            }

            if (dropdownlist1.Enabled == true)
            {
                dropdownlist1.Items.Clear();
                dropdownlist1.DataSource = staff;
                dropdownlist1.AppendDataBoundItems = true;
                dropdownlist1.Items.Insert(0, new ListItem("---Select Clerk for this time---"));
                dropdownlist1.DataBind();
            }
            else
            {
                dropdownlist1.Items.Insert(0, new ListItem(collectionlist[0].StoreStaff.storeStaffName.ToString()));
            }



            if (dropdownlist2.Enabled == true)
            {
                dropdownlist2.Items.Clear();
                dropdownlist2.DataSource = staff;
                dropdownlist2.AppendDataBoundItems = true;
                dropdownlist2.Items.Insert(0, new ListItem("---Select Clerk for this time---"));
                dropdownlist2.DataBind();
            }
            else
            {
                dropdownlist2.Items.Insert(0, new ListItem(collectionlist[1].StoreStaff.storeStaffName.ToString()));
            }


            if (dropdownlist3.Enabled == true)
            {
                dropdownlist3.Items.Clear();
                dropdownlist3.DataSource = staff;
                dropdownlist3.AppendDataBoundItems = true;
                dropdownlist3.Items.Insert(0, new ListItem("---Select Clerk for this time---"));
                dropdownlist3.DataBind();
            }
            else
            {
                dropdownlist3.Items.Insert(0, new ListItem(collectionlist[2].StoreStaff.storeStaffName.ToString()));
            }

            if (dropdownlist4.Enabled == true)
            {
                dropdownlist4.Items.Clear();
                dropdownlist4.DataSource = staff;
                dropdownlist4.AppendDataBoundItems = true;
                dropdownlist4.Items.Insert(0, new ListItem("---Select Clerk for this time---"));
                dropdownlist4.DataBind();
            }
            else
            {
                dropdownlist4.Items.Insert(0, new ListItem(collectionlist[3].StoreStaff.storeStaffName.ToString()));
            }

            if (dropdownlist5.Enabled == true)
            {
                dropdownlist5.Items.Clear();
                dropdownlist5.DataSource = staff;
                dropdownlist5.AppendDataBoundItems = true;
                dropdownlist5.Items.Insert(0, new ListItem("---Select Clerk for this time---"));
                dropdownlist5.DataBind();
            }
            else
            {
                dropdownlist5.Items.Insert(0, new ListItem(collectionlist[4].StoreStaff.storeStaffName.ToString()));
            }

            if (dropdownlist6.Enabled == true)
            {
                dropdownlist6.Items.Clear();
                dropdownlist6.DataSource = staff;
                dropdownlist6.AppendDataBoundItems = true;
                dropdownlist6.Items.Insert(0, new ListItem("---Select Clerk for this time---"));
                dropdownlist6.DataBind();
            }
            else
            {
                dropdownlist6.Items.Insert(0, new ListItem(collectionlist[5].StoreStaff.storeStaffName.ToString()));
            }
        }


        protected void Btn_Approve_Click(object sender, EventArgs e)
        {
            string supervisor = (string)Session["loginID"];

            {
                if (dropdownlist1.Text != "---Select Clerk for this time---" && dropdownlist2.Text != "---Select Clerk for this time---" &&
                    dropdownlist3.Text != "---Select Clerk for this time---" && dropdownlist4.Text != "---Select Clerk for this time---" &&
                    dropdownlist5.Text != "---Select Clerk for this time---" && dropdownlist6.Text != "---Select Clerk for this time---")
                {
                    collectionDAO.updatecollection(dropdownlist1.Text, Label_CollectionPoint1.Text);
                    collectionDAO.updatecollection(dropdownlist2.Text, Label_CollectionPoint2.Text);
                    collectionDAO.updatecollection(dropdownlist3.Text, Label_CollectionPoint3.Text);
                    collectionDAO.updatecollection(dropdownlist4.Text, Label_CollectionPoint4.Text);
                    collectionDAO.updatecollection(dropdownlist5.Text, Label_CollectionPoint5.Text);
                    collectionDAO.updatecollection(dropdownlist6.Text, Label_CollectionPoint6.Text);
                }
                else
                {
                    ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>win.alert('Notice', 'Please select all the clerks name for this time disbursements！');</script>");
                }
            }
        }


    }


}