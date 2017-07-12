namespace Tokiku.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(StocksMetaData))]
    public partial class Stocks
    {
    }
    
    public partial class StocksMetaData
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
    
        public virtual ICollection<PickList> PickList { get; set; }
        public virtual ICollection<Receipts> Receipts { get; set; }
        public virtual ICollection<Returns> Returns { get; set; }
        public virtual ICollection<Inventory> Inventory { get; set; }
    }
}
