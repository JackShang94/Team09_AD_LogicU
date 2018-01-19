using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Team09LogicU.App_Code.UtilClass
{
    public class cart
    {
        private  string name;
        private string itemID;
        private string description;
        private int qty;
        public cart()
        {

        }
        public cart(string name,string itemID,string desc,int qty)
        {
            this.name = name;
            this.itemID = itemID;
            this.description = desc;
            this.qty = qty;
        }

        public string Name
        {
            get;set;
        }
        public string ItemID
        {
            get ; set;
        }
        public string Description
        {
            get;set;
        }
        public int Qty
        {
            get;set;
        }
        
    }
}