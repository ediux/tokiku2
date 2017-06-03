namespace Tokiku.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(StatesMetaData))]
    public partial class States
    {
    }
    
    public partial class StatesMetaData
    {
        [Required]
        public byte Id { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string StateName { get; set; }
    
        public virtual ICollection<ShopFlowHistory> ShopFlowHistory { get; set; }
        public virtual ICollection<Projects> Projects { get; set; }
        public virtual ICollection<ProjectContract> ProjectContract { get; set; }
        public virtual ICollection<Engineering> Engineering { get; set; }
    }
}
