using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Tokiku.ViewModels
{
    public class VoidViewModel : ViewModelBase2, IVoidViewModel
    {

        #region Value
        private bool _Value = false;
        /// <summary>
        /// 停用/啟用數值內容
        /// </summary>
        public bool Value
        {
            get => _Value;
            set { _Value = value; RaisePropertyChanged("Value"); }
        }

        #endregion

        #region Text

        private string _Text = string.Empty;
        /// <summary>
        /// 取得或設定代表停用/啟用數值內容的文字內容
        /// </summary>
        public string Text
        {
            get => _Text;
            set { _Text = value; RaisePropertyChanged("Text"); }
        }

        #endregion

        public override string ToString()
        {
            return Text;
        }
    }
}
