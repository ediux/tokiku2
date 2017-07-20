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
        
        [StringLength(10, ErrorMessage="欄位長度不得大於 10 個字元")]
        public string LastShopFlowId { get; set; }
        [Required]
        public System.Guid ShopFlowId { get; set; }
        public Nullable<System.Guid> NextShopFlowId { get; set; }
        
        [StringLength(128, ErrorMessage="欄位長度不得大於 128 個字元")]
        public string RefenceDataId { get; set; }
        [Required]
        public System.DateTime StartTime { get; set; }
        public Nullable<System.DateTime> EndTime { get; set; }
        [Required]
        public System.DateTime CreateTime { get; set; }
        [Required]
        public System.Guid CreateUserId { get; set; }
    }
}
