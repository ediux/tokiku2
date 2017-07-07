using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tokiku.ViewModels
{
    public class ControlTableViewModel : IBaseViewModel
    {
        #region Id
        private Guid _Id;

        /// <summary>
        /// BOM的編號
        /// </summary>
        public Guid Id
        {
            get { return _Id; }
            set { _Id = value; }
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
        public IEnumerable<string> Errors { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool HasError { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// 引發屬性變更事件。
        /// </summary>
        /// <param name="PropertyName">發生變更的屬性名稱。</param>
        protected void RaisePropertyChanged(string PropertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

        public void Initialized()
        {
            throw new NotImplementedException();
        }

        public void Query()
        {
            throw new NotImplementedException();
        }

        public void Refresh()
        {
            throw new NotImplementedException();
        }

        public void SaveModel()
        {
            throw new NotImplementedException();
        }

        public void SetModel(dynamic entity)
        {
            throw new NotImplementedException();
        }
    }
}
