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

/* Unmerged change from project 'Team09LogicU'
Before:
        public string DeptID;
        public int Needed;
        public int Actual;
After:
        private string deptID;
        private int needed;
        private int actual;
*/
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

/* Unmerged change from project 'Team09LogicU'
Before:
        public string ItemID;
        public string ItemDescription;
        public string Localtion;
        public int Needed;
        public int Actual;
        public  List<BreakdownByDepartment> BreakList;
After:
        private string itemID;
        private string itemDescription;
        private string localtion;
        private int needed;
        private int actual;
        private List<BreakdownByDepartment> breakList;
*/
        private string itemID;
        private string itemDescription;
        private string localtion;
        private int needed;
        private int actual;
        private List<BreakdownByDepartment> breakList;

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

        public string Localtion
        {
            get
            {
                return localtion;
            }

            set
            {
                localtion = value;
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

        public List<BreakdownByDepartment> BreakList
        {
            get
            {
                return breakList;
            }

            set
            {
                breakList = value;
            }
        }

        public RetrievalFormItem() {
            BreakList = new List<BreakdownByDepartment>();
        }

        public RetrievalFormItem(string itemID, string itemDescription, string localtion, int needed, int actual, List<BreakdownByDepartment> breakList)
        {
            this.itemID = itemID;
            this.itemDescription = itemDescription;
            this.localtion = localtion;
            this.needed = needed;
            this.actual = actual;
            this.breakList = breakList;
        }
    }
}