using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Team09LogicU.App_Code.UtilClass;
using Team09LogicU.Models;

namespace Team09LogicU.App_Code.DAO
{
    public class NotificationDAO
    {
        SA45_Team09_LogicUEntities context = new DBEntities().getDBInstance();
         
        public void addDeptNotification(string staffID,string message, DateTime date)
        {
            DeptNotification notification = new DeptNotification();
            notification.staffID = staffID;
            notification.message = message;
            notification.date = date;
            notification.status = "NEW";

            context.DeptNotifications.Add(notification);
            context.SaveChanges();
        }

        public void addStoreNotification(string storeStaffID, string message, DateTime date)
        {
            StoreNotification notification = new StoreNotification();
            notification.storeStaffID = storeStaffID;
            notification.message = message;
            notification.date = date;
            notification.status = "NEW";

            context.StoreNotifications.Add(notification);
            context.SaveChanges();
        }

        public List<DeptNotification> getNewDeptNotificationByID(string staffID )
        {
            List<DeptNotification> list = new List<DeptNotification>();
            list = context.DeptNotifications.OrderByDescending(x=>x.date).
                Where(x => x.staffID == staffID && x.status == "NEW").ToList();
            return list;
        }

        public List<DeptNotification> getAllDeptNotificationByID(string staffID)
        {
            List<DeptNotification> list = new List<DeptNotification>();
            list = context.DeptNotifications.OrderByDescending(x => x.date).Where(x => x.staffID == staffID).ToList();
            return list;
        }

        public List<StoreNotification> getNewStoreNotificationByID(string storeStaffID)
        {
            List<StoreNotification> list = new List<StoreNotification>();
            list = context.StoreNotifications.OrderByDescending(x => x.date).Where(x => 
            x.storeStaffID == storeStaffID && x.status == "NEW").ToList();
            return list;
        }

        public List<StoreNotification> getAllStoreNotificationByID(string storeStaffID)
        {
            List<StoreNotification> list = new List<StoreNotification>();
            list = context.StoreNotifications.OrderByDescending(x => x.date).Where(x => x.storeStaffID == storeStaffID).ToList();
            return list;
        }

        public void setDeptNotificationStatusAsOld(int notificationID)
        {
            List<DeptNotification> nlist = context.DeptNotifications.Where(x => x.notificationID == notificationID).ToList();
            if (nlist.Count>0)
            {
                DeptNotification notification = nlist.First();
                notification.status = "OLD";
                context.SaveChanges();
            }
        }

        public void setStoreNotificationStatusAsOld(int notificationID)
        {
            List<StoreNotification> nlist = context.StoreNotifications.Where(x => x.notificationID == notificationID).ToList();
            if (nlist.Count>0)
            {
                StoreNotification notification = nlist.First();
                notification.status = "OLD";
                context.SaveChanges();
            }
        }
    }
}