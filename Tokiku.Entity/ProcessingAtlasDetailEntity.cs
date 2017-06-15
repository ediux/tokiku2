using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tokiku.Entity
{
    public class ProcessingAtlasDetailEntity
    {
        public int UpdateTimes
        {
            get;
            set;
        }

        public DateTime? LastUpdate
        {
            get;
            set;
        }

        public DateTime? ConstructionOrderChangeDate
        {
            get;
            set;
        }
    }
}
