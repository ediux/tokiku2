namespace Tokiku.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(TranscationCategoriesMetaData))]
    public partial class TranscationCategories
    {
    }
    
    public partial class TranscationCategoriesMetaData
    {
        [Required]
        public int Id { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string Name { get; set; }
    
        public virtual ICollection<ManufacturersBussinessItems> ManufacturersBussinessItems { get; set; }
    }
}
