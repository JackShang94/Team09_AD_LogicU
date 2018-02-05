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
            r.approvedDate = null;//set as minvalue

            m.Requisitions.Add(r);
            m.SaveChanges();
            int rID = r.requisitionID;
            /*************Then Add requisitionItems******************/
            RequisitionItemDAO ridao = new RequisitionItemDAO();
            foreach (var d in dict)
            {
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

        public List<Requisition> getRequisitionByDate(DateTime from, DateTime to)//used by dept emp for searching
        {
            return m.Requisitions.Where(x => x.requisitionDate.Date >= from && x.requisitionDate <= to).ToList<Requisition>();
        }

        public void updateRequisition(Requisition r, string remarks, string status)//used by dept head
        {
            r.status = status;
            r.remarks = remarks;
            r.approvedDate = DateTime.Now;
            m.SaveChanges();
        }

        public string getStatusByReqID(int reqID)
        {
            var a = m.Requisitions.Where(x => x.requisitionID == reqID).SingleOrDefault();
            if (a != null)
            {
                return m.Requisitions.Where(x => x.requisitionID == reqID).Select(x => x.status).First().ToString();
            }
            return null;
        }

        public string getStaffIDByReqID(int reqID)
        {
            var a = m.Requisitions.Where(x => x.requisitionID == reqID).SingleOrDefault();
            if (a != null)
            {
                return m.Requisitions.Where(x => x.requisitionID == reqID).Select(x => x.staffID).First().ToString();
            }
            return null;
        }

        public List<Requisition> getRequisitionByStatus(string status)//used by dept head
        {
            return m.Requisitions.Where(x => x.status == status).ToList<Requisition>();
        }

        public List<Requisition> getReqByStaffIDandStatus(string staffID, string status)
        {
            return m.Requisitions.Where(x => x.staffID == staffID && x.status == status).ToList<Requisition>();
        }

        public List<Requisition> getRequisitionByStaffID(string staffID)
        {
            return m.Requisitions.Where(x => x.staffID == staffID).OrderByDescending(x => x.requisitionDate).ToList<Requisition>();
        }

        public List<Requisition> getRequisitionByDeptID(string DeptID)//used by disbursement,outstanding
        {
            return m.Requisitions.Where(x => x.deptID == DeptID).ToList<Requisition>();
        }

        public List<RequisitionByStaffCart> findRequisitionByDeptIdAndStatus(string deptID, string status)
        {
            List<RequisitionByStaffCart> list = m.Requisitions.
                Where(x => x.status == status && x.deptID == deptID).OrderByDescending(x =>
                x.requisitionDate).Select(x => new RequisitionByStaffCart {
                    RequisitionId = x.requisitionID, StaffName = x.DeptStaff.staffName, RequisitionDate = x.requisitionDate, Status = x.status
                }).ToList<RequisitionByStaffCart>();
            return list;
        }

        public List<RequisitionByStaffCart> findRequisitionByDeptID(string DeptID)//used by dept head to view history
        {
            List<RequisitionByStaffCart> list = m.Requisitions.
               Where(x => x.deptID == DeptID).OrderByDescending(x => x.requisitionDate).Select(x => 
               new RequisitionByStaffCart {
                   RequisitionId = x.requisitionID, StaffName = x.DeptStaff.staffName, RequisitionDate = x.requisitionDate, Status = x.status
               }).ToList<RequisitionByStaffCart>();
            return list;
        }

        public Requisition findRequisitionByrequisitionId(int reqID)
        {
            return m.Requisitions.Find(reqID);
        }

        public List<RequisitionByStaffCart> findRequisitionByStaffID(string staffID)//
        {
            List<RequisitionByStaffCart> list = m.Requisitions.
                Where(x => x.staffID == staffID).OrderByDescending(x => x.requisitionDate).Select(x => 
                new RequisitionByStaffCart {
                    RequisitionId = x.requisitionID, StaffName = x.DeptStaff.staffName, RequisitionDate = x.requisitionDate, Status = x.status
                }).ToList<RequisitionByStaffCart>();
            return list;
        }

        public List<RequisitionByStaffCart> findRequisitionByDate(DateTime from, DateTime to, string deptID)//used by dept head for searching
        {
            List<RequisitionByStaffCart> list = m.Requisitions.
                Where(x => x.deptID == deptID).
                Select(x => new RequisitionByStaffCart {
                    RequisitionId = x.requisitionID, StaffName = x.DeptStaff.staffName, RequisitionDate = x.requisitionDate, Status = x.status
                }).ToList<RequisitionByStaffCart>();

            List<RequisitionByStaffCart> finalList = new List<RequisitionByStaffCart>();
            for (int i = 0; i < list.Count(); i++)//compare datetime
            {
                if (list[i].RequisitionDate.Year > from.Year && list[i].RequisitionDate.Year < to.Year)
                {
                    finalList.Add(list[i]);
                }
                else if (list[i].RequisitionDate.Year == from.Year || list[i].RequisitionDate.Year == to.Year)
                {
                    if (
                        (list[i].RequisitionDate.Year == from.Year && list[i].RequisitionDate.Year != to.Year && list[i].RequisitionDate.Month > from.Month) ||
                        (list[i].RequisitionDate.Year == to.Year && list[i].RequisitionDate.Year != from.Year && list[i].RequisitionDate.Month < to.Month) ||

                        (list[i].RequisitionDate.Year == to.Year && list[i].RequisitionDate.Year == from.Year
                        && list[i].RequisitionDate.Month < to.Month && list[i].RequisitionDate.Month > from.Month)
                        )
                    {
                        finalList.Add(list[i]);
                    }
                    else
                    {
                        if (
                            (list[i].RequisitionDate.Month == from.Month && list[i].RequisitionDate.Month != to.Month && list[i].RequisitionDate.Day > from.Day) ||
                            (list[i].RequisitionDate.Month == to.Month && list[i].RequisitionDate.Month != from.Month && list[i].RequisitionDate.Day < to.Day) ||

                            (list[i].RequisitionDate.Month == to.Month && list[i].RequisitionDate.Month == from.Month
                            && list[i].RequisitionDate.Day < to.Day && list[i].RequisitionDate.Day > from.Day)
                            )
                        {
                            finalList.Add(list[i]);
                        }
                    }
                }
            }
            return finalList;

        }

        public List<RequisitionByStaffCart> findRequisitionByDateAndStaffID(DateTime from, DateTime to, string staffID)//used by dept head for searching
        {
            List<RequisitionByStaffCart> list = m.Requisitions.
                Where(x => x.staffID == staffID).
                Select(x => new RequisitionByStaffCart {
                    RequisitionId = x.requisitionID, StaffName = x.DeptStaff.staffName, RequisitionDate = x.requisitionDate, Status = x.status
                }).ToList<RequisitionByStaffCart>();

            List<RequisitionByStaffCart> finalList = new List<RequisitionByStaffCart>();
            for (int i = 0; i < list.Count(); i++)
            {
                if (list[i].RequisitionDate.Year > from.Year && list[i].RequisitionDate.Year < to.Year)
                {
                    finalList.Add(list[i]);
                }
                else if (list[i].RequisitionDate.Year == from.Year || list[i].RequisitionDate.Year == to.Year)
                {
                    if (
                        (list[i].RequisitionDate.Year == from.Year && list[i].RequisitionDate.Year != to.Year && list[i].RequisitionDate.Month > from.Month) ||
                        (list[i].RequisitionDate.Year == to.Year && list[i].RequisitionDate.Year != from.Year && list[i].RequisitionDate.Month < to.Month) ||

                        (list[i].RequisitionDate.Year == to.Year && list[i].RequisitionDate.Year == from.Year
                        && list[i].RequisitionDate.Month < to.Month && list[i].RequisitionDate.Month > from.Month)
                        )
                    {
                        finalList.Add(list[i]);
                    }
                    else
                    {
                        if (
                            (list[i].RequisitionDate.Month == from.Month && list[i].RequisitionDate.Month != to.Month && list[i].RequisitionDate.Day > from.Day) ||
                            (list[i].RequisitionDate.Month == to.Month && list[i].RequisitionDate.Month != from.Month && list[i].RequisitionDate.Day < to.Day) ||

                            (list[i].RequisitionDate.Month == to.Month && list[i].RequisitionDate.Month == from.Month
                            && list[i].RequisitionDate.Day < to.Day && list[i].RequisitionDate.Day > from.Day)
                            )
                        {
                            finalList.Add(list[i]);
                        }
                    }
                }
            }
            return finalList;

        }
        /*************used By Individual Requisition******************************/
        public List<Requisition> findRequisitionByDateIndividual(DateTime from, DateTime to, string staffID)
        {
            List<Requisition> list = m.Requisitions.Where(x => x.staffID == staffID && x.status != "pending").ToList();
            List<Requisition> finalList = new List<Requisition>();
            for (int i = 0; i < list.Count(); i++)
            {
                if (list[i].requisitionDate.Year > from.Year && list[i].requisitionDate.Year < to.Year)
                {
                    finalList.Add(list[i]);
                }
                else if (list[i].requisitionDate.Year == from.Year || list[i].requisitionDate.Year == to.Year)
                {
                    if (
                        (list[i].requisitionDate.Year == from.Year && list[i].requisitionDate.Year != to.Year && list[i].requisitionDate.Month > from.Month) ||
                        (list[i].requisitionDate.Year == to.Year && list[i].requisitionDate.Year != from.Year && list[i].requisitionDate.Month < to.Month) ||

                        (list[i].requisitionDate.Year == to.Year && list[i].requisitionDate.Year == from.Year
                        && list[i].requisitionDate.Month < to.Month && list[i].requisitionDate.Month > from.Month)
                        )
                    {
                        finalList.Add(list[i]);
                    }
                    else
                    {
                        if (
                            (list[i].requisitionDate.Month == from.Month && list[i].requisitionDate.Month != to.Month && list[i].requisitionDate.Day > from.Day) ||
                            (list[i].requisitionDate.Month == to.Month && list[i].requisitionDate.Month != from.Month && list[i].requisitionDate.Day < to.Day) ||

                            (list[i].requisitionDate.Month == to.Month && list[i].requisitionDate.Month == from.Month
                            && list[i].requisitionDate.Day < to.Day && list[i].requisitionDate.Day > from.Day)
                            )
                        {
                            finalList.Add(list[i]);
                        }
                    }
                }
            }
            return finalList;
        }
    }
}