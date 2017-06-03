namespace Tokiku.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(PaymentTypesMetaData))]
    public partial class PaymentTypes
    {
    }
    
    public partial class PaymentTypesMetaData
    {
        [Required]
        public byte Id { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string PaymentTypeName { get; set; }
    
        public virtual ICollection<Manufacturers> Manufacturers { get; set; }
    }
}
