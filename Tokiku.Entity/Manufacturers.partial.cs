namespace Tokiku.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(ManufacturersMetaData))]
    public partial class Manufacturers
    {
    }
    
    public partial class ManufacturersMetaData
    {
        [Required]
        public System.Guid Id { get; set; }
        
        [StringLength(15, ErrorMessage="欄位長度不得大於 15 個字元")]
        [Required(ErrorMessage ="廠商代號/客戶代號為必要項!")]
        public string Code { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required(ErrorMessage ="廠商名稱/客戶名稱為必要項!")]
        public string Name { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        public string ShortName { get; set; }
        
        [StringLength(15, ErrorMessage="欄位長度不得大於 15 個字元")]
        public string UniformNumbers { get; set; }
        
        [StringLength(10, ErrorMessage="欄位長度不得大於 10 個字元")]
        public string Phone { get; set; }
        
        [StringLength(10, ErrorMessage="欄位長度不得大於 10 個字元")]
        public string Fax { get; set; }
        
        [StringLength(200, ErrorMessage="欄位長度不得大於 200 個字元")]
        public string eMail { get; set; }
        
        [StringLength(250, ErrorMessage="欄位長度不得大於 250 個字元")]
        public string Address { get; set; }
        
        [StringLength(10, ErrorMessage="欄位長度不得大於 10 個字元")]
        public string FactoryPhone { get; set; }
        
        [StringLength(10, ErrorMessage="欄位長度不得大於 10 個字元")]
        public string FactoryFax { get; set; }
        
        [StringLength(250, ErrorMessage="欄位長度不得大於 250 個字元")]
        public string FactoryAddress { get; set; }
        public string Comment { get; set; }
        [Required]
        public bool Void { get; set; }
        [Required]
        public bool IsClient { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        public string ContractNumber { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> CompletionDate { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        public string AccountingCode { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        public string BankName { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        public string BankAccount { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        public string BankAccountName { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        public string CheckNumber { get; set; }
        public Nullable<float> ContractAmount { get; set; }
        public Nullable<float> AmountDue { get; set; }
        public Nullable<float> PrepaymentGuaranteeAmount { get; set; }
        public Nullable<System.DateTime> OpenDate { get; set; }
        [Required]
        public byte PaymentType { get; set; }
        [Required]
        public System.DateTime CreateTime { get; set; }
        [Required]
        public System.Guid CreateUserId { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        public string Principal { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        public string MainContactPerson { get; set; }
        [StringLength(10, ErrorMessage = "欄位長度不得大於 50 個字元")]
        public string Mobile { get; set; }
        [StringLength(10, ErrorMessage = "欄位長度不得大於 50 個字元")]
        public string Extension { get; set; }

        public virtual PaymentTypes PaymentTypes { get; set; }
        public virtual ICollection<Molds> Molds { get; set; }
        public virtual ICollection<ProjectItemCost> ProjectItemCost { get; set; }
        public virtual ICollection<WorkShops> WorkShops { get; set; }
        public virtual ICollection<Contacts> Contacts { get; set; }
        public virtual ICollection<Projects> ClientForProjects { get; set; }
        public virtual ICollection<ManufacturersBussinessItems> ManufacturersBussinessItems { get; set; }
    }
}
