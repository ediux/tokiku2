using GalaSoft.MvvmLight.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{


    public class TranscationCategoriesViewModel : EntityBaseViewModel<TranscationCategories>, ITranscationCategoriesViewModel
    {
        public TranscationCategoriesViewModel()
        {

        }

        [PreferredConstructor]
        public TranscationCategoriesViewModel(TranscationCategories entity) : base(entity)
        {

        }
        #region Id

        public int Id
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

    }
}
