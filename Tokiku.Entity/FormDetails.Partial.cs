namespace Tokiku.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(FormDetailsMetaData))]
    public partial class FormDetails
    {
    }
    
    public partial class FormDetailsMetaData
    {
        [Required]
        public System.Guid Id { get; set; }
        public Nullable<System.Guid> FormId { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string DemandUnit { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string FormNumber { get; set; }
        [Required]
        public int BatchNumber { get; set; }
        public Nullable<System.DateTime> ExpectedDelivery { get; set; }
        public Nullable<System.DateTime> ActualDelivery { get; set; }
        [Required]
        public System.DateTime MakingFormDate { get; set; }
        [Required]
        public System.Guid MakingUserId { get; set; }
        public Nullable<System.Guid> ManufacturersId { get; set; }
        public Nullable<double> ReservedPercentage { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        public string ReservedField1 { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        public string ReservedField2 { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        public string ReservedField3 { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        public string ReservedField4 { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        public string ReservedField5 { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        public string ReservedField6 { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        public string ReservedField7 { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        public string ReservedField8 { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        public string ReservedField9 { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        public string ReservedField10 { get; set; }
        [Required]
        public System.DateTime CreateTime { get; set; }
        [Required]
        public System.Guid CreateUserId { get; set; }
    
        public virtual Forms Forms { get; set; }
        public virtual Manufacturers Manufacturers { get; set; }
        public virtual Users Users { get; set; }
        public virtual Users Users1 { get; set; }
        public virtual ICollection<MaterialEstimation> MaterialEstimation { get; set; }
        public virtual ICollection<PurchasingOrder> PurchasingOrder { get; set; }
    }
}
