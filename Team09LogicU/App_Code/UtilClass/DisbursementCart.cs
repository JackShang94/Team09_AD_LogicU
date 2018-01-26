using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Team09LogicU.App_Code.UtilClass
{
    [Serializable]
    public class DisbursementCart
    {
        private string itemID;
        private string itemDescription;
        private int expectedc;
        private int actual;
        

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
    }
}