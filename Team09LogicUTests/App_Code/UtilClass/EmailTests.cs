using Microsoft.VisualStudio.TestTools.UnitTesting;
using Team09LogicU.App_Code.UtilClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team09LogicU.App_Code.UtilClass.Tests
{
    [TestClass()]
    public class EmailTests
    {
        [TestMethod()]
        public void sendNewReqEmailToHeadTest()
        {
            string testStaffName = "Mr. White";
            string testHeadName = "Mr. Black";

            Email testClass = new Email();
            testClass.sendNewReqEmailToHead(testStaffName, testHeadName);           
        }
    }
}