namespace Tokiku.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(ProcessingAtlasMetaData))]
    public partial class ProcessingAtlas
    {
    }
    
    public partial class ProcessingAtlasMetaData
    {
        [Required]
        public System.Guid Id { get; set; }
        [Required]
        public System.Guid ProjectContractId { get; set; }
        [Required]
        public int Atlas { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string Name { get; set; }
        [Required]
        public System.DateTime CreateTime { get; set; }
        [Required]
        public System.Guid CreateUserId { get; set; }
    
        public virtual ProjectContract ProjectContract { get; set; }
    }
}
