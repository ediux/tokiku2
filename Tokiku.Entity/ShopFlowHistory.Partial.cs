namespace Tokiku.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(ShopFlowHistoryMetaData))]
    public partial class ShopFlowHistory
    {
    }
    
    public partial class ShopFlowHistoryMetaData
    {
        [Required]
        public System.Guid Id { get; set; }
        [Required]
        public System.Guid EngineeringId { get; set; }
        public Nullable<System.Guid> ShopId { get; set; }
        [Required]
        public byte State { get; set; }
        [Required]
        public System.DateTime CreateTime { get; set; }
        [Required]
        public System.Guid CreateUserId { get; set; }
        public Nullable<System.Guid> ShopFlowId { get; set; }
    
        public virtual States States { get; set; }
        public virtual Users CreateUser { get; set; }
        public virtual ShopFlowHistory ShopFlowHistory1 { get; set; }
        public virtual Engineering Engineering { get; set; }
    }
}
