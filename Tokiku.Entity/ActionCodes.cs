using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tokiku.Entity
{
    public enum ActionCodes
    {
        Create = 1,
        Read = 0,
        Update = 2,
        Delete = 4,
        ConstructionOrderChange = 8
    }
}