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
    
    public partial class Inventory
    {
        public System.Guid Id { get; set; }
        public Nullable<System.Guid> ControlTableId { get; set; }
        public Nullable<System.Guid> ControlTableDetailId { get; set; }
        public Nullable<System.Guid> RequireDetailId { get; set; }
        public Nullable<System.Guid> StockId { get; set; }
        public int Amount { get; set; }
    
        public virtual ControlTableDetails ControlTableDetails { get; set; }
        public virtual RequiredDetails RequiredDetails { get; set; }
        public virtual Stocks Stocks { get; set; }
        public virtual ControlTables ControlTables { get; set; }
    }
}
