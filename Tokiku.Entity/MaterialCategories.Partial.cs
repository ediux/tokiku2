namespace Tokiku.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(MaterialCategoriesMetaData))]
    public partial class MaterialCategories
    {
    }
    
    public partial class MaterialCategoriesMetaData
    {
        [Required]
        public System.Guid Id { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        public string Name { get; set; }
        [Required]
        public System.DateTime CreateTime { get; set; }
        [Required]
        public System.Guid CreateUserId { get; set; }
    
        public virtual ICollection<Materials> Materials { get; set; }
        public virtual ICollection<MoldsInProjects> MoldsInProjects { get; set; }
        public virtual ICollection<ProjectItemCost> ProjectItemCost { get; set; }
        public virtual ICollection<ManufacturersBussinessItems> ManufacturersBussinessItems { get; set; }
    }
}
