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
    
    public partial class ShopFlowHistory
    {
        public System.Guid Id { get; set; }
        public System.Guid EngineeringId { get; set; }
        public Nullable<System.Guid> ShopId { get; set; }
        public byte State { get; set; }
        public System.DateTime CreateTime { get; set; }
        public System.Guid CreateUserId { get; set; }
        public Nullable<System.Guid> ShopFlowId { get; set; }
        public Nullable<System.Guid> ShopFlowDetailId { get; set; }
        public System.DateTime StartTime { get; set; }
        public Nullable<System.DateTime> EndTime { get; set; }
    
        public virtual States States { get; set; }
        public virtual Users CreateUser { get; set; }
        public virtual ShopFlowHistory ShopFlowHistory1 { get; set; }
        public virtual Engineering Engineering { get; set; }
    }
}
