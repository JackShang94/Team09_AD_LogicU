using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Team09LogicU.App_Code.UtilClass;
using Team09LogicU.Models;
namespace Team09LogicU.App_Code.DAO
{
    public class RequisitionDAO
    {
        SA45_Team09_LogicUEntities m = new DBEntities().getDBInstance();
        
        public List<Requisition> getRequisitionList()//by dept emp
        {
            return m.Requisitions.ToList<Requisition>();
        }

        public void addRequisition(string staffID, string deptID, Dictionary<string, int> dict)//by dept emp //
        {
          
            Requisition r = new Requisition();
            
            r.staffID = staffID;
            r.deptID = deptID;
            r.status = "pending";//can use a configuration class
            r.requisitionDate = DateTime.Now;
            r.approvedDate =null ;//set as minvalue
            

           
            m.Requisitions.Add(r);
            m.SaveChanges();
            int rID = r.requisitionID;
            /*************Then Add requisitionItems******************/
            RequisitionItemDAO ridao = new RequisitionItemDAO();
            foreach (var d in dict) {
                m.RequisitionItems.Add(ridao.addItem(rID, d.Key, d.Value));
            }
            m.SaveChanges();
        }

        public void removeRequisition(int reqID)//used by dept emp
        {
            Requisition r = m.Requisitions.Find(reqID);
            if (r != null)
            {
                m.Requisitions.Remove(r);
                m.SaveChanges();
            }
            return;
        }

        public List<Requisition> getRequisitionByDate(DateTime from,DateTime to)//used by dept emp for searching
        {
            return m.Requisitions.Where(x => x.requisitionDate.Date >= from && x.requisitionDate<=to).ToList<Requisition>();
        }

        public void updateRequisition(Requisition r,string remarks,string status)//?????used by dept head
        {
            r.status = status;
            r.remarks = remarks;
            r.approvedDate = DateTime.Now;
            m.SaveChanges();//?????
        }

        public List<Requisition> getRequisitionByStatus(string status)//used by dept head
        {
            return m.Requisitions.Where(x => x.status == status).ToList<Requisition>();
        }

        public List<Requisition> getRequisitionByStaffID(string staffID)//
        {
            return m.Requisitions.Where(x => x.staffID == staffID).ToList<Requisition>();
        }
        public List<Requisition> getReqByStaffIDandStatus(string staffID,string status)
        {
            return m.Requisitions.Where(x => x.staffID == staffID && x.status == status).ToList<Requisition>();
        }
        public List<Requisition> getRequisitionByDeptID(string DeptID)//used by disbursement,outstanding
        {
            return m.Requisitions.Where(x => x.deptID == DeptID).ToList<Requisition>();
        }

        public string getStatusByReqID(int reqID)
        {
            return m.Requisitions.Where(x => x.requisitionID == reqID).Select(x => x.status).ToList().First().ToString();
        }
        //public List<Requisition> getThisWeek(DateTime time)
        //{
        //    return m.Requisitions.Where(x => x.requisitionDate <  (DayOfWeek.Wednesday)).ToList<Requisition>();
        //}



    }
}