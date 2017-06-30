using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TokikuNew.Controls
{
    public enum DocumentLifeCircle
    {
        None=0,
        Create = 1,
        Read = 2,
        Update = 3,
        Delete = 4,
        Save=5
    }
}
