namespace Tokiku.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(ReceiveMetaData))]
    public partial class Receive
    {
    }
    
    public partial class ReceiveMetaData
    {
        [Required]
        public System.Guid Id { get; set; }
        [Required]
        public int Order { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string ReceiptNumber { get; set; }
        public Nullable<System.Guid> IncomingManufacturersId { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string IncomingNumber { get; set; }
        [Required]
        public System.Guid MakingUserId { get; set; }
        [Required]
        public System.DateTime MakingTime { get; set; }
        
        [StringLength(15, ErrorMessage="欄位長度不得大於 15 個字元")]
        public string MakerPhone { get; set; }
        [Required]
        public System.Guid StockId { get; set; }
        
        [StringLength(512, ErrorMessage="欄位長度不得大於 512 個字元")]
        public string Comment { get; set; }
        [Required]
        public System.DateTime CreateTime { get; set; }
        [Required]
        public System.Guid CreateUserId { get; set; }
    
        public virtual ICollection<ReceiveDetails> ReceiptDetails { get; set; }
        public virtual Users Users { get; set; }
        public virtual Users Users1 { get; set; }
        public virtual Stocks Stocks { get; set; }
        public virtual Manufacturers Manufacturers { get; set; }
    }
}
