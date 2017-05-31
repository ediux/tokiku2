using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Tokiku.ViewModels
{
    public class PaymentTypeViewModel : BaseViewModel,IBaseViewModel
    {


        public byte Id
        {
            get { return (byte)GetValue(IdProperty); }
            set { SetValue(IdProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Id.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IdProperty =
            DependencyProperty.Register("Id", typeof(byte), typeof(PaymentTypeViewModel), new PropertyMetadata((byte)0, new PropertyChangedCallback(DefaultFieldChanged)));



        public string PaymentTypeName
        {
            get { return (string)GetValue(PaymentTypeNameProperty); }
            set { SetValue(PaymentTypeNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PaymentTypeName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PaymentTypeNameProperty =
            DependencyProperty.Register("PaymentTypeName", typeof(string), typeof(PaymentTypeViewModel), new PropertyMetadata(string.Empty, new PropertyChangedCallback(DefaultFieldChanged)));


    }
}
