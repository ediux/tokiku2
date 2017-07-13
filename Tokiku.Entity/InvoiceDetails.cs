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
    
    public partial class InvoiceDetails
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public InvoiceDetails()
        {
            this.InvoiceDetails1 = new HashSet<InvoiceDetails>();
        }
    
        public System.Guid Id { get; set; }
        public Nullable<System.Guid> InvoiceId { get; set; }
        public Nullable<System.Guid> OrderDetailId { get; set; }
        public Nullable<System.Guid> ReceiptDetailsId { get; set; }
        public int PendingPaymentQuantity { get; set; }
        public Nullable<int> PaymentQuantity { get; set; }
        public Nullable<System.Guid> LastInvoiceId { get; set; }
        public Nullable<decimal> PendingPaymentAmount { get; set; }
        public Nullable<decimal> PaymentAmount { get; set; }
        public bool IsReserveMoney { get; set; }
        public bool IsPrepayments { get; set; }
        public string PrepaymentsDescription { get; set; }
        public Nullable<decimal> PrepaymentsAmount { get; set; }
    
        public virtual Invoices Invoices { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InvoiceDetails> InvoiceDetails1 { get; set; }
        public virtual InvoiceDetails InvoiceDetails2 { get; set; }
        public virtual OrderDetails OrderDetails { get; set; }
        public virtual ReceiveDetails ReceiptDetails { get; set; }
    }
}