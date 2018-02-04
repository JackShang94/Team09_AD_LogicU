using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Team09LogicU.App_Code.UtilClass
{
    public class LogicUExceptions : ApplicationException
    {
        public LogicUExceptions(string message): base(message)
        {

        }

        public bool isNullString(string checkstring)
        {
            bool IsNullString = false;
            if (checkstring=="")
            {
                IsNullString = true;
                return IsNullString;
            }
            else
            {
                return IsNullString;
            }
        }
    }
}