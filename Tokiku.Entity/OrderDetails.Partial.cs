namespace Tokiku.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(OrderDetailsMetaData))]
    public partial class OrderDetails
    {
    }
    
    public partial class OrderDetailsMetaData
    {
        [Required]
        public System.Guid Id { get; set; }
        public Nullable<System.Guid> OrderId { get; set; }
        public Nullable<System.Guid> ControlTableDetailId { get; set; }
        [Required]
        public decimal RequiredQuantity { get; set; }
        [Required]
        public decimal SparePartsNumber { get; set; }
        [Required]
        public decimal OrderQuantity { get; set; }
        public string Comment { get; set; }
        [Required]
        public System.DateTime CreateTime { get; set; }
        [Required]
        public System.Guid CreateUserId { get; set; }
    
        public virtual Orders Orders { get; set; }
        public virtual ICollection<PickListDetails> PickListDetails { get; set; }
        public virtual Users Users { get; set; }
        public virtual ICollection<ReceiveDetails> ReceiptDetails { get; set; }
        public virtual ICollection<ReturnDetails> ReturnDetails { get; set; }
        public virtual ICollection<InvoiceDetails> InvoiceDetails { get; set; }
        public virtual ControlTableDetails ControlTableDetails { get; set; }
    }
}
