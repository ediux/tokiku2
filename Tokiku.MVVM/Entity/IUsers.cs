using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tokiku.Entity
{
    public interface IUsers
    {
        System.Guid UserId { get; set; }

        string UserName { get; set; }

        string LoweredUserName { get; set; }

        string MobileAlias { get; set; }
        bool IsAnonymous { get; set; }
        System.DateTime LastActivityDate { get; set; }

    }
}
