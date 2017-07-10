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
        public string Code { get; set; }
        public Nullable<System.Guid> ManufacturersId { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        public string FactoryNumber { get; set; }
        [Required]
        public System.Guid MaterialCategoriesId { get; set; }
        public Nullable<decimal> UnitWeight { get; set; }
        public Nullable<int> OrderLength { get; set; }
        public Nullable<decimal> RequiredQuantity { get; set; }
        public Nullable<decimal> RequiredQuantitySubtotal { get; set; }
        [Required]
        public decimal RequiredQuantityWeightSummary { get; set; }
        public Nullable<decimal> NumberofOrdersNotPlaced { get; set; }
        public Nullable<decimal> QuantityofOrderSummary { get; set; }
        public Nullable<decimal> PrepareSubtotal { get; set; }
        public Nullable<decimal> TotalWeightofOrder { get; set; }
        public Nullable<decimal> ArrivalCondition_QuantitySubtotal { get; set; }
        public Nullable<decimal> ArrivalCondition_WeightSubtotal { get; set; }
        public Nullable<decimal> ArrivalCondition_OutofStock { get; set; }
        public Nullable<decimal> ReturnStatus_QuantitySubtotal { get; set; }
        public Nullable<decimal> ReturnStatus_WeightSubtotal { get; set; }
        public Nullable<decimal> ReturnStatus_Receipt_QuantitySubtotal { get; set; }
        public Nullable<decimal> ReturnStatus_Receipt_WeightSubtotal { get; set; }
        public Nullable<decimal> ReturnStatus_Charge_QuantitySubtotal { get; set; }
        public Nullable<decimal> ReturnStatus_Charge_WeightSubtotal { get; set; }
        public Nullable<decimal> PickingCondition_QuantitySubtotal { get; set; }
        public Nullable<decimal> PickingCondition_WeightSubtotal { get; set; }
        public Nullable<decimal> InventoryMargin_LossAdjustment_QuantitySubtotal { get; set; }
        public Nullable<decimal> InventoryMargin_LossAdjustment_WeightSubtotal { get; set; }
        public Nullable<decimal> InventoryStatus_QuantitySubtotal { get; set; }
        public Nullable<decimal> InventoryStatus_WeightSubtotal { get; set; }
        public Nullable<System.Guid> PurchasingOrderId { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        public string ProcessingNumber { get; set; }
        
        [StringLength(512, ErrorMessage="欄位長度不得大於 512 個字元")]
        [Required]
        public string MaterialAndSurfaceTreatment { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        public string Unit { get; set; }
        public Nullable<System.Guid> ShopFlowId { get; set; }
        public string Comment { get; set; }
        [Required]
        public System.DateTime CreateTime { get; set; }
        [Required]
        public System.Guid CreateUserId { get; set; }
    
        public virtual MaterialCategories MaterialCategories { get; set; }
        public virtual ProcessingAtlas ProcessingAtlas { get; set; }
        public virtual ShopFlow ShopFlow { get; set; }
        public virtual Users Users { get; set; }
        public virtual ICollection<MaterialValuation> MaterialValuation { get; set; }
        public virtual ICollection<OrderMiscellaneous> OrderMiscellaneous { get; set; }
        public virtual Manufacturers Manufacturers { get; set; }
        public virtual PurchasingOrder PurchasingOrder { get; set; }
    }
}
