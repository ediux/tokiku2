namespace Tokiku.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(View_ManufacturersBussinessTranscationsMetaData))]
    public partial class View_ManufacturersBussinessTranscations
    {
    }
    
    public partial class View_ManufacturersBussinessTranscationsMetaData
    {
        [Required]
        public System.Guid Id { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string Code { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string Name { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string TranscationItemName { get; set; }
    }
}
