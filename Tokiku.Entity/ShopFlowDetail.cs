//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Tokiku.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class ShopFlowDetail
    {
        public System.Guid Id { get; set; }
        public Nullable<System.Guid> ShopFlowId { get; set; }
        public Nullable<System.Guid> WorkShopId { get; set; }
        public System.DateTime CreateTime { get; set; }
        public System.Guid CreateUserId { get; set; }
        public System.Guid ProcessingAtlasId { get; set; }
        public System.Guid CurrentManufacturersId { get; set; }
        public System.Guid NextManufacturerId { get; set; }
    
        public virtual Users CreateUser { get; set; }
        public virtual WorkShops WorkShops { get; set; }
        public virtual ShopFlow ShopFlow { get; set; }
        public virtual Manufacturers Manufacturers { get; set; }
        public virtual Manufacturers Manufacturers1 { get; set; }
        public virtual ProcessingAtlas ProcessingAtlas { get; set; }
    }
}
