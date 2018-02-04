using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Team09LogicU.App_Code.UtilClass
{
    public class AdjustmentVoucherCart
    {
        private int adjvID;
        private string clerkName;
        private string authorisedBy;
        private DateTime date;
        private string status;

        public AdjustmentVoucherCart()
        { }

        public int AdjvID
        {
            get; set;
        }
        public string ClerkName
        {
            get; set;
        }

        public string AuthorisedBy
        {
            get; set;
        }

        public DateTime Date
        {
            get; set;
        }

        public string Status
        {
            get; set;
        }
    }
}