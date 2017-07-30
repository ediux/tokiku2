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

        public static QualityAbnormallyDetailsViewModelCollection QueryAll(Guid ProjectId)
        {
            try
            {
                QualityAbnormallyDetailsViewModelCollection collection = new QualityAbnormallyDetailsViewModelCollection();

                collection = Query<QualityAbnormallyDetailsViewModelCollection, AbnormalQualityDetails>(
                     collection.SaveModelController, "QueryAllByProject", ProjectId);

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

        public static QualityAbnormallyDetailsViewModelCollection Query(Guid MasterId)
        {
            try
            {
                QualityAbnormallyDetailsViewModelCollection collection = new QualityAbnormallyDetailsViewModelCollection();

                collection = Query<QualityAbnormallyDetailsViewModelCollection, AbnormalQualityDetails>(
                     collection.SaveModelController, "QueryAll", MasterId);

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
