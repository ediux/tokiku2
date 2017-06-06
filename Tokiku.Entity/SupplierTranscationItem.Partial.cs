namespace Tokiku.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(SupplierTranscationItemMetaData))]
    public partial class SupplierTranscationItem
    {
    }
    
    public partial class SupplierTranscationItemMetaData
    {
        [Required]
        public System.Guid ManufacturersBussinessItemsId { get; set; }
        [Required]
        public System.Guid ProjectId { get; set; }
        
        [StringLength(512, ErrorMessage="欄位長度不得大於 512 個字元")]
        public string PlaceofReceipt { get; set; }
    
        public virtual ManufacturersBussinessItems ManufacturersBussinessItems { get; set; }
        public virtual Projects Projects { get; set; }
    }
}
