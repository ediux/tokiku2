namespace Tokiku.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(AbnormalQualityMetaData))]
    public partial class AbnormalQuality
    {
    }
    
    public partial class AbnormalQualityMetaData
    {
        [Required]
        public System.Guid Id { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string UnusualNumber { get; set; }
        [Required]
        public System.DateTime MakingTime { get; set; }
        [Required]
        public System.Guid MakingUserId { get; set; }
        [Required]
        public System.Guid ProjectContractId { get; set; }
        public Nullable<System.Guid> EngineeringId { get; set; }
        public Nullable<System.Guid> SupplierTranscationItemId { get; set; }
        public Nullable<System.Guid> ReceiptsId { get; set; }
        public Nullable<System.Guid> ProcessingAtlasId { get; set; }
        [Required]
        public System.DateTime CreateTime { get; set; }
        [Required]
        public System.Guid CreateUserId { get; set; }
    
        public virtual Engineering Engineering { get; set; }
        public virtual ProcessingAtlas ProcessingAtlas { get; set; }
        public virtual ProjectContract ProjectContract { get; set; }
        public virtual Receive Receipts { get; set; }
        public virtual SupplierTranscationItem SupplierTranscationItem { get; set; }
        public virtual Users Users { get; set; }
        public virtual Users Users1 { get; set; }
        public virtual ICollection<AbnormalQualityDetails> AbnormalQualityDetails { get; set; }
    }
}
