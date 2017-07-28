namespace Tokiku.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(EncodingRecordsMetaData))]
    public partial class EncodingRecords
    {
    }
    
    public partial class EncodingRecordsMetaData
    {
        [Required]
        public System.Guid Id { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        public string EncodingName { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        public string CodeName1 { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        public string CodeName2 { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        public string CodeName3 { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        public string CodeName4 { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        public string CodeName5 { get; set; }
        [Required]
        public int Number1 { get; set; }
        [Required]
        public int Number2 { get; set; }
        [Required]
        public int Number3 { get; set; }
        [Required]
        public int Number4 { get; set; }
        [Required]
        public int Number5 { get; set; }
    }
}
