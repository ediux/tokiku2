using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public class MaterialCategoriesViewModel : EntityBaseViewModel<MaterialCategories>, IMaterialCategoriesViewModel
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
