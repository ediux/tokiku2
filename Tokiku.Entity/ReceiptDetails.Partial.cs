namespace Tokiku.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(ReceiptDetailsMetaData))]
    public partial class ReceiptDetails
    {
    }
    
    public partial class ReceiptDetailsMetaData
    {
        [Required]
        public System.Guid Id { get; set; }
        public Nullable<System.Guid> ReceiptsId { get; set; }
        public Nullable<System.Guid> OrderDetailId { get; set; }
        [Required]
        public int ShippingOrder { get; set; }
        [Required]
        public double Weight { get; set; }
        [Required]
        public int LackQuantity { get; set; }
        [Required]
        public int ReceiptQuantity { get; set; }
    
        public virtual OrderDetails OrderDetails { get; set; }
        public virtual Receipts Receipts { get; set; }
        public virtual ICollection<InvoiceDetails> InvoiceDetails { get; set; }
        public virtual ICollection<InvoiceDetails_Material> InvoiceDetails_Material { get; set; }
        public virtual ICollection<InvoiceDetails_Miscellaneous> InvoiceDetails_Miscellaneous { get; set; }
    }
}
