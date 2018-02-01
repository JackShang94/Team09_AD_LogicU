using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Team09LogicU.App_Code.UtilClass
{
    public class AssignClerkGridView
    {

        private string collectionPointName;
        private string deptID;
        private string status;
       
        public AssignClerkGridView()
        {
        }

        public string CollectionPointName
        {
            get
            {
                return collectionPointName;
            }

            set
            {
                collectionPointName = value;
            }
        }
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

        public string Status
        {
            get
            {
                return status;
            }

            set
            {
                status = value;
            }
        }
    }
}