namespace Tokiku.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(ControlTableDetailsMetaData))]
    public partial class ControlTableDetails
    {
    }
    
    public partial class ControlTableDetailsMetaData
    {
        [Required]
        public System.Guid Id { get; set; }
        public Nullable<System.Guid> ControlTableId { get; set; }
        public Nullable<decimal> RequiredQuantitySubtotal { get; set; }
        public Nullable<decimal> RequiredQuantityWeightSummary { get; set; }
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
    
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
        public virtual ICollection<OrderMaterialValuation> OrderMaterialValuation { get; set; }
        public virtual ICollection<Inventory> Inventory { get; set; }
        public virtual ControlTables ControlTables { get; set; }
        public virtual ICollection<OrderControlTableDetails> OrderControlTableDetails { get; set; }
    }
}
