namespace Tokiku.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(OrderControlTableDetailsMetaData))]
    public partial class OrderControlTableDetails
    {
    }
    
    public partial class OrderControlTableDetailsMetaData
    {
        [Required]
        public System.Guid Id { get; set; }
        public Nullable<System.Guid> ProcessingAtlasId { get; set; }
        public Nullable<System.Guid> ControlTableDetailsId { get; set; }
        public Nullable<System.Guid> OrderDetailId { get; set; }
        [Required]
        public int OrderTotalQuantity { get; set; }
        [Required]
        public decimal OrderTotalWeight { get; set; }
    
        public virtual ControlTableDetails ControlTableDetails { get; set; }
        public virtual OrderDetails OrderDetails { get; set; }
        public virtual ProcessingAtlas ProcessingAtlas { get; set; }
    }
}
