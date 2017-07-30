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

            //CopyofPOCOInstance.UnusualNumber
        }

        /// <summary>
        /// 查詢單一個體的檢視資料
        /// </summary>
        /// <param name="ManufacturersId"></param>
        public QualityAbnormallyViewModel Query(Guid ProjectId)
        {
            try
            {
                QualityAbnormallyViewModel viewmodel = null;

                viewmodel = QuerySingle<QualityAbnormallyViewModel, AbnormalQuality>(
                    "AbnormalQuality", "QuerySingle", ProjectId);

                return viewmodel;
            }
            catch (Exception ex)
            {
                QualityAbnormallyViewModel view = new QualityAbnormallyViewModel();
                setErrortoModel(view, ex);
                return view;
            }

        }

        public string UnusualNumber { get => CopyofPOCOInstance.UnusualNumber; set { CopyofPOCOInstance.UnusualNumber = value; RaisePropertyChanged("UnusualNumber"); } }

    }
}
