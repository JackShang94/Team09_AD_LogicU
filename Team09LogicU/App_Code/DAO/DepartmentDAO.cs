using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Team09LogicU.App_Code.UtilClass;
using Team09LogicU.Models;

namespace Team09LogicU.App_Code.DAO
{
    public class DepartmentDAO
    {
        SA45_Team09_LogicUEntities context = new DBEntities().getDBInstance();
        //find department by Id
        public Department findByDeptId(string deptId)
        {
            List<Department> deptList = context.Departments.Where(x => x.deptID == deptId).ToList();
            Department dept = new Department();
            if(deptList.Count()>0)
            {
                dept = deptList.First();
            }
            return dept;
        }
        //
        //find all departments
        public List<Department> findAll()
        {
            return context.Departments.ToList<Department>();
        }
    }
}