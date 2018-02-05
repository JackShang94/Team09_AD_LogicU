using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Team09LogicU.App_Code.UtilClass
{
    [Serializable]
    public class DisbursementCart
    {
        private string iD;
        private string description;
        private int expected;
        private int actual;
        
        public string Description
        {
            get
            {
                return description;
            }

            set
            {
                description = value;
            }
        }

        public int Expected
        {
            get
            {
                return expected;
            }

            set
            {
                expected = value;
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


        public string ID
        {
            get
            {
                return iD;
            }

            set
            {
                iD = value;
            }
        }
    }
}