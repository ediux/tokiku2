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
        public Nullable<System.Guid> ProjectId { get; set; }
        public Nullable<System.Guid> ContractorId { get; set; }
        [Required]
        public System.DateTime SigningDate { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string ContractNumber { get; set; }
        [Required]
        public System.DateTime StartDate { get; set; }
        [Display(Name = "完工日期")]
        public Nullable<System.DateTime> CompletionDate { get; set; }
        public Nullable<float> ContractAmount { get; set; }
        public Nullable<float> AmountDue { get; set; }
        public Nullable<float> PrepaymentGuaranteeAmount { get; set; }
        public Nullable<System.DateTime> OpenDate { get; set; }
        public Nullable<byte> PaymentType { get; set; }
        public Nullable<System.DateTime> WarrantyDate { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        public string Architect { get; set; }
        public Nullable<int> BuildingHeightAboveground { get; set; }
        public Nullable<int> BuildingHeightUnderground { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        public string BuildingCompany { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        public string SupervisionUnit { get; set; }
        public Nullable<float> Area { get; set; }
        public Nullable<bool> IsAppend { get; set; }
        public Nullable<bool> IsRepair { get; set; }
        public Nullable<byte> State { get; set; }
        [Required]
        public byte CheckoutDay { get; set; }
        [Required]
        public byte PaymentDay { get; set; }
        [Required]
        public System.DateTime CreateTime { get; set; }
        [Required]
        public System.Guid CreateUserId { get; set; }
    
        public virtual ICollection<Engineering> Engineering { get; set; }
        public virtual Manufacturers Manufacturers { get; set; }
        public virtual Projects Projects { get; set; }
        public virtual States States { get; set; }
        public virtual Users Users { get; set; }
        public virtual ICollection<PromissoryNoteManagement> PromissoryNoteManagement { get; set; }
    }
}
