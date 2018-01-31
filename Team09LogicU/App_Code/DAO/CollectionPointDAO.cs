using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Team09LogicU.App_Code.UtilClass;
using Team09LogicU.Models;

namespace Team09LogicU.App_Code.DAO
{
    public class CollectionPointInformation 
    {
        public string CollectionPointDescription;
        public string NumberOfDisbursement;
    }
    public class CollectionPointDAO
    {

        SA45_Team09_LogicUEntities context = new SA45_Team09_LogicUEntities();

        //show all collectionpoints
        //
        public List<CollectionPoint> getAllCollectionPoint()
        {
            return context.CollectionPoints.ToList();
        }

        public CollectionPoint getCollectionPointByDescription(string description)
        {
            return context.CollectionPoints.Where(x => x.description == description).First();
        }

        public List<CollectionPointInformation> getCollectionPointInformation()
        {
            List<CollectionPointInformation> list = new List<CollectionPointInformation>();

            //var result = from es in context.HoursWorked
            //             join ts in context.TimeSheet on es.Employee equals ts.Employee
            //             join ed in context.EmployeeDetailed on es.Employee equals ed.Employee
            //             group ts by new { es.Name, ed.Date } into g
            //             select new
            //             {
            //                 Name = g.Key.Name,
            //                 FirstDate = g.Key.Date,
            //                 HoursWorked = g.Sum(e => e.LaborTime),
            //             };



            return list;
        }
        public void updatecollection(string storestaffID,string description)
        {
            CollectionPoint col = context.CollectionPoints.Where(x => x.description == description).First();
            col.storeStaffID = storestaffID;
            context.SaveChanges();
        }

    }
}