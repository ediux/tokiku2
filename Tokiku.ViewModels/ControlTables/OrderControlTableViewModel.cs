using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Controllers;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public class OrderControlTableViewModelCollection : BaseViewModelCollection<OrderControlTableViewModel>
    {
        public OrderControlTableViewModelCollection()
        {
        }

        public OrderControlTableViewModelCollection(IEnumerable<OrderControlTableViewModel> source) : base(source)
        {
        }

        public static OrderControlTableViewModelCollection Query()
        {
            OrderControlTableController ctrl = new OrderControlTableController();
            ExecuteResultEntity<ICollection<Orders>> ere = ctrl.QuerAll();

            if (!ere.HasError)
            {
                return new OrderControlTableViewModelCollection(ere.Result.Select(s => new OrderControlTableViewModel(s)).ToList());
            }
            return new OrderControlTableViewModelCollection();
        }

    }

    public class OrderControlTableViewModel : BaseViewModelWithPOCOClass<Orders>
    {
        public OrderControlTableViewModel()
        {

        }
        public OrderControlTableViewModel(Orders entiy):base(entiy)
        {

        }
        // ID
        public int Order
        {
            get { return CopyofPOCOInstance.Order; }
            set { CopyofPOCOInstance.Order = value; RaisePropertyChanged("Order"); }
        }
        // 訂製單單號
        public string FormNumber
        {
            get { return CopyofPOCOInstance.FormNumber; }
            set { CopyofPOCOInstance.FormNumber = value; RaisePropertyChanged("FormNumber"); }
        }
        // 廠商代碼
        public string ManufacturersCode
        {
            get { return CopyofPOCOInstance.Manufacturers.Code; }
            set { CopyofPOCOInstance.Manufacturers.Code = value; RaisePropertyChanged("ManufacturersCode"); }
        }
        // 廠商名稱
        public string ManufacturersName
        {
            get { return CopyofPOCOInstance.Manufacturers.Name; }
            set { CopyofPOCOInstance.Manufacturers.Name = value; RaisePropertyChanged("ManufacturersName"); }
        }

    }
}
