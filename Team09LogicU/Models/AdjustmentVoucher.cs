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
    
    public partial class AdjustmentVoucher
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AdjustmentVoucher()
        {
            this.AdjustmentVoucherItems = new HashSet<AdjustmentVoucherItem>();
        }
    
        public int adjVID { get; set; }
        public string storeStaffID { get; set; }
        public string authorisedBy { get; set; }
        public System.DateTime adjDate { get; set; }
        public string status { get; set; }
    
        public virtual StoreStaff StoreStaff { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AdjustmentVoucherItem> AdjustmentVoucherItems { get; set; }
    }
}
