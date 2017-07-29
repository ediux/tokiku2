using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Controllers;
using Tokiku.Entity;
using Tokiku.MVVM.Tools;

namespace Tokiku.ViewModels
{
    public class InventoryViewModelCollection : BaseViewModelCollection<InventoryViewModel,Inventory>
    {
        public InventoryViewModelCollection()
        {
        }

        public InventoryViewModelCollection(IEnumerable<InventoryViewModel> source) : base(source)
        {
        }
        
        public static InventoryViewModelCollection Query()
        {
            return Query<InventoryViewModelCollection>("Inventory", "QueryAll");
        }

    }

    public class InventoryViewModel : BaseViewModelWithPOCOClass<Inventory>
    {
        public InventoryViewModel()
        {
        }

        public InventoryViewModel(Inventory entity) : base(entity)
        {
        }

        public static InventoryViewModel CreateNew(Guid ProjectId)
        {
            try {
                return QuerySingle<InventoryViewModel, Inventory>(
                    "Inventory", "CreateNew", ProjectId);
            }catch (Exception ex) {
                InventoryViewModel view = new InventoryViewModel();
                view.setErrortoModel(ex);
                return view;
            }
        }

        // 需求單單號
        public string FormNumber
        {
            get { return CopyofPOCOInstance.RequiredDetails?.Required.FormNumber; }
            set { CopyofPOCOInstance.RequiredDetails.Required.FormNumber = value; RaisePropertyChanged("FormNumber"); }
        }
        // 東菊編號
        public string RequiredDetailsCode
        {
            get { return CopyofPOCOInstance.RequiredDetails.Code; }
            set { CopyofPOCOInstance.RequiredDetails.Code = value; RaisePropertyChanged("RequiredDetailsCode"); }
        }
        // 廠商編號
        public string FactoryNumber
        {
            get { return CopyofPOCOInstance.RequiredDetails.FactoryNumber; }
            set { CopyofPOCOInstance.RequiredDetails.FactoryNumber = value; RaisePropertyChanged("FactoryNumber"); }
        }
        // 材質
        public string MaterialCategoriesName
        {
            get { return CopyofPOCOInstance.RequiredDetails.Materials.Name; }
            set { CopyofPOCOInstance.RequiredDetails.Materials.Name = value; RaisePropertyChanged("MaterialCategoriesName"); }
        }
        // 單位重(kg/m)
        public decimal UnitWeight
        {
            get { return CopyofPOCOInstance.RequiredDetails.UnitWeight; }
            set { CopyofPOCOInstance.RequiredDetails.UnitWeight = value; RaisePropertyChanged("UnitWeight"); }
        }
        // 訂購長度(mm)
        public int? OrderLength
        {
            get { return CopyofPOCOInstance.RequiredDetails.OrderLength; }
            set { CopyofPOCOInstance.RequiredDetails.OrderLength = value; RaisePropertyChanged("OrderLength"); }
        }
        // 下單數量
        public decimal? QuantityofOrderSummary
        {
            get { return CopyofPOCOInstance.ControlTableDetails.QuantityofOrderSummary; }
            set { CopyofPOCOInstance.ControlTableDetails.QuantityofOrderSummary = value; RaisePropertyChanged("QuantityofOrderSummary"); }
        }
        // 訂單總重
        public decimal? TotalWeightofOrder
        {
            get { return CopyofPOCOInstance.ControlTableDetails.TotalWeightofOrder; }
            set { CopyofPOCOInstance.ControlTableDetails.TotalWeightofOrder = value; RaisePropertyChanged("TotalWeightofOrder"); }
        }

    }
}
