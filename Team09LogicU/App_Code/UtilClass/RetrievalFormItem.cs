using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Team09LogicU.App_Code.UtilClass
{
    [Serializable]
    public class BreakdownByDepartment
    {

        private string deptID;
        private int needed;
        private int actual;
        
        public string DeptID
        {
            get
            {
                return deptID;
            }

            set
            {
                deptID = value;
            }
        }

        public int Needed
        {
            get
            {
                return needed;
            }

            set
            {
                needed = value;
            }
        }

        public int Actual
        {
            get
            {
                return actual;
            }

            set
            {
                actual = value;
            }
        }

   

        public BreakdownByDepartment() { }

        public BreakdownByDepartment(string deptID, int needed, int actual)
        {
            this.deptID = deptID;
            this.needed = needed;
            this.actual = actual;
        }
    }
    [Serializable]
    public class RetrievalFormItem
    {
        private string itemID;
        private string itemDescription;
        private string location;
        private int needed;
        private int actual;
        private List<BreakdownByDepartment> breakdownByDepartmentList;

        public string ItemID
        {
            get
            {
                return itemID;
            }

            set
            {
                itemID = value;
            }
        }

        public string ItemDescription
        {
            get
            {
                return itemDescription;
            }

            set
            {
                itemDescription = value;
            }
        }

        public string Location
        {
            get
            {
                return location;
            }

            set
            {
                location = value;
            }
        }

        public int Needed
        {
            get
            {
                return needed;
            }

            set
            {
                needed = value;
            }
        }

        public int Actual
        {
            get
            {
                return actual;
            }

            set
            {
                actual = value;
            }
        }

        public List<BreakdownByDepartment> BreakdownByDepartmentList
        {
            get
            {
                return breakdownByDepartmentList;
            }

            set
            {
                breakdownByDepartmentList = value;
            }
        }

        public RetrievalFormItem() {
            BreakdownByDepartmentList = new List<BreakdownByDepartment>();
        }

        public RetrievalFormItem(string itemID, string itemDescription, string location, int needed, int actual, List<BreakdownByDepartment> breakList)
        {
            this.itemID = itemID;
            this.itemDescription = itemDescription;
            this.location = location;
            this.needed = needed;
            this.actual = actual;
            this.breakdownByDepartmentList = breakList;
        }
    }
}