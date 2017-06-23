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
    
    public partial class ProjectContract
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProjectContract()
        {
            this.PromissoryNoteManagement = new HashSet<PromissoryNoteManagement>();
            this.ProcessingAtlas = new HashSet<ProcessingAtlas>();
        }
    
        public System.Guid Id { get; set; }
        public System.Guid ProjectId { get; set; }
        public string Name { get; set; }
        public string ContractNumber { get; set; }
        public System.DateTime SigningDate { get; set; }
        public bool IsAppend { get; set; }
        public bool IsRepair { get; set; }
        public System.DateTime CreateTime { get; set; }
        public System.Guid CreateUserId { get; set; }
    
        public virtual Users CreateUser { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PromissoryNoteManagement> PromissoryNoteManagement { get; set; }
        public virtual Projects Projects { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProcessingAtlas> ProcessingAtlas { get; set; }
    }
}
