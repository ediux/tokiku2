namespace Tokiku.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(MembershipMetaData))]
    public partial class Membership
    {
    }
    
    public partial class MembershipMetaData
    {
        [Required]
        [Display(Name="編號")]
        public System.Guid UserId { get; set; }
        
        [StringLength(128, ErrorMessage="欄位長度不得大於 128 個字元")]
        [Required]
        public string Password { get; set; }
        [Required]
        public int PasswordFormat { get; set; }
        
        [StringLength(128, ErrorMessage="欄位長度不得大於 128 個字元")]
        [Required]
        public string PasswordSalt { get; set; }
        
        [StringLength(16, ErrorMessage="欄位長度不得大於 16 個字元")]
        public string MobilePIN { get; set; }
        
        [StringLength(256, ErrorMessage="欄位長度不得大於 256 個字元")]
        public string Email { get; set; }
        
        [StringLength(256, ErrorMessage="欄位長度不得大於 256 個字元")]
        public string LoweredEmail { get; set; }
        
        [StringLength(256, ErrorMessage="欄位長度不得大於 256 個字元")]
        public string PasswordQuestion { get; set; }
        
        [StringLength(128, ErrorMessage="欄位長度不得大於 128 個字元")]
        public string PasswordAnswer { get; set; }
        [Required]
        public bool IsApproved { get; set; }
        [Required]
        public bool IsLockedOut { get; set; }
        [Required]
        public System.DateTime CreateDate { get; set; }
        [Required]
        public System.DateTime LastLoginDate { get; set; }
        [Required]
        public System.DateTime LastPasswordChangedDate { get; set; }
        [Required]
        public System.DateTime LastLockoutDate { get; set; }
        [Required]
        public int FailedPasswordAttemptCount { get; set; }
        [Required]
        public System.DateTime FailedPasswordAttemptWindowStart { get; set; }
        [Required]
        public int FailedPasswordAnswerAttemptCount { get; set; }
        [Required]
        public System.DateTime FailedPasswordAnswerAttemptWindowStart { get; set; }
        public string Comment { get; set; }
    
        public virtual Users Users { get; set; }
    }
}
