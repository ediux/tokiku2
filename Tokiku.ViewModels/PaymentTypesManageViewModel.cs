using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Tokiku.Controllers;

namespace Tokiku.ViewModels
{
    public class PaymentTypesManageViewModelCollection : BaseViewModelCollection<PaymentTypesManageViewModel>
    {
        public PaymentTypesManageViewModelCollection()
        {

        }

        public PaymentTypesManageViewModelCollection(IEnumerable<PaymentTypesManageViewModel> source) : base(source)
        {

        }

     
    }

    public class PaymentTypesManageViewModel : BaseViewModel
    {
        PaymentTypesManageController _controller;

        public PaymentTypesManageViewModel(PaymentTypesManageController controller)
        {
            _controller = controller;
        }
        /// <summary>
        /// 編號
        /// </summary>
        public Guid Id
        {
            get { return (Guid)GetValue(IdProperty); }
            set { SetValue(IdProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Id.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IdProperty =
            DependencyProperty.Register("Id", typeof(Guid), typeof(PaymentTypesManageViewModel), new PropertyMetadata(Guid.NewGuid()));



        /// <summary>
        /// 支付方式
        /// </summary>
        public string Name
        {
            get { return (string)GetValue(NameProperty); }
            set { SetValue(NameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Name.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NameProperty =
            DependencyProperty.Register("Name", typeof(string), typeof(PaymentTypeViewModel), new PropertyMetadata(string.Empty));

        /// <summary>
        /// 查詢單一資料列
        /// </summary>
        /// <param name="Key"></param>
        /// <returns></returns>
        public PaymentTypeViewModel Query(byte Key)
        {
            var result = _controller.Query(w => w.Id == Key);
            if (!result.HasError)
            {
                var k = result.Result.SingleOrDefault();

                return new PaymentTypeViewModel()
                {
                    Id = k.Id,
                    PaymentTypeName = k.PaymentTypeName
                };
            }

            return new PaymentTypeViewModel();
        }
    }
}
