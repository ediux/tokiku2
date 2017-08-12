namespace Tokiku.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(View_ObtainMaterialMetaData))]
    public partial class View_ObtainMaterial
    {
    }
    
    public partial class View_ObtainMaterialMetaData
    {
        
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
        public int ShippingQuantity { get; set; }
        public Nullable<decimal> InventoryStatus_QuantitySubtotal { get; set; }
        
        [StringLength(512, ErrorMessage="欄位長度不得大於 512 個字元")]
        public string Comment { get; set; }
        public Nullable<int> PickingStatus_QuantitySubtotal { get; set; }
        public Nullable<double> PickingStatus_WeightSubtotal { get; set; }
        [Required]
        public System.Guid PickListDetailsId { get; set; }
        [Required]
        public System.Guid PickListId { get; set; }
        [Required]
        public System.Guid OrderDetailsId { get; set; }
        [Required]
        public System.Guid RequiredDetailsId { get; set; }
        [Required]
        public System.Guid RequiredId { get; set; }
        [Required]
        public System.Guid ManufacturersId { get; set; }
        [Required]
        public System.Guid ControlTableDetailsId { get; set; }
    }
}
