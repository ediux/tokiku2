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
    
    public partial class Manufacturers
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Manufacturers()
        {
            this.Molds = new HashSet<Molds>();
            this.ProjectItemCost = new HashSet<ProjectItemCost>();
            this.WorkShops = new HashSet<WorkShops>();
            this.Contacts = new HashSet<Contacts>();
            this.ClientForProjects = new HashSet<Projects>();
            this.FormDetails = new HashSet<FormDetails>();
            this.ManufacturersBussinessItems = new HashSet<ManufacturersBussinessItems>();
            this.SupplierTranscationItem = new HashSet<SupplierTranscationItem>();
            this.ShopFlowDetail = new HashSet<ShopFlowDetail>();
            this.ShopFlowDetail1 = new HashSet<ShopFlowDetail>();
        }
    
        public System.Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string UniformNumbers { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string eMail { get; set; }
        public string Address { get; set; }
        public string FactoryPhone { get; set; }
        public string FactoryFax { get; set; }
        public string FactoryAddress { get; set; }
        public string Comment { get; set; }
        public bool Void { get; set; }
        public bool IsClient { get; set; }
        public string BankName { get; set; }
        public string BankAccount { get; set; }
        public string BankAccountName { get; set; }
        public byte PaymentType { get; set; }
        public System.DateTime CreateTime { get; set; }
        public System.Guid CreateUserId { get; set; }
        public string Principal { get; set; }
        public string MainContactPerson { get; set; }
        public string Mobile { get; set; }
        public string Extension { get; set; }
        public Nullable<int> TicketPeriodId { get; set; }
        public string InvoiceAddress { get; set; }
    
        public virtual PaymentTypes PaymentTypes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Molds> Molds { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProjectItemCost> ProjectItemCost { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WorkShops> WorkShops { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Contacts> Contacts { get; set; }
        public virtual TicketPeriod TicketPeriod { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Projects> ClientForProjects { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FormDetails> FormDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ManufacturersBussinessItems> ManufacturersBussinessItems { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SupplierTranscationItem> SupplierTranscationItem { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ShopFlowDetail> ShopFlowDetail { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ShopFlowDetail> ShopFlowDetail1 { get; set; }
    }
}
