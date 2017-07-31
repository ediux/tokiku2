namespace Tokiku.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(View_ShippingListMetaData))]
    public partial class View_ShippingList
    {
    }
    
    public partial class View_ShippingListMetaData
    {
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string Name { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string ShippingNumber { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string ReceiptNumber { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string PickListNumber { get; set; }
        [Required]
        public System.DateTime PickListTime { get; set; }
        [Required]
        public System.DateTime ShippingTime { get; set; }
        
        [StringLength(256, ErrorMessage="欄位長度不得大於 256 個字元")]
        [Required]
        public string ShippingName { get; set; }
        [Required]
        public System.Guid OrderDetailsId { get; set; }
        [Required]
        public System.Guid PickListDetailsId { get; set; }
        [Required]
        public System.Guid ReceiptDetailsId { get; set; }
        [Required]
        public System.Guid PickListId { get; set; }
        [Required]
        public System.Guid ShippingId { get; set; }
        [Required]
        public System.Guid ReceiptsId { get; set; }
    }
}
