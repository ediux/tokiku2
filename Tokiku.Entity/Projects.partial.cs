namespace Tokiku.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(ProjectsMetaData))]
    public partial class Projects
    {
    }
    
    public partial class ProjectsMetaData
    {
        [Required]
        public System.Guid Id { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string Code { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required(ErrorMessage = "專案名稱不能為空白。")]
        public string Name { get; set; }
        [Required]
        public float Area { get; set; }
        [Required]
        public int BuildingHeightAboveground { get; set; }
        [Required]
        public int BuildingHeightUnderground { get; set; }
        [Required]
        public System.DateTime ProjectSigningDate { get; set; }
        [Required]
        public System.DateTime StartDate { get; set; }
        [Required]
        public byte State { get; set; }
        public Nullable<System.Guid> ClientId { get; set; }
        [Required]
        public bool Void { get; set; }
        [Required]
        public System.DateTime CreateTime { get; set; }
        [Required]
        public System.Guid CreateUserId { get; set; }
        public Nullable<System.DateTime> CompletionDate { get; set; }
        public Nullable<byte> CheckoutDay { get; set; }
        public Nullable<byte> PaymentDay { get; set; }
        
        [StringLength(25, ErrorMessage="欄位長度不得大於 25 個字元")]
        public string ShortName { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        public string SystemType { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        public string SystemDesign { get; set; }
        
        [StringLength(250, ErrorMessage="欄位長度不得大於 250 個字元")]
        public string SiteAddress { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        public string Architect { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        public string ArchitectConsultant { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        public string BuildingCompany { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        public string BuildingCompanyConsultant { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        public string SupervisionUnit { get; set; }
        public string Comment { get; set; }
    
        public virtual ICollection<MoldsInProjects> MoldsInProjects { get; set; }
        public virtual ICollection<ProjectContract> ProjectContract { get; set; }
        public virtual States States { get; set; }
        public virtual ICollection<Manufacturers> Manufacturers { get; set; }
        public virtual ICollection<SupplierTranscationItem> SupplierTranscationItem { get; set; }
    }
}
