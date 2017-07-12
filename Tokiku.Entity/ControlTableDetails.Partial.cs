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
        public Nullable<System.Guid> RequiredDetailId { get; set; }
    
        public virtual ControlTables ControlTables { get; set; }
        public virtual RequiredDetails RequiredDetails { get; set; }
        public virtual ICollection<Inventory> Inventory { get; set; }
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
        public virtual ICollection<OrderMaterialValuation> OrderMaterialValuation { get; set; }
    }
}
