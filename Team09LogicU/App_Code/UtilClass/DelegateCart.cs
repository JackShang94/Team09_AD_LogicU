using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Team09LogicU.App_Code.UtilClass
{
    public class DelegateCart
    {
        private int iD;
        private string name;
        private DateTime startDate;
        private DateTime endDate;
        private string status;

        public DelegateCart()
        { }

        public int ID
        {
            get; set;
        }

        public string Name
        {
            get; set;
        }

        public DateTime StartDate
        {
            get; set;
        }

        public DateTime EndDate
        {
            get; set;
        }

        public string Status
        {
            get; set;
        }
    }
}