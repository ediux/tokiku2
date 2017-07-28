namespace Tokiku.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(View_PickListMetaData))]
    public partial class View_PickList
    {
    }
    
    public partial class View_PickListMetaData
    {
        [Required]
        public System.Guid Id { get; set; }
        public Nullable<System.Guid> ProjectId { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string ProjectCode { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string ProjectName { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string ShopFlowName { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string PickListNumber { get; set; }
        public Nullable<System.Guid> IncomingManufacturerId { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string IncomingManufacturer { get; set; }
    }
}
