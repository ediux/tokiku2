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
        public Nullable<System.Guid> ProcessingAtlasId { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string Name { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string CombinationNumber { get; set; }
        [Required]
        public System.Guid MaterialCategoriesId { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        public string ProcessingNumber { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        public string CrowdedNumber { get; set; }
        
        [StringLength(512, ErrorMessage="欄位長度不得大於 512 個字元")]
        [Required]
        public string MaterialDescription { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        public string CutLength { get; set; }
        public Nullable<decimal> SingleNumber { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        public string Unit { get; set; }
        [Required]
        public decimal TotalDemand { get; set; }
        public Nullable<System.Guid> ShopFlowId { get; set; }
        public string Comment { get; set; }
        public string Postion { get; set; }
        [Required]
        public System.DateTime CreateTime { get; set; }
        [Required]
        public System.Guid CreateUserId { get; set; }
        public Nullable<int> OrderLength { get; set; }
        public Nullable<decimal> UnitWeight { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string Code { get; set; }
    
        public virtual MaterialCategories MaterialCategories { get; set; }
        public virtual ProcessingAtlas ProcessingAtlas { get; set; }
        public virtual ShopFlow ShopFlow { get; set; }
        public virtual Users Users { get; set; }
    }
}
