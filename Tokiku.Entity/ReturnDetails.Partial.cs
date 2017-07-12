namespace Tokiku.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(ReturnDetailsMetaData))]
    public partial class ReturnDetails
    {
    }
    
    public partial class ReturnDetailsMetaData
    {
        [Required]
        public System.Guid Id { get; set; }
        public Nullable<System.Guid> ReturnsId { get; set; }
        public Nullable<System.Guid> OrderDetailId { get; set; }
        [Required]
        public int ShippingOrder { get; set; }
        [Required]
        public double Weight { get; set; }
        [Required]
        public int LackQuantity { get; set; }
        [Required]
        public int ReturnQuantity { get; set; }
        
        [StringLength(512, ErrorMessage="欄位長度不得大於 512 個字元")]
        public string Comment { get; set; }
    
        public virtual OrderDetails OrderDetails { get; set; }
        public virtual Returns Returns { get; set; }
    }
}
