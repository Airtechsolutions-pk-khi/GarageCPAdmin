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
    
    public partial class Role_Forms
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Role_Forms()
        {
            this.Role_GroupForms = new HashSet<Role_GroupForms>();
        }
    
        public int FormID { get; set; }
        public int RowId { get; set; }
        public string FormName { get; set; }
        public string FormPath { get; set; }
        public Nullable<int> FormOrder { get; set; }
        public string FormType { get; set; }
        public Nullable<int> SubMenuID { get; set; }
        public string CssClass { get; set; }
        public string Icon { get; set; }
        public Nullable<bool> IsMenuItem { get; set; }
        public Nullable<bool> FrontEnd { get; set; }
        public Nullable<System.DateTime> LastUpdatedDate { get; set; }
        public string LastUpdatedBy { get; set; }
        public Nullable<int> StatusID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public string CreatedBy { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Role_GroupForms> Role_GroupForms { get; set; }
    }
}