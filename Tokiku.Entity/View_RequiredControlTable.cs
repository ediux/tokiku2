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
    
    public partial class View_RequiredControlTable
    {
        public string Code { get; set; }
        public string ManufacturersName { get; set; }
        public string FactoryNumber { get; set; }
        public string Materials { get; set; }
        public decimal UnitWeight { get; set; }
        public Nullable<int> OrderLength { get; set; }
        public Nullable<int> RequiredQuantitySubtotal { get; set; }
        public Nullable<decimal> RequiredQuantityWeightSummary { get; set; }
        public Nullable<decimal> NumberofOrdersNotPlaced { get; set; }
        public Nullable<decimal> QuantityofOrderSummary { get; set; }
        public Nullable<int> ArrivalCondition_QuantitySubtotal { get; set; }
        public Nullable<double> ArrivalCondition_WeightSubtotal { get; set; }
        public Nullable<decimal> ArrivalCondition_OutofStock { get; set; }
        public Nullable<int> ReturnStatus_QuantitySubtotal { get; set; }
        public Nullable<double> ReturnStatus_WeightSubtotal { get; set; }
        public Nullable<double> Weight { get; set; }
        public Nullable<int> ShippingQuantity { get; set; }
        public System.Guid ProjectId { get; set; }
        public string ProjectName { get; set; }
    }
}
