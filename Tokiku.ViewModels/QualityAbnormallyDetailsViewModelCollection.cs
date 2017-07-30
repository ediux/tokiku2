using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public class QualityAbnormallyDetailsViewModelCollection : BaseViewModelCollection<QualityAbnormallyDetailsViewModel>
    {
        public QualityAbnormallyDetailsViewModelCollection()
        {
            _ControllerName = "AbnormalQualityDetails";
        }

        public QualityAbnormallyDetailsViewModelCollection(IEnumerable<QualityAbnormallyDetailsViewModel> source) : base(source)
        {
            _ControllerName = "AbnormalQualityDetails";
        }

        public static QualityAbnormallyDetailsViewModelCollection Query(Guid ProjectId,Guid MasterId)
        {
            try
            {
                QualityAbnormallyDetailsViewModelCollection collection = new QualityAbnormallyDetailsViewModelCollection();

                collection = Query<QualityAbnormallyDetailsViewModelCollection, AbnormalQualityDetails>(
                     collection.SaveModelController, "QueryAll", ProjectId,MasterId);

                return collection;
            }
            catch (Exception ex)
            {
                QualityAbnormallyDetailsViewModelCollection emptycollection =
                    new QualityAbnormallyDetailsViewModelCollection();
                setErrortoModel(emptycollection, ex);
                return emptycollection;
            }
        }
    }
}
