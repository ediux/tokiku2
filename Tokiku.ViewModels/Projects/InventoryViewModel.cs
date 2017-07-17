using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Controllers;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public class InventoryViewModelCollection : BaseViewModelCollection<InventoryViewModel>
    {
        public InventoryViewModelCollection()
        {
            
        }

        public InventoryViewModelCollection(IEnumerable<InventoryViewModel> source) : base(source)
        {

        }
        
        public static InventoryViewModelCollection Query()
        {
            return Query<InventoryViewModelCollection, Inventory>("Inventory", "QueryAll");

            //InventoryController ctrl = new InventoryController();
            //ExecuteResultEntity<ICollection<Inventory>> ere = ctrl.QuerAll();

            //if (!ere.HasError)
            //{
            //    return new InventoryViewModelCollection(ere.Result.Select(s => new InventoryViewModel(s)).ToList());
            //}
            //return new InventoryViewModelCollection();
        }

    }

    public class InventoryViewModel : BaseViewModelWithPOCOClass<Inventory>
    {
        public InventoryViewModel(Inventory entity) : base(entity)
        {

        }

        // 需求單單號
        public string FormNumber
        {
            get { return CopyofPOCOInstance.ControlTableDetails.RequiredDetails.Required.FormNumber; }
            set { CopyofPOCOInstance.ControlTableDetails.RequiredDetails.Required.FormNumber = value; RaisePropertyChanged("FormNumber"); }
        }
        // 東菊編號
        public string RequiredDetailsCode
        {
            get { return CopyofPOCOInstance.ControlTableDetails.RequiredDetails.Code; }
            set { CopyofPOCOInstance.ControlTableDetails.RequiredDetails.Code = value; RaisePropertyChanged("RequiredDetailsCode"); }
        }
        // 廠商編號
        public string FactoryNumber
        {
            get { return CopyofPOCOInstance.ControlTableDetails.RequiredDetails.FactoryNumber; }
            set { CopyofPOCOInstance.ControlTableDetails.RequiredDetails.FactoryNumber = value; RaisePropertyChanged("FactoryNumber"); }
        }
        // 材質
        public string MaterialCategoriesName
        {
            get { return CopyofPOCOInstance.ControlTables.MaterialCategories.Name; }
            set { CopyofPOCOInstance.ControlTables.MaterialCategories.Name = value; RaisePropertyChanged("MaterialCategoriesName"); }
        }
        // 單位重(kg/m)
        public decimal UnitWeight
        {
            get { return CopyofPOCOInstance.ControlTableDetails.RequiredDetails.UnitWeight; }
            set { CopyofPOCOInstance.ControlTableDetails.RequiredDetails.UnitWeight = value; RaisePropertyChanged("UnitWeight"); }
        }
        // 訂購長度(mm)
        public int? OrderLength
        {
            get { return CopyofPOCOInstance.ControlTableDetails.RequiredDetails.OrderLength; }
            set { CopyofPOCOInstance.ControlTableDetails.RequiredDetails.OrderLength = value; RaisePropertyChanged("OrderLength"); }
        }

    }
}
