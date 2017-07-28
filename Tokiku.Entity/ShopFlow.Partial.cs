namespace Tokiku.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(ShopFlowMetaData))]
    public partial class ShopFlow
    {
    }
    
    public partial class ShopFlowMetaData
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
    
        public virtual ICollection<BOM> BOM { get; set; }
        public virtual ICollection<Required> Required { get; set; }
        public virtual ICollection<ShopFlowDetail> ShopFlowDetail { get; set; }
        public virtual ICollection<ControlTables> ControlTables { get; set; }
    }
}
