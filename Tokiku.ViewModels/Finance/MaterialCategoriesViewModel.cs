using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Tokiku.DataServices;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public class MaterialCategoriesViewModel : DocumentBaseViewModel<MaterialCategories>, IMaterialCategoriesViewModel
    {
        public MaterialCategoriesViewModel(ICoreDataService CoreDataService) : base(CoreDataService)
        {

        }

        public MaterialCategoriesViewModel(MaterialCategories entity, ICoreDataService CoreDataService)
            : base(entity, CoreDataService)
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
