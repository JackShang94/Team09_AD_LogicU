using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Team09LogicU.App_Code.UtilClass
{
    public class BreakdownByDepartment
    {
        public string DeptID;
        public int Needed;
        public int Actual;

        public BreakdownByDepartment() { }

    }
    public class RetrievalFormItem
    {
        public string ItemID;
        public string ItemDescription;
        public string Localtion;
        public int Needed;
        public int Actual;
        public  List<BreakdownByDepartment> BreakList;

        public RetrievalFormItem() {
            BreakList = new List<BreakdownByDepartment>();
        }
    }
}