namespace Tokiku.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(InvoiceDetails_MaterialMetaData))]
    public partial class InvoiceDetails_Material
    {
    }
    
    public partial class InvoiceDetails_MaterialMetaData
    {
        [Required]
        public System.Guid Id { get; set; }
        public Nullable<System.Guid> InvoiceId { get; set; }
        public Nullable<System.Guid> OrderMaterialValuationId { get; set; }
        public Nullable<System.Guid> ReceiptDetailsId { get; set; }
        [Required]
        public decimal UnitPrice { get; set; }
        [Required]
        public double Weight { get; set; }
        [Required]
        public decimal TotalPrice { get; set; }
        [Required]
        public int Quantity { get; set; }
    
        public virtual Invoices Invoices { get; set; }
        public virtual OrderMaterialValuation OrderMaterialValuation { get; set; }
        public virtual ReceiptDetails ReceiptDetails { get; set; }
    }
}
