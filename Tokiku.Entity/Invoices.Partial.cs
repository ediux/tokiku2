namespace Tokiku.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(InvoicesMetaData))]
    public partial class Invoices
    {
    }
    
    public partial class InvoicesMetaData
    {
        [Required]
        public System.Guid Id { get; set; }
        [Required]
        public int Order { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string InvoiceNumber { get; set; }
        public Nullable<System.Guid> InvoiceManufacturerId { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string ManufacturerInvoiceNumber { get; set; }
        public Nullable<System.Guid> InvoiceUserId { get; set; }
        [Required]
        public System.DateTime InvoiceTime { get; set; }
        [Required]
        public System.DateTime EstimatedPaymentDate { get; set; }
        [Required]
        public bool PrepaymentsOnly { get; set; }
        
        [StringLength(512, ErrorMessage="欄位長度不得大於 512 個字元")]
        public string Comment { get; set; }
        [Required]
        public System.DateTime CreateTime { get; set; }
        [Required]
        public System.Guid CreateUserId { get; set; }
    
        public virtual ICollection<InvoiceDetails> InvoiceDetails { get; set; }
        public virtual ICollection<InvoiceDetails_Material> InvoiceDetails_Material { get; set; }
        public virtual ICollection<InvoiceDetails_Miscellaneous> InvoiceDetails_Miscellaneous { get; set; }
        public virtual Users CreateUser { get; set; }
        public virtual Users InvoiceUser { get; set; }
        public virtual Manufacturers Manufacturers { get; set; }
    }
}
