using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Team09LogicU.App_Code.UtilClass
{
    public class RequisitionByStaffCart
    {
        private int requisitionID;
        private string staffName;
        private DateTime requisitionDate;
        private string status;


        public RequisitionByStaffCart()
        {

        }
        public RequisitionByStaffCart(int reqID, string stfName, DateTime reqDate)
        {
            requisitionID = reqID;
            staffName = stfName;
            requisitionDate = reqDate;

        }
        public RequisitionByStaffCart(int reqID, string stfName, DateTime reqDate, string stat)
        {
            requisitionID = reqID;
            staffName = stfName;
            requisitionDate = reqDate;
            status = stat;

        }
        public int RequisitionId
        {
            get
            {
                return requisitionID;
            }
            set
            {
                requisitionID = value;
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
        public DateTime RequisitionDate
        {
            get
            {
                return requisitionDate;
            }
            set
            {
                requisitionDate = value;
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