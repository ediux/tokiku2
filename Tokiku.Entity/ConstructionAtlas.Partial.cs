namespace Tokiku.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(ConstructionAtlasMetaData))]
    public partial class ConstructionAtlas
    {
    }
    
    public partial class ConstructionAtlasMetaData
    {
        [Required]
        public System.Guid Id { get; set; }
        public Nullable<System.Guid> ProjectContractId { get; set; }
        
        [StringLength(250, ErrorMessage="欄位長度不得大於 250 個字元")]
        [Required]
        public string ImageName { get; set; }
        [Required]
        public int Edition { get; set; }
        [Required]
        public System.DateTime SubmissionDate { get; set; }
        
        [StringLength(250, ErrorMessage="欄位長度不得大於 250 個字元")]
        [Required]
        public string SubmitCertificateNumber { get; set; }
        public Nullable<System.DateTime> ReplyDate { get; set; }
        
        [StringLength(250, ErrorMessage="欄位長度不得大於 250 個字元")]
        public string ReplyNumber { get; set; }
        [Required]
        public int ReplyContent { get; set; }
        [Required]
        public bool Finalized { get; set; }
        
        [StringLength(512, ErrorMessage="欄位長度不得大於 512 個字元")]
        public string Comment { get; set; }
        [Required]
        public System.DateTime CreateTime { get; set; }
        [Required]
        public System.Guid CreateUserId { get; set; }
        public Nullable<System.Guid> ProjectId { get; set; }
    
        public virtual Projects Projects { get; set; }
    }
}
