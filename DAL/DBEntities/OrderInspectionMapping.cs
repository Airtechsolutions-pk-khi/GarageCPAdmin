//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL.DBEntities
{
    using System;
    using System.Collections.Generic;
    
    public partial class OrderInspectionMapping
    {
        public int CarInspectionMapID { get; set; }
        public Nullable<int> CarInspectionDetailID { get; set; }
        public Nullable<double> Kilometers { get; set; }
        public Nullable<bool> IsInspection { get; set; }
        public Nullable<bool> IsReplace { get; set; }
        public Nullable<bool> IsInspectionWithoutReplace { get; set; }
        public Nullable<int> LocationID { get; set; }
        public Nullable<int> OrderID { get; set; }
        public Nullable<int> StatusID { get; set; }
        public string LastUpdatedBy { get; set; }
        public Nullable<System.DateTime> LastUpdatedDate { get; set; }
    
        public virtual Order Order { get; set; }
    }
}
