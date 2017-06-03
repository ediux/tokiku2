namespace Tokiku.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(BOMMetaData))]
    public partial class BOM
    {
    }
    
    public partial class BOMMetaData
    {
        [Required]
        public System.Guid Id { get; set; }
        public Nullable<System.Guid> ShopFlowId { get; set; }
        [Required]
        public System.Guid MaterialsId { get; set; }
        [Required]
        public float Amount { get; set; }
    
        public virtual Materials Materials { get; set; }
        public virtual ShopFlowHistory ShopFlowHistory { get; set; }
    }
}
