namespace Tokiku.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(TicketTypesMetaData))]
    public partial class TicketTypes
    {
    }
    
    public partial class TicketTypesMetaData
    {
        [Required]
        public byte Id { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string Name { get; set; }
        [Required]
        public bool IsPromissoryNote { get; set; }
    
        public virtual ICollection<PromissoryNoteManagement> PromissoryNoteManagement { get; set; }
    }
}
