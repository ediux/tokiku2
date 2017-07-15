using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tokiku.ViewModels
{
    public class AssemblyTableViewModelCollection : BaseViewModelCollection<AssemblyTableViewModel>
    {
        public AssemblyTableViewModelCollection():base()
        {

        }

        public AssemblyTableViewModelCollection(IEnumerable<AssemblyTableViewModel> source) : base(source)
        {

        }
    }
}
