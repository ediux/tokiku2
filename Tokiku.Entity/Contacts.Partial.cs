namespace Tokiku.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(ContactsMetaData))]
    public partial class Contacts
    {
    }
    
    public partial class ContactsMetaData
    {
        [Required]
        public System.Guid Id { get; set; }
        
        [StringLength(15, ErrorMessage="欄位長度不得大於 15 個字元")]
        [Required]
        public string Name { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        public string Dep { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        public string Title { get; set; }
        
        [StringLength(10, ErrorMessage="欄位長度不得大於 10 個字元")]
        public string Phone { get; set; }
        
        [StringLength(6, ErrorMessage="欄位長度不得大於 6 個字元")]
        public string ExtensionNumber { get; set; }
        
        [StringLength(10, ErrorMessage="欄位長度不得大於 10 個字元")]
        public string Mobile { get; set; }
        
        [StringLength(10, ErrorMessage="欄位長度不得大於 10 個字元")]
        public string Fax { get; set; }
        [Required]
        public bool IsPrincipal { get; set; }
        [Required]
        public bool Void { get; set; }
        [Required]
        public System.DateTime CreateTime { get; set; }
        [Required]
        public System.Guid CreateUserId { get; set; }
        
        [StringLength(250, ErrorMessage="欄位長度不得大於 250 個字元")]
        public string EMail { get; set; }
        [Required]
        public bool IsDefault { get; set; }
        public string Comment { get; set; }
    
        public virtual ICollection<Manufacturers> Manufacturers { get; set; }
    }
}
