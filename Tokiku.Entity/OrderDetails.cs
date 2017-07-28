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
    
    public partial class OrderDetails
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public OrderDetails()
        {
            this.PickListDetails = new HashSet<PickListDetails>();
            this.ReceiptDetails = new HashSet<ReceiveDetails>();
            this.InvoiceDetails = new HashSet<InvoiceDetails>();
            this.OrderControlTableDetails = new HashSet<OrderControlTableDetails>();
            this.ReturnDetails = new HashSet<ReturnDetails>();
        }
    
        public System.Guid Id { get; set; }
        public Nullable<System.Guid> OrderId { get; set; }
        public Nullable<System.Guid> ControlTableDetailId { get; set; }
        public decimal RequiredQuantity { get; set; }
        public decimal SparePartsNumber { get; set; }
        public decimal OrderQuantity { get; set; }
        public string Comment { get; set; }
        public System.DateTime CreateTime { get; set; }
        public System.Guid CreateUserId { get; set; }
        public Nullable<System.Guid> RequiredDetailsId { get; set; }
    
        public virtual Orders Orders { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PickListDetails> PickListDetails { get; set; }
        public virtual Users Users { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ReceiveDetails> ReceiptDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InvoiceDetails> InvoiceDetails { get; set; }
        public virtual ControlTableDetails ControlTableDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderControlTableDetails> OrderControlTableDetails { get; set; }
        public virtual RequiredDetails RequiredDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ReturnDetails> ReturnDetails { get; set; }
    }
}
