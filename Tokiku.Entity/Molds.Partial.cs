namespace Tokiku.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(MoldsMetaData))]
    public partial class Molds
    {
    }
    
    public partial class MoldsMetaData
    {
        [Required]
        public System.Guid Id { get; set; }
        public Nullable<System.DateTime> OpenDate { get; set; }
        
        [StringLength(250, ErrorMessage="欄位長度不得大於 250 個字元")]
        [Required]
        public string LegendMoldReduction { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        public string UsePosition { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        public string Code { get; set; }
        [Required]
        public System.Guid ManufacturersId { get; set; }
        [Required]
        public System.Guid MaterialId { get; set; }
        [Required]
        public float UnitWeight { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        public string SurfaceTreatment { get; set; }
        [Required]
        public float PaintArea { get; set; }
        [Required]
        public float MembraneTreatment { get; set; }
        [Required]
        public float MinimumYield { get; set; }
        [Required]
        public float ProductionIngot { get; set; }
        [Required]
        public float TotalOrderWeight { get; set; }
        [Required]
        public int MoldUseStatusId { get; set; }
        
        [StringLength(512, ErrorMessage="欄位長度不得大於 512 個字元")]
        public string Comment { get; set; }
        [Required]
        public System.DateTime CreateTime { get; set; }
        [Required]
        public System.Guid CreateUserId { get; set; }
        
        [StringLength(16, ErrorMessage="欄位長度不得大於 16 個字元")]
        public string SerialNumber { get; set; }
    
        public virtual Manufacturers Manufacturers { get; set; }
        public virtual Materials Materials { get; set; }
        public virtual MoldUseStatus MoldUseStatus { get; set; }
        public virtual Users CreateUser { get; set; }
        public virtual ICollection<MoldsInProjects> MoldsInProjects { get; set; }
    }
}
