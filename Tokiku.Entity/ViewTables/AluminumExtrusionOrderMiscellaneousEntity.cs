using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tokiku.Entity
{
    public class AluminumExtrusionOrderMiscellaneousEntity
    {
        // "*東菊編號/項目*"
        public string TokikuId { get; set; }
        // "*廠商編號*"
        public string ManufacturersId { get; set; }
        //"*說明*"
        public string Description { get; set; }
        //"*單價*"
        public Nullable<int> UnitPrice { get; set; }
        //"*數量*"
        public Nullable<int> Quantity { get; set; }
        //"*金額*"
        public Nullable<int> Amount { get; set; }
    }
}
