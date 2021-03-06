namespace Tokiku.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(ReturnsMetaData))]
    public partial class Returns
    {
    }
    
    public partial class ReturnsMetaData
    {
        [Required]
        public System.Guid Id { get; set; }
        [Required]
        public System.Guid OrderId { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string ReturnNumber { get; set; }
        public Nullable<System.Guid> IncomingManufacturerId { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string IncomingNumber { get; set; }
        public Nullable<System.Guid> MakingUserId { get; set; }
        [Required]
        public System.DateTime MakingTime { get; set; }
        
        [StringLength(15, ErrorMessage="欄位長度不得大於 15 個字元")]
        public string MakerPhone { get; set; }
        public Nullable<System.Guid> StockId { get; set; }
        
        [StringLength(512, ErrorMessage="欄位長度不得大於 512 個字元")]
        public string Comment { get; set; }
        [Required]
        public System.DateTime CreateTime { get; set; }
        [Required]
        public System.Guid CreateUserId { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        public string ReceiptNumber { get; set; }
    
        public virtual Manufacturers Manufacturers { get; set; }
        public virtual Orders Orders { get; set; }
        public virtual ICollection<ReturnDetails> ReturnDetails { get; set; }
        public virtual Users CreateUser { get; set; }
        public virtual Users MakingUser { get; set; }
        public virtual Stocks Stocks { get; set; }
    }
}
