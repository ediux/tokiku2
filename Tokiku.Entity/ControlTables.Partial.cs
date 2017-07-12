namespace Tokiku.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(ControlTablesMetaData))]
    public partial class ControlTables
    {
    }
    
    public partial class ControlTablesMetaData
    {
        [Required]
        public System.Guid Id { get; set; }
        public Nullable<System.Guid> MaterialCategoriesId { get; set; }
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
        [Required]
        public System.DateTime CreateTime { get; set; }
        [Required]
        public System.Guid CreateUserId { get; set; }
    
        public virtual ICollection<ControlTableDetails> ControlTableDetails { get; set; }
        public virtual MaterialCategories MaterialCategories { get; set; }
        public virtual ICollection<Inventory> Inventory { get; set; }
    }
}
