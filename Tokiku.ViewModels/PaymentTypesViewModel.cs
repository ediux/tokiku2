using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tokiku.Entity;
using GalaSoft.MvvmLight.Ioc;

namespace Tokiku.ViewModels
{
    public class PaymentTypesViewModel : EntityBaseViewModel<PaymentTypes>,IPaymentTypesViewModel
    {
        [PreferredConstructor]
        public PaymentTypesViewModel():base()
        {

        }

        public PaymentTypesViewModel(PaymentTypes entity):base(entity)
        {

        }

        /// <summary>
        /// 支付方式
        /// </summary>
        public string PaymentTypeName
        {
            get { return CopyofPOCOInstance.PaymentTypeName; }
            set { CopyofPOCOInstance.PaymentTypeName = value; RaisePropertyChanged("PaymentTypeName"); }
        }
    }
}