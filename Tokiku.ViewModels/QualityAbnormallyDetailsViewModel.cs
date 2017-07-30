using System;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public class QualityAbnormallyDetailsViewModel : BaseViewModelWithPOCOClass<AbnormalQualityDetails>
    {
        public QualityAbnormallyDetailsViewModel()
        {
            _SaveModelController = "AbnormalQualityDetails";
        }

        public QualityAbnormallyDetailsViewModel(AbnormalQualityDetails entity) : base(entity)
        {
            _SaveModelController = "AbnormalQualityDetails";
        }

        #region 查詢單一個體的檢視資料
        /// <summary>
        /// 查詢單一個體的檢視資料
        /// </summary>
        /// <param name="ManufacturersId"></param>
        public QualityAbnormallyDetailsViewModel Query(Guid Id)
        {
            try
            {
                QualityAbnormallyDetailsViewModel viewmodel = new QualityAbnormallyDetailsViewModel();

                viewmodel = QuerySingle<QualityAbnormallyDetailsViewModel, AbnormalQualityDetails>(
                    viewmodel.SaveModelController, "QuerySingle", Id);

                return viewmodel;
            }
            catch (Exception ex)
            {
                QualityAbnormallyDetailsViewModel view = new QualityAbnormallyDetailsViewModel();
                setErrortoModel(view, ex);
                return view;
            }

        }
        #endregion
    }
}
