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
    
    public partial class OrderCheckoutDetail
    {
        public int OrderCheckOutDetailID { get; set; }
        public int OrderCheckoutID { get; set; }
        public Nullable<int> PaymentMode { get; set; }
        public Nullable<double> AmountPaid { get; set; }
        public Nullable<double> AmountDiscount { get; set; }
        public string CardNumber { get; set; }
        public string CardHolderName { get; set; }
        public string CardType { get; set; }
        public Nullable<System.DateTime> CheckoutDate { get; set; }
        public string SessionID { get; set; }
        public Nullable<int> OrderStatus { get; set; }
        public string LastUpdateBy { get; set; }
        public Nullable<System.DateTime> LastUpdatedDate { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public string CreatedBy { get; set; }
    
        public virtual OrderCheckout OrderCheckout { get; set; }
    }
}
