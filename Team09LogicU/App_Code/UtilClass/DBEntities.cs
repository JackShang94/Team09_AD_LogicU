using System;
using System.Collections.Generic;
using System.Web;
using Team09LogicU;
using Team09LogicU.Models;
namespace Team09LogicU.App_Code.UtilClass
{
    public class DBEntities
    {
        private static SA45_Team09_LogicUEntities instance = null;
        
        public DBEntities()
        {
            Initialize();
        }
        private void Initialize()
        {
            instance = new SA45_Team09_LogicUEntities();
        }

        public SA45_Team09_LogicUEntities getDBInstance()
        {
            return instance;
        }

    }
}