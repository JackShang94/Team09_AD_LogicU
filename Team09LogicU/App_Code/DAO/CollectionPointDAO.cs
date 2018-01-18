using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Team09LogicU.App_Code.UtilClass;
using Team09LogicU.Models;

namespace Team09LogicU.App_Code.DAO
{
    public class CollectionPointDAO
    {

        SA45_Team09_LogicUEntities context = new DBEntities().getDBInstance();

        //search collection point for specific department
        public CollectionPoint getLocationandTime(string deptcode)
        {
            Department getDepartment = context.Departments.First(z => z.deptID == deptcode);
            CollectionPoint selectedpoint = context.CollectionPoints.First(a => a.collectionPointID == getDepartment.collectionPointID);
            return selectedpoint;
        }

        //show all collectionpoints
        public CollectionPoint getCollectionPointList(string cPId)
        {
            return context.CollectionPoints.Where(x => x.collectionPointID == cPId).First();
        }

        //get collection point description
        public CollectionPoint getCollectionPointDescription(string description)
        {
            return context.CollectionPoints.Where(x => x.description == description).First();
        }
    }
}