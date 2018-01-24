using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Team09LogicU.Models;
using Team09LogicU.App_Code.DAO;
using Team09LogicU.App_Code.UtilClass;

namespace Team09LogicU.App_Code.UtilClass
{
    public class ReorderCart
    {
        private string supplierID;
        private string staffName;
        private string orderDate;

        public string SupplierID
        {
            get
            {
                return supplierID;
            }
            set
            {
                supplierID = value;
            }
        }

        public string StaffName
        {
            get
            {
                return staffName;
            }
            set
            {
                staffName = value;
            }
        }

        public string OrderDate
        {
            get
            {
                return orderDate;
            }
            set
            {
                orderDate = value;
            }
        }
    }
}