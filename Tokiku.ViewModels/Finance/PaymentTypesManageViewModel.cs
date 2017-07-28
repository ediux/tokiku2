using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Tokiku.Controllers;
using Tokiku.Entity;

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



        public static PaymentTypesManageViewModelCollection Query()
        {
            return Query<PaymentTypesManageViewModelCollection, PaymentTypes>(
                "PaymentTypesManage", "QueryAll");
            //var result = _controller.QueryAll();
            //if (!result.HasError)
            //{
            //    if (result.Result.Any())
            //    {
            //        ClearItems();

            //        foreach (var entity in result.Result)
            //        {
            //            PaymentTypesManageViewModel item = new PaymentTypesManageViewModel();
            //            item.SetModel(entity);
            //            Add(item);
            //        }

            //    }
            //}
        }

    }

    public class PaymentTypesManageViewModel : BaseViewModelWithPOCOClass<PaymentTypes>
    {
        PaymentTypesManageController _controller;
        public PaymentTypesManageViewModel()
        {
            _controller = new PaymentTypesManageController();
           
        }
        public PaymentTypesManageViewModel(PaymentTypesManageController controller)
        {
            _controller = controller;

        }
        public PaymentTypesManageViewModel(PaymentTypes entity):base(entity)
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

     
        ///// <summary>
        ///// 查詢單一資料列
        ///// </summary>
        ///// <param name="Key"></param>
        ///// <returns></returns>
        //public void Query(byte Key)
        //{
        //    var result = _controller.Query(w => w.Id == Key);
        //    if (!result.HasError)
        //    {
        //        var k = result.Result.SingleOrDefault();
        //        BindingFromModel(k, this);
        //    }
        //}

        //public override void SetModel(dynamic entity)
        //{
        //    if (!Dispatcher.CheckAccess())
        //    {
        //        Dispatcher.Invoke(new Action<dynamic>(SetModel), System.Windows.Threading.DispatcherPriority.Normal, entity);
        //    }
        //    else
        //    {
        //        PaymentTypes data = (PaymentTypes)entity;
        //        BindingFromModel(data, this);
        //    }

        //}
        public override string ToString()
        {
            return PaymentTypeName;
        }
    }
}
