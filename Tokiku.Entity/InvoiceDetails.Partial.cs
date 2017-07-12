namespace Tokiku.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(InvoiceDetailsMetaData))]
    public partial class InvoiceDetails
    {
    }
    
    public partial class InvoiceDetailsMetaData
    {
        [Required]
        public System.Guid Id { get; set; }
        public Nullable<System.Guid> InvoiceId { get; set; }
        public Nullable<System.Guid> OrderDetailId { get; set; }
        public Nullable<System.Guid> ReceiptDetailsId { get; set; }
        [Required]
        public int PendingPaymentQuantity { get; set; }
        public Nullable<int> PaymentQuantity { get; set; }
        public Nullable<System.Guid> LastInvoiceId { get; set; }
        public Nullable<decimal> PendingPaymentAmount { get; set; }
        public Nullable<decimal> PaymentAmount { get; set; }
        [Required]
        public bool IsReserveMoney { get; set; }
        [Required]
        public bool IsPrepayments { get; set; }
        
        [StringLength(512, ErrorMessage="欄位長度不得大於 512 個字元")]
        public string PrepaymentsDescription { get; set; }
        public Nullable<decimal> PrepaymentsAmount { get; set; }
    
        public virtual Invoices Invoices { get; set; }
        public virtual ICollection<InvoiceDetails> InvoiceDetails1 { get; set; }
        public virtual InvoiceDetails InvoiceDetails2 { get; set; }
        public virtual OrderDetails OrderDetails { get; set; }
        public virtual ReceiveDetails ReceiptDetails { get; set; }
    }
}
