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
    
    public partial class RequiredDetails
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RequiredDetails()
        {
            this.ControlTableDetails = new HashSet<ControlTableDetails>();
        }
    
        public System.Guid Id { get; set; }
        public Nullable<System.Guid> RequiredId { get; set; }
        public int Order { get; set; }
        public string Code { get; set; }
        public string FactoryNumber { get; set; }
        public Nullable<System.Guid> MaterialsId { get; set; }
        public decimal UnitWeight { get; set; }
        public Nullable<int> OrderLength { get; set; }
    
        public virtual Materials Materials { get; set; }
        public virtual Required Required { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ControlTableDetails> ControlTableDetails { get; set; }
    }
}
