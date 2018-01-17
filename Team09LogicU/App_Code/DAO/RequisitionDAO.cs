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
        
        public List<object> getRequisitionList()//by dept emp
        {
            return m.Requisitions.Select(x => new { x.requisitionID, x.requisitionDate,x.approvedDate, x.status }).ToList<object>();
        }

        public void addRequisition(string reqID,string staffID, string deptID)//by dept emp
        {
            Requisition r = new Requisition();
            r.staffID = staffID;
            r.deptID = deptID;
           
            r.status = "pending";//can use a configuration class
            r.requisitionDate = DateTime.Now;
            r.approvedDate = DateTime.Today;//??????

            m.Requisitions.Add(r);
            m.SaveChanges();

        }

        public void removeRequisition(int reqID)//dept emp
        {
            Requisition r = m.Requisitions.Find(reqID);
            m.Requisitions.Remove(r);
            m.SaveChanges();
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

        public List<Requisition> findRequisitionByStatus(string status)//used by dept head
        {
            return m.Requisitions.Where(x => x.status == status).ToList<Requisition>();
        }

        public List<Requisition> findRequisitionByStaffID(string staffID)//
        {
            return m.Requisitions.Where(x => x.staffID == staffID).ToList<Requisition>();
        }
        public List<Requisition> findRequisitionByDeptID(string DeptID)//used by disbursement,outstanding
        {
            return m.Requisitions.Where(x => x.deptID == DeptID).ToList<Requisition>();
        }





    }
}