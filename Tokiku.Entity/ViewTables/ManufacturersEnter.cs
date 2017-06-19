using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tokiku.Entity.ViewTables
{
    public class ManufacturersEnter
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Principal { get; set; }
        public string UniformNumbers { get; set; }
        public string MainContactPerson { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Fax { get; set; }
        public string FactoryPhone { get; set; }
        public string FactoryAddress { get; set; }
        public string Void { get; set; }
    }
}
