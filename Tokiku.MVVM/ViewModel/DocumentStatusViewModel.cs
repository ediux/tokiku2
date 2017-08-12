using System.ComponentModel;
using System.Windows;
using GalaSoft.MvvmLight;

namespace Tokiku.ViewModels
{
    public class DocumentStatusViewModel : ViewModelBase, IDocumentStatusViewModel
    {
        public DocumentStatusViewModel()
        {
            _IsModify = false;
            _IsNewInstance = true;
            _IsSaved = false;
        }
        private bool _IsNewInstance = false;
        /// <summary>
        /// 指出目前是否處於初始化狀態
        /// </summary>
        public bool IsNewInstance
        {
            get => _IsNewInstance;
            set { _IsNewInstance = value; RaisePropertyChanged("IsNewInstance"); }
        }

        private bool _IsModify = false;
            
        /// <summary>
        /// 指出是否已經修改
        /// </summary>
        public bool IsModify
        {
            get => _IsModify;
            set { _IsModify = value; RaisePropertyChanged("IsModify"); }
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
                _IsSaved = value;
                RaisePropertyChanged("IsSaved");
            }
        } 
    }
}
