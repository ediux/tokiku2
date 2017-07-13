//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Tokiku.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class ControlTableDetails
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ControlTableDetails()
        {
            this.Inventory = new HashSet<Inventory>();
            this.OrderDetails = new HashSet<OrderDetails>();
            this.OrderMaterialValuation = new HashSet<OrderMaterialValuation>();
        }
    
        public System.Guid Id { get; set; }
        public Nullable<System.Guid> ControlTableId { get; set; }
        public Nullable<System.Guid> RequiredDetailId { get; set; }
    
        public virtual ControlTables ControlTables { get; set; }
        public virtual RequiredDetails RequiredDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Inventory> Inventory { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderMaterialValuation> OrderMaterialValuation { get; set; }
    }
}