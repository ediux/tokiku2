namespace Tokiku.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(RequiredDetailsMetaData))]
    public partial class RequiredDetails
    {
    }
    
    public partial class RequiredDetailsMetaData
    {
        [Required]
        public System.Guid Id { get; set; }
        public Nullable<System.Guid> RequiredId { get; set; }
        [Required]
        public int Order { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string Code { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string FactoryNumber { get; set; }
        public Nullable<System.Guid> MaterialsId { get; set; }
        [Required]
        public decimal UnitWeight { get; set; }
        public Nullable<int> OrderLength { get; set; }
        [Required]
        public int RequiredQuantity { get; set; }
    
        public virtual Materials Materials { get; set; }
        public virtual Required Required { get; set; }
        public virtual ICollection<ControlTableDetails> ControlTableDetails { get; set; }
    }
}
