namespace Tokiku.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(InventoryMetaData))]
    public partial class Inventory
    {
    }
    
    public partial class InventoryMetaData
    {
        [Required]
        public System.Guid Id { get; set; }
        public Nullable<System.Guid> ControlTableId { get; set; }
        public Nullable<System.Guid> ControlTableDetailId { get; set; }
        public Nullable<System.Guid> RequireDetailId { get; set; }
        public Nullable<System.Guid> StockId { get; set; }
        [Required]
        public int Amount { get; set; }
    
        public virtual ControlTableDetails ControlTableDetails { get; set; }
        public virtual ControlTables ControlTables { get; set; }
        public virtual RequiredDetails RequiredDetails { get; set; }
        public virtual Stocks Stocks { get; set; }
    }
}
