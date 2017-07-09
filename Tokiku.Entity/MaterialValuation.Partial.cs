namespace Tokiku.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(MaterialValuationMetaData))]
    public partial class MaterialValuation
    {
    }
    
    public partial class MaterialValuationMetaData
    {
        [Required]
        public System.Guid Id { get; set; }
        [Required]
        public System.Guid FormDetailId { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        public string ItemName { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        public string Material { get; set; }
        public Nullable<int> UnitPrice { get; set; }
        public Nullable<double> Weight { get; set; }
        public Nullable<int> TotalPrice { get; set; }
        public Nullable<System.Guid> BOMId { get; set; }
    
        public virtual FormDetails FormDetails { get; set; }
        public virtual BOM BOM { get; set; }
    }
}
