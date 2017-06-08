namespace Tokiku.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(TicketPeriodMetaData))]
    public partial class TicketPeriod
    {
    }
    
    public partial class TicketPeriodMetaData
    {
        [Required]
        public int Id { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string Name { get; set; }
        [Required]
        public int DayLimit { get; set; }
        public Nullable<System.DateTime> CreateTime { get; set; }
        public Nullable<System.Guid> CreateUserId { get; set; }
    
        public virtual ICollection<ManufacturersBussinessItems> ManufacturersBussinessItems { get; set; }
    }
}
