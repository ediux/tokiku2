using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tokiku.Entity.ViewTables
{
    public class ControlTableFormEntity
    {
        public System.Guid Id { get; set; }
        public string Name { get; set; }

        public Guid FormDetailId { get; set; }
        public string DemandUnit { get; set; }
        public string FormNumber { get; set; }
        public int BatchNumber { get; set; }
        public DateTime? ExpectedDelivery { get; set; }
        public DateTime ActualDelivery { get; set; }
        public DateTime MakingFormDate { get; set; }
        public Guid MakingUserId { get; set; }
        public Guid? ManufacturersId { get; set; }
        public double? ReservedPercentage { get; set; }
        public string ReservedField1 { get; set; }
        public string ReservedField2 { get; set; }
        public string ReservedField3 { get; set; }
        public string ReservedField4 { get; set; }
        public string ReservedField5 { get; set; }
        public string ReservedField6 { get; set; }
        public string ReservedField7 { get; set; }
        public string ReservedField8 { get; set; }
        public string ReservedField9 { get; set; }
        public string ReservedField10 { get; set; }

        public System.DateTime CreateTime { get; set; }
        public System.Guid CreateUserId { get; set; }
    }
}
