using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tokiku.Entity
{
    public class AluminumExtrusionOrderMaterialValuationEntity
    {
        //"材質"
        public string Material { get; set; }
        //"*kg單價*"
        public Nullable<int> UnitPrice { get; set; }
        //"重量"
        public Nullable<double> Weight { get; set; }
        //"預估總價"
        public Nullable<int> TotalPrice { get; set; }
    }
}
