using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Team09LogicU.Models;
namespace Team09LogicU.App_Code.DAO
{
    public class DelegateDAO
    {
        SA45_Team09_LogicUEntities context = new SA45_Team09_LogicUEntities();

        //add new delegate entry to DB
        public void delegateToStaff(string newHeadId, DateTime startDate, DateTime endDate)
        {
            
            //Delegate d = new Delegate();

            ////create delegate first
            //d.staffID = newHeadId;
            //d.startDate = startDate;
            //d.endDate = endDate;
            //context.Delegates.Add(d);
            //context.SaveChanges();

        }

        //set the most near active delegate to the employee
        public void terminateDelegate(string name)
        {
            //DeptStaff delegateStaff = context.DeptStaffs.Where(x => x.name == name).First();
            //try
            //{
            //    List<Delegate> delegates = getActiveDelegatesForEmp(staff.staffId);
            //    staff.delegateId = delegates.First().delegateId;
            //    context.SaveChanges();
            //}
            //catch (InvalidOperationException)
            //{
            //    staff.delegateId = null;
            //    context.SaveChanges();
            //}

        }

        //public int getLastDelegateID()
        //{
        //    return context.Delegates.OrderByDescending(x => x.delegateId).Select(x => x.delegateId).First();
        //}

        //public List<DelegateCart> getActiveDelegateCarts(string deptId)
        //{
            //DateTime now = DateTime.Today;
            //List<LogicUTrial.Delegate> delegates = new List<LogicUTrial.Delegate>();
            //delegates= context.Delegates.Where(x => x.endDate >= now).ToList();
            //List<DelegateCart> dcs = new List<DelegateCart>();
            //for(int i=delegates.Count-1;i>=0;i--)
            //{
            //    Staff s = context.Staffs.Find(delegates[i].staffId);
            //    if (s.departmentId != deptId)
            //    {
            //        delegates.RemoveAt(i);
            //    }
            //    else
            //    {
            //        DelegateCart dc = new DelegateCart();
            //        dc.delegateId = (Int32)s.delegateId;
            //        dc.staffName = s.name;
            //        dc.startDate = delegates[i].startDate;
            //        dc.endDate = delegates[i].endDate;
            //        dcs.Add(dc);
            //    }
            //}
        //    List<DelegateCart> dcs = new List<DelegateCart>();
        //    List<LogicUTrial.Delegate> ds = new List<LogicUTrial.Delegate>();
        //    ds = getActiveDelegates(deptId);
        //    foreach (LogicUTrial.Delegate d in ds)
        //    {
        //        Staff s = context.Staffs.Find(d.staffId);
        //        DelegateCart dc = new DelegateCart();
        //        dc.delegateId = (Int32)d.delegateId;
        //        dc.staffName = s.name;
        //        dc.startDate = d.startDate;
        //        dc.endDate = d.endDate;
        //        dcs.Add(dc);
        //    }
        //    return dcs;
        //}

        //get active delegations for the department
        //public List<LogicUTrial.Delegate> getActiveDelegates(string deptId)
        //{
        //    DateTime now = DateTime.Today;
        //    List<LogicUTrial.Delegate> delegates = context.Delegates.Where(x => x.endDate >= now).ToList();
        //    for (int i = delegates.Count - 1; i >= 0; i--)
        //    //foreach (LogicUTrial.Delegate d in delegates)
        //    {
        //        Staff s = context.Staffs.Find(delegates[i].staffId);
        //        if (s.departmentId != deptId)
        //        {
        //            delegates.RemoveAt(i);
        //        }
        //    }
        //    return delegates;
        //}

        //get active delegations for the employee
        //public List<LogicUTrial.Delegate> getActiveDelegatesForEmp(string empId)
        //{
        //    DateTime now = DateTime.Today;
        //    List<LogicUTrial.Delegate> delegates = context.Delegates.Where(x => x.endDate >= now && x.staffId == empId).OrderBy(p => p.startDate).ToList();
        //    return delegates;
        //}

        //public LogicUTrial.Delegate getComingOrCurrentdelegationForEmp()
        //{

        //}

        //public void removeDelegationById(int delegateId)
        //{
        //    LogicUTrial.Delegate d = context.Delegates.Find(delegateId);
        //    context.Delegates.Remove(d);
        //    context.SaveChanges();
        //}
    }
}