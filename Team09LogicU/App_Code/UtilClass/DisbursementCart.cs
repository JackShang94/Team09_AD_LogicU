using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Team09LogicU.App_Code.UtilClass
{
    public class DisbursementCart
    {
        private string itemDescription;
        private int expectedc;
        private int actual;
        private DateTime disburstime;
        private string status;

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

        public int Expectedc
        {
            get
            {
                return expectedc;
            }

            set
            {
                expectedc = value;
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

        public DateTime Disburstime
        {
            get
            {
                return disburstime;
            }

            set
            {
                disburstime = value;
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