//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Team09LogicU.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class OutstandingItem
    {
        public int outstandingItemID { get; set; }
        public int outstandingID { get; set; }
        public string itemID { get; set; }
        public int expectedQty { get; set; }
        public int actualQty { get; set; }
    
        public virtual Item Item { get; set; }
        public virtual Outstanding Outstanding { get; set; }
    }
}
