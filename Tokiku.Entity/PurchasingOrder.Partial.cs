namespace Tokiku.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(PurchasingOrderMetaData))]
    public partial class PurchasingOrder
    {
    }
    
    public partial class PurchasingOrderMetaData
    {
        [Required]
        public System.Guid Id { get; set; }
        public Nullable<System.Guid> FormDetailId { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string Code { get; set; }
        public Nullable<System.Guid> MaterialId { get; set; }
        [Required]
        public double UnitWeight { get; set; }
        [Required]
        public double OrderLength { get; set; }
        [Required]
        public decimal RequiredQuantity { get; set; }
        [Required]
        public decimal SparePartsNumber { get; set; }
        [Required]
        public decimal OrderQuantity { get; set; }
        public string Comment { get; set; }
        [Required]
        public System.DateTime CreateTime { get; set; }
        [Required]
        public System.Guid CreateUserId { get; set; }
        public Nullable<System.Guid> BOMId { get; set; }
    
        public virtual FormDetails FormDetails { get; set; }
        public virtual Materials Materials { get; set; }
        public virtual Users Users { get; set; }
        public virtual BOM BOM { get; set; }
    }
}
