namespace Tokiku.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(UsersMetaData))]
    public partial class Users
    {
    }
    
    public partial class UsersMetaData
    {
        [Required]
        public System.Guid UserId { get; set; }
        
        [StringLength(256, ErrorMessage="欄位長度不得大於 256 個字元")]
        [Required]
        public string UserName { get; set; }
        
        [StringLength(256, ErrorMessage="欄位長度不得大於 256 個字元")]
        [Required]
        public string LoweredUserName { get; set; }
        
        [StringLength(16, ErrorMessage="欄位長度不得大於 16 個字元")]
        public string MobileAlias { get; set; }
        [Required]
        public bool IsAnonymous { get; set; }
        [Required]
        public System.DateTime LastActivityDate { get; set; }
    
        public virtual Membership Membership { get; set; }
        public virtual Profile Profile { get; set; }
        public virtual ICollection<Roles> Roles { get; set; }
        public virtual ICollection<ShopFlowHistory> ShopFlowHistory { get; set; }
        public virtual ICollection<Materials> Materials { get; set; }
        public virtual ICollection<PromissoryNoteManagement> PromissoryNoteManagement { get; set; }
        public virtual ICollection<ProjectContract> ProjectContract { get; set; }
        public virtual ICollection<ShopFlowDetail> ShopFlowDetail { get; set; }
    }
}
