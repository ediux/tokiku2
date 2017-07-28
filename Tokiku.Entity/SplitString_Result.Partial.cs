namespace Tokiku.Entity
{
    using System;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(SplitString_ResultMetaData))]
    public partial class SplitString_Result
    {
    }
    
    public partial class SplitString_ResultMetaData
    {
        public Nullable<int> Id { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        public string Data { get; set; }
    }
}
