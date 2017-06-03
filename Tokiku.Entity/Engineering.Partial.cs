namespace Tokiku.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(EngineeringMetaData))]
    public partial class Engineering
    {
    }
    
    public partial class EngineeringMetaData
    {
        [Required]
        public System.Guid Id { get; set; }
        [Required]
        public System.Guid ProjectContractId { get; set; }
        
        [StringLength(15, ErrorMessage="欄位長度不得大於 15 個字元")]
        [Required]
        public string Code { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string Name { get; set; }
        [Required]
        public System.DateTime StartDate { get; set; }
        [Required]
        public System.DateTime CompletionDate { get; set; }
        public Nullable<byte> State { get; set; }
        public Nullable<System.DateTime> WarrantyDate { get; set; }
        [Required]
        public System.DateTime CreateTime { get; set; }
        [Required]
        public System.Guid CreateUserId { get; set; }
    
        public virtual ProjectContract ProjectContract { get; set; }
        public virtual ICollection<ShopFlowHistory> ShopFlowHistory { get; set; }
        public virtual ICollection<Compositions> Compositions { get; set; }
        public virtual States States { get; set; }
    }
}
