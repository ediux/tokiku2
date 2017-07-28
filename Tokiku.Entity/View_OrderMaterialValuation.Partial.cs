namespace Tokiku.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(View_OrderMaterialValuationMetaData))]
    public partial class View_OrderMaterialValuation
    {
    }
    
    public partial class View_OrderMaterialValuationMetaData
    {
        [Required]
        public System.Guid ProjectId { get; set; }
        [Required]
        public System.Guid OrdersId { get; set; }
        [Required]
        public System.Guid ShopFlowId { get; set; }
        public Nullable<System.Guid> OrderTypeId { get; set; }
        [Required]
        public System.Guid OrderMaterialValuationId { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string ProjectCode { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string ProjectName { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string FormName { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string ShowFlowName { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string RequiredDep { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string FormNumber { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string BatchNumber { get; set; }
        [Required]
        public System.DateTime ExpectedDelivery { get; set; }
        public Nullable<System.DateTime> ActualDelivery { get; set; }
        
        [StringLength(256, ErrorMessage="欄位長度不得大於 256 個字元")]
        [Required]
        public string MakerUser { get; set; }
        public Nullable<System.DateTime> MakingTime { get; set; }
        public Nullable<double> ReservedPercentage { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string ShippingManufacture { get; set; }
        public Nullable<System.Guid> ShippingManufactureId { get; set; }
        public Nullable<System.Guid> MaterialsId { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string Materials { get; set; }
        [Required]
        public float UnitPrice { get; set; }
        [Required]
        public double Weight { get; set; }
        [Required]
        public int TotalPrice { get; set; }
        [Required]
        public System.DateTime CreateTime { get; set; }
        
        [StringLength(256, ErrorMessage="欄位長度不得大於 256 個字元")]
        [Required]
        public string CreateUser { get; set; }
    }
}
