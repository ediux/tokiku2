namespace Tokiku.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(View_RequiredControlTableMetaData))]
    public partial class View_RequiredControlTable
    {
        public int RowIndex { get; set; }
    }
    
    public partial class View_RequiredControlTableMetaData
    {
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string Code { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string ManufacturersName { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string FactoryNumber { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string Materials { get; set; }
        [Required]
        public decimal UnitWeight { get; set; }
        public Nullable<int> OrderLength { get; set; }
        public Nullable<int> RequiredQuantitySubtotal { get; set; }
        public Nullable<decimal> RequiredQuantityWeightSummary { get; set; }
        public Nullable<decimal> NumberofOrdersNotPlaced { get; set; }
        public Nullable<decimal> QuantityofOrderSummary { get; set; }
        public Nullable<int> ArrivalCondition_QuantitySubtotal { get; set; }
        public Nullable<double> ArrivalCondition_WeightSubtotal { get; set; }
        public Nullable<decimal> ArrivalCondition_OutofStock { get; set; }
        public Nullable<int> ReturnStatus_QuantitySubtotal { get; set; }
        public Nullable<double> ReturnStatus_WeightSubtotal { get; set; }
        public Nullable<double> Weight { get; set; }
        public Nullable<int> ShippingQuantity { get; set; }
        [Required]
        public System.Guid ProjectId { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string ProjectName { get; set; }
        public Nullable<decimal> InventoryMargin_LossAdjustment_QuantitySubtotal { get; set; }
        public Nullable<decimal> InventoryMargin_LossAdjustment_WeightSubtotal { get; set; }
        public Nullable<decimal> InventoryStatus_QuantitySubtotal { get; set; }
        public Nullable<decimal> InventoryStatus_WeightSubtotal { get; set; }
    }
}
