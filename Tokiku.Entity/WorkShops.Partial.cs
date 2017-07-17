namespace Tokiku.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(WorkShopsMetaData))]
    public partial class WorkShops
    {
    }
    
    public partial class WorkShopsMetaData
    {
        [Required]
        public System.Guid Id { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string Name { get; set; }
        public Nullable<System.Guid> RefId { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        public string Location { get; set; }
        public Nullable<System.Guid> OwnerId { get; set; }
        [Required]
        public bool Void { get; set; }
        [Required]
        public System.DateTime CreateTime { get; set; }
        [Required]
        public System.Guid CreateUserId { get; set; }
    
        public virtual Manufacturers Manufacturers { get; set; }
    }
}
