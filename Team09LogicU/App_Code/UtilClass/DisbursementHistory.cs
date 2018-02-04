using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Team09LogicU.Models;
using Team09LogicU.App_Code.DAO;
using Team09LogicU.App_Code.UtilClass;

namespace Team09LogicU.App_Code.UtilClass
{
    public class DisbursementHistory
    {
        private int disbursementID;
        private string staffName;
        private DateTime date;

        public DisbursementHistory()
        { }

        public int DisbursementID
        {
            get
            {
                return disbursementID;
            }

            set
            {
                disbursementID = value;
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

        public DateTime Date
        {
            get
            {
                return date;
            }

            set
            {
                date = value;
            }
        }


    }
}