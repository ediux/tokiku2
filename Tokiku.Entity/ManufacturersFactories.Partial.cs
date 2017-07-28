namespace Tokiku.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(ManufacturersFactoriesMetaData))]
    public partial class ManufacturersFactories
    {
    }
    
    public partial class ManufacturersFactoriesMetaData
    {
        [Required]
        public System.Guid Id { get; set; }
        public Nullable<System.Guid> ManufacturersId { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string Name { get; set; }
        
        [StringLength(10, ErrorMessage="欄位長度不得大於 10 個字元")]
        public string FactoryPhone { get; set; }
        
        [StringLength(10, ErrorMessage="欄位長度不得大於 10 個字元")]
        public string FactoryFax { get; set; }
        
        [StringLength(250, ErrorMessage="欄位長度不得大於 250 個字元")]
        [Required]
        public string FactoryAddress { get; set; }
        [Required]
        public System.DateTime CreateTime { get; set; }
        [Required]
        public System.Guid CreateUserId { get; set; }
    
        public virtual Manufacturers Manufacturers { get; set; }
        public virtual ICollection<Receive> Receipts { get; set; }
    }
}
