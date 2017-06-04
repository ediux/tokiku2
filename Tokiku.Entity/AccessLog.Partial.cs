namespace Tokiku.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(AccessLogMetaData))]
    public partial class AccessLog
    {
    }
    
    public partial class AccessLogMetaData
    {
        [Required]
        public long Id { get; set; }
        [Required]
        public System.Guid DataId { get; set; }
        [Required]
        public System.DateTime CreateTime { get; set; }
        [Required]
        public System.Guid UserId { get; set; }
        [Required]
        public byte ActionCode { get; set; }
        
        [StringLength(512, ErrorMessage="欄位長度不得大於 512 個字元")]
        public string Reason { get; set; }
    }
}
