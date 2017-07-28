using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Windows.Input;
using Tokiku.Entity;
using Tokiku.MVVM.Commands;
using Tokiku.MVVM.Tools;

namespace Tokiku.ViewModels
{
    public abstract class BaseViewModelCollection<TView> : ObservableCollection<TView>, IMultiBaseViewModel where TView : IBaseViewModelWithLoginedUser
    {
        public BaseViewModelCollection()
        {
            _RelayCommand = new RelayCommand((x) => ReplyFrom(x), (x) => true);
            //_SaveCommand = new SaveModelCommand((x) => SaveModel(x));
            //_CreateNewCommand = new CreateNewModelCommand();

            //Initialized();
        }

        public BaseViewModelCollection(IEnumerable<TView> source) : base(source)
        {
            _RelayCommand = new RelayCommand((x) => ReplyFrom(x), (x) => true);
            //_SaveCommand = new SaveModelCommand((x) => SaveModel(x));
            //_CreateNewCommand = new CreateNewModelCommand();

            //Initialized();
        }

        public ICommand QueryCommand { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public ICommand SaveCommand { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public ICommand CreateNewCommand { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public ICommand DeleteCommand { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        #region 轉送命令
        private ICommand _RelayCommand;
        /// <summary>
        /// 轉送命令
        /// </summary>
        public ICommand RelayCommand { get => _RelayCommand; set => _RelayCommand = value; }

        /// <summary>
        /// 承接轉送命令來的資料來源物件處理方法。
        /// </summary>
        /// <param name="Parameter"></param>
        protected virtual void ReplyFrom(object Parameter)
        {

        }

        #endregion
        public object Details => throw new NotImplementedException();

        public IEnumerable<string> Errors { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool HasError { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public string ControllerName => throw new NotImplementedException();

        public void Initialized(object Parameter)
        {
            throw new NotImplementedException();
        }

        public void SaveModel(bool isLast = true)
        {
            throw new NotImplementedException();
        }

        public void SaveModel()
        {
            throw new NotImplementedException();
        }
    }
}
