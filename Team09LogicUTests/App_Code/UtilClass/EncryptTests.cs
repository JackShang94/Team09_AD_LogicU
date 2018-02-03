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
    public class EncryptTests
    {
        [TestMethod()]
        public void encryptStringTest()
        {
            string testPassword = "emp001";
            Encrypt testClass = new Encrypt();
            string testresult = testClass.encryptString(testPassword);

            Assert.AreEqual("80DA43043CBBE6F4225FC0A1F83086EE8CBEE84F", testresult);
        }
    }
}