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
        public Nullable<System.Guid> ShopFlowDetailId { get; set; }
        [Required]
        public byte State { get; set; }
        [Required]
        public System.DateTime StartTime { get; set; }
        public Nullable<System.DateTime> EndTime { get; set; }
        [Required]
        public System.Guid CreateUserId { get; set; }
    
        public virtual States States { get; set; }
        public virtual Users Users { get; set; }
    }
}
