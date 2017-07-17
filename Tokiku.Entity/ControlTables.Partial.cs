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
        public Nullable<System.Guid> ProjectId { get; set; }
        public Nullable<System.Guid> MaterialCategoriesId { get; set; }
        [Required]
        public System.DateTime CreateTime { get; set; }
        [Required]
        public System.Guid CreateUserId { get; set; }
    
        public virtual MaterialCategories MaterialCategories { get; set; }
        public virtual Projects Projects { get; set; }
        public virtual ICollection<Inventory> Inventory { get; set; }
        public virtual ICollection<ControlTableDetails> ControlTableDetails { get; set; }
    }
}
