using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tokiku.ViewModels
{
    public class ProcessingAtlasViewModelCollection : BaseViewModelCollection<ProcessingAtlasViewModel>
    {
        public ProcessingAtlasViewModelCollection()
        {

        }

        public ProcessingAtlasViewModelCollection(IEnumerable<ProcessingAtlasViewModel> source) : base(source)
        {

        }
    }
}
