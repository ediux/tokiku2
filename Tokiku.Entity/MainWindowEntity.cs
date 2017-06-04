using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tokiku.Entity
{
    public class MainWindowEntity
    {
        public ExecuteResultEntity<Users> LoginedUser { get; set; }
        public ExecuteResultEntity<ICollection<Projects>> Projects { get; set; }
        public ExecuteResultEntity<ICollection<Manufacturers>> Manufacturers { get; set; }
        public ExecuteResultEntity<ICollection<Manufacturers>> Clients { get; set; }
    }
}
