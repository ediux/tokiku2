namespace Tokiku.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(ProjectItemCostMetaData))]
    public partial class ProjectItemCost
    {
    }
    
    public partial class ProjectItemCostMetaData
    {
        [Required]
        public System.Guid Id { get; set; }
        [Required]
        public System.Guid EngineeringId { get; set; }
        [Required]
        public System.Guid MaterialCategoriesId { get; set; }
        [Required]
        public System.Guid ManufacturersId { get; set; }
        
        [StringLength(512, ErrorMessage="欄位長度不得大於 512 個字元")]
        public string Specification { get; set; }
        [Required]
        public float Unit { get; set; }
        [Required]
        public decimal UnitPrice { get; set; }
        [Required]
        public decimal Quantity { get; set; }
        [Required]
        public decimal Amount { get; set; }
        [Required]
        public bool IsBudget { get; set; }
        [Required]
        public System.DateTime CreateTime { get; set; }
        [Required]
        public System.Guid CreateUserId { get; set; }
    
        public virtual Engineering Engineering { get; set; }
        public virtual Manufacturers Manufacturers { get; set; }
        public virtual MaterialCategories MaterialCategories { get; set; }
        public virtual Users CreateUser { get; set; }
    }
}
