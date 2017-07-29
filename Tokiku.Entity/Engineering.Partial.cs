namespace Tokiku.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(EngineeringMetaData))]
    public partial class Engineering
    {
    }
    
    public partial class EngineeringMetaData
    {
        [Required]
        public System.Guid Id { get; set; }
        
        [StringLength(15, ErrorMessage="欄位長度不得大於 15 個字元")]
        public string Code { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string Name { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> CompletionDate { get; set; }
        public Nullable<byte> State { get; set; }
        [Required]
        public System.DateTime CreateTime { get; set; }
        [Required]
        public System.Guid CreateUserId { get; set; }
        [Required]
        public System.Guid ProjectContractId { get; set; }
        public Nullable<System.Guid> LastEngineeringId { get; set; }
        public Nullable<decimal> Amount { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        public string Unit { get; set; }
    
        public virtual States States { get; set; }
        public virtual ICollection<ProjectItemCost> ProjectItemCost { get; set; }
        public virtual ProjectContract ProjectContract { get; set; }
        public virtual ICollection<AbnormalQuality> AbnormalQuality { get; set; }
    }
}
