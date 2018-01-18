using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;
using Team09LogicU.Models;

namespace Team09LogicU.App_Code.UtilClass
{
    public class Encrypt
    {
        public Encrypt() { }
        public string encryptString(string PasswordString)
        {
            string encryptString = null;
            encryptString = FormsAuthentication.HashPasswordForStoringInConfigFile(PasswordString, "SHA1");
            return encryptString;
        }
    }
}