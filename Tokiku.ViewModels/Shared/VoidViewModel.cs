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
        public string Text
        {
            get => _Text;
            set { _Text = value; RaisePropertyChanged("Text"); }
        }

        #endregion

        public void SetModel(dynamic entity)
        {
            bool data = (bool)entity;
            if (data)
            {
                Value = data;
                Text = "停用";
            }
            else
            {
                Value = data;
                Text = "啟用";
            }
        }

        //public override string ToString()
        //{
        //    return Text;
        //}
    }
}
