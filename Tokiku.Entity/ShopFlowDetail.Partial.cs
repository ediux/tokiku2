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
        public Nullable<System.Guid> WorkShopId { get; set; }
        [Required]
        public System.DateTime CreateTime { get; set; }
        [Required]
        public System.Guid CreateUserId { get; set; }
    
        public virtual ShopFlow ShopFlow { get; set; }
        public virtual Users CreateUser { get; set; }
        public virtual WorkShops WorkShops { get; set; }
    }
}
