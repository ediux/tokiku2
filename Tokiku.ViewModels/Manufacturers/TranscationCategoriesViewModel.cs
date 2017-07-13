using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public class TranscationCategoriesViewModelCollection : BaseViewModelCollection<TranscationCategoriesViewModel>
    {
        private Controllers.ManufacturersManageController controller;

        public override void Initialized()
        {
            base.Initialized();
            controller = new Controllers.ManufacturersManageController();
            Query();
        }

        public static TranscationCategoriesViewModelCollection Query()
        {
            return Query<TranscationCategoriesViewModelCollection, TranscationCategories>("ManufacturersManage", "GetTranscationCategoriesListAsync");
            //var result = await controller.GetTranscationCategoriesList();

            //if (!result.HasError)
            //{
            //    if (result.Result.Any())
            //    {
            //        ClearItems();
            //        foreach (var item in result.Result)
            //        {
            //            TranscationCategoriesViewModel model = new TranscationCategoriesViewModel();
            //            model.SetModel(item);
            //            Add(model);
            //        }
            //    }
            //}
            //else
            //{
            //    Errors = result.Errors;
            //    HasError = result.HasError;
            //}
        }
    }

    public class TranscationCategoriesViewModel : BaseViewModelWithPOCOClass<TranscationCategories>
    {
        public TranscationCategoriesViewModel()
        {

        }
        public TranscationCategoriesViewModel(TranscationCategories entity) : base(entity)
        {

        }
        #region Id


        public new int Id
        {
            get { return CopyofPOCOInstance.Id; }
            set { CopyofPOCOInstance.Id = value; RaisePropertyChanged("Id"); }
        }

   

        #endregion

        #region Name


        public string Name
        {
            get { return CopyofPOCOInstance.Name; }
            set { CopyofPOCOInstance.Name = value; RaisePropertyChanged("Name"); }
        }

    
        #endregion

        //public override void SetModel(dynamic entity)
        //{
        //    try
        //    {
        //        TranscationCategories data = (TranscationCategories)entity;
        //        BindingFromModel(data, this);
        //    }
        //    catch (Exception ex)
        //    {

        //        setErrortoModel(this, ex);
        //    }
        //}
    }
}
