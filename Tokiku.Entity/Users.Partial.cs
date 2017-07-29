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
        public virtual ICollection<Materials> Materials { get; set; }
        public virtual ICollection<Molds> Molds { get; set; }
        public virtual ICollection<ProjectContract> ProjectContract { get; set; }
        public virtual ICollection<ProjectItemCost> ProjectItemCost { get; set; }
        public virtual ICollection<PromissoryNoteManagement> PromissoryNoteManagement { get; set; }
        public virtual ICollection<BOM> BOM { get; set; }
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
        public virtual ICollection<Orders> OrdersByCreateUser { get; set; }
        public virtual ICollection<Orders> OrdersByMakingUser { get; set; }
        public virtual ICollection<PickList> PickList { get; set; }
        public virtual ICollection<PickList> PickList_MakingUser { get; set; }
        public virtual ICollection<Receive> Receipts_CreateUser { get; set; }
        public virtual ICollection<Receive> Receipts_MakingUser { get; set; }
        public virtual ICollection<Invoices> Invoices_CreateUser { get; set; }
        public virtual ICollection<Invoices> Invoices_InvoiceUser { get; set; }
        public virtual ICollection<MaterialEstimation> MaterialEstimation { get; set; }
        public virtual ICollection<Required> Required { get; set; }
        public virtual ICollection<Required> Required1 { get; set; }
        public virtual ICollection<ShopFlowDetail> ShopFlowDetail { get; set; }
        public virtual ICollection<Returns> Returns { get; set; }
        public virtual ICollection<Returns> Returns1 { get; set; }
        public virtual ICollection<AbnormalQuality> AbnormalQuality { get; set; }
        public virtual ICollection<AbnormalQuality> AbnormalQuality1 { get; set; }
    }
}
