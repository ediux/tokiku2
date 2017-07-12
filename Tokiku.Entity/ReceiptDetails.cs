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
    
    public partial class ReceiptDetails
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ReceiptDetails()
        {
            this.InvoiceDetails = new HashSet<InvoiceDetails>();
            this.InvoiceDetails_Material = new HashSet<InvoiceDetails_Material>();
            this.InvoiceDetails_Miscellaneous = new HashSet<InvoiceDetails_Miscellaneous>();
        }
    
        public System.Guid Id { get; set; }
        public Nullable<System.Guid> ReceiptsId { get; set; }
        public Nullable<System.Guid> OrderDetailId { get; set; }
        public int ShippingOrder { get; set; }
        public double Weight { get; set; }
        public int LackQuantity { get; set; }
        public int ReceiptQuantity { get; set; }
    
        public virtual OrderDetails OrderDetails { get; set; }
        public virtual Receipts Receipts { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InvoiceDetails> InvoiceDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InvoiceDetails_Material> InvoiceDetails_Material { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InvoiceDetails_Miscellaneous> InvoiceDetails_Miscellaneous { get; set; }
    }
}
