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
    
    public partial class View_PickList
    {
        public System.Guid Id { get; set; }
        public Nullable<System.Guid> ProjectId { get; set; }
        public string ProjectCode { get; set; }
        public string ProjectName { get; set; }
        public string ShopFlowName { get; set; }
        public string PickListNumber { get; set; }
        public Nullable<System.Guid> IncomingManufacturerId { get; set; }
        public string IncomingManufacturer { get; set; }
    }
}
