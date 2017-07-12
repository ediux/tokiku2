namespace Tokiku.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(OrderMiscellaneousMetaData))]
    public partial class OrderMiscellaneous
    {
    }
    
    public partial class OrderMiscellaneousMetaData
    {
        [Required]
        public System.Guid Id { get; set; }
        public Nullable<System.Guid> OrderId { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required(ErrorMessage ="項目為必要項!")]
        public string CodeOrItem { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        public string FactoryNumber { get; set; }
        
        [StringLength(512, ErrorMessage="欄位長度不得大於 512 個字元")]
        public string Description { get; set; }
        [Required]
        public int UnitPrice { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public decimal TotalPrice { get; set; }
    
        public virtual ICollection<InvoiceDetails_Miscellaneous> InvoiceDetails_Miscellaneous { get; set; }
        public virtual Orders Orders { get; set; }
    }
}
