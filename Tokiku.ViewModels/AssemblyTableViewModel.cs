using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Tokiku.ViewModels
{
    public class AssemblyTableViewModel : IBaseViewModel
    {


        #region Id
        private Guid _Id;

        public Guid Id
        {
            get { return _Id; }
            set { _Id = value; RaisePropertyChanged("Id"); }
        }
        #endregion

        #region Atlas

        private int _atlas = 1;

        public int Atlas
        {
            get { return _atlas; }
            set { _atlas = value; RaisePropertyChanged("Atlas"); }
        }

        #endregion

        #region Combination Number 組合編號
        private string _CombinationNumber = string.Empty;
        public string CombinationNumber
        {
            get => _CombinationNumber;
            set { _CombinationNumber = value; RaisePropertyChanged("CombinationNumber"); }
        }
        #endregion

        #region Processing number 加工編號
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

        #region Crowded number 擠型編號
        private string _CrowdedNumber;

        /// <summary>
        /// 擠型編號
        /// </summary>
        public string CrowdedNumber
        {
            get { return _CrowdedNumber; }
            set { _CrowdedNumber = value; RaisePropertyChanged("CrowdedNumber"); }
        }

        #endregion

        #region Cut length
        private decimal _CutLength;

        public decimal CutLength
        {
            get { return _CutLength; }
            set { _CutLength = value; RaisePropertyChanged("CutLength"); }
        }

        #endregion

        #region 數量

        private int _Amount;

        public int Amount
        {
            get { return _Amount; }
            set { _Amount = value; RaisePropertyChanged("Amount"); }
        }

        #endregion

        #region Material Description 
        private string _MaterialDescription = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string MaterialDescription { get => _MaterialDescription; set { _MaterialDescription = value; RaisePropertyChanged("MaterialDescription"); } }
        #endregion

        #region TotalDemand
        private decimal _TotalDemand;
        /// <summary>
        /// 
        /// </summary>
        public decimal TotalDemand { get => _TotalDemand; set { _TotalDemand = value; RaisePropertyChanged("TotalDemand"); } }
        #endregion


        private IEnumerable<string> _Errors = new string[] { };

        public IEnumerable<string> Errors { get => _Errors; set => _Errors = value; }

        private bool _HasError = false;

        public bool HasError { get => _HasError; set => _HasError = value; }

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// 引發屬性變更事件。
        /// </summary>
        /// <param name="PropertyName">發生變更的屬性名稱。</param>
        protected void RaisePropertyChanged(string PropertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

        public void Query()
        {
            throw new NotImplementedException();
        }

        public void Initialized()
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
