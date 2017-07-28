namespace Tokiku.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(View_OrdersMetaData))]
    public partial class View_Orders
    {
    }
    
    public partial class View_OrdersMetaData
    {
        [Required]
        public System.Guid ProjectId { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string ProjectCode { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string ProjectName { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string ShopFlowName { get; set; }
        public Nullable<System.Guid> OrderTypeId { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string FormName { get; set; }
        [Required]
        public System.Guid RequiredId { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string FormNumber { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string Code { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string FactoryNumber { get; set; }
        [Required]
        public System.Guid MaterialsId { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string Materials { get; set; }
        [Required]
        public decimal UnitWeight { get; set; }
        public Nullable<int> OrderLength { get; set; }
        [Required]
        public decimal RequiredQuantity { get; set; }
        [Required]
        public decimal SparePartsNumber { get; set; }
        [Required]
        public decimal OrderQuantity { get; set; }
        public string Comment { get; set; }
    }
}
