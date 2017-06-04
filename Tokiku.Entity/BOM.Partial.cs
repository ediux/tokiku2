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
        [Required]
        public System.Guid ProjectItemCostId { get; set; }
        [Required]
        public int Bidders { get; set; }
        [Required]
        public int NumberTenders { get; set; }
        
        [StringLength(512, ErrorMessage="欄位長度不得大於 512 個字元")]
        public string ItemName { get; set; }
        [Required]
        public System.Guid ShopFlowId { get; set; }
        [Required]
        public System.DateTime CreateTime { get; set; }
        [Required]
        public System.Guid CreateUserId { get; set; }
    }
}
