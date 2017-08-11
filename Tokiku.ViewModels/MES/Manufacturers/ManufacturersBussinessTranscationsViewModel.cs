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
    /// <summary>
    /// 交易歷史紀錄檢視模型
    /// </summary>
    public class ManufacturersBussinessTranscationsViewModel : EntityBaseViewModel<SupplierTranscationItem>,
        IManufacturersBussinessTranscationsViewModel
    {
        [PreferredConstructor]
        public ManufacturersBussinessTranscationsViewModel() : base()
        {

        }

        
        public ManufacturersBussinessTranscationsViewModel(SupplierTranscationItem entity) : base(entity)
        {

        }

        #region Code
        /// <summary>
        /// 專案代碼
        /// </summary>
        public string Code
        {
            get { return CopyofPOCOInstance.Projects.Code; }

            set
            {
                RaisePropertyChanged("Code", CopyofPOCOInstance.Projects.Code, value, broadcast: true);
            }
        }

        #endregion

        #region Name

        /// <summary>
        /// 專案簡稱
        /// </summary>
        public string Name
        {
            get => CopyofPOCOInstance.Projects.ShortName;
            set
            {
                RaisePropertyChanged("Name", CopyofPOCOInstance.Projects.ShortName, value, broadcast: true);
            }
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
