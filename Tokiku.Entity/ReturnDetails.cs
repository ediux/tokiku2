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
    
    public partial class ReturnDetails
    {
        public System.Guid Id { get; set; }
        public System.Guid ReturnId { get; set; }
        public Nullable<System.Guid> OrderDetailId { get; set; }
        public int ShippingOrder { get; set; }
        public double Weight { get; set; }
        public int LackQuantity { get; set; }
        public int ReturnQuantity { get; set; }
        public string Comment { get; set; }
    
        public virtual OrderDetails OrderDetails { get; set; }
        public virtual Returns Returns { get; set; }
    }
}
