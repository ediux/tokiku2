using System.Collections.ObjectModel;
using Tokiku.DataServices;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public class MaterialCategoriesListViewModel : DocumentBaseViewModel<MaterialCategories>, IMaterialCategoriesListViewModel
    {

        public MaterialCategoriesListViewModel(ICoreDataService CoreDataService) : base(CoreDataService)
        {

        }

        public MaterialCategoriesListViewModel(MaterialCategories entity, 
            ICoreDataService CoreDataService) : base(entity, CoreDataService)
        {

        }

        private ObservableCollection<IMaterialCategoriesViewModel> _MaterialCategories;

        public ObservableCollection<IMaterialCategoriesViewModel> MaterialCategories { get => _MaterialCategories; set { _MaterialCategories = value; RaisePropertyChanged("MaterialCategories"); } }
        //public MaterialCategoriesViewModelCollection(IEnumerable<MaterialCategoriesViewModel> source) : base(source)
        //{

        //}
        ////private ManufacturersManageController controller;



        //public static MaterialCategoriesViewModelCollection Query()
        //{
        //    return Query<MaterialCategoriesViewModelCollection, MaterialCategories>("ManufacturersManage", "GetMaterialCategoriesList");

        //    //var result = await controller.GetMaterialCategoriesListAsync();
        //    //if (!result.HasError)
        //    //{
        //    //    if (result.Result.Any())
        //    //    {
        //    //        ClearItems();
        //    //        foreach (var item in result.Result)
        //    //        {
        //    //            MaterialCategoriesViewModel model = new MaterialCategoriesViewModel();
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