namespace Tokiku.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(ProjectContractMetaData))]
    public partial class ProjectContract
    {
    }
    
    public partial class ProjectContractMetaData
    {
        [Required]
        public System.Guid Id { get; set; }
        [Required]
        public System.Guid ProjectId { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string Name { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string ContractNumber { get; set; }
        [Required]
        public System.DateTime SigningDate { get; set; }
        [Required]
        public bool IsAppend { get; set; }
        [Required]
        public bool IsRepair { get; set; }
        [Required]
        public System.DateTime CreateTime { get; set; }
        [Required]
        public System.Guid CreateUserId { get; set; }
    
        public virtual ICollection<Engineering> Engineering { get; set; }
        public virtual Projects Projects { get; set; }
        public virtual Users CreateUser { get; set; }
        public virtual ICollection<PromissoryNoteManagement> PromissoryNoteManagement { get; set; }
    }
}
