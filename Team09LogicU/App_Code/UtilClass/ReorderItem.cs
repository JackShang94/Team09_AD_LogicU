using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Team09LogicU.Models;
using Team09LogicU.App_Code.DAO;
using Team09LogicU.App_Code.UtilClass;

namespace Team09LogicU.App_Code.UtilClass
{
    public class ReorderItem
    {
        private string itemID;
        private string description;
        private string unitOfMeasure;
        private int qtyOnHand;
        private int reorderLevel;
        private int reorderQty;
        List<SupplierItem> supplierItemList;

        private int orderQty;
        private string supplierID;


        public string ItemID
        {
            get
            {
                return itemID;
            }
            set
            {
                itemID = value;
            }
        }
        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
            }
        }

        public string UnitOfMeasure
        {
            get
            {
                return unitOfMeasure;
            }
            set
            {
                unitOfMeasure = value;
            }
        }

        public int QtyOnHand
        {
            get
            {
                return qtyOnHand;
            }
            set
            {
                qtyOnHand = value;
            }
        }

        public int ReorderLevel
        {
            get
            {
                return reorderLevel;
            }
            set
            {
                reorderLevel = value;
            }
        }

        public int ReorderQty
        {
            get
            {
                return reorderQty;
            }
            set
            {
                reorderQty = value;
            }
        }


        public List<SupplierItem> SupplierItemList
        {
            get
            {
                return supplierItemList;
            }

            set
            {
                supplierItemList = value;
            }
        }

        public int OrderQty
        {
            get
            {
                return orderQty;
            }
            set
            {
                orderQty = value;
            }
        }

        public string SupplierID
        {
            get
            {
                return supplierID;
            }
            set
            {
                supplierID = value;
            }
        }

    }


}