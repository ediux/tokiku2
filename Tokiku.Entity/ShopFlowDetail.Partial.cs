namespace Tokiku.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(ShopFlowDetailMetaData))]
    public partial class ShopFlowDetail
    {
    }
    
    public partial class ShopFlowDetailMetaData
    {
        [Required]
        public System.Guid Id { get; set; }
        public Nullable<System.Guid> ShopFlowId { get; set; }
        [Required]
        public System.Guid ProcessingAtlasId { get; set; }
        [Required]
        public System.Guid CurrentManufacturersId { get; set; }
        [Required]
        public System.Guid NextManufacturerId { get; set; }
        [Required]
        public System.DateTime CreateTime { get; set; }
        [Required]
        public System.Guid CreateUserId { get; set; }
    
        public virtual Manufacturers Manufacturers { get; set; }
        public virtual Manufacturers Manufacturers1 { get; set; }
        public virtual ProcessingAtlas ProcessingAtlas { get; set; }
        public virtual ShopFlow ShopFlow { get; set; }
        public virtual Users Users { get; set; }
    }
}
