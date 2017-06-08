namespace Tokiku.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(ManufacturersBussinessItemsMetaData))]
    public partial class ManufacturersBussinessItems
    {
    }
    
    public partial class ManufacturersBussinessItemsMetaData
    {
        [Required]
        public System.Guid Id { get; set; }
        [Required]
        public System.Guid MaterialCategoriesId { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string Name { get; set; }
        [Required]
        public byte PaymentTypeId { get; set; }
        [Required]
        public int TicketPeriodId { get; set; }
        [Required]
        public System.Guid ManufacturersId { get; set; }
    
        public virtual Manufacturers Manufacturers { get; set; }
        public virtual MaterialCategories MaterialCategories { get; set; }
        public virtual PaymentTypes PaymentTypes { get; set; }
        public virtual TicketPeriod TicketPeriod { get; set; }
        public virtual ICollection<SupplierTranscationItem> SupplierTranscationItem { get; set; }
    }
}
