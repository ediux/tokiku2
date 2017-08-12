namespace Tokiku.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(TradingItemsMetaData))]
    public partial class TradingItems
    {
    }
    
    public partial class TradingItemsMetaData
    {
        [Required]
        public System.Guid Id { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string Name { get; set; }
        [Required]
        public System.DateTime CreateTime { get; set; }
        [Required]
        public System.Guid CreateUserId { get; set; }
    
        public virtual ICollection<ManufacturersBussinessItems> ManufacturersBussinessItems { get; set; }
    }
}
