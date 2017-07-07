//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Tokiku.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class Projects
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Projects()
        {
            this.ProjectContract = new HashSet<ProjectContract>();
            this.SupplierTranscationItem = new HashSet<SupplierTranscationItem>();
            this.MoldsInProjects = new HashSet<MoldsInProjects>();
            this.Manufacturers = new HashSet<Manufacturers>();
            this.ConstructionAtlas = new HashSet<ConstructionAtlas>();
            this.PromissoryNoteManagement = new HashSet<PromissoryNoteManagement>();
            this.FormDetails = new HashSet<FormDetails>();
        }
    
        public System.Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public float Area { get; set; }
        public int BuildingHeightAboveground { get; set; }
        public int BuildingHeightUnderground { get; set; }
        public System.DateTime ProjectSigningDate { get; set; }
        public System.DateTime StartDate { get; set; }
        public byte State { get; set; }
        public Nullable<System.Guid> ClientId { get; set; }
        public bool Void { get; set; }
        public System.DateTime CreateTime { get; set; }
        public System.Guid CreateUserId { get; set; }
        public Nullable<System.DateTime> CompletionDate { get; set; }
        public Nullable<byte> CheckoutDay { get; set; }
        public Nullable<byte> PaymentDay { get; set; }
        public string ShortName { get; set; }
        public string SystemType { get; set; }
        public string SystemDesign { get; set; }
        public string SiteAddress { get; set; }
        public string Architect { get; set; }
        public string ArchitectConsultant { get; set; }
        public string BuildingCompany { get; set; }
        public string BuildingCompanyConsultant { get; set; }
        public string SupervisionUnit { get; set; }
        public string Comment { get; set; }
        public string OwnerAdvisor { get; set; }
        public string OwnerContractNumber { get; set; }
        public string SiteContactPersonPhone { get; set; }
        public string SiteContactPerson { get; set; }
        public string SitePhone { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProjectContract> ProjectContract { get; set; }
        public virtual States States { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SupplierTranscationItem> SupplierTranscationItem { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MoldsInProjects> MoldsInProjects { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Manufacturers> Manufacturers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ConstructionAtlas> ConstructionAtlas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PromissoryNoteManagement> PromissoryNoteManagement { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FormDetails> FormDetails { get; set; }
    }
}
