namespace Tokiku.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(OrdersMetaData))]
    public partial class Orders
    {
    }
    
    public partial class OrdersMetaData
    {
        [Required]
        public System.Guid Id { get; set; }
        [Required]
        public int Order { get; set; }
        public Nullable<System.Guid> OrderTypeId { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string RequiredDep { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string FormNumber { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string BatchNumber { get; set; }
        [Required]
        public System.DateTime ExpectedDelivery { get; set; }
        public Nullable<System.DateTime> ActualDelivery { get; set; }
        public Nullable<System.Guid> MakingUserId { get; set; }
        public Nullable<System.DateTime> MakingTime { get; set; }
        public Nullable<double> ReservedPercentage { get; set; }
        public Nullable<System.Guid> ShippingManufactureId { get; set; }
        [Required]
        public System.DateTime CreateTime { get; set; }
        [Required]
        public System.Guid CreateUserId { get; set; }
    
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
        public virtual ICollection<OrderMaterialValuation> OrderMaterialValuation { get; set; }
        public virtual Users CreateUsers { get; set; }
        public virtual Users MakingUsers { get; set; }
        public virtual OrderTypes OrderTypes { get; set; }
        public virtual ICollection<OrderMiscellaneous> OrderMiscellaneous { get; set; }
        public virtual Manufacturers Manufacturers { get; set; }
        public virtual ICollection<Returns> Returns { get; set; }
    }
}
