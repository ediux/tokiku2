using System.ComponentModel;
using System.Windows;
using GalaSoft.MvvmLight;
using System;

namespace Tokiku.ViewModels
{
    public class DocumentStatusViewModel : ViewModelBase2, IDocumentStatusViewModel
    {
        public DocumentStatusViewModel()
        {
            try
            {
                _IsModify = false;
                _IsNewInstance = true;
                _IsSaved = false;
            }
            catch (Exception ex)
            {
                setErrortoModel(this, ex);
            }

        }
        private bool _IsNewInstance = false;
        /// <summary>
        /// 指出目前是否處於初始化狀態
        /// </summary>
        public bool IsNewInstance
        {
            get => _IsNewInstance;
            set
            {
                try
                {
                    _IsNewInstance = value; RaisePropertyChanged("IsNewInstance");
                }
                catch (Exception ex)
                {
                    setErrortoModel(this, ex);
                }

            }
        }

        private bool _IsModify = false;

        /// <summary>
        /// 指出是否已經修改
        /// </summary>
        public bool IsModify
        {
            get => _IsModify;
            set
            {
                try
                {
                    _IsModify = value; RaisePropertyChanged("IsModify");
                }
                catch (Exception ex)
                {
                    setErrortoModel(this, ex);
                }
            }
        }

        private bool _IsSaved = false;

        /// <summary>
        /// 是否已存檔?
        /// </summary>
        public bool IsSaved
        {
            get { return _IsSaved; }
            set
            {
                try
                {
                    _IsSaved = value;
                    RaisePropertyChanged("IsSaved");
                }
                catch (Exception ex)
                {
                    setErrortoModel(this, ex);
                }
            }
        }
    }
}
