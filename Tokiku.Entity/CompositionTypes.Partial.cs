namespace Tokiku.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(CompositionTypesMetaData))]
    public partial class CompositionTypes
    {
    }
    
    public partial class CompositionTypesMetaData
    {
        [Required]
        public int Id { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        public string Name { get; set; }
    
        public virtual ICollection<Compositions> Compositions { get; set; }
    }
}
