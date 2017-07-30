using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Entity;

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

        public static QualityAbnormallyViewModelCollection Query(Guid ProjectId)
        {
            try
            {
                QualityAbnormallyViewModelCollection collection = new QualityAbnormallyViewModelCollection();

                collection = Query<QualityAbnormallyViewModelCollection,AbnormalQuality >(
                     collection.SaveModelController, "QueryAll", ProjectId);

                return collection;
            }
            catch (Exception ex)
            {
                QualityAbnormallyViewModelCollection emptycollection =
                    new QualityAbnormallyViewModelCollection();
                setErrortoModel(emptycollection, ex);
                return emptycollection;
            }
        }
    }
}
