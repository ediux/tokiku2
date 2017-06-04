namespace Tokiku.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(MoldsInProjectsMetaData))]
    public partial class MoldsInProjects
    {
    }
    
    public partial class MoldsInProjectsMetaData
    {
        [Required]
        public System.Guid Id { get; set; }
        [Required]
        public System.Guid MaterialCategoryId { get; set; }
        [Required]
        public System.Guid MoldId { get; set; }
        [Required]
        public System.Guid ProjectId { get; set; }
    
        public virtual MaterialCategories MaterialCategories { get; set; }
        public virtual Molds Molds { get; set; }
        public virtual Projects Projects { get; set; }
    }
}
