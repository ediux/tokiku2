namespace Tokiku.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(View_OrderControlTableMetaData))]
    public partial class View_OrderControlTable
    {
    }
    
    public partial class View_OrderControlTableMetaData
    {
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string FormNumber { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string Code { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string ProjectsName { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string RequiredDetailsCode { get; set; }
        
        [StringLength(15, ErrorMessage="欄位長度不得大於 15 個字元")]
        [Required]
        public string ManufacturersCode { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string ManufacturersName { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string MaterialsName { get; set; }
        [Required]
        public decimal UnitWeight { get; set; }
        public Nullable<int> OrderLength { get; set; }
        public Nullable<decimal> OrderQuantity { get; set; }
        public Nullable<decimal> SparePartsNumber { get; set; }
        public Nullable<decimal> OrderTotalQuantity { get; set; }
        public Nullable<decimal> OrderTotalWeight { get; set; }
        [Required]
        public System.DateTime ExpectedDelivery { get; set; }
        public Nullable<int> ShippingOrder { get; set; }
        public string Comment { get; set; }
        [Required]
        public int LackQuantity { get; set; }
        public Nullable<decimal> LackWeight { get; set; }
        public Nullable<int> Atlas { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        public string ReceiptNumber { get; set; }
        [Required]
        public System.Guid OrdersMakingUserId { get; set; }
        [Required]
        public System.Guid OrderTypeId { get; set; }
        [Required]
        public System.Guid ShippingManufactureId { get; set; }
        public Nullable<System.Guid> OrderId { get; set; }
        [Required]
        public System.Guid ControlTableDetailId { get; set; }
        [Required]
        public System.Guid RequiredDetailsId { get; set; }
        [Required]
        public System.Guid MaterialsId { get; set; }
        [Required]
        public System.Guid RequiredId { get; set; }
        [Required]
        public System.Guid OrderDetailId { get; set; }
        [Required]
        public System.Guid ReceiptsId { get; set; }
        [Required]
        public System.Guid ProjectId { get; set; }
        [Required]
        public System.Guid ProjectContractId { get; set; }
    }
}
