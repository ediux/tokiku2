namespace Tokiku.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(View_BussinessItemsListMetaData))]
    public partial class View_BussinessItemsList
    {
    }
    
    public partial class View_BussinessItemsListMetaData
    {
        [Required]
        public System.Guid Id { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        public string MaterialCategories { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string Name { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string PaymentTypeName { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string TicketPeriod { get; set; }
        [Required]
        public System.Guid ManufacturersId { get; set; }
    }
}
