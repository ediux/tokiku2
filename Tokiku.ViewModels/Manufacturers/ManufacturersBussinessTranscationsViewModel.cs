using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public class ManufacturersBussinessTranscationsViewModel : BaseViewModelWithPOCOClass<SupplierTranscationItem>
    {
        public ManufacturersBussinessTranscationsViewModel() : base()
        {

        }

        public ManufacturersBussinessTranscationsViewModel(SupplierTranscationItem entity) : base(entity)
        {

        }



        #region Code


        public string Code
        {
            get { return CopyofPOCOInstance.Projects.Code; }
            set { CopyofPOCOInstance.Projects.Code = value; RaisePropertyChanged("Code"); }
        }

       

        #endregion

        #region Name


        public string Name
        {
            get { return ""; }
            set {  }
        }

     

        #endregion

        #region TranscationItemName

        //public string TranscationItemName
        //{
        //    get { return (string)GetValue(TranscationItemNameProperty); }
        //    set { SetValue(TranscationItemNameProperty, value); }
        //}

    

        #endregion

        #region ManufacturersId


        //public Guid ManufacturersId
        //{
        //    get { return (Guid)GetValue(ManufacturersIdProperty); }
        //    set { SetValue(ManufacturersIdProperty, value); }
        //}

       


        #endregion

      
    }
}
