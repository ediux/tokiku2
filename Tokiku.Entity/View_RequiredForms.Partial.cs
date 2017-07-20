namespace Tokiku.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(View_RequiredFormsMetaData))]
    public partial class View_RequiredForms
    {
    }
    
    public partial class View_RequiredFormsMetaData
    {
        [Required]
        public System.Guid ProjectId { get; set; }
        [Required]
        public System.Guid ControlTableId { get; set; }
        [Required]
        public System.Guid ControlTableDetailId { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string ProjectName { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string ShopFlowName { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string FormNumber { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string ManufacturersName { get; set; }
        
        [StringLength(256, ErrorMessage="欄位長度不得大於 256 個字元")]
        [Required]
        public string MakingUser { get; set; }
        [Required]
        public System.DateTime MakingTime { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string RequiredPostion { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string Code { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string FactoryNumber { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string Materials { get; set; }
        public Nullable<int> OrderLength { get; set; }
        [Required]
        public int RequiredQuantity { get; set; }
        [Required]
        public decimal UnitWeight { get; set; }
        [Required]
        public System.DateTime CreateTime { get; set; }
        
        [StringLength(256, ErrorMessage="欄位長度不得大於 256 個字元")]
        [Required]
        public string CreateUser { get; set; }
        [Required]
        public System.Guid RequiredId { get; set; }
        [Required]
        public System.Guid RequiredDetailsId { get; set; }
        
        [StringLength(3, ErrorMessage="欄位長度不得大於 3 個字元")]
        [Required]
        public string FormName { get; set; }
        [Required]
        public System.Guid MaterialsId { get; set; }
        [Required]
        public System.Guid ManufacturersId { get; set; }
        [Required]
        public System.Guid CreateUserId { get; set; }
        [Required]
        public System.Guid ShopFlowId { get; set; }
    }
}
