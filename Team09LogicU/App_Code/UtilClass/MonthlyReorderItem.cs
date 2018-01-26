using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Team09LogicU.App_Code.UtilClass
{
    public class MonthlyReorderItem
    {
        private int poID;
        private string orderDate;
        private string itemID;
        private string description;
        private int orderQty;
        private decimal price;
        private decimal totalAmount;

        public MonthlyReorderItem()
        { }

        public int PoID
        {
            get
            {
                return poID;
            }

            set
            {
                poID = value;
            }
        }
        public string OrderDate
        {
            get
            {
                return orderDate;
            }

            set
            {
                orderDate = value;
            }
        }
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

        public decimal Price
        {
            get
            {
                return price;
            }

            set
            {
                price = value;
            }
        }

        public decimal TotalAmount
        {
            get
            {
                return totalAmount;
            }

            set
            {
                totalAmount = value;
            }
        }
    }
}