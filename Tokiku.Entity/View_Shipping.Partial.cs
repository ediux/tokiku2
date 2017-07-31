namespace Tokiku.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(View_ShippingMetaData))]
    public partial class View_Shipping
    {
    }
    
    public partial class View_ShippingMetaData
    {
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string PickListNumber { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string BatchNumber { get; set; }
        
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
        [Required]
        public decimal OrderQuantity { get; set; }
        [Required]
        public int ShippingOrder { get; set; }
        [Required]
        public double Weight { get; set; }
        [Required]
        public int LackQuantity { get; set; }
        [Required]
        public int ShippingQuantity { get; set; }
        
        [StringLength(512, ErrorMessage="欄位長度不得大於 512 個字元")]
        public string Comment { get; set; }
        public Nullable<System.Guid> PickListId { get; set; }
        public Nullable<System.Guid> OrderDetailId { get; set; }
        public Nullable<System.Guid> OrderId { get; set; }
        public Nullable<System.Guid> RequiredDetailsId { get; set; }
        public Nullable<System.Guid> ShippingManufactureId { get; set; }
        public Nullable<System.Guid> MaterialsId { get; set; }
    }
}
