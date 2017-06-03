namespace Tokiku.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(CompositionsMetaData))]
    public partial class Compositions
    {
    }
    
    public partial class CompositionsMetaData
    {
        [Required]
        public System.Guid Id { get; set; }
        public Nullable<System.Guid> EngineeringId { get; set; }
        [Required]
        public int Order { get; set; }
        public Nullable<int> CompositionTypeId { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string Code { get; set; }
        
        [StringLength(512, ErrorMessage="欄位長度不得大於 512 個字元")]
        public string SpecDesc { get; set; }
        [Required]
        public float Amount { get; set; }
        
        [StringLength(200, ErrorMessage="欄位長度不得大於 200 個字元")]
        public string Reserved1 { get; set; }
        
        [StringLength(200, ErrorMessage="欄位長度不得大於 200 個字元")]
        public string Reserved2 { get; set; }
        
        [StringLength(200, ErrorMessage="欄位長度不得大於 200 個字元")]
        public string Reserved3 { get; set; }
        
        [StringLength(200, ErrorMessage="欄位長度不得大於 200 個字元")]
        public string Reserved4 { get; set; }
        
        [StringLength(200, ErrorMessage="欄位長度不得大於 200 個字元")]
        public string Reserved5 { get; set; }
        [Required]
        public System.DateTime CreateTime { get; set; }
        [Required]
        public System.Guid CreateUserId { get; set; }
    
        public virtual CompositionTypes CompositionTypes { get; set; }
        public virtual Engineering Engineering { get; set; }
    }
}
