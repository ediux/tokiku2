namespace Tokiku.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(RequiredMetaData))]
    public partial class Required
    {
    }
    
    public partial class RequiredMetaData
    {
        [Required]
        public System.Guid Id { get; set; }
        public Nullable<System.Guid> ProjectId { get; set; }
        public Nullable<System.Guid> ProjectContractId { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string FormNumber { get; set; }
        public Nullable<System.Guid> ManufacturersId { get; set; }
        public Nullable<System.Guid> MaterialCategoriesId { get; set; }
        [Required]
        public System.DateTime MakingTime { get; set; }
        [Required]
        public System.Guid MakingUserId { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string RequiredPostion { get; set; }
        [Required]
        public System.DateTime CreateTime { get; set; }
        [Required]
        public System.Guid CreateUserId { get; set; }
    
        public virtual Manufacturers Manufacturers { get; set; }
        public virtual MaterialCategories MaterialCategories { get; set; }
        public virtual ProjectContract ProjectContract { get; set; }
        public virtual Projects Projects { get; set; }
        public virtual Users CreateUser { get; set; }
        public virtual Users MakingUser { get; set; }
        public virtual ICollection<RequiredDetails> RequiredDetails { get; set; }
    }
}
