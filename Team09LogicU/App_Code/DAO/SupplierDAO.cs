using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Team09LogicU.Models;

namespace Team09LogicU.App_Code.DAO
{
    public class SupplierDAO
    {
        SA45_Team09_LogicUEntities context = new SA45_Team09_LogicUEntities();
        public  List<Supplier> getSupplierList()
        {
            return context.Suppliers.ToList();
        }


        public  Supplier getSupplierByID(string id)
        {
            return context.Suppliers.Where(x => x.supplierID == id).First();
        }

        public void addSupplier(string supplierCode, string supplierName, string gstRegistrationNo, string address, string fax, string phone, string contactName)
        {
            Supplier supplier = new Supplier();

            supplier.supplierID = supplierCode;
            supplier.supplierName = supplierName;
            supplier.gstRegistrationNo = gstRegistrationNo;
            supplier.address = address;
            supplier.fax = fax;
            supplier.phone = phone;
            supplier.contactName = contactName;

            context.Suppliers.Add(supplier);
            context.SaveChanges();
        }

        public  void updateSupplier(string supplierCode, string supplierName, string gstRegistrationNo, string address, string fax, string phone, string contactName)
        {
            Supplier sl = context.Suppliers.Where(x => x.supplierID == supplierCode).First();
            sl.supplierID = supplierCode;
            sl.supplierName = supplierName;
            sl.gstRegistrationNo = gstRegistrationNo;
            sl.address = address;
            sl.fax = fax;
            sl.phone = phone;
            sl.contactName = contactName;
            context.SaveChanges();
        }

        public void deleteSupplier(Supplier supplier)
        {
            context.Suppliers.Remove(supplier);
            context.SaveChanges();
        }

    }
}