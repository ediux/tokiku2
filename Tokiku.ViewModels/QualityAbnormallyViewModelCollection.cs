using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tokiku.ViewModels
{
    public class QualityAbnormallyViewModelCollection : BaseViewModelCollection<QualityAbnormallyViewModel>
    {
        public QualityAbnormallyViewModelCollection()
        {

        }

        public QualityAbnormallyViewModelCollection(IEnumerable<QualityAbnormallyViewModel> source) : base(source)
        {

        }

        
    }
}
