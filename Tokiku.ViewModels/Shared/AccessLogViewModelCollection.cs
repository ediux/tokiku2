using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tokiku.ViewModels
{
    public class AccessLogViewModelCollection : BaseViewModelCollection<AccessLogViewModel>
    {
        public AccessLogViewModelCollection() : base()
        {

        }

        public AccessLogViewModelCollection(IEnumerable<AccessLogViewModel> source) : base(source)
        {

        }


    }
}
