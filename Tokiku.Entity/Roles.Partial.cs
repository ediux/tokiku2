namespace Tokiku.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(RolesMetaData))]
    public partial class Roles
    {
    }
    
    public partial class RolesMetaData
    {
        [Required]
        public System.Guid RoleId { get; set; }
        
        [StringLength(256, ErrorMessage="欄位長度不得大於 256 個字元")]
        [Required]
        public string RoleName { get; set; }
        
        [StringLength(256, ErrorMessage="欄位長度不得大於 256 個字元")]
        [Required]
        public string LoweredRoleName { get; set; }
        
        [StringLength(256, ErrorMessage="欄位長度不得大於 256 個字元")]
        public string Description { get; set; }
    
        public virtual ICollection<Users> Users { get; set; }
    }
}
