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

        public void updateRequisition(Requisition r,string remarks,string status)//used by dept head
        {
            r.status = status;
            r.remarks = remarks;
            r.approvedDate = DateTime.Now;
            m.SaveChanges();
        }

        public List<Requisition> getRequisitionByStatus(string status)//used by dept head
        {
            return m.Requisitions.Where(x => x.status == status).ToList<Requisition>();
        }

        public List<Requisition> getRequisitionByStaffID(string staffID)//
        {
            return m.Requisitions.Where(x => x.staffID == staffID).ToList<Requisition>();
        }
        public List<Requisition> getRequisitionByDeptID(string DeptID)//used by disbursement,outstanding
        {
            return m.Requisitions.Where(x => x.deptID == DeptID).ToList<Requisition>();
        }

        public List<RequisitionByStaffCart> findRequisitionByDeptIdAndStatus(string deptID, string status)
        {
            List<RequisitionByStaffCart> list = m.Requisitions.
                Where(x => x.status == status && x.deptID == deptID).OrderByDescending(x => x.requisitionDate).Select(x => new RequisitionByStaffCart{RequisitionId = x.requisitionID,  StaffName = x.DeptStaff.staffName, RequisitionDate = x.requisitionDate, Status = x.status }).ToList<RequisitionByStaffCart>();
            return list;
            
        }

        public List<RequisitionByStaffCart> findRequisitionByDeptID(string DeptID)//used by dept head to view history
        {
            List<RequisitionByStaffCart> list = m.Requisitions.
               Where(x => x.deptID == DeptID).OrderByDescending(x => x.requisitionDate).Select(x => new RequisitionByStaffCart { RequisitionId = x.requisitionID, StaffName = x.DeptStaff.staffName, RequisitionDate = x.requisitionDate, Status = x.status }).ToList<RequisitionByStaffCart>();
            return list;
        }

        public Requisition findRequisitionByrequisitionId(int reqID)
        {
            return m.Requisitions.Find(reqID);
        }

        public List<RequisitionByStaffCart> findRequisitionByStaffID(string staffID)//
        {
            List<RequisitionByStaffCart> list = m.Requisitions.  
                Where(x => x.staffID == staffID).OrderByDescending(x => x.requisitionDate).Select(x => new RequisitionByStaffCart { RequisitionId = x.requisitionID, StaffName = x.DeptStaff.staffName, RequisitionDate = x.requisitionDate, Status = x.status }).ToList<RequisitionByStaffCart>();
            return list;          
        }

        public List<RequisitionByStaffCart> findRequisitionByDate(DateTime from, DateTime to, string deptID)//used by dept head for searching
        {
            List<RequisitionByStaffCart> list = m.Requisitions.    
                Where(x => (x.requisitionDate.Year >= from.Year && x.requisitionDate.Month >= from.Month && x.requisitionDate.Day >= from.Day) 
                && (x.requisitionDate.Year <= to.Year && x.requisitionDate.Month <= to.Month && x.requisitionDate.Day <= to.Day)
                &&x.deptID == deptID).
                Select(x => new RequisitionByStaffCart { RequisitionId = x.requisitionID, StaffName = x.DeptStaff.staffName, RequisitionDate = x.requisitionDate, Status = x.status }).ToList<RequisitionByStaffCart>();
            return list;        
        }

        public List<RequisitionByStaffCart> findRequisitionByDateAndStaffID(DateTime from, DateTime to, string staffID)//used by dept head for searching
        {
            List<RequisitionByStaffCart> list = m.Requisitions.
                Where(x => (x.requisitionDate.Year >= from.Year && x.requisitionDate.Month >= from.Month && x.requisitionDate.Day >= from.Day)
                && (x.requisitionDate.Year <= to.Year && x.requisitionDate.Month <= to.Month && x.requisitionDate.Day <= to.Day)
                && x.staffID == staffID).
                Select(x => new RequisitionByStaffCart { RequisitionId = x.requisitionID, StaffName = x.DeptStaff.staffName, RequisitionDate = x.requisitionDate, Status = x.status }).ToList<RequisitionByStaffCart>();
            return list;
        }

        //public List<Requisition> getThisWeek(DateTime time)
        //{
        //    return m.Requisitions.Where(x => x.requisitionDate <  (DayOfWeek.Wednesday)).ToList<Requisition>();
        //}



    }
}