using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Team09LogicU.App_Code.UtilClass
{
    public class OutstandingCart
    {
        private string itemID;
        private string itemDesc;
        private string unit;
        private int needed;
        private DateTime disburseDate;

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

        public string ItemDesc
        {
            get
            {
                return itemDesc;
            }

            set
            {
                itemDesc = value;
            }
        }

        public string Unit
        {
            get
            {
                return unit;
            }

            set
            {
                unit = value;
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

        public DateTime DisburseDate
        {
            get
            {
                return disburseDate;
            }

            set
            {
                disburseDate = value;
            }
        }
    }
}