using System.ComponentModel;
using System.Windows;

namespace Tokiku.ViewModels
{
    public class DocumentStatusViewModel : INotifyPropertyChanged
    {
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

        #region PropertyChanged 事件
        /// <summary>
        /// 屬性變更事件。
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// 引發屬性變更事件。
        /// </summary>
        /// <param name="PropertyName">發生變更的屬性名稱。</param>
        protected void RaisePropertyChanged(string PropertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }
        #endregion
    }
}
