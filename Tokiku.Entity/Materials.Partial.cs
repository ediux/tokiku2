namespace Tokiku.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(MaterialsMetaData))]
    public partial class Materials
    {
    }
    
    public partial class MaterialsMetaData
    {
        [Required]
        public System.Guid Id { get; set; }
        [Required]
        public System.Guid ManufacturersId { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string Name { get; set; }
        [Required]
        public float UnitPrice { get; set; }
        [Required]
        public System.DateTime CreateTime { get; set; }
        [Required]
        public System.Guid CreateUserId { get; set; }
    
        public virtual Users CreateUser { get; set; }
        public virtual ICollection<Molds> Molds { get; set; }
        public virtual ICollection<RequiredDetails> RequiredDetails { get; set; }
    }
}
