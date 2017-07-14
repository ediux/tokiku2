using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Tokiku.Controllers;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public class MaterialCategoriesViewModelCollection : BaseViewModelCollection<MaterialCategoriesViewModel>
    {
        public MaterialCategoriesViewModelCollection()
        {

        }

        public MaterialCategoriesViewModelCollection(IEnumerable<MaterialCategoriesViewModel> source) : base(source)
        {

        }
        //private ManufacturersManageController controller;



        public static MaterialCategoriesViewModelCollection Query()
        {
            return Query<MaterialCategoriesViewModelCollection, MaterialCategories>("ManufacturersManage", "GetMaterialCategoriesList");

            //var result = await controller.GetMaterialCategoriesListAsync();
            //if (!result.HasError)
            //{
            //    if (result.Result.Any())
            //    {
            //        ClearItems();
            //        foreach (var item in result.Result)
            //        {
            //            MaterialCategoriesViewModel model = new MaterialCategoriesViewModel();
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

    public class MaterialCategoriesViewModel : BaseViewModelWithPOCOClass<MaterialCategories>
    {
        public MaterialCategoriesViewModel()
        {

        }

        public MaterialCategoriesViewModel(MaterialCategories entity) : base(entity)
        {

        }

        #region Name
        public string Name
        {
            get { return CopyofPOCOInstance.Name; }
            set { CopyofPOCOInstance.Name = value; RaisePropertyChanged("Name"); }
        }
        #endregion



    }
}
