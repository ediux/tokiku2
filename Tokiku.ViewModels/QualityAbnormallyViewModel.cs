using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Entity;
namespace Tokiku.ViewModels
{
    public class QualityAbnormallyViewModel : BaseViewModelWithPOCOClass<AbnormalQuality>
    {
        public QualityAbnormallyViewModel()
        {
            _SaveModelController = "AbnormalQuality";
        }

        public QualityAbnormallyViewModel(AbnormalQuality entity) : base(entity)
        {
            _SaveModelController = "AbnormalQuality";
        }

        
    }
}
