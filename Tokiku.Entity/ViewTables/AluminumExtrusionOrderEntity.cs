using System;

namespace Tokiku.Entity
{
    public class AluminumExtrusionOrderEntity
    {
        // "*東菊編號*"
        public string TokikuId { get; set; }
        // "*大同編號*"
        public string ManufacturersId { get; set; }
        // "*材質*"
        public string Material { get; set; }
        // "*單位重(kg/m)*"
        public Nullable<float> UnitWeight { get; set; }
        // "*訂購長度(mm)*"
        public Nullable<int> OrderLength { get; set; }
        // "[需求數量]"
        public Nullable<int> RequiredQuantity { get; set; }
        // "[備品數量]"
        public Nullable<int> SparePartsQuantity { get; set; }
        // "[下單數量]"
        public Nullable<int> PlaceAnOrderQuantity { get; set; }
        // "[備註]"
        public string Note { get; set; }
    }
}
