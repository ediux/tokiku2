using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Tokiku.ViewModels
{
    public class VoidViewModel : DependencyObject
    {

        #region Value
        /// <summary>
        /// 停用/啟用數值內容
        /// </summary>
        public bool Value
        {
            get { return (bool)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Value.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(bool), typeof(VoidViewModel), new PropertyMetadata(false));

        #endregion

        #region Text


        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Text.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(VoidViewModel), new PropertyMetadata(string.Empty));

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

        public override string ToString()
        {
            return Text;
        }
    }
}
