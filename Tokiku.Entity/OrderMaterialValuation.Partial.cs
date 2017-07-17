namespace Tokiku.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(OrderMaterialValuationMetaData))]
    public partial class OrderMaterialValuation
    {
    }
    
    public partial class OrderMaterialValuationMetaData
    {
        [Required]
        public System.Guid Id { get; set; }
        public Nullable<System.Guid> OrderId { get; set; }
        public Nullable<System.Guid> ControlTableDetailId { get; set; }
        [Required]
        public double Weight { get; set; }
        [Required]
        public int TotalPrice { get; set; }
    
        public virtual Orders Orders { get; set; }
        public virtual ICollection<InvoiceDetails_Material> InvoiceDetails_Material { get; set; }
        public virtual ControlTableDetails ControlTableDetails { get; set; }
    }
}
