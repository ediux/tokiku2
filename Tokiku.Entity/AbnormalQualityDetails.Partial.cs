namespace Tokiku.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(AbnormalQualityDetailsMetaData))]
    public partial class AbnormalQualityDetails
    {
    }
    
    public partial class AbnormalQualityDetailsMetaData
    {
        [Required]
        public System.Guid Id { get; set; }
        [Required]
        public System.Guid AbnormalQualityId { get; set; }
        [Required]
        public System.Guid ReceiptDetailsId { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string ProcessingNumber { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string Specifications { get; set; }
        [Required]
        public int ExceptionsQuantity { get; set; }
        
        [StringLength(512, ErrorMessage="欄位長度不得大於 512 個字元")]
        [Required]
        public string ExceptionsReason { get; set; }
        
        [StringLength(512, ErrorMessage="欄位長度不得大於 512 個字元")]
        [Required]
        public string ProcessingMethod { get; set; }
        
        [StringLength(4000, ErrorMessage="欄位長度不得大於 4000 個字元")]
        public string Comment { get; set; }
        public Nullable<decimal> LossCalculation { get; set; }
        public Nullable<System.Guid> RefundsManufacturersId { get; set; }
        public Nullable<decimal> OrderAmount { get; set; }
        
        [StringLength(512, ErrorMessage="欄位長度不得大於 512 個字元")]
        public string Reason { get; set; }
    
        public virtual AbnormalQuality AbnormalQuality { get; set; }
        public virtual Manufacturers Manufacturers { get; set; }
        public virtual ReceiveDetails ReceiptDetails { get; set; }
    }
}
