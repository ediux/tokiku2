using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public class ControlTableViewModel : BaseViewModelWithPOCOClass<BOM>
    {
        #region Id
        /// <summary>
        /// BOM的編號
        /// </summary>
        public Guid Id
        {
            get { return CopyofPOCOInstance.Id; }
            set { CopyofPOCOInstance.Id = value; RaisePropertyChanged("Id"); }
        }
        #endregion

        #region Row Index
        private int _RowIndex;

        /// <summary>
        /// 項次
        /// </summary>
        public int RowIndex
        {
            get { return _RowIndex; }
            set { _RowIndex = value; RaisePropertyChanged(""); }
        }
        #endregion

        #region 製單
        private string _OrderNumber;

        public string OrderNumber
        {
            get { return _OrderNumber; }
            set { _OrderNumber = value; }
        }

        #endregion
        #region 東菊編號
        private string _Code;

        /// <summary>
        /// 東菊編號
        /// </summary>
        public string Code
        {
            get { return _Code; }
            set { _Code = value; RaisePropertyChanged("Code"); }
        }
        #endregion

        #region 廠商
        private string _ManufacturersName;

        /// <summary>
        /// 廠商名稱
        /// </summary>
        public string ManufacturersName
        {
            get { return _ManufacturersName; }
            set { _ManufacturersName = value; RaisePropertyChanged(""); }
        }

        #endregion

        #region 加工編號
        private string _ProcessingNumber;
        /// <summary>
        /// 加工編號
        /// </summary>
        public string ProcessingNumber
        {
            get { return _ProcessingNumber; }
            set { _ProcessingNumber = value; RaisePropertyChanged("ProcessingNumber"); }
        }

        #endregion

        #region Material and surface treatment 材質及表面處理
        private string _MaterialDescription;

        public string MaterialDescription
        {
            get { return _MaterialDescription; }
            set { _MaterialDescription = value; RaisePropertyChanged(""); }
        }

        #endregion

       
       
    }
}
