using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.DataServices;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public class TranscationCategoriesListViewModel : DocumentBaseViewModel<TranscationCategories>, ITranscationCategoriesListViewModel
    {
        private IFinancialManagementDataService _FinancialManagementDataService;
        public TranscationCategoriesListViewModel(IFinancialManagementDataService FinancialManagementDataService,
            ICoreDataService CoreDataService) : base(CoreDataService)
        {
            _FinancialManagementDataService = FinancialManagementDataService;
        }

        public ObservableCollection<TranscationCategoriesViewModel> TranscationCategories { get; set; }
        //public static TranscationCategoriesListViewModel Query()
        //{
        //    //return Query<TranscationCategoriesListViewModel, TranscationCategories>(
        //    //    "ManufacturersManage",
        //    //    "GetTranscationCategoriesList");
        //    //var result = await controller.GetTranscationCategoriesList();

        //    //if (!result.HasError)
        //    //{
        //    //    if (result.Result.Any())
        //    //    {
        //    //        ClearItems();
        //    //        foreach (var item in result.Result)
        //    //        {
        //    //            TranscationCategoriesViewModel model = new TranscationCategoriesViewModel();
        //    //            model.SetModel(item);
        //    //            Add(model);
        //    //        }
        //    //    }
        //    //}
        //    //else
        //    //{
        //    //    Errors = result.Errors;
        //    //    HasError = result.HasError;
        //    //}
        //}
    }
}
