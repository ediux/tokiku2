namespace Tokiku.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(ProjectsMetaData))]
    public partial class Projects
    {
    }
    
    public partial class ProjectsMetaData
    {
        [Required]
        public System.Guid Id { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string Code { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string ProjectName { get; set; }
        
        [StringLength(25, ErrorMessage="欄位長度不得大於 25 個字元")]
        public string ShortName { get; set; }
        [Required]
        public System.DateTime ProjectSigningDate { get; set; }
        
        [StringLength(250, ErrorMessage="欄位長度不得大於 250 個字元")]
        public string SiteAddress { get; set; }
        public Nullable<System.Guid> ClientId { get; set; }
        [Required]
        public System.DateTime CreateTime { get; set; }
        [Required]
        public System.Guid CreateUserId { get; set; }
        public string Comment { get; set; }
        [Required]
        public bool Void { get; set; }
        [Required]
        public byte State { get; set; }
    
        public virtual States States { get; set; }
        public virtual ICollection<Manufacturers> Clients { get; set; }
        public virtual ICollection<ProjectContract> ProjectContract { get; set; }
    }
}
