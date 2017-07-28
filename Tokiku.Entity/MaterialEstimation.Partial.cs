namespace Tokiku.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(MaterialEstimationMetaData))]
    public partial class MaterialEstimation
    {
    }
    
    public partial class MaterialEstimationMetaData
    {
        [Required]
        public System.Guid Id { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal UnitPrice { get; set; }
        [Required]
        public decimal Weight { get; set; }
        [Required]
        public decimal TotalAmount { get; set; }
        [Required]
        public System.Guid FormDetailId { get; set; }
        [Required]
        public System.DateTime CreateTime { get; set; }
        [Required]
        public System.Guid CreateUserId { get; set; }
    
        public virtual Users CreateUser { get; set; }
    }
}
