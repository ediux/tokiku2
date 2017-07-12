namespace Tokiku.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(InvoiceDetails_MiscellaneousMetaData))]
    public partial class InvoiceDetails_Miscellaneous
    {
    }
    
    public partial class InvoiceDetails_MiscellaneousMetaData
    {
        [Required]
        public System.Guid Id { get; set; }
        public Nullable<System.Guid> InvoiceId { get; set; }
        public Nullable<System.Guid> OrderMiscellaneousId { get; set; }
        public Nullable<System.Guid> ReceiptDetailsId { get; set; }
        [Required]
        public decimal PaymentAmount { get; set; }
    
        public virtual Invoices Invoices { get; set; }
        public virtual ReceiptDetails ReceiptDetails { get; set; }
    }
}
