namespace Tokiku.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(PromissoryNoteManagementMetaData))]
    public partial class PromissoryNoteManagement
    {
    }
    
    public partial class PromissoryNoteManagementMetaData
    {
        [Required]
        public System.Guid Id { get; set; }
        [Required]
        public byte TicketTypeId { get; set; }
        [Required]
        public float Amount { get; set; }
        [Required]
        public System.DateTime OpenDate { get; set; }
        public Nullable<System.DateTime> RecoveryDate { get; set; }
        [Required]
        public System.DateTime CreateTime { get; set; }
        [Required]
        public System.Guid CreateUserId { get; set; }
        public Nullable<System.Guid> ProjectId { get; set; }
    
        public virtual TicketTypes TicketTypes { get; set; }
        public virtual Users CreateUser { get; set; }
        public virtual Projects Projects { get; set; }
    }
}
