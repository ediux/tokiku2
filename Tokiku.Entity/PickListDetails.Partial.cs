namespace Tokiku.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(PickListDetailsMetaData))]
    public partial class PickListDetails
    {
    }
    
    public partial class PickListDetailsMetaData
    {
        [Required]
        public System.Guid Id { get; set; }
        public Nullable<System.Guid> PickListId { get; set; }
        public Nullable<System.Guid> OrderDetailId { get; set; }
        [Required]
        public int ShippingOrder { get; set; }
        [Required]
        public double Weight { get; set; }
        [Required]
        public int LackQuantity { get; set; }
        [Required]
        public int ShippingQuantity { get; set; }
        
        [StringLength(512, ErrorMessage="欄位長度不得大於 512 個字元")]
        public string Comment { get; set; }
    
        public virtual OrderDetails OrderDetails { get; set; }
        public virtual PickList PickList { get; set; }
    }
}
