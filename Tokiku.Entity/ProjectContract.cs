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
        }
    
        public System.Guid Id { get; set; }
        public Nullable<System.Guid> ProjectId { get; set; }
        public System.Guid ContractorId { get; set; }
        public System.DateTime SigningDate { get; set; }
        public string ContractNumber { get; set; }
        public System.DateTime StartDate { get; set; }
        public System.DateTime CompletionDate { get; set; }
        public string AccountingCode { get; set; }
        public string BankName { get; set; }
        public string BankAccount { get; set; }
        public string BankAccountName { get; set; }
        public string CheckNumber { get; set; }
        public Nullable<float> ContractAmount { get; set; }
        public Nullable<float> AmountDue { get; set; }
        public byte PaymentType { get; set; }
        public System.DateTime CreateTime { get; set; }
        public System.Guid CreateUserId { get; set; }
        public Nullable<float> PrepaymentGuaranteeAmount { get; set; }
        public Nullable<System.DateTime> OpenDate { get; set; }
    
        public virtual Manufacturers Manufacturers { get; set; }
        public virtual Users CreateUser { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PromissoryNoteManagement> PromissoryNoteManagement { get; set; }
        public virtual Projects Projects { get; set; }
    }
}
