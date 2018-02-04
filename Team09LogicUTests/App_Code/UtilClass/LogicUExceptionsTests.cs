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
    public class LogicUExceptionsTests
    {
        [TestMethod()]
        public void isNullStringTest()
        {
            LogicUExceptions testClass = new LogicUExceptions("testClass");
            string testString = "";
            bool result = testClass.isNullString(testString);
            Assert.IsTrue(result);
        }
    }
}